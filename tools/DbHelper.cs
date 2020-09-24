using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace DbSchemaComparison.tools
{
    public class DbHelper
    {
        private string getDbStr()
        {
            string connStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            connStr = connStr.Replace("{dir}", AppDomain.CurrentDomain.BaseDirectory);
            return connStr;
        }
        public void RunSql(string sql, string[] ps, object[] vs)
        {
            SqlConnection conn = new SqlConnection(getDbStr());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (ps != null && ps.Length > 0)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(ps[i], vs[i]));
                }
            }
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable RunDataTableSql(string sql, string[] ps, object[] vs)
        {
            using(SqlConnection conn = new SqlConnection(getDbStr()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (ps != null && ps.Length > 0)
                {
                    for (int i = 0; i < ps.Length; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(ps[i], vs[i]));
                    }
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.Close();
                return dt;
            }
        }
    }
}
