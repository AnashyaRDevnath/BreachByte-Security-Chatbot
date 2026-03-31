using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Threading;
using System.Media;

namespace BreachByte_SecurityBot
{
    public class UserInterface
    {
      

        //Display ascii art logo
        public void DisplayLogo()
        {
           

            string logo = """



                              ------------------------
                            .                          .
                           /                            \
                          /                              \
                         |                                |
                         |                                |
                         |                                |
           --------------------------------------------------------- 
        .                                                               .
       |       ___  ____ ____ ____ ____ _  _ ___  _   _ ___ ____         |
       |       |__] |__/ |___ |__| |    |__| |__]  \_/   |  |___         |
       |       |__] |  \ |___ |  | |___ |  | |__]   |    |  |___         |
       |                                                                 |
       |       ____ ____ ____ _  _ ____ _ ___ _   _    ___  ____ ___     |
       |       [__  |___ |    |  | |__/ |  |   \_/     |__] |  |  |      |
       |       ___] |___ |___ |__| |  \ |  |    |      |__] |__|  |      |
       |                                                                 |
       |                                                                 |
       '---------------------------------------------------------------'
    """;

            Console.ForegroundColor = ConsoleColor.DarkCyan; 
            Console.WriteLine(logo);
            Console.ResetColor();

        }

        //Voice greeting
        public void VoiceGreeting()
        {
            try
            {
                SoundPlayer audio = new SoundPlayer("VoiceGreeting.wav");
                audio.PlaySync();
            }
            catch (Exception)
            {

            }
           
        }

        //Typing effect
        //cite stack overflow: https://stackoverflow.com/questions/25337336/how-to-make-text-be-typed-out-in-console-application 
        //fe02x- author
        public void TypingEffect(string message, int delay = 30)
        {
            foreach (var character in message)
            {

                Console.Write(character);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public string WelcomeUser()
        {

            TypingEffect("Hello, what's your name? ");
                string userName = Console.ReadLine();

            Console.WriteLine();

            //border
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(new string('=', 65)); //top border

           
            String line1 = $"Welcome to the BreachByte Security Bot {userName}! ";
              string line2 = "This is a cybersecurity awareness chatbot.";

            Console.WriteLine($"= {line1.PadRight(61)} =");
            Console.WriteLine($"= {line2.PadRight(61)} =");

            // 4. Bottom Border
            Console.WriteLine(new string('=', 65));

            Console.ResetColor();
            Console.WriteLine("\n");



            string welcome = @"

                                                                                                                                                            
,--.,--.              ,--.                                ,--.                                   ,--.        ,--.                                     ,-.   
|  ||  |,--,--,--.    |  ,---.  ,---. ,--.--. ,---.     ,-'  '-. ,---.      ,--,--. ,---.  ,---. `--' ,---.,-'  '-.    ,--. ,--.,---. ,--.,--.    .--.'. \  
|  |`-' |        |    |  .-.  || .-. :|  .--'| .-. :    '-.  .-'| .-. |    ' ,-.  |(  .-' (  .-' ,--.(  .-''-.  .-'     \  '  /| .-. ||  ||  |    '--' |  | 
|  |    |  |  |  |    |  | |  |\   --.|  |   \   --.      |  |  ' '-' '    \ '-'  |.-'  `).-'  `)|  |.-'  `) |  |        \   ' ' '-' ''  ''  '    .--. |  | 
`--'    `--`--`--'    `--' `--' `----'`--'    `----'      `--'   `---'      `--`--'`----' `----' `--'`----'  `--'      .-'  /   `---'  `----'     '--'.' /  
                                                                                                                       `---'                          `-'   


";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(welcome);
            Console.ResetColor( );

            return userName;

        }

        //Enhanced console ui with visual elements 

        //Divider
        public void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        //section headers
        public void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine($"   {title.ToUpper()}   ");
            Console.WriteLine("==================================================\n");
            Console.ResetColor();
        }



    }
}