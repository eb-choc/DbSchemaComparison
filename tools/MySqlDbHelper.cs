using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DbSchemaComparison.tools
{
    public class MySqlDbHelper
    {
        public MySqlConnection DefaultConn = null;
        public string ConnectionString = null;
        public MySqlDbHelper(string connStr)
        {
            this.ConnectionString = connStr;
        }
        public void RunSql(string sql, string[] ps = null, object[] vs = null, 
            Transaction trans = null)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                if (trans != null)
                {
                    conn.EnlistTransaction(trans);
                }
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (ps != null)
                {
                    for (int i = 0; i < ps.Length; i++)
                    {
                        cmd.Parameters.Add(new MySqlParameter(ps[i], vs[i]));
                    }
                }
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable RunDataTableSql(string sql, string[] ps = null, object[] vs = null,
            Transaction trans = null)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                if (trans != null)
                {
                    conn.EnlistTransaction(trans);
                }
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandTimeout = 3000;
                if (ps != null)
                {
                    for (int i = 0; i < ps.Length; i++)
                    {
                        cmd.Parameters.Add(new MySqlParameter(ps[i], vs[i]));
                    }
                }
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        public Object GetFirstValue(string sql, string[] ps = null, object[] vs = null)
        {
            object ret = null;
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandTimeout = 3000;
                if (ps != null)
                {
                    for (int i = 0; i < ps.Length; i++)
                    {
                        cmd.Parameters.Add(new MySqlParameter(ps[i], vs[i]));
                    }
                }
                ret = cmd.ExecuteScalar();
                conn.Close();
            }
            return ret;
        }
    }
}
