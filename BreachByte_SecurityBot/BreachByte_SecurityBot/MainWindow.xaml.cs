using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                // If the audio fails, the app just silently ignores it and keeps working
            }

            TextBlock welcomeText = new TextBlock();
            welcomeText.Text = "BreachByte: Welcome! How are you? What's your name?";
            welcomeText.Foreground = System.Windows.Media.Brushes.LightGreen;
            welcomeText.Margin = new Thickness(0, 5, 0, 15);
            ChatHistoryPanel.Children.Add(welcomeText);

        }

        private void ProcessMessage()
        {
            string userInput = UserInputBox.Text;
            if (string.IsNullOrWhiteSpace(userInput)) return;

            //Show user message
            TextBlock userText = new TextBlock();
            userText.Text = $"{myBot.SavedUserName}: {userInput}";
            userText.Foreground = System.Windows.Media.Brushes.Cyan; // Makes your text Cyan!
            userText.Margin = new Thickness(0, 5, 0, 5);
            userText.TextWrapping = TextWrapping.Wrap;

            // Add the UI element to the panel, and scroll down
            ChatHistoryPanel.Children.Add(userText);
           ChatScrollViewer.ScrollToEnd(); 

            //Ask the BotBrain for an answer
            string botAnswer = myBot.GetBotResponse(userInput);

            //Show the bot's answer
            TextBlock botText = new TextBlock();
            botText.Text = $"BreachByte: {botAnswer}";
            botText.Foreground = System.Windows.Media.Brushes.LightGreen;
            botText.Margin = new Thickness(0, 5, 0, 15);
            botText.TextWrapping = TextWrapping.Wrap;
            ChatHistoryPanel.Children.Add(botText);
           

            //Cleanup
            UserInputBox.Clear();
            ChatScrollViewer.ScrollToEnd();
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessMessage();
        }

        private void UserInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the user pressed the 'Enter' key on their keyboard
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ProcessMessage();
            }
        }
    }
}
