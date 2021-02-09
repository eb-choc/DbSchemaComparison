using DbSchemaComparison.tools;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DbSchemaComparison
{
    public partial class ResetIDForm : Form
    {
        private List<DbConnectionDO> connections = null;
        private string defaultTitle = "";
        private MsgForm msgForm = null;
        public ResetIDForm(MsgForm mf)
        {
            InitializeComponent();
            defaultTitle = this.Text;
            this.msgForm = mf;
        }

        private void ResetIDForm_Load(object sender, EventArgs e)
        {
            connections = new DbConnectionDO().GetAll();
            if (connections.Count > 0)
            {
                foreach (DbConnectionDO c in connections)
                {
                    comboBox1.Items.Add(c.Conn_Name);
                }
            }
        }

        private DbConnectionDO GetByName(string name)
        {
            if (connections.Count > 0)
            {
                foreach (DbConnectionDO conn in connections)
                {
                    if (conn.Conn_Name == name)
                    {
                        return conn;
                    }
                }
            }
            return null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string name = comboBox1.SelectedItem.ToString();
            DbConnectionDO c = GetByName(name);
            if (c != null)
            {
                string connStr = "server=" + c.HOST + ";port=" + c.PORT + ";user=" + c.UserName + ";password=" + c.Pwd + "; database=information_schema;";
                string sql = "show databases";
                DataTable dt = new MySqlDbHelper(connStr).RunDataTableSql(sql, null, null, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        comboBox2.Items.Add(row["Database"].ToString());
                    }
                    comboBox2.SelectedIndex = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(msgForm.IsWorking)
            {
                MessageBox.Show("前一个任务还没有执行完成，请等待！");
                return;
            }
            
            frmTK tk = new frmTK();
            if(tk.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("请选择一个具体表！");
                return;
            }
            string name = comboBox1.SelectedItem.ToString();
            DbConnectionDO c = GetByName(name);
            string dbname = comboBox2.SelectedItem.ToString();
            string tablename = comboBox3.Text;
            int startNum = Convert.ToInt32(numericUpDown1.Value);

            Action<DbConnectionDO, string, string, int> act = StartReset;
            act.BeginInvoke(c, dbname, tablename, startNum, null, null);
            button1.Enabled = false;
        }

        private void StartReset(DbConnectionDO conn, string dbname, string tablename, int startNum)
        {
            msgForm.IsWorking = true;
            string conn_str = "server=" + conn.HOST + ";port=" + conn.PORT + ";user=" + conn.UserName + ";password=" + conn.Pwd + "; database=" + dbname + ";";
            msgForm.ClearText();
            msgForm.SetText("正在查询数据记录相关信息");
            MySqlDbHelper dbhelper = new MySqlDbHelper(conn_str);
            string sql = "select max(id) from " + tablename;
            object v = dbhelper.GetFirstValue(sql);
            int maxId = 0;
            if(v != null)
            {
                maxId = Convert.ToInt32(v);
            }
            if(maxId <= 0 || maxId < startNum)
            {
                MessageBox.Show("表起始值无效！");
                return;
            }
            CommittableTransaction trans = new CommittableTransaction(TimeSpan.FromMinutes(120));            
            sql = "select count(*) from " + tablename;
            v = dbhelper.GetFirstValue(sql);
            int count = Convert.ToInt32(v);
            msgForm.SetText(tablename + "表找到" + count + "条数据，最大ID=" + maxId + (count > 10000 ? "，开始分批执行" : ""));
            int currentId = 0;
            List<string> sb_updateid = new List<string>();
            int pcount = 10000;
            int execCount = 0;
            if (count > pcount)
            {
                while(true)
                {
                    int currentStartNum = 0;
                    int currentExecCount = 0;
                    string ss1 = "";
                    sql = "select id from " + tablename + " where id > " + currentId + " order by id asc limit "+ pcount + ";";
                    currentId = ExecResetId(dbhelper, sql, tablename, startNum, trans, 
                        out currentStartNum, out ss1, out currentExecCount);
                    if(currentId <= 0)
                    {
                        break;
                    }
                    startNum = currentStartNum;
                    execCount += currentExecCount;
                    sb_updateid.Add(ss1);
                    msgForm.SetText("执行到ID=" + currentId + "，剩" + (count - execCount));
                    
                }
            }
            else
            {
                sql = "select id from " + tablename + " order by id asc";
                int currStartNum;
                string ss1 = "";
                ExecResetId(dbhelper, sql, tablename, startNum, trans, out currStartNum, out ss1, out execCount);
                sb_updateid.Add(ss1);
            }
            msgForm.SetText("执行最后的ID更新");
            int index = 0;
            foreach(string s in sb_updateid)
            {
                msgForm.SetText("执行更新第" + (index + 1) + "批，剩" + (sb_updateid.Count - index - 1));
                new MySqlDbHelper(dbhelper.ConnectionString).RunSql(s, null, null, trans);
                index++;
            }
            sql = "alter table event_log AUTO_INCREMENT " + (count + 1); //从新的数字开始数数
            new MySqlDbHelper(dbhelper.ConnectionString).RunSql(sql, null, null, trans);
            trans.Commit();
            msgForm.SetText("执行完成");
            msgForm.IsWorking = false;
        }

        private int ExecResetId(MySqlDbHelper dbhelper, string sql, string tablename, int startNum,
            CommittableTransaction trans, out int currentStartNum, out string ss1, 
            out int currentExecCount)
        {
            int curNum = startNum;
            int lastId = 0;
            currentExecCount = 0;
            StringBuilder sb = new StringBuilder();
            DataTable dt = dbhelper.RunDataTableSql(sql);
            List<int> ids = new List<int>();
            ss1 = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int cid = curNum * (-1);
                    string sql_1 = "UPDATE " + tablename + " set id=" + cid + " where id=" + row["id"] + ";";
                    sb.AppendLine(sql_1);
                    curNum++;
                    currentExecCount++;
                    lastId = Convert.ToInt32(row["id"]);
                    ids.Add(cid);
                }
            }
            else
            {
                currentStartNum = 0;
                return -1;
            }
            ss1 = "UPDATE " + tablename + " set id=id*(-1) where id in (" + string.Join(",", ids.ToArray()) + ");";

            new MySqlDbHelper(dbhelper.ConnectionString).RunSql(sb.ToString(), null, null, trans);            
            currentStartNum = curNum;
            return lastId;
        }

        private void SetTitle(string title)
        {
            if(this.InvokeRequired)
            {
                Action<string> act = SetTitle;
                this.Invoke(act, title);
            }
            else
            {
                this.Text = defaultTitle + title;
            }
        }
    }
}
