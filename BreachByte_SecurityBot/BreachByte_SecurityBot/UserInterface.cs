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
            //(Gillespie. P, n.d)

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
        public void TypingEffect(string message, int delay = 30) //(fe02x, 2014)
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
            //(Gillespie. P, n.d)

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

/*  Reference List
 *  fe02x, 2014. How to make text be "typed out" in console application?.[Online] Available at: <https://stackoverflow.com/questions/25337336/how-to-make-text-be-typed-out-in-console-application > [Accessed 25 March 2026].
 *  Gillespie. P, n.d. Text to ASCII Art Generator (TAAG). [Online]. Available at: <https://patorjk.com/software/taag/#p=display&f=Cybermedium&t=BreachByte%0ASecurity+Bot&x=none&v=4&h=4&w=80&we=false> 
 *  & Available at:<https://patorjk.com/software/taag/#p=display&f=Soft&t=I%27m+here+to+assist+you+%3A%29&x=none&v=4&h=4&w=80&we=false> [Accessed 23 March 2026].












*/