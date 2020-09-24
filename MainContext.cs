using DbSchemaComparison.tools;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace DbSchemaComparison
{
    public class MainContext
    {
        //主表单
        private MainForm mainForm = null;
        private string conn_source_str = null;
        private string conn_target_str = null;
        private List<String> sourceDbs = new List<string>();
        private List<String> targetDbs = new List<string>();

        private StringBuilder sb = new StringBuilder();

        public void BeginCompare(DbConnectionDO source_conn, string source_db, DbConnectionDO target_conn, string target_db)
        {
            conn_source_str = "server=" + source_conn.HOST + ";port=" + source_conn.PORT + ";user=" + source_conn.UserName + ";password=" + source_conn.Pwd + "; database=" + source_db + ";";
            conn_target_str = "server=" + target_conn.HOST + ";port=" + target_conn.PORT + ";user=" + target_conn.UserName + ";password=" + target_conn.Pwd + "; database=" + target_db + ";";
            CompareDbSchemaField(source_conn, source_db, target_conn, target_db);
        }

        private void CompareDbSchemaField(DbConnectionDO source_conn, string source_db, DbConnectionDO target_conn, string target_db)
        {
            //1、获取表列表
            InitTableList();
            List<string> targetFound = new List<string>(); //目标表中已经找到的表名称
            if (sourceDbs.Count > 0)
            {
                CommittableTransaction trans = new CommittableTransaction();
                for (int i = 0; i < sourceDbs.Count; i++)
                {
                    string sd = sourceDbs[i];
                    mainForm.SetTitle("比较" + sd);
                    int process = Convert.ToInt32((i + 1) * 100 / sourceDbs.Count * 0.8);
                    mainForm.SetProcessBar(10 + process);
                    string sql_s = "show columns from " + sd;
                    DataTable dt_s = new MySqlDbHelper(conn_source_str).RunDataTableSql(sql_s);
                    List<string> fields_s = new List<string>();
                    if(dt_s != null && dt_s.Rows.Count > 0)
                    {
                        if (targetDbs.IndexOf(sd) > -1)
                        {
                            DataTable dt_t = new MySqlDbHelper(conn_target_str).RunDataTableSql(sql_s);
                            CompareTable(dt_s, dt_t, sd);
                            targetFound.Add(sd);
                        }
                        else
                        {
                            CreateTable(dt_s, sd);
                        }
                    }
                }
            }
            mainForm.SetTitle("删除多余表...");
            //在source没有，但是target有的要删除
            if(targetDbs != null && targetDbs.Count > 0 && targetFound.Count > 0)
            {
                foreach(string table in targetDbs)
                {
                    if(targetFound.IndexOf(table) < 0)
                    {
                        sb.AppendLine("DROP TABLE " + table + ";");
                    }
                }
            }
            if (sb.ToString() != "")
            {
                mainForm.SetProcessBar(95);
                mainForm.SetTitle("写入文件...");
                string dir = AppDomain.CurrentDomain.BaseDirectory + "\\sql";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string file = dir + "\\sql_" + DateTime.Now.ToString("yyyyMMdd") + ".sql";
                File.WriteAllText(file, sb.ToString());
                mainForm.SetProcessBar(100);
                MessageBox.Show("操作成功，点击确定打开文件！", "恭喜", MessageBoxButtons.OK);
                Process.Start(file);
                mainForm.SetTitle("");
                mainForm.SetProcessBar(0);
            }
            else
            {
                mainForm.SetProcessBar(100);
                MessageBox.Show("很好， 两边数据库结构无差异！");
            }
        }

        private void CompareTable(DataTable dt_s, DataTable dt_t, string table)
        {
            List<string> dt2Found = new List<string>();
            foreach (DataRow row1 in dt_s.Rows)
            {
                bool find = false;
                foreach (DataRow row2 in dt_t.Rows)
                {
                    if (row2["Field"].ToString() == row1["Field"].ToString())
                    {
                        find = true;
                        dt2Found.Add(row2["Field"].ToString());
                        if (row2["Type"].ToString() != row1["Type"].ToString() ||
                            row2["Null"].ToString() != row1["Null"].ToString())
                        {
                            string modify_str = "ALTER TABLE " + table + " MODIFY COLUMN " + row1["Field"];
                            if (row2["Type"].ToString() != row1["Type"].ToString())
                            {
                                modify_str += " " + row2["Type"].ToString();
                            }
                            if (row2["Null"].ToString() != row1["Null"].ToString())
                            {
                                modify_str += " " + (row2["Null"].ToString() == "YES" ? " NULL " : " NOT NULL ");
                            }
                            modify_str += ";";
                            sb.AppendLine(modify_str);
                        }
                        break;
                    }
                }
                if(!find) //说明没有找到，则要新增
                {
                    string modify_str = "ALTER TABLE " + table + " ADD COLUMN " + row1["Field"] + " " + row1["Type"] + " " +
                        (row1["Null"].ToString() == "YES" ? " " : " NOT NULL ");
                    modify_str += ";";
                    sb.AppendLine(modify_str);
                }
            }
            //再确定在dt_t中多出来的，要在dt_s中删除
            foreach(DataRow row in dt_t.Rows)
            {
                bool find = false;
                foreach(string f in dt2Found)
                {
                    if(row["Field"].ToString() == f)
                    {
                        find = true;
                        break;
                    }
                }
                if(!find)
                {
                    string modify_str = "ALTER TABLE " + table + " DROP " + row["Field"];
                    modify_str += ";";
                    sb.AppendLine(modify_str);
                }
            }
        }

        private void CreateTable(DataTable dt, string table)
        {
            string sql_create = "CREATE TABLE `" + table + "` (";
            string primary_key = "";
            foreach(DataRow row in dt.Rows)
            {
                sql_create += "`" + row["Field"] + "`" + " " + row["Type"];
                if(row["Null"].ToString() == "NO")
                {
                    sql_create += " NOT NULL ";
                }
                if(row["Default"] != null)
                {
                    sql_create += (row["Type"].ToString().IndexOf("varchar") > -1 ? " DEFAULT '" + row["Default"] + "' " : " ");
                }
                if(row["Extra"] != null && row["Extra"].ToString() != "")
                {
                    sql_create += row["Extra"].ToString();
                }
                sql_create += ",";
                if(row["Key"].ToString() == "PRI")
                {
                    primary_key = row["Field"].ToString();
                }
            }
            if(primary_key != "")
            {
                sql_create += "PRIMARY KEY (`" + primary_key + "`)";
            }
            sql_create += ") ENGINE=InnoDB ;";
            sb.AppendLine(sql_create);
        }

        private void InitTableList()
        {
            string sql_view1 = "select table_name from information_schema.Views where table_schema=DATABASE()";
            string sql_table1 = "select table_name from information_schema.Tables where table_schema = DATABASE()";

            mainForm.SetTitle("获取源数据库视图清单...");
            DataTable dt_view1 = new MySqlDbHelper(conn_source_str).RunDataTableSql(sql_view1);
            mainForm.SetProcessBar(2);
            mainForm.SetTitle("获取源数据库表清单...");
            DataTable dt_table1 = new MySqlDbHelper(conn_source_str).RunDataTableSql(sql_table1);
            mainForm.SetProcessBar(5);
            if (dt_table1 != null && dt_table1.Rows.Count > 0)
            {
                foreach(DataRow row1 in dt_table1.Rows)
                {
                    bool find = false;
                    if (dt_view1 != null && dt_view1.Rows.Count > 0)
                    {
                        foreach(DataRow row2 in dt_view1.Rows)
                        {
                            if(row2["table_name"].ToString() == row1["table_name"].ToString())
                            {
                                find = true;
                                break;
                            }
                        }
                    }
                    if(!find)
                    {
                        sourceDbs.Add(row1["table_name"].ToString());
                    }
                }
            }
            mainForm.SetTitle("获取目标数据库视图清单...");
            DataTable dt_view2 = new MySqlDbHelper(conn_target_str).RunDataTableSql(sql_view1);
            mainForm.SetProcessBar(7);
            mainForm.SetTitle("获取目标数据库表清单...");
            DataTable dt_table2 = new MySqlDbHelper(conn_target_str).RunDataTableSql(sql_table1);
            mainForm.SetProcessBar(10);
            if (dt_table2 != null && dt_table2.Rows.Count > 0)
            {
                foreach (DataRow row1 in dt_table2.Rows)
                {
                    bool find = false;
                    if (dt_view2 != null && dt_view2.Rows.Count > 0)
                    {
                        foreach (DataRow row2 in dt_view2.Rows)
                        {
                            if (row2["table_name"].ToString() == row1["table_name"].ToString())
                            {
                                find = true;
                                break;
                            }
                        }
                    }
                    if (!find)
                    {
                        targetDbs.Add(row1["table_name"].ToString());
                    }
                }
            }
        }

        public MainContext(MainForm f)
        {
            this.mainForm = f;
        }
    }
}
