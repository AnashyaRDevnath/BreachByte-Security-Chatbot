namespace BreachByte_SecurityBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* ---PSEUDO CODE---
               CALL UserInterface to START_GREETING
              CALL BotBrain to START_CONVERSATION_LOOP
              END PROGRAM
            
             */

            //Voice greeting
            AudioPlayer audio = new AudioPlayer();
            audio.PlayVoiceGreeting ();

            //Ascii logo
            UserInterface logo = new UserInterface();
            logo.DisplayLogo();
            Console.ReadLine();

        }
    }
}
