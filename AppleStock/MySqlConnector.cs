using System;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Generic;
using System.Text;

namespace AppleStock
{
    class MySqlConnector
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = "YOUR-SERVER.mysql.database.azure.com",
            Database = "YOUR-DATABASE",
            UserID = "USER@YOUR-SERVER",
            Password = "PASSWORD",
            SslMode = MySqlSslMode.Required,
        };

    }
}
