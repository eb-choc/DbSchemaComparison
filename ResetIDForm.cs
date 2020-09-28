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
            string name = comboBox1.SelectedItem.ToString();
            DbConnectionDO c = GetByName(name);
            string dbname = comboBox2.SelectedItem.ToString();
            string tablename = comboBox3.Text;
            int startNum = Convert.ToInt32(numericUpDown1.Value);

            Action<DbConnectionDO, string, string, int> act = StartReset;
            act.BeginInvoke(c, dbname, tablename, startNum, null, null);
        }

        private void StartReset(DbConnectionDO conn, string dbname, string tablename, int startNum)
        {
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
            CommittableTransaction trans = new CommittableTransaction(TimeSpan.FromMinutes(60));            
            sql = "select count(*) from " + tablename;
            v = dbhelper.GetFirstValue(sql);
            int count = Convert.ToInt32(v);
            msgForm.SetText(tablename + "表找到" + count + "条数据，最大ID=" + maxId + (count > 10000 ? "，开始分批执行" : ""));
            int currentId = 0;
            int pcount = 10000;
            if (count > pcount)
            {
                while(true)
                {
                    int currentStartNum = 0;
                    sql = "select id from " + tablename + " where id > " + currentId + " order by id asc limit "+ pcount + ";";
                    currentId = ExecResetId(dbhelper, sql, tablename, startNum, trans, out currentStartNum);
                    if(currentId <= 0)
                    {
                        break;
                    }
                    startNum = currentStartNum;
                    msgForm.SetText("当前执行到ID=" + currentId);
                }
            }
            else
            {
                sql = "select id from " + tablename + " order by id asc";
                int currStartNum;
                ExecResetId(dbhelper, sql, tablename, startNum, trans, out currStartNum);  
            }
            msgForm.SetText("执行最后的ID更新");
            sql = "UPDATE " + tablename + " set id=id*(-1) where id < 0";
            new MySqlDbHelper(dbhelper.ConnectionString).RunSql(sql, null, null, trans);
            trans.Commit();
            msgForm.SetText("执行完成");
        }

        private int ExecResetId(MySqlDbHelper dbhelper, string sql, string tablename, int startNum,
            CommittableTransaction trans, out int currentStartNum)
        {
            int curNum = startNum;
            int lastId = 0;
            StringBuilder sb = new StringBuilder();
            DataTable dt = dbhelper.RunDataTableSql(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string sql_1 = "UPDATE " + tablename + " set id=" + curNum * (-1) + " where id=" + row["id"] + ";";
                    sb.AppendLine(sql_1);
                    curNum++;
                    lastId = Convert.ToInt32(row["id"]);
                }
            }
            else
            {
                currentStartNum = 0;
                return -1;
            }

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
