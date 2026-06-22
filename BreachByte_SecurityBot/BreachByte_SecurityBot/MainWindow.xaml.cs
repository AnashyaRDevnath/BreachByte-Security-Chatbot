using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace BreachByte_SecurityBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ==========================================
        // FIELDS
        // ==========================================

        // Activity log storage
        private List<string> activityLog = new List<string>();

        // State tracker for the "show more" activity log feature
        private bool isWaitingForShowMore = false;

        // Stores tasks added via NLP (natural language commands)
        private List<string> userTasks = new List<string>();

        private string pendingTask = "";

        // The chatbot brain
        private BotBrain myBot;

        // State trackers for the reminder flow
        private bool isWaitingForReminder = false;
        private int currentPendingTaskId = -1;

        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        public MainWindow()
        {
            InitializeComponent();
            myBot = new BotBrain();
            LoadTasks();

            // Play voice greeting on startup
            try
            {
                string greetingPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VoiceGreeting.wav");
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(greetingPath);
                player.Play();
            }
            catch
            {
                // If the audio fails, the app silently ignores it and keeps working
            }

            // Display the initial welcome message in the chat
            TextBlock welcomeText = new TextBlock();
            welcomeText.Text = "BreachByte: Welcome! How are you? What's your name?";
            welcomeText.Foreground = System.Windows.Media.Brushes.LightGreen;
            welcomeText.Margin = new Thickness(0, 5, 0, 15);
            ChatHistoryPanel.Children.Add(welcomeText);
        }

        // ==========================================
        // ACTIVITY LOG
        // ==========================================

        // Adds a timestamped entry to the activity log
        private void LogActivity(string description)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            activityLog.Add($"[{timestamp}] {description}");
        }

        // ==========================================
        // DATABASE METHODS
        // ==========================================

        // Fetches all tasks from the database and binds them to the DataGrid
        private void LoadTasks()
        {
            DatabaseHelper db = new DatabaseHelper();

            if (db.OpenConnection())
            {
                try
                {
                    // Fetch all task fields needed for the DataGrid
                    string query = "SELECT task_id, title, reminder_date, is_completed FROM cyber_tasks";

                    MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());

                    // Use an adapter to translate MySQL data into a C# DataTable
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the data to the XAML DataGrid
                    TasksDataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading tasks: {ex.Message}");
                }
                finally
                {
                    // Always close the connection when finished
                    db.CloseConnection();
                }
            }
        }

        // ==========================================
        // CHAT PROCESSING
        // ==========================================

        // Handles all incoming user messages — routes to the correct logic block
        private async void ProcessMessage()
        {
            string originalUserInput = UserInputBox.Text;
            string userInput = originalUserInput.ToLower().Trim();

            // Guard: do nothing if the input box is empty
            if (string.IsNullOrWhiteSpace(userInput))
            {
                await TypeMessageAsync("BreachByte: ", "Oops! Looks like you forgot to type something 😅. Type 'What can i ask about' to see available cybercrime topic options or type 'Bye' to end our conversation😊", System.Windows.Media.Brushes.DarkMagenta);
                return;
            }

            // Clear input and display the user's message in the chat
            UserInputBox.Clear();

            TextBlock userText = new TextBlock();
            userText.Text = $"{myBot.SavedUserName}: {originalUserInput}";
            userText.Foreground = System.Windows.Media.Brushes.Cyan;
            userText.Margin = new Thickness(0, 5, 0, 5);
            userText.TextWrapping = TextWrapping.Wrap;

            ChatHistoryPanel.Children.Add(userText);
            ChatScrollViewer.ScrollToEnd();

            // ==========================================
            // TASK REMINDER FLOW
            // ==========================================

            if (isWaitingForReminder)
            {
                // Extract any digits from their response (e.g., "in 3 days" or just "3")
                string numberOnly = new String(userInput.Where(Char.IsDigit).ToArray());

                if (userInput.Contains("no") && string.IsNullOrEmpty(numberOnly))
                {
                    // User declined a reminder
                    await TypeMessageAsync("BreachByte: ", "No problem! Task saved without a reminder.", System.Windows.Media.Brushes.LightGreen);
                    isWaitingForReminder = false;
                    currentPendingTaskId = -1;
                }
                else if (!string.IsNullOrEmpty(numberOnly) && int.TryParse(numberOnly, out int days))
                {
                    // User provided a number of days — save the reminder date
                    DateTime reminderDate = DateTime.Now.AddDays(days);

                    DatabaseHelper db = new DatabaseHelper();
                    if (db.OpenConnection())
                    {
                        string updateQuery = "UPDATE cyber_tasks SET reminder_date = @date WHERE task_id = @id";
                        MySqlCommand cmd = new MySqlCommand(updateQuery, db.GetConnection());
                        cmd.Parameters.AddWithValue("@date", reminderDate);
                        cmd.Parameters.AddWithValue("@id", currentPendingTaskId);
                        cmd.ExecuteNonQuery();
                        db.CloseConnection();
                    }

                    await TypeMessageAsync("BreachByte: ", $"Got it! I'll remind you in {days} days.", System.Windows.Media.Brushes.LightGreen);

                    // Reset reminder state and refresh the task list
                    isWaitingForReminder = false;
                    currentPendingTaskId = -1;
                    LoadTasks();
                }
                else if (userInput.Contains("yes") || userInput.Contains("please") || userInput.Contains("remind"))
                {
                    // User said yes but forgot to provide a number
                    await TypeMessageAsync("BreachByte: ", "Awesome! In how many days would you like me to remind you? (e.g., type '3' or 'in 3 days')", System.Windows.Media.Brushes.LightGreen);
                    return; // Keep waiting — do not reset state
                }
                else
                {
                    // Unrecognised response
                    await TypeMessageAsync("BreachByte: ", "I didn't quite catch that. Would you like a reminder? (Type 'yes' or 'no')", System.Windows.Media.Brushes.LightGreen);
                    return;
                }
            }

            // ==========================================
            // DIRECT TASK COMMAND (e.g. "add task - Update antivirus")
            // ==========================================

            else if (Regex.IsMatch(userInput, @"(?i)(?:add|create|make|set)\s+(?:a\s+)?(?:new\s+)?(?:task|to-do)"))
            {
                Match match = Regex.Match(userInput, @"(?i)(?:add|create|make|set)\s+(?:a\s+)?(?:new\s+)?(?:task|to-do)(?:\s+for\s+me)?(?:\s+to)?\s*(.*)");

                if (match.Success)
                {

                    string extractedTask = match.Groups[1].Value.Trim();

                    // Failsafe: if they didn't type a task name
                    if (string.IsNullOrEmpty(extractedTask))
                    {
                        await TypeMessageAsync("BreachByte: ", "I can certainly add a task for you! What would you like the task to be?", System.Windows.Media.Brushes.LightGreen);
                        return;
                    }

                    string taskDescription = $"Automated cybersecurity task: {extractedTask}";
                    userTasks.Add(extractedTask);
                    LogActivity($"Task added: '{extractedTask}'");

                    // DATABASE INTEGRATION
                    DatabaseHelper db = new DatabaseHelper();
                    if (db.OpenConnection())
                    {
                        string insertQuery = "INSERT INTO cyber_tasks (title, description) VALUES (@title, @desc); SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd = new MySqlCommand(insertQuery, db.GetConnection());
                        cmd.Parameters.AddWithValue("@title", extractedTask);
                        cmd.Parameters.AddWithValue("@desc", taskDescription);

                        // Save the ID in case they say "yes" to the reminder!
                        currentPendingTaskId = Convert.ToInt32(cmd.ExecuteScalar());
                        db.CloseConnection();
                    }

                 
                    LoadTasks();

                    isWaitingForReminder = true;
                    pendingTask = extractedTask; // Saves it in the bot's short-term memory

                    await TypeMessageAsync("BreachByte: ", $"Task added: '{extractedTask}'. Would you like to set a reminder for this?", System.Windows.Media.Brushes.LightGreen);
                }
                return;
            }

            // ==========================================
            // QUIZ LAUNCHER
            // ==========================================

            else if (userInput == "quiz" || userInput == "start game")
            {
                LogActivity("User initiated the Cybersecurity Training Simulator.");

                QuizWindow quiz = new QuizWindow(myBot.SavedUserName);
                quiz.ShowDialog();

                LogActivity($"Quiz completed. Final Score: {quiz.FinalScore}/11.");

                await TypeMessageAsync("BreachByte: ", $"Welcome back, {myBot.SavedUserName}! I see you scored {quiz.FinalScore}/11 on the simulator.", System.Windows.Media.Brushes.LightGreen);
                return;
            }

            // ==========================================
            // ACTIVITY LOG VIEWER
            // ==========================================

            else if (userInput == "show activity log" || userInput == "what have you done for me?")
            {
                LogActivity("User requested to view the activity log.");

                if (activityLog.Count == 0)
                {
                    await TypeMessageAsync("BreachByte: ", "My activity log is currently empty. Try starting a quiz or asking me a question!", System.Windows.Media.Brushes.LightGreen);
                    return;
                }

                // Display only the last 5 entries to keep it concise
                int displayCount = Math.Min(5, activityLog.Count);
                var recentLogs = activityLog.Skip(Math.Max(0, activityLog.Count - displayCount)).ToList();

                string logMessage = "Here is a summary of my recent actions:\n\n";
                for (int i = 0; i < recentLogs.Count; i++)
                    logMessage += $"{i + 1}. {recentLogs[i]}\n";

                // Offer "show more" if there are more than 5 entries
                if (activityLog.Count > 5)
                {
                    logMessage += "\n(Type 'show more' to see the full history)";
                    isWaitingForShowMore = true;
                }

                await TypeMessageAsync("BreachByte: ", logMessage, System.Windows.Media.Brushes.LightGreen);
                return;
            }

            // Handles the "show more" follow-up for the activity log
            else if (userInput == "show more" && isWaitingForShowMore == true)
            {
                isWaitingForShowMore = false;

                string logMessage = "Here is my complete activity history:\n\n";
                for (int i = 0; i < activityLog.Count; i++)
                    logMessage += $"{i + 1}. {activityLog[i]}\n";

                await TypeMessageAsync("BreachByte: ", logMessage, System.Windows.Media.Brushes.LightGreen);
                return;
            }

            // ==========================================
            // NLP TASK ENGINE
            // ==========================================

            // Matches natural language task commands e.g. "create a task to update my password"
            else if (Regex.IsMatch(userInput, @"(?i)(?:add|create|make|set)\s+(?:a\s+)?(?:new\s+)?(?:task|to-do)"))
            {
                Match match = Regex.Match(userInput, @"(?i)(?:add|create|make|set)\s+(?:a\s+)?(?:new\s+)?(?:task|to-do)(?:\s+for\s+me)?(?:\s+to)?\s*(.*)");

                if (match.Success)
                {
                    string extractedTask = match.Groups[1].Value.Trim();

                    // If the user said "add a task" without specifying what it is
                    if (string.IsNullOrEmpty(extractedTask))
                    {
                        await TypeMessageAsync("BreachByte: ", "I can certainly add a task for you! What would you like the task to be?", System.Windows.Media.Brushes.LightGreen);
                        return;
                    }

                    userTasks.Add(extractedTask);
                    LogActivity($"Task added: '{extractedTask}'");
                    isWaitingForReminder = true;

                    await TypeMessageAsync("BreachByte: ", $"Task added: '{extractedTask}'. Would you like to set a reminder for this?", System.Windows.Media.Brushes.LightGreen);
                }
                return;
            }

            // ==========================================
            // NORMAL CHATBOT LOGIC
            // ==========================================

            else
            {
                string botAnswer = myBot.GetBotResponse(userInput);

                // Log the topic if the brain triggered one
                if (myBot.TopicJustTriggered != "")
                    LogActivity($"Provided NLP information on: {myBot.TopicJustTriggered}");

                await TypeMessageAsync("BreachByte: ", botAnswer, System.Windows.Media.Brushes.LightGreen);
            }

            // Exit logic — shut down the app after the goodbye message
            if (userInput == "exit" || userInput == "quit" || userInput.Contains("bye"))
            {
                await Task.Delay(2000);
                System.Windows.Application.Current.Shutdown();
            }

            ChatScrollViewer.ScrollToEnd();
        }

        // ==========================================
        // TYPING EFFECT
        // ==========================================

        // Renders the bot's response character by character with a typing animation.
        // Bolds the user's name whenever it appears in the message.
        private async Task TypeMessageAsync(string prefix, string message, SolidColorBrush textColor)
        {
            TextBlock botMsg = new TextBlock();
            botMsg.Foreground = textColor;
            botMsg.TextWrapping = TextWrapping.Wrap;
            botMsg.Margin = new Thickness(0, 5, 0, 15);
            botMsg.FontFamily = new System.Windows.Media.FontFamily("Consolas");

            ChatHistoryPanel.Children.Add(botMsg);

            // Add the "BreachByte: " prefix
            botMsg.Inlines.Add(new Run(prefix));

            string userName = myBot.SavedUserName;

            // Start typing into a regular Run
            Run currentRun = new Run();
            botMsg.Inlines.Add(currentRun);

            for (int i = 0; i < message.Length; i++)
            {
                // Check if the upcoming characters match the user's name
                if (userName.Length > 0 && i + userName.Length <= message.Length &&
                    message.Substring(i, userName.Length).Equals(userName, StringComparison.OrdinalIgnoreCase))
                {
                    // Type the name in bold white
                    Run boldName = new Run();
                    boldName.FontWeight = FontWeights.Bold;
                    boldName.Foreground = System.Windows.Media.Brushes.White;
                    botMsg.Inlines.Add(boldName);

                    for (int j = 0; j < userName.Length; j++)
                    {
                        boldName.Text += message[i];
                        i++;
                        await Task.Delay(15); // (Microsoft, 2025)
                    }
                    i--; // Adjust index as the outer loop will increment it

                    // Resume typing in a regular Run
                    currentRun = new Run();
                    botMsg.Inlines.Add(currentRun);
                }
                else
                {
                    currentRun.Text += message[i];
                    await Task.Delay(15);
                }

                ChatScrollViewer.ScrollToEnd();
            }
        }

        // ==========================================
        // BUTTON & INPUT EVENT HANDLERS
        // ==========================================

        private void SendButton_Click(object sender, RoutedEventArgs e) // (Microsoft, 2025)
        {
            ProcessMessage();
        }

        private void UserInputBox_KeyDown(object sender, KeyEventArgs e) // (Microsoft, 2025) and (Microsoft, n.d.)
        {
            // Trigger send when the user presses Enter
            if (e.Key == System.Windows.Input.Key.Enter)
                ProcessMessage();
        }

        private void BtnRefreshTasks_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadTasks();
        }

        private void BtnAddTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Open the Add Task popup, centred over the main window
            AddTaskWindow addTaskPopup = new AddTaskWindow();
            addTaskPopup.Owner = this;
            addTaskPopup.ShowDialog();

            // Refresh the DataGrid after the popup closes
            LoadTasks();
        }

        private void BtnToggleStatus_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a task from the list to update.", "System Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DataRowView row = (DataRowView)TasksDataGrid.SelectedItem;
            int taskId = Convert.ToInt32(row["task_id"]);
            bool currentStatus = Convert.ToBoolean(row["is_completed"]);

            // Flip the completion status
            bool newStatus = !currentStatus;

            DatabaseHelper db = new DatabaseHelper();
            if (db.OpenConnection())
            {
                try
                {
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
                    LoadTasks();
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

            // Ask for confirmation before permanently deleting
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

        // ==========================================
        // QUICK ACCESS NAVIGATION BAR
        // ==========================================

        private void BtnNavQuiz_Click(object sender, RoutedEventArgs e)
        {
            UserInputBox.Text = "start game";
            SendButton_Click(null, null);
        }

        private void BtnNavTopics_Click(object sender, RoutedEventArgs e)
        {
            UserInputBox.Text = "what can i ask";
            SendButton_Click(null, null);
        }

        private void BtnNavLog_Click(object sender, RoutedEventArgs e)
        {
            UserInputBox.Text = "show activity log";
            SendButton_Click(null, null);
        }
    }
}