using MySql.Data.MySqlClient;
using System;

namespace MYSQL
{
    public class MYSQL
    {
        MySqlConnection conn = null;
        bool connected = false;
        string host = "";
        int port = 3306;
        string username = "";
        string password = "";
        string database = "";

        #region 初始化数据库连接信息
        public MYSQL(String host, int port, String username, String password, String database)
        {
            this.host = host;
            this.port = port;
            this.username = username;
            this.password = password;
            this.database = database;
        }
        #endregion

        #region 连接数据库
        public bool connect()
        {
            string connStr = $"server = {host}; user = {username}; database = {database}; port = {port}; password = {password}";

            try
            {
                if (!connected)
                {
                    conn = new MySqlConnection(connStr);
                    conn.Open();
                    MySqlCommand cmdCreate = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS `{database}`", conn);
                    cmdCreate.ExecuteNonQuery();
                    conn.Close();
                    connected = true;
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
        #endregion

        public MySqlDataReader executeQuery(string str)
        {
            Console.WriteLine(str);
            try
            {
                if (connected)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public bool executeUpdate(string str)
        {
            Console.WriteLine(str);
            try
            {
                if (connected)
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public void tryClose()
        {
            try
            {
                conn.Close();
            }
            catch
            {

            }
        }
    }
}
