using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AppleStock
{ 
    public class UserOrder
    {
        private string listProduct;
        private string price;
        private DateTime dateOrder;
        private string clientName;
        private string clientFirstname;
        private string clientMail;
        private string no_order;
        private int id;
        private string reference;

        public string ListProduct { get => listProduct; set => listProduct = value; }
        public string Price { get => price; set => price = value; }
        public string DateOrder { get => DateOrder; set => DateOrder = value; }
        public string ClientName { get => clientName; set => ClientName = value; }
        public string ClientFirstname { get => clientFirstname; set => clientFirstname = value; }
        public string ClientMail { get => clientMail; set => clientMail = value; }
        public string No_order { get => no_order; set => no_order = value; }
        public int Id { get => id; set => id = value; }
        public string Reference { get => reference; set => reference = value; }

    public UserOrder(string listProduct, string price, DateTime dateOrder, string clientName, string clientFirstname, string clientMail, string no_order, int id, string reference)
    {
        this.listProduct = listProduct;
        this.price = price;
        this.dateOrder = dateOrder;
        this.clientName = clientName;
        this.clientFirstname = clientFirstname;
        this.clientMail = clientMail;
        this.no_order = no_order;
        this.id = id;
        this.reference = reference;


        }

        public static void SelectUserOrder(MySqlConnection conn)
    {
        MySqlCommand cmd = new MySqlCommand();

        cmd.Connection = conn;
        conn.Open();

        cmd.CommandText = "SELECT * FROM userorder";


        using (DbDataReader reader = cmd.ExecuteReader())
            //MySqlDataReader dataReader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                //lis les données et les stock dans la liste
                while (reader.Read())
                {
                    var ListProduct = reader.GetString(1);
                    var Price = reader.GetString(2);
                    var DateOrder = reader.GetString(3);
                    var ClientName = reader.GetString(4);
                    var ClientFirstname = reader.GetString(5);
                    var ClientMail = reader.GetString(6);
                    var No_order = reader.GetString(7);
                    var Reference = reader.GetString(8);



                    Console.WriteLine($"{ListProduct} {Price} {DateOrder} {ClientName} {ClientFirstname} {ClientMail} {No_order} {Reference}");

                    cmd.Connection = conn;

                }


            }
    }



        public static void CreateUserOrder(string listProduct, string price, DateTime dateOrder, string clientName, string clientFirstname, string clientMail, string no_order, int id, string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO product(model, category, quantity, color, price) VALUES (@model,@category,@quantity,@color,@price')";
            cmd.Parameters.AddWithValue("@listProduct", listProduct);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@dateOrder", dateOrder);
            cmd.Parameters.AddWithValue("@clientName", clientName);
            cmd.Parameters.AddWithValue("@clientFirstname", clientFirstname);
            cmd.Parameters.AddWithValue("@clientMail", clientMail);
            cmd.Parameters.AddWithValue("@no_order", no_order);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@reference", reference);




            cmd.Connection = conn;
            //conn.Open();

            cmd.ExecuteNonQuery();
            Console.WriteLine(" La commande a été enregistré ");
            Console.ReadKey();

        }

        public static void UpdateUserOrder(string listProduct, string price, DateTime dateOrder, string clientName, string clientFirstname, string clientMail, string no_order, int id, string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "UPDATE userorder SET (model= @model , category = @category, quantity=@quantity, color=@color, price=@price) WHERE reference =@reference";
            cmd.Parameters.AddWithValue("@listProduct", listProduct);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@dateOrder", dateOrder);
            cmd.Parameters.AddWithValue("@clientName", clientName);
            cmd.Parameters.AddWithValue("@clientFirstname", clientFirstname);
            cmd.Parameters.AddWithValue("@clientMail", clientMail);
            cmd.Parameters.AddWithValue("@no_order", no_order);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@reference", reference);

            cmd.Connection = conn;
            conn.Open();


            cmd.ExecuteNonQuery();
            Console.WriteLine(" La commande a été modifié ");
            Console.ReadKey();

        }

        public static void DeleteUserOrder(string reference, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "DELETE product WHERE reference =@reference";

            cmd.Parameters.AddWithValue("@reference", reference);
            cmd.Connection = conn;
            conn.Open();


            cmd.ExecuteNonQuery();
            Console.WriteLine(" La commande a été supprimé ");
            Console.ReadKey();

        }
    }

}



        
    

