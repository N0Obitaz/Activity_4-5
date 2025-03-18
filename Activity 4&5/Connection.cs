using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using Console = Colorful.Console;
namespace Activity
{
    class Connection
    {
        protected string connectionString;

        public Connection()
        {
            string server = "localhost";
            string database = "actdb";
            string uid = "root";
            string password = "";
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        }
        //Insert Data
        public void InsertData(string username, string userPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO user (username, password) VALUES (@username, @password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", userPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //Check User Credentials
        public bool ValidateLogin(string username, string userPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", userPassword);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        //Check Existing users
        public bool UserExists(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM user WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        //Check Exising Product
        public bool CheckProduct(string productName)
        {
            try
            {
                using(MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) from products WHERE productname = @productName";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("productName", productName);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            
        }
        //Count Products
        public bool CheckProductLimit()
        {
           
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))

                {
                    connection.Open();
                    string countQuery = "SELECT COUNT(*) from products";
                    using (MySqlCommand cmd = new MySqlCommand(countQuery, connection))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        
                        return count < 11;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: nandito" + ex.Message);
                return false;
            }
        }

        //Insert Porducts
        public void insertProduct(string productName, float productPrice, string productDescription)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO products (productname, productprice, productdescription) VALUES (@productname, @productprice, @productdescription)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productname", productName);
                        cmd.Parameters.AddWithValue("@productprice", productPrice);
                        cmd.Parameters.AddWithValue("@productdescription", productDescription);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine(@"
██████╗ ██████╗  ██████╗ ██████╗ ██╗   ██╗ ██████╗████████╗                                        
██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██║   ██║██╔════╝╚══██╔══╝                                        
██████╔╝██████╔╝██║   ██║██║  ██║██║   ██║██║        ██║                                           
██╔═══╝ ██╔══██╗██║   ██║██║  ██║██║   ██║██║        ██║                                           
██║     ██║  ██║╚██████╔╝██████╔╝╚██████╔╝╚██████╗   ██║                                           
╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝  ╚═════╝   ╚═╝                                           
                                                                                                   
██╗███╗   ██╗███████╗███████╗██████╗ ████████╗███████╗██████╗                                      
██║████╗  ██║██╔════╝██╔════╝██╔══██╗╚══██╔══╝██╔════╝██╔══██╗                                     
██║██╔██╗ ██║███████╗█████╗  ██████╔╝   ██║   █████╗  ██║  ██║                                     
██║██║╚██╗██║╚════██║██╔══╝  ██╔══██╗   ██║   ██╔══╝  ██║  ██║                                     
██║██║ ╚████║███████║███████╗██║  ██║   ██║   ███████╗██████╔╝                                     
╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═════╝                                      
                                                                                                   
███████╗██╗   ██╗ ██████╗ ██████╗███████╗███████╗███████╗███████╗██╗   ██╗██╗     ██╗  ██╗   ██╗██╗
██╔════╝██║   ██║██╔════╝██╔════╝██╔════╝██╔════╝██╔════╝██╔════╝██║   ██║██║     ██║  ╚██╗ ██╔╝██║
███████╗██║   ██║██║     ██║     █████╗  ███████╗███████╗█████╗  ██║   ██║██║     ██║   ╚████╔╝ ██║
╚════██║██║   ██║██║     ██║     ██╔══╝  ╚════██║╚════██║██╔══╝  ██║   ██║██║     ██║    ╚██╔╝  ╚═╝
███████║╚██████╔╝╚██████╗╚██████╗███████╗███████║███████║██║     ╚██████╔╝███████╗███████╗██║   ██╗
╚══════╝ ╚═════╝  ╚═════╝ ╚═════╝╚══════╝╚══════╝╚══════╝╚═╝      ╚═════╝ ╚══════╝╚══════╝╚═╝   ╚═╝", Color.Green);
                    }
                }


            }catch(Exception ex)
            {
                Console.WriteLine("Error: "+ ex.Message, Color.Red);

            }

        }
        //Delete Products
        public void DeleteProduct(string productName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE from products where productname = @productName";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productName", productName);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine(@"
██████╗ ██████╗  ██████╗ ██████╗ ██╗   ██╗ ██████╗████████╗    ██████╗ ███████╗██╗     ███████╗████████╗███████╗██████╗ 
██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██║   ██║██╔════╝╚══██╔══╝    ██╔══██╗██╔════╝██║     ██╔════╝╚══██╔══╝██╔════╝██╔══██╗
██████╔╝██████╔╝██║   ██║██║  ██║██║   ██║██║        ██║       ██║  ██║█████╗  ██║     █████╗     ██║   █████╗  ██║  ██║
██╔═══╝ ██╔══██╗██║   ██║██║  ██║██║   ██║██║        ██║       ██║  ██║██╔══╝  ██║     ██╔══╝     ██║   ██╔══╝  ██║  ██║
██║     ██║  ██║╚██████╔╝██████╔╝╚██████╔╝╚██████╗   ██║       ██████╔╝███████╗███████╗███████╗   ██║   ███████╗██████╔╝
╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝  ╚═════╝   ╚═╝       ╚═════╝ ╚══════╝╚══════╝╚══════╝   ╚═╝   ╚══════╝╚═════╝ 
                                                                                                                        
███████╗██╗   ██╗ ██████╗ ██████╗███████╗███████╗███████╗███████╗██╗   ██╗██╗     ██╗  ██╗   ██╗                        
██╔════╝██║   ██║██╔════╝██╔════╝██╔════╝██╔════╝██╔════╝██╔════╝██║   ██║██║     ██║  ╚██╗ ██╔╝                        
███████╗██║   ██║██║     ██║     █████╗  ███████╗███████╗█████╗  ██║   ██║██║     ██║   ╚████╔╝                         
╚════██║██║   ██║██║     ██║     ██╔══╝  ╚════██║╚════██║██╔══╝  ██║   ██║██║     ██║    ╚██╔╝                          
███████║╚██████╔╝╚██████╗╚██████╗███████╗███████║███████║██║     ╚██████╔╝███████╗███████╗██║                           
╚══════╝ ╚═════╝  ╚═════╝ ╚═════╝╚══════╝╚══════╝╚══════╝╚═╝      ╚═════╝ ╚══════╝╚══════╝╚═╝", Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error here" + ex.Message, Color.Red);
            }
        }
    }

    

    
}




