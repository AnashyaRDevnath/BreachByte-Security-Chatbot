using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace BreachByte_SecurityBot
{
    public partial class AddTaskWindow : Window
    {
        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        public AddTaskWindow()
        {
            InitializeComponent();
        }

        // ==========================================
        // BUTTON EVENT HANDLERS
        // ==========================================

        // Validates input and saves the new task to the database
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Guard: ensure the title field is not empty
            if (string.IsNullOrWhiteSpace(TxtTitle.Text))
            {
                MessageBox.Show("Please enter a Task Title.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DatabaseHelper db = new DatabaseHelper();

            if (db.OpenConnection())
            {
                try
                {
                    // Parameterized query prevents SQL injection
                    string query = "INSERT INTO cyber_tasks (title, description) VALUES (@title, @desc)";

                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());

                    // Bind the text box values safely to the query parameters
                    cmd.Parameters.AddWithValue("@title", TxtTitle.Text);
                    cmd.Parameters.AddWithValue("@desc", TxtDescription.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Task successfully added to the database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }

        // Closes the popup without saving
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}