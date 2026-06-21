using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data;
using MySql.Data.MySqlClient;

namespace BreachByte_SecurityBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Instantiate BotBrain
        private BotBrain myBot;

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            myBot = new BotBrain();
            LoadTasks();

            //Voice greeting
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("VoiceGreeting.wav");
                player.Play();
            }
            catch
            {
                //If the audio fails, the app just silently ignores it and keeps working
            }

            TextBlock welcomeText = new TextBlock();
            welcomeText.Text = "BreachByte: Welcome! How are you? What's your name?";
            welcomeText.Foreground = System.Windows.Media.Brushes.LightGreen;
            welcomeText.Margin = new Thickness(0, 5, 0, 15);
            ChatHistoryPanel.Children.Add(welcomeText);
        }


            private void LoadTasks()
        {
            DatabaseHelper db = new DatabaseHelper();

            if (db.OpenConnection())
            {
                try
                {
                    // 1. Write the SQL query to fetch the tasks
                    string query = "SELECT task_id, title, is_completed FROM cyber_tasks";

                    // 2. Package the query and the connection together
                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());

                    // 3. Use an Adapter to translate the MySQL data into C# data
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 4. Inject the data into the XAML DataGrid
                    TasksDataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading tasks: {ex.Message}");
                }
                finally
                {
                    // Always close the bridge when finished!
                    db.CloseConnection();
                }
            }
        }
        

        //Added async so the app can wait between letters
        private async void ProcessMessage()
        {
            string userInput = UserInputBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                await TypeMessageAsync("BreachByte: ", "Oops! Looks like you forgot to type something 😅. Type 'What can i ask about' to see available cybercrime topic options or type 'Bye' to end our conversation😊", System.Windows.Media.Brushes.DarkMagenta);
                return;
            }

            //Cleanup
            UserInputBox.Clear();

            //Show user message
            TextBlock userText = new TextBlock();
            userText.Text = $"{myBot.SavedUserName}: {userInput}";
            userText.Foreground = System.Windows.Media.Brushes.Cyan; // Makes text Cyan!
            userText.Margin = new Thickness(0, 5, 0, 5);
            userText.TextWrapping = TextWrapping.Wrap;

            //Add the UI element to the panel, and scroll down
            ChatHistoryPanel.Children.Add(userText);
            ChatScrollViewer.ScrollToEnd();

            //Ask the BotBrain for an answer
            string botAnswer = myBot.GetBotResponse(userInput);

            //Show the bot's answer (call typing method)
            await TypeMessageAsync("BreachByte: ", botAnswer, System.Windows.Media.Brushes.LightGreen);

            //exit logic (so app shuts down after user says bye
            if (userInput == "exit" || userInput == "quit" || userInput.Contains("bye"))
            {
                // Wait for 2 seconds (2000 milliseconds) so they can read the goodbye
                await Task.Delay(2000);

                // This command tells Windows to close the specific WPF app safely
                System.Windows.Application.Current.Shutdown();
            }

            ChatScrollViewer.ScrollToEnd();
        }

        //Typing effect for bot
        private async Task TypeMessageAsync(string prefix, string message, SolidColorBrush textColor)
        {
            TextBlock botMsg = new TextBlock();
            botMsg.Foreground = textColor;
            botMsg.TextWrapping = TextWrapping.Wrap;
            botMsg.Margin = new Thickness(0, 5, 0, 15);
            botMsg.FontFamily = new System.Windows.Media.FontFamily("Consolas");

            ChatHistoryPanel.Children.Add(botMsg);

            // 1. Add the prefix (BreachByte:)
            botMsg.Inlines.Add(new Run(prefix));

            // 2. Identify the name we are looking for
            string userName = myBot.SavedUserName;

            // We create a "Current Run" to type into
            Run currentRun = new Run();
            botMsg.Inlines.Add(currentRun);

            // 3. The Typing Loop
            for (int i = 0; i < message.Length; i++)
            {
                // Check if the next chunk of letters matches the User's Name
                if (userName.Length > 0 && i + userName.Length <= message.Length &&
                    message.Substring(i, userName.Length).Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                    //Create a bold Run
                    Run boldName = new Run();
                    boldName.FontWeight = FontWeights.Bold;
                    boldName.Foreground = System.Windows.Media.Brushes.White; // Make it pop in White!
                    botMsg.Inlines.Add(boldName);

                    // Type the name out in bold
                    for (int j = 0; j < userName.Length; j++)
                    {
                        boldName.Text += message[i];
                        i++;
                        await Task.Delay(15); //(Microsoft, 2025)
                    }
                    i--; // Adjust index because the outer loop will increment it

                    // Switch back to a regular Run for the rest of the sentence
                    currentRun = new Run();
                    botMsg.Inlines.Add(currentRun);
                }
                else
                {
                    // Just normal typing
                    currentRun.Text += message[i];
                    await Task.Delay(15);
                }

                ChatScrollViewer.ScrollToEnd();
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)  //(Microsoft, 2025)
        {
            ProcessMessage();
        }

        private void UserInputBox_KeyDown(object sender, KeyEventArgs e)  // (Microsoft, 2025) and (Microsoft, n.d)
        {
            // Check if the user pressed the 'Enter' key on their keyboard
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ProcessMessage();
            }
        }

        private void BtnRefreshTasks_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadTasks();
        }

        private void BtnAddTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // 1. Create the popup window
            AddTaskWindow addTaskPopup = new AddTaskWindow();

            // 2. Set its owner so it centers perfectly over the main app
            addTaskPopup.Owner = this;

            // 3. ShowDialog() stops the user from clicking the main app until the popup closes
            addTaskPopup.ShowDialog();

            // 4. Once they close the popup, automatically refresh the grid to show the new task!
            LoadTasks();
        }

        private void BtnToggleStatus_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // 1. Ensure the user actually selected a row first
            if (TasksDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a task from the list to update.", "System Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // 2. Extract the data from the selected row
            DataRowView row = (DataRowView)TasksDataGrid.SelectedItem;
            int taskId = Convert.ToInt32(row["task_id"]);
            bool currentStatus = Convert.ToBoolean(row["is_completed"]);

            // 3. Flip the boolean status (If true, make false. If false, make true)
            bool newStatus = !currentStatus;

            DatabaseHelper db = new DatabaseHelper();
            if (db.OpenConnection())
            {
                try
                {
                    // 4. Secure parameterized UPDATE query
                    string query = "UPDATE cyber_tasks SET is_completed = @status WHERE task_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database Error: {ex.Message}");
                }
                finally
                {
                    db.CloseConnection();
                    LoadTasks(); // Instantly refresh the UI to show the new status!
                }
            }
        }

        private void BtnDeleteTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a task from the list to delete.", "System Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Ask for confirmation before permanently deleting!
            MessageBoxResult result = MessageBox.Show("Are you sure you want to permanently delete this task?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                DataRowView row = (DataRowView)TasksDataGrid.SelectedItem;
                int taskId = Convert.ToInt32(row["task_id"]);

                DatabaseHelper db = new DatabaseHelper();
                if (db.OpenConnection())
                {
                    try
                    {
                        // Secure parameterized DELETE query
                        string query = "DELETE FROM cyber_tasks WHERE task_id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                        cmd.Parameters.AddWithValue("@id", taskId);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database Error: {ex.Message}");
                    }
                    finally
                    {
                        db.CloseConnection();
                        LoadTasks();
                    }
                }
            }
        }
    }
}
