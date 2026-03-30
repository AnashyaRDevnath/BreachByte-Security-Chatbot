namespace BreachByte_SecurityBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //For app to display to emojis
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //https://stackoverflow.com/questions/67508469/how-to-show-emoji-in-c-sharp-console-output miken32


            //Voice greeting
           AudioPlayer audio = new AudioPlayer();
            audio.PlayVoiceGreeting ();

            //Ascii logo
            UserInterface logo = new UserInterface();
            logo.DisplayLogo();
            string name =logo.WelcomeUser(); //reference 

            //response system
            BotBrain convo = new BotBrain();
            convo.Conversation(name);

        }
    }
}
