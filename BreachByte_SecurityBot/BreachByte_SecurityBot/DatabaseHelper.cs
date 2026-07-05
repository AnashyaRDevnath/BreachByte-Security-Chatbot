using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreachByte_SecurityBot
{
    public class DatabaseHelper
    {
        // Local database credentials
        private string connectionString = "Server=localhost;Port=3306;Database=BreachByteDB;Uid=root;Pwd=your_password;";

        private MySqlConnection connection;

        // Constructor: Sets up the connection string when the helper is created
        public DatabaseHelper()
        {
            
            connection = new MySqlConnection(connectionString);
        }

        // Method to open the connection safely
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // This will help debug if the connection fails
                Console.WriteLine($"Error connecting to database: {ex.Message}");
                       return false;
            }
        }

        // Method to close the connection safely
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error closing database: {ex.Message}");
                return false;
            }
        }

        // Expose the connection so other methods can use it for queries
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
    

