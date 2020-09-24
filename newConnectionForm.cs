using DbSchemaComparison.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbSchemaComparison
{
    public partial class newConnectionForm : Form
    {
        public newConnectionForm()
        {
            InitializeComponent();
            com_type.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conn_name = txt_conn_name.Text;
            string conn_type = com_type.SelectedItem.ToString();
            string host = txt_host.Text;
            int port = Convert.ToInt32(txt_port.Text);
            string user_name = txt_user.Text;
            string pwd = txt_pwd.Text;
            string sql_sel = "select 1 from connections where conn_type=@conn_type and host=@host and port=@port";
            DataTable dt = new DbHelper().RunDataTableSql(sql_sel,
                new string[] { "conn_type", "host", "port" },
                new object[] { conn_type, host, port });
            if(dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("该环境的数据库已经存在!");
                return;
            }
            string sql = @"insert into connections (conn_type, conn_name, host, port, username, pwd) values 
                (@conn_type,@conn_name,@host,@port,@username,@pwd)";
            new DbHelper().RunSql(sql,
                new string[] { "conn_type", "conn_name", "host", "port", "username", "pwd" },
                new object[] { conn_type, conn_name, host, port, user_name, pwd });
            MessageBox.Show("保存成功");
            this.Close();

        }
    }
}
