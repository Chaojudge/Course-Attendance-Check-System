 using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systemSetting;

namespace publicClass
{
    public class mysqlImp
    {
        private MySqlConnection conn;

        private mysqlImp() { }
        public static mysqlImp mysql = new mysqlImp();
        public static mysqlImp getMysql()
        {
            return mysql;
        }

        public void connect()
        {
            string connToMysqlStr = ""
                + "Database=" + dataSourceInfo.getDataSourceInfo().getDataBaseName() + ";"
                + "Data Source=" + dataSourceInfo.getDataSourceInfo().getDataSourceIP() + ";"
                + "User Id=" + dataSourceInfo.getDataSourceInfo().getDataSourceUser() + ";"
                + "Password=" + dataSourceInfo.getDataSourceInfo().getDataSourcePwd() + ";"
                + "pooling=false;" + ";"
                + "CharSet=utf8;" + ";"
                + "port=" + dataSourceInfo.getDataSourceInfo().getDataSourcePort() + ";";
            conn = new MySqlConnection(connToMysqlStr);
            conn.Open();
        }

        public MySqlDataReader query(string queryStr)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(queryStr, conn);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reader失败:" +ex.ToString());
            }
            return null;
        }

        public void update(string updateStr)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(updateStr, conn);
                // command = conn.CreateCommand();
                command.ExecuteNonQuery();
                //command.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("数据更新失败："+ ex.ToString());
            }
        }

        public DataTable showTable(string query)
        {
            DataTable table = null;
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                table = new DataTable();
                if (adapter != null)
                {
                    adapter.Fill(table);
                    return table;
                }
            }
            catch (Exception){ }
            return null;
        }
    }
}
