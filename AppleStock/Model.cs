using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AppleStock
{
    public class Model
    {
        

        private int id;
        private string modelProduct;
        private string reference;


        public int Id { get => id; set => id = value; }
        public string ModelProduct { get => modelProduct; set => modelProduct = value; }
        public string Reference { get => reference; set => reference = value; }

    


        public Model(int id, string modelProduct,string reference)
        {
            this.id = id;
            this.modelProduct = modelProduct;
            this.reference = reference;
            
        }

        public static void SelectModel(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "SELECT * FROM model";


            using (DbDataReader reader = cmd.ExecuteReader())
                //MySqlDataReader dataReader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    //lis les données et les stock dans la liste
                    while (reader.Read())
                    {
                        var ModelProduct = reader.GetString(1);
                        var Reference = reader.GetString(2);

                        Console.WriteLine($"{ModelProduct} {Reference} ");
                    }
                    cmd.Connection = conn;

                }


        }





        public static void CreateModel(string modelProduct, string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO product(modelProduct) VALUES (@modelPrduct)";
            cmd.Parameters.AddWithValue("@modelProduct", modelProduct);
            cmd.Parameters.AddWithValue("@reference", reference);


            cmd.Connection = conn;
            //conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" Le modelère a été enregistré ");
            Console.ReadKey();

        }

        public static void UpdateModel(string modelProduct,string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE product SET (modelProduct= @modelProduct , reference = @reference) WHERE reference =@reference";
            cmd.Parameters.AddWithValue("@modelProduct", modelProduct);
            cmd.Parameters.AddWithValue("@reference", reference);
            
            cmd.Connection = conn;
            conn.Open();


            cmd.ExecuteNonQuery();
            Console.WriteLine(" Le produit a été modifié ");
            Console.ReadKey();

        }

        public static void DeleteModel( string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE product WHERE reference= @reference";
            cmd.Parameters.AddWithValue("@reference", reference);
        
            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" Le modèle a été supprimé ");
            Console.ReadKey();

        }
    }

}



  