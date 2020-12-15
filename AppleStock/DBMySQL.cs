using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace SqlCon
{
    public class DBMySQL
    {
        public static MySqlConnection GetDBConnection(string host, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                 + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }


        public static bool ValidateLogin(string email, string password, MySqlConnection conn)

        {
            
               // string sqlcommand = "SELECT * FROM user WHERE email = '"+email+"' AND password = '"+password+";'";
            
            string sqlcommand = "SELECT * FROM user WHERE email = @email AND password = @password ";

            // Créez un objet Command.
            MySqlCommand cmd = new MySqlCommand();

                // Établissez la connexion de la commande.
                
                cmd.CommandText = sqlcommand;
               cmd.Parameters.AddWithValue("@email", email);
               cmd.Parameters.AddWithValue("@password", password);
                cmd.Connection = conn;

            MySqlDataReader login = cmd.ExecuteReader();

                if (login.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
         }
        

        public static void afficheruser(MySqlConnection conn)
        {

          

                string sql = "Select id, name, lastname, email, password from user";

                // Créez un objet Command.
                MySqlCommand cmd = new MySqlCommand();

                // Établissez la connexion de la commande.
                cmd.Connection = conn;
                cmd.CommandText = sql;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            // Récupérez l'indexe (index) de colonne Emp_ID dans l'instruction de requête SQL.
                            int empIdIndex = reader.GetOrdinal("id"); // 0


                            long empId = Convert.ToInt64(reader.GetValue(0));

                            // La colonne Emp_No a l'indexe = 1.
                            string empNo = reader.GetString(1);
                            int empNameIndex = reader.GetOrdinal("name");// 2
                            string empName = reader.GetString(empNameIndex);

                            // Index (index) de la colonne Mng_Id dans l'instructions de requête SQL.


                            // Si une colonne est nullable, vérifiez toujours DBNull ...

                            Console.WriteLine("--------------------");
                            Console.WriteLine("empIdIndex:" + empIdIndex);
                            Console.WriteLine("EmpId:" + empId);
                            Console.WriteLine("EmpNo:" + empNo);
                            Console.WriteLine("EmpName:" + empName);

                        }
                    }
                }
            }
        }
    }











