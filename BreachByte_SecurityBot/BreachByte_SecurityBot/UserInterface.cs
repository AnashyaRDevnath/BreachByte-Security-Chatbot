using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BreachByte_SecurityBot
{
    internal class UserInterface
    {
        /*
       SET Valid_Name to FALSE
    WHILE Valid_Name is FALSE
        DISPLAY "What is your name?"
        GET User_Input
        
        IF User_Input is EMPTY
            SET Text_Color to Red
            DISPLAY "Oops! You didn't type anything. Let's try again."
        ELSE
            SET Valid_Name to TRUE
            Save User_Input as PlayerName
        END IF
    END WHILE

    CALL TYPING_EFFECT method to DISPLAY "It is great to meet you, " + PlayerName + "!"
END METHOD

METHOD TYPING_EFFECT (Give this method a Sentence)
    FOR EACH Letter IN Sentence
        PRINT Letter to screen
        WAIT a few milliseconds
    END FOR
    MOVE to the next line
END METHOD
         */

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

            Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            Console.WriteLine(logo);
            Console.ResetColor();

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
            Console.ForegroundColor = ConsoleColor.Magenta;
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

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(welcome);
            Console.ResetColor( );

            return userName;

        }

       

    }
}