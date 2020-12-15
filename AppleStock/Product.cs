using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AppleStock
{
    public class Product
    {

        private int id;
        private string model;
        private string category;
        private string quantity;
        private string color;
        private string price;
        private string reference;

        public int Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
        public string Category { get => category; set => category = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string Color { get => color; set => color = value; }
        public string Price { get => price; set => price = value; }
        public string Reference { get => reference; set => reference= value; }

        public Product(int id, string model, string category, string quantity, string color, string price, string reference)
        {
            this.id = id;
            this.model = model;
            this.category = category;
            this.quantity = quantity;
            this.color = color;
            this.price = price;
            this.reference = reference;
        }

        public static void SelectProduct(MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "SELECT * FROM product";


            using (DbDataReader reader = cmd.ExecuteReader())
                //MySqlDataReader dataReader = cmd.ExecuteReader();

            if (reader.HasRows)
                {

                    //lis les données et les stock dans la liste
                    while (reader.Read())
                    {
                        var Model = reader.GetString(1);
                        var Category = reader.GetString(2);
                        var Quantity = reader.GetString(3);
                        var Color = reader.GetString(4);
                        var Price = reader.GetString(5);
                        var Reference = reader.GetString(6);

                        Console.WriteLine($"{Model} {Category} {Quantity} {Color} {Price} {Reference}");
                    }
                    cmd.Connection = conn;

                }
           

        }
         
            


        

        public static void CreateProduct(string model, string category, string quantity, string color, string price, string reference,MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO product(model, category, quantity, color, price,reference) VALUES (@model,@category,@quantity,@color,@price,@reference)";
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@color",color);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@reference", reference);

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" Le produit a été enregistré ");
            Console.ReadKey();



        }

        public static void UpdateProduct(string model, string category, string quantity, string color, string price,string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE product SET (model= @model , category = @category, quantity=@quantity, color=@color, price=@price) WHERE reference =@reference";
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@reference", reference);

            cmd.Connection = conn;
           // conn.Open();


            cmd.ExecuteNonQuery();
            Console.WriteLine(" Le produit a été modifié ");
            Console.ReadKey();

        }

        public static void DeleteProduct( string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE product WHERE reference='@reference'";
            cmd.Parameters.AddWithValue("@reference",reference);

            cmd.Connection = conn;
           // conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" Le produit a été supprimé ");
            Console.ReadKey();

        }
    }

}
/*public override string ToString()
{
    return model + " | " + category + " |  " + quantity + " | " + reference + " | " + price + " | " + color;
}
    }
}*/

