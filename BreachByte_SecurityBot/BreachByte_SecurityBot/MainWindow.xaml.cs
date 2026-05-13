using System.Windows;
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

            ChatHistoryBox.Items.Add("Welcome! How are you? What's your name? ");

        }

        private void ProcessMessage()
        {
            string userInput = UserInputBox.Text;
            if (string.IsNullOrWhiteSpace(userInput)) return;

            // 1. Show user message
            ChatHistoryBox.Items.Add($"{myBot.SavedUserName}: {userInput}");

            // 2. Ask the BotBrain for an answer
            string botAnswer = myBot.GetBotResponse(userInput);

            // 3. Show the bot's answer
            ChatHistoryBox.Items.Add($"BreachByte: {botAnswer}");

            // 4. Cleanup
            UserInputBox.Clear();
            ChatHistoryBox.ScrollIntoView(ChatHistoryBox.Items[ChatHistoryBox.Items.Count - 1]);
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
