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
        //Instantiate BotBrain
        private BotBrain myBot;

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            myBot = new BotBrain();

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

        //Added async so the app can wait between letters
        private async void ProcessMessage()
        {
            string userInput = UserInputBox.Text;

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
            userText.Foreground = System.Windows.Media.Brushes.Cyan; // Makes your text Cyan!
            userText.Margin = new Thickness(0, 5, 0, 5);
            userText.TextWrapping = TextWrapping.Wrap;

            //Add the UI element to the panel, and scroll down
            ChatHistoryPanel.Children.Add(userText);
            ChatScrollViewer.ScrollToEnd();

            //Ask the BotBrain for an answer
            string botAnswer = myBot.GetBotResponse(userInput);

            //Show the bot's answer (call typing method)
            await TypeMessageAsync("BreachByte: ", botAnswer, System.Windows.Media.Brushes.LightGreen);

            
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
    }
}
