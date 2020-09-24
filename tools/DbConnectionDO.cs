using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSchemaComparison.tools
{
    public class DbConnectionDO
    {
        public int ID { get; set; }
        public string Conn_Type { get; set; }
        public string Conn_Name { get; set; }
        public string HOST { get; set; }
        public int PORT { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }

        public List<DbConnectionDO> GetAll()
        {
            List<DbConnectionDO> ret = new List<DbConnectionDO>();
            string sql = "select * from connections order by id ASC";
            DataTable dt = new DbHelper().RunDataTableSql(sql, null, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ret.Add(new DbConnectionDO()
                    {
                        ID = Convert.ToInt32(row["id"]),
                        Conn_Name = row["conn_name"].ToString(),
                        Conn_Type = row["conn_type"].ToString(),
                        HOST = row["host"].ToString(),
                        PORT = Convert.ToInt32(row["port"]),
                        Pwd = row["pwd"].ToString(),
                        UserName = row["username"].ToString()
                    });
                }
            }
            return ret;
        }
    }
}
