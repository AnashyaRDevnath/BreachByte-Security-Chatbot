
namespace BreachByte_SecurityBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            
            //Voice greeting
            ui.VoiceGreeting();
           
            //Ascii Logo
            ui.DisplayLogo();
            string name = ui.WelcomeUser(); //reference 

            //response system
            BotBrain convo = new BotBrain();
            convo.Conversation(name);

            //For app to display to emojis
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //https://stackoverflow.com/questions/67508469/how-to-show-emoji-in-c-sharp-console-output miken32


        }
    }
}
