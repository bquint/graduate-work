using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SudnoTest_App
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=31.31.196.172;port=3306;username=u1392463_admin;password=Dibikuper321;database=u1392463_gims_mhs;charset=utf8");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public  MySqlConnection GetConnection()
        {
            return connection;
        }

     
    }
}
