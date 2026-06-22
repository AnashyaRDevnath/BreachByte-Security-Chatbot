using System;
using System.Collections.Generic;
using System.Media;
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
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private List<CyberQuestions> questions;
        private int currentScore = 0;
        private int currentQuestionIndex = 0;

        private System.Windows.Media.MediaPlayer correctSoundPlayer = new System.Windows.Media.MediaPlayer();
        private System.Windows.Media.MediaPlayer wrongSoundPlayer = new System.Windows.Media.MediaPlayer();
        
        // This holds the final score 
        public int FinalScore => currentScore;

        // Tell it to accept the username from the chat
        public QuizWindow(string userName)
        {
            InitializeComponent();

            // Personalize the window title with the user's name!
            this.Title = $"Cybersecurity Training Simulator - Agent {userName}";

            LoadQuestions();
            DisplayQuestion();
        }
        public QuizWindow()
        {
            InitializeComponent();

            string correctPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Sounds", "correct.mp3");
            correctSoundPlayer.Open(new Uri(correctPath));

            string wrongPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Sounds", "wrong.mp3");
            wrongSoundPlayer.Open(new Uri(wrongPath));
          
            LoadQuestions();
            DisplayQuestion();
        }
        private void LoadQuestions()
        {
            questions = new List<CyberQuestions>
            {
                new CyberQuestions("According to BreachByte, what is the recommended minimum length for a strong password?",
                    new List<string>{ "6 characters", "8 characters", "10 characters", "15 characters" },
                    "10 characters",
                    "Correct! Aim for at least 10 characters and use passphrases mixed with symbols and numbers instead of single words.", QuestionType.MultipleChoice),

                new CyberQuestions("You can use the website 'Have I Been _____' to check if your accounts were leaked in a data breach.",
                    null, "Pwned",
                    "Correct! If your accounts were leaked on 'Have I Been Pwned', change those passwords immediately!", QuestionType.FillInTheBlank),

                new CyberQuestions("True or False: 'Whaling' is a type of phishing attack specifically aimed at high-level executives.",
                    new List<string>{ "True", "False" },
                    "True",
                    "Correct! Whaling is aimed at high-level executives to access sensitive data or divert funds.", QuestionType.TrueFalse),

                new CyberQuestions("Malicious SMS messages that trick victims into clicking links to capture sensitive data are known as _____.",
                    null, "Smishing",
                    "Correct! Smishing uses text messages to trick you into downloading malware or giving up credentials.", QuestionType.FillInTheBlank),

                new CyberQuestions("True or False: It is completely safe to enter sensitive information on websites as long as the URL starts with 'http'.",
                    new List<string>{ "True", "False" },
                    "False",
                    "Correct! To enhance online safety, utilize trusted websites ensuring URLs begin with 'https' before entering sensitive information.", QuestionType.TrueFalse),

                new CyberQuestions("What is the safest way to close an unexpected, suspicious pop-up window?",
                    new List<string>{ "Click the 'X' in the corner", "Click 'No thanks' inside the window", "Use the 'alt + F4' keyboard shortcut", "Restart your computer" },
                    "Use the 'alt + F4' keyboard shortcut",
                    "Correct! Refrain from interacting with pop-ups directly, using 'alt + F4' instead of clicking their close buttons.", QuestionType.MultipleChoice),

                new CyberQuestions("If a scammer calls you pretending to be a bank representative to steal login credentials, this is called:",
                    new List<string>{ "Phishing", "Vishing", "Quishing", "Clone Phishing" },
                    "Vishing",
                    "Correct! Vishing utilizes voice calls to impersonate entities like banks.", QuestionType.MultipleChoice),

                new CyberQuestions("The most dangerous type of malware that encrypts an organization's files and demands payment to restore access is called _____.",
                    null, "Ransomware",
                    "Correct! Ransomware holds data hostage until you pay to get it back.", QuestionType.FillInTheBlank),

                new CyberQuestions("What is your number one defense against a ransomware attack?",
                    new List<string>{ "Paying the ransom quickly", "Having an offline and cloud backup", "Only using public Wi-Fi", "Ignoring system updates" },
                    "Having an offline and cloud backup",
                    "Correct! Back up everything. If hackers lock your computer, you can wipe it and restore your files.", QuestionType.MultipleChoice),

                new CyberQuestions("True or False: Identity thieves only operate online, so physical printed documents thrown in the dustbin are safe.",
                    new List<string>{ "True", "False" },
                    "False",
                    "Correct! Thieves can simply steal mail from your dustbin. Don't throw old accounts away without first destroying them.", QuestionType.TrueFalse),

                new CyberQuestions("The golden rule when receiving a suspicious email or text is: 'When in doubt, don't click the _____'.",
                    null, "link",
                    "Correct! Think before you click! Avoiding suspicious links is a key step in mitigating risks.", QuestionType.FillInTheBlank)
            };
        }

        private void DisplayQuestion()
        {
            FeedbackTextBlock.Visibility = Visibility.Collapsed;
            NextButton.Visibility = Visibility.Collapsed;
            AnswersPanel.Children.Clear();

            if (currentQuestionIndex >= questions.Count)
            {
                EndGame();
                return;
            }

            CyberQuestions q = questions[currentQuestionIndex];
            QuestionTextBlock.Text = $"Question {currentQuestionIndex + 1} of {questions.Count}:\n\n{q.QuestionText}";
            ScoreText.Text = $"Score: {currentScore} / {questions.Count}";

            if (q.Type == QuestionType.MultipleChoice || q.Type == QuestionType.TrueFalse)
            {
                foreach (string option in q.Options)
                {
                    Button btn = new Button
                    {
                        Content = option,
                        Margin = new Thickness(0, 5, 0, 5),
                        Padding = new Thickness(10),
                        Background = Brushes.DarkSlateBlue,
                        Foreground = Brushes.White,
                        FontWeight = FontWeights.Bold
                    };
                    btn.Click += (s, e) => CheckAnswer(option);
                    AnswersPanel.Children.Add(btn);
                }
            }
            else if (q.Type == QuestionType.FillInTheBlank)
            {
                TextBox answerBox = new TextBox
                {
                    Margin = new Thickness(0, 5, 0, 10),
                    Padding = new Thickness(5),
                    FontSize = 16,
                    Background = Brushes.White,
                    Foreground = Brushes.Black,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 250
                };

                Button submitBtn = new Button
                {
                    Content = "SUBMIT ANSWER",
                    Padding = new Thickness(10),
                    Background = Brushes.DarkCyan,
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 150
                };
                submitBtn.Click += (s, e) => CheckAnswer(answerBox.Text.Trim());

                AnswersPanel.Children.Add(answerBox);
                AnswersPanel.Children.Add(submitBtn);
            }
        }

        private void CheckAnswer(string userResponse)
        {
            CyberQuestions q = questions[currentQuestionIndex];

            if (userResponse.Equals(q.CorrectAnswer, StringComparison.OrdinalIgnoreCase))
            {
                currentScore++;

                correctSoundPlayer.Stop();
                correctSoundPlayer.Play();

                string cleanExplanation = q.Explanation.Replace("Correct! ", "");
                FeedbackTextBlock.Text = "✔️ " + cleanExplanation;
                FeedbackTextBlock.Foreground = Brushes.LimeGreen;

            }
            else
            {
                wrongSoundPlayer.Stop();
                wrongSoundPlayer.Play();

                string cleanExplanation = q.Explanation.Replace("Correct! ", "");
                FeedbackTextBlock.Text = $"❌ Incorrect! The correct answer was: {q.CorrectAnswer}\n\n{cleanExplanation}";
                FeedbackTextBlock.Foreground = Brushes.Red;
            }

            AnswersPanel.Children.Clear();
            FeedbackTextBlock.Visibility = Visibility.Visible;
            NextButton.Visibility = Visibility.Visible;
            ScoreText.Text = $"Score: {currentScore} / {questions.Count}";
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }

        private void EndGame()
        {
            

            QuestionTextBlock.Text = "QUIZ COMPLETE!";
            
            AnswersPanel.Children.Clear();
            NextButton.Visibility = Visibility.Collapsed;
            FeedbackTextBlock.Visibility = Visibility.Visible;
            FeedbackTextBlock.Foreground = Brushes.Cyan;

            double percentage = (double)currentScore / questions.Count * 100;
            string finalMessage = $"Final Score: {currentScore} / {questions.Count} ({percentage:0}%)\n\n";

            if (percentage == 100)
                finalMessage += "Perfect Score! You are a cybersecurity pro! 🏆";
            else if (percentage >= 70)
                finalMessage += "Great job! You have strong cybersecurity awareness! 🛡️";
            else
                finalMessage += "Keep learning to stay safe online! Review the topics to strengthen your defenses. 📖";

            FeedbackTextBlock.Text = finalMessage;

            Button closeBtn = new Button
            {
                Content = "CLOSE SIMULATOR",
                Margin = new Thickness(0, 20, 0, 0),
                Padding = new Thickness(10),
                Background = Brushes.DarkRed,
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold
            };
            closeBtn.Click += (s, e) => this.Close();
            AnswersPanel.Children.Add(closeBtn);
        }
    }
}
