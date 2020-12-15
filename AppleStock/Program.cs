using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlCon;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AppleStock
{
    class Program
    {
        static void Main(string[] args)
        {

            MySqlConnection conn = DBconnection.GetDBConnection();
            conn.Open();


            Console.WriteLine(" ------------------------");
            Console.WriteLine("|      Apple STOCK       |");
            Console.WriteLine("|                        |");
            Console.WriteLine("| 1. Se connecter        |");
            Console.WriteLine("| 2. S'inscrire          |");
            Console.WriteLine("| X. Quitter             |");
            Console.WriteLine(" ------------------------");

            var input = Console.ReadLine();
            string choixOne = string.Empty;
            string choixTwo = string.Empty;

            bool successfull = false;
            while (!successfull)
            {

                if (input == "1")
                {

                    Console.WriteLine("Entrez votre identifiant:");
                    var email = Console.ReadLine();
                    Console.WriteLine("Entrez votre mot de passe:");
                    var password = Console.ReadLine();
                    successfull = SqlCon.DBMySQL.ValidateLogin(email, password, conn);

                }

                if (successfull)
                {

                    Console.Clear();
                    Console.WriteLine(" Connexion établit ");
                    Console.WriteLine(" ---------------------------");
                    Console.WriteLine("|    AppleStock Menu         |");
                    Console.WriteLine("|                            |");
                    Console.WriteLine("| 1. Liste des produits      |");
                    Console.WriteLine("| 2. Liste des commandes     |");
                    Console.WriteLine("| 3. Liste des Catégories    |");
                    Console.WriteLine("| 4. Liste des Modèles       |");
                    Console.WriteLine("|                            |");
                    Console.WriteLine(" ---------------------------");

                    var choix1 = Console.ReadLine();
                    choixOne = choix1;


                    if (input == "1" || input == "2" || input == "3" || input == "4")
                    {

                        Console.WriteLine(" ---------------------------");
                        Console.WriteLine("|   Les Fonctionalités       |");
                        Console.WriteLine("|                            |");
                        Console.WriteLine("| 1. Afficher                |");
                        Console.WriteLine("| 2. Ajouter                 |");
                        Console.WriteLine("| 3. Modifier                |");
                        Console.WriteLine("| 4. Supprimer               |");
                        Console.WriteLine("|                            |");
                        Console.WriteLine(" ---------------------------");


                        var choix2 = Console.ReadLine();
                        choixTwo = choix2;

                    }

                    if (choixOne == "1")
                    {
                        if (choixTwo == "1")
                        {
                            Product.SelectProduct(conn);
                        }
                        else if (choixTwo == "2")
                        {
                            Console.WriteLine(" Le produit que vous souhaité ajouter : ");
                            Console.WriteLine("Modèle:");
                            var model = Console.ReadLine();
                            Console.WriteLine("Catégorie:");
                            var category = Console.ReadLine();
                            Console.WriteLine("Quantité:");
                            var quantity = Console.ReadLine();
                            Console.WriteLine("Couleur:");
                            var color = Console.ReadLine();
                            Console.WriteLine("Prix:");
                            var price = Console.ReadLine();
                            Console.WriteLine("Reference:");
                            var reference = Console.ReadLine();



                            Product.CreateProduct(model, category, quantity, color, price, reference, conn);

                        }else if(choixTwo == "3")
                        {
                            Product.SelectProduct(conn);

                            Console.WriteLine(" Donnez la référence du produit à modifié : ");
                            Console.WriteLine("Reference:");
                            var reference = Console.ReadLine();

                            Console.WriteLine(" Modifez le produit de votre choix : ");
                            Console.WriteLine("Modèle:");
                            var model = Console.ReadLine();
                            Console.WriteLine("Catégorie:");
                            var category = Console.ReadLine();
                            Console.WriteLine("Quantité:");
                            var quantity = Console.ReadLine();
                            Console.WriteLine("Couleur:");
                            var color = Console.ReadLine();
                            Console.WriteLine("Prix:");
                            var price = Console.ReadLine();
                           

                            Product.UpdateProduct(model, category, quantity, color, price,reference, conn);

                        }else if(choixTwo == "4")
                        {

                            Product.SelectProduct(conn);

                            Console.WriteLine(" Donnez la référence du produit à supprimé : ");
                            Console.WriteLine("Reference:");
                            var reference = Console.ReadLine();

                            Product.DeleteProduct(reference, conn);
                        }


                    }
                    else
                    {
                        Console.WriteLine("Your username or password is incorect, try again !!!");

                    }
                }
            }
        }
    }
}
           /* var input = Console.ReadLine();

            MySqlConnection conn = DBconnection.GetDBConnection();
            // Create a command associated with the Connection.


            // Set Command Text
            conn.Open();

            string emailinput = null;
            string passwordinput = null;
            bool successfull = false;
            // while (!successfull)
            // {

            if (input == "1")
            {
                Console.WriteLine("Entrez votre identifiant:");
                var email = Console.ReadLine();
                Console.WriteLine("Entrez votre mot de passe:");
                var password = Console.ReadLine();
                emailinput = email.ToString();
                passwordinput = password.ToString();

                //DBMySQL.ValidateLogin(email, password);

            }
          //  successfull = SqlCon.DBMySQL.ValidateLogin(emailinput, passwordinput, conn);

            if (successfull)
            {
                Console.Clear();
                Console.WriteLine(" ---------------------------");
                Console.WriteLine("| AppleStock Menu            |");
                Console.WriteLine("|                            |");
                Console.WriteLine("| 1. Liste des produits      |");
                Console.WriteLine("| 2. Ajouter une commande    |");
                Console.WriteLine("| 6. Logout                  |");
                Console.WriteLine("|                            |");
                Console.WriteLine("|                            |");
                Console.WriteLine(" ---------------------------");
            }
            else
            {
                Console.WriteLine("Your username or password is incorect, try again !!!");

            }
            conn.Close();
            // Disposez un objet, libérez des ressources.
            conn.Dispose();
        }
    }
}
           /* try
            {
            SqlCon.DBMySQL.ValidateLogin(email,password, conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Terminez la connexion.
                conn.Close();
                // Disposez un objet, libérez des ressources.
                conn.Dispose();
            }*/
        
    




           /* Console.Read();
            Console.Clear();
                Console.WriteLine(" ------------------------");
                Console.WriteLine("|      Apple STOCK       |");
                Console.WriteLine("|                        |");
                Console.WriteLine("| 1. Se connecter        |");
                Console.WriteLine("| 2. Quitter             |");
                Console.WriteLine("|                        |");
                Console.WriteLine(" ------------------------");

                var input = Console.ReadLine();


                bool successfull = false;
                while (!successfull)
                {

                    if (input == "1")
                    {
                        Console.WriteLine("Entrez votre identifiant:");
                        var email = Console.ReadLine();
                        Console.WriteLine("Entrez votre mot de passe:");
                        var password = Console.ReadLine();

                        //DBMySQL.ValidateLogin(email, password);

                    }
                }
            }
        }
 }


                    /*foreach (Users user in arrUsers)
                     {
                         if (username == user.username && password == user.password)
                         {
                             Console.WriteLine("You have successfully logged in !!!");
                             Console.ReadLine();
                             successfull = true;
                             break;
                         }
                     }

                     if (!successfull)
                     {
                         Console.WriteLine("Your username or password is incorect, try again !!!");
                     }

                 }

                 if (successfull)
                 {


                     Console.Clear();
                     Console.WriteLine(" ---------------------------");
                     Console.WriteLine("| AppleStock Menu            |");
                     Console.WriteLine("|                            |");
                     Console.WriteLine("| 1. Liste des produits      |");
                     Console.WriteLine("| 2. Ajouter une commande    |");
                     Console.WriteLine("| 6. Logout                  |");
                     Console.WriteLine("|                            |");
                     Console.WriteLine("|                            |");
                     Console.WriteLine(" ---------------------------");
                 }

             }

         }
     }

 }   */

                 /*   using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Text;
                    using System.Threading.Tasks;
                    using SqlCon;
                    using System.Data.Common;
                    using MySql.Data.MySqlClient;
                 */
/*namespace AppleStock
    {
        class QueryDataExample
        {
            static void Main(string[] args)
            {

           

            // Obtenez de l'objet Connection qui se connecte à DB.
            MySqlConnection conn = DBconnection.GetDBConnection();
                // Create a command associated with the Connection.


                // Set Command Text
                conn.Open();
                try
                {
                    QueryUser(conn);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    Console.WriteLine(e.StackTrace);
                }
                finally
                {
                    // Terminez la connexion.
                    conn.Close();
                    // Disposez un objet, libérez des ressources.
                    conn.Dispose();
                }
                Console.Read();
            }

            private static void QueryUser(MySqlConnection conn)
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

    }*/

