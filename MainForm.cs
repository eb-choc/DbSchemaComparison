using DbSchemaComparison.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbSchemaComparison
{
    public partial class MainForm : Form
    {
        private List<DbConnectionDO> connections = new List<DbConnectionDO>();
        private string defaultTitle = "";
        private MsgForm msfForm = null;
        public MainForm()
        {
            InitializeComponent();
            刷新数据库连接ToolStripMenuItem_Click(null, null);
            defaultTitle = this.Text;
            msfForm = new MsgForm();
            msfForm.Show();
            //msfForm.Visible = false;
        }

        private void 新建数据库连接NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newConnectionForm newConnForm = new newConnectionForm();
            newConnForm.ShowDialog();
        }

        private void 数据库连接管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionsManagementForm mform = new connectionsManagementForm();
            mform.ShowDialog();
        }

        private void 刷新数据库连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            connections = new DbConnectionDO().GetAll();
            if (connections.Count > 0)
            {
                foreach (DbConnectionDO c in connections)
                {
                    comboBox1.Items.Add(c.Conn_Name);
                    comboBox2.Items.Add(c.Conn_Name);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboBox1.SelectedItem.ToString();
            DbConnectionDO c = GetByName(name);
            if(c != null)
            {
                lbl_host1.Text = c.HOST;
                lbl_port1.Text = c.PORT.ToString();
                lbl_type1.Text = c.Conn_Type;
                InitDatabase(comboBox3, c);
            }
        }

        private DbConnectionDO GetByName(string name)
        {
            if (connections.Count > 0)
            {
                foreach (DbConnectionDO c in connections)
                {
                    if (c.Conn_Name == name)
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboBox2.SelectedItem.ToString();
            DbConnectionDO c = GetByName(name);
            if (c != null)
            {
                lbl_host2.Text = c.HOST;
                lbl_port2.Text = c.PORT.ToString();
                lbl_type2.Text = c.Conn_Type;
                InitDatabase(comboBox4, c);
            }
        }

        private void InitDatabase(ComboBox cmb, DbConnectionDO c)
        {
            cmb.Items.Clear();
            string connStr = "server=" + c.HOST + ";port=" + c.PORT + ";user=" + c.UserName + ";password=" + c.Pwd + "; database=information_schema;";
            string sql = "show databases";
            DataTable dt = new MySqlDbHelper(connStr).RunDataTableSql(sql, null, null, null);
            if(dt != null && dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    cmb.Items.Add(row["Database"].ToString());
                }
                cmb.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("请选择源数据库和目标数据库！");
                return;
            }
            if(comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString() && comboBox3.SelectedItem.ToString() == comboBox4.SelectedItem.ToString())
            {
                MessageBox.Show("源数据库和目标数据库不能相同！");
                return;
            }
            string name1 = comboBox1.SelectedItem.ToString();
            DbConnectionDO source_c = GetByName(name1);
            string name2 = comboBox2.SelectedItem.ToString();
            DbConnectionDO target_c = GetByName(name2);
            string source_db = comboBox3.SelectedItem.ToString();
            string target_db = comboBox4.SelectedItem.ToString();
            button1.Enabled = false;
            MainContext context = new MainContext(this, msfForm);
            Action<DbConnectionDO, String, DbConnectionDO, String> act = context.BeginCompare;
            act.BeginInvoke(source_c, source_db, target_c, target_db, null, null);
        }

        public void SetProcessBar(int percent)
        {
            if (this.InvokeRequired)
            {
                Action<int> act = SetProcessBar;
                this.Invoke(act, percent);
            }
            else
            {
                if (percent > 0)
                {
                    processBar1.Visible = true;
                }
                else
                {
                    processBar1.Visible = false;
                }
                processBar1.Value = percent;
                lbl_status_proces.Text = percent + " %";
            }
        }

        public void SetTitle(string title)
        {
            if (this.InvokeRequired)
            {
                Action<string> act = SetTitle;
                this.Invoke(act, title);
            }
            else
            {
                this.Text = defaultTitle + " --- " + title;
            }
        }

        private void 重置表ID值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetIDForm f = new ResetIDForm(msfForm);
            f.ShowDialog();
        }
    }
}
