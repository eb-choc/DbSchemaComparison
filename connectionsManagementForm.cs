using DbSchemaComparison.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbSchemaComparison
{
    public partial class connectionsManagementForm : Form
    {
        private DataTable dtList = null;
        private int currentId = 0;
        public connectionsManagementForm()
        {
            InitializeComponent();
        }

        private void connectionsManagementForm_Load(object sender, EventArgs e)
        {
            LoadConnections();
        }
        private void LoadConnections()
        {
            listView1.Items.Clear();
            string sql = "select * from connections order by id desc";
            dtList = new DbHelper().RunDataTableSql(sql, null, null);
            if (dtList != null && dtList.Rows.Count > 0)
            {
                foreach (DataRow row in dtList.Rows)
                {
                    string[] ms = new string[] { row["conn_type"].ToString(), row["conn_name"].ToString(),
                        row["host"].ToString(), row["port"].ToString()
                    };
                    listView1.Items.Add(new ListViewItem(ms));
                }
                listView1.Items[0].Selected = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count <= 0 || listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            string conn_name = textBox1.Text;
            string conn_type = comboBox1.SelectedItem.ToString();
            string host = textBox2.Text;
            int port = Convert.ToInt32(textBox3.Text);
            string user_name = textBox4.Text;
            string pwd = textBox5.Text;
            string sql = @"update connections set conn_type=@conn_type, conn_name=@conn_name, 
                        host=@host, port=@port, username=@username, pwd=@pwd where id=@id";
            new DbHelper().RunSql(sql,
                new string[] { "conn_type", "conn_name", "host", "port", "username", "pwd", "id" },
                new object[] { conn_type, conn_name, host, port, user_name, pwd, currentId });
            MessageBox.Show("保存成功");
            LoadConnections();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;
            ListViewItem item = listView1.SelectedItems[0];
            string conn_type = item.SubItems[0].Text;
            string conn_name = item.SubItems[1].Text;
            foreach(DataRow row in dtList.Rows)
            {
                if(row["conn_type"].ToString() == conn_type && row["conn_name"].ToString() == conn_name)
                {
                    comboBox1.SelectedItem = conn_type;
                    textBox1.Text = conn_name;
                    textBox2.Text = row["host"].ToString();
                    textBox3.Text = row["port"].ToString();
                    textBox4.Text = row["username"].ToString();
                    textBox5.Text = row["pwd"].ToString();
                    currentId = Convert.ToInt32(row["id"].ToString());
                }
            }
        }
    }
}
