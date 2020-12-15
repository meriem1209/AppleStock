using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppleStock;
using MySql.Data.MySqlClient;

namespace SqlCon
{
   public class DBconnection    {

        public static MySqlConnection GetDBConnection()
        {
            string host = "applestock.mysql.database.azure.com";
            string database = "apple_test";
            string username = "appleroot@applestock";
            string password = "Apple1234";

            return DBMySQL.GetDBConnection(host, database, username, password);
        }

    }
}