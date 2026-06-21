using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BreachByte_SecurityBot
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // 1. Check if the user left the title blank
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
                    // 2. The SECURE Parameterized Query (prevents SQL injection)
                    string query = "INSERT INTO cyber_tasks (title, description) VALUES (@title, @desc)";

                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());

                    // 3. Bind the text box data safely to the @ variables
                    cmd.Parameters.AddWithValue("@title", TxtTitle.Text);
                    cmd.Parameters.AddWithValue("@desc", TxtDescription.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Task successfully added to the database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Close the popup window after saving
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
