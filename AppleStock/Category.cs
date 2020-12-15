using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AppleStock
{
    public class Category
    {

        private int id;
        private string typeProduct;
        private string reference;


        public int Id { get => id; set => id = value; }
        public string TypeProduct { get => typeProduct; set => typeProduct = value; }
        public string Reference { get => reference; set => reference = value; }




        public Category(int id, string typeProduct, string reference)
        {
            this.id = id;
            this.typeProduct = typeProduct;
            this.reference = reference;

        }

        public static void SelectCategory(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "SELECT * FROM category";


            using (DbDataReader reader = cmd.ExecuteReader())
                //MySqlDataReader dataReader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    //lis les données et les stock dans la liste
                    while (reader.Read())
                    {
                        var TypeProduct = reader.GetString(1);
                        var Reference = reader.GetString(2);

                        Console.WriteLine($"{TypeProduct} {Reference} ");
                    }
                    cmd.Connection = conn;

                }


        }





        public static void CreateCategory(string typeProduct, string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO category(typeProduct) VALUES (@typeProduct)";
            cmd.Parameters.AddWithValue("@typeProduct", typeProduct);
            cmd.Parameters.AddWithValue("@reference", reference);


            cmd.Connection = conn;
            //conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" La catégorie a été enregistré ");
            Console.ReadKey();

        }

        public static void UpdateProduct(string typeProduct, string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE category SET (typeProduct= @typeProduct , reference = @reference) WHERE reference =@reference";
            cmd.Parameters.AddWithValue("@typeProduct", typeProduct);
            cmd.Parameters.AddWithValue("@reference", reference);

            cmd.Connection = conn;
            conn.Open();


            cmd.ExecuteNonQuery();
            Console.WriteLine(" La catégorie a été modifié ");
            Console.ReadKey();

        }

        public static void DeleteProduct(string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE category WHERE reference= @reference";
            cmd.Parameters.AddWithValue("@reference", reference);

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" La catégorie a été supprimé ");
            Console.ReadKey();

        }
    }

}



