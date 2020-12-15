using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AppleStock
{
    public class User
    {
        private int id;
        private string firstname;
        private string lastname;
        private string email;
        private string password;
        

        public int Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => Lastname; set => Lastname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
         

        public User(int id, string firstname, string lastname, string email, string password)
        {
            this.id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.password = password;
        }

        public static void SelectUser(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "SELECT * FROM user";


            using (DbDataReader reader = cmd.ExecuteReader())
                //MySqlDataReader dataReader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    //lis les données et les stock dans la liste
                    while (reader.Read())
                    {
                        var Firstname = reader.GetString(1);
                        var Lastname = reader.GetString(2);
                        var Password = reader.GetString(3);
                      

                        Console.WriteLine($"{Firstname} {Lastname} {Password} d");
                    }
                    cmd.Connection = conn;

                }


        }

        public static void CreateUser(string firstname, string lastname, string password, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO product(firstname, lastname, password) VALUES (@fristname,@lastname,@password')";
            cmd.Parameters.AddWithValue("@fristname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@dateOrder", password);



            cmd.Connection = conn;
            //conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" L'utilisateur a été enregistré ");
            Console.ReadKey();

        }

        public static void UpdateUser(string firstname, string lastname,  string password, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE userorder SET (firstname= @firstname , lastname= @lastname, password=@password) WHERE firstname =@firstname and lastname=@lastname";
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Connection = conn;
            conn.Open();


            cmd.ExecuteNonQuery();
            Console.WriteLine(" L'utilisateur a été modifié ");
            Console.ReadKey();

        }

        public static void DeleteUser(string firstname, string lastname, string password, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE USER WHERE firstname= @firstname and lastname=@lastname";
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Connection = conn;
            conn.Open();


            cmd.ExecuteNonQuery();
            Console.WriteLine(" L'utilisateur a été supprimé ");
            Console.ReadKey();

        }
    }
}
