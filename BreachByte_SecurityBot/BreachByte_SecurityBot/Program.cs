
namespace BreachByte_SecurityBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            //For app to display to emojis
            Console.OutputEncoding = System.Text.Encoding.UTF8; //(miken32, 2024)

            UserInterface ui = new UserInterface();
            
            //Voice greeting
            ui.VoiceGreeting();
           
            //Ascii Logo
            ui.DisplayLogo();
            string name = ui.WelcomeUser(); //reference 

            //response system
            BotBrain convo = new BotBrain();
            convo.Conversation(name);
           

           


        }
    }
}

/* Reference list
 * Miken32, 2024. How to show emoji in c# console output? [Online]. Available at:<https://stackoverflow.com/questions/67508469/how-to-show-emoji-in-c-sharp-console-output> [Accessed 30 March 2026].
*/