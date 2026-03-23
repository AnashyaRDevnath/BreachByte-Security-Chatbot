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
        public void DisplayLogo ()
        {
            string logo = @"

                                                                                                                                                                                                                    
,-----.                         ,--.    ,-----.          ,--.             ,---.                         ,--. ,--.                                                                                                   
|  |) /_,--.--.,---. ,--,--.,---|  ,---.|  |) /,--. ,--,-'  '-.,---.     '   .-' ,---. ,---,--.,--,--.--`--,-'  '-,--. ,--.                                                                                         
|  .-.  |  .--| .-. ' ,-.  | .--|  .-.  |  .-.  \  '  /'-.  .-| .-. :    `.  `-.| .-. | .--|  ||  |  .--,--'-.  .-'\  '  /                                                                                          
|  '--' |  |  \   --\ '-'  \ `--|  | |  |  '--' /\   '   |  | \   --.    .-'    \   --\ `--'  ''  |  |  |  | |  |   \   '                                                                                           
`------'`--'   `----'`--`--'`---`--' `--`------.-'  /    `--'  `----'    `-----' `----'`---'`----'`--'  `--' `--' .-'  /                                                                                            
 ,-----.       ,--.                    ,---.   `---'                 ,--. ,--.                ,---.               `---'                                         ,-----,--.             ,--. ,--.          ,--.      
'  .--.,--. ,--|  |-. ,---.,--.--.    '   .-' ,---. ,---,--.,--,--.--`--,-'  '-,--. ,--.     /  O  \,--.   ,--.,--,--,--.--.,---.,--,--, ,---. ,---. ,---.     '  .--.|  ,---. ,--,--,-'  '-|  |-. ,---.,-'  '-.    
|  |    \  '  /| .-. | .-. |  .--'    `.  `-.| .-. | .--|  ||  |  .--,--'-.  .-'\  '  /     |  .-.  |  |.'.|  ' ,-.  |  .--| .-. |      | .-. (  .-'(  .-'     |  |   |  .-.  ' ,-.  '-.  .-| .-. | .-. '-.  .-'    
'  '--'\ \   ' | `-' \   --|  |       .-'    \   --\ `--'  ''  |  |  |  | |  |   \   '      |  | |  |   .'.   \ '-'  |  |  \   --|  ||  \   --.-'  `.-'  `)    '  '--'|  | |  \ '-'  | |  | | `-' ' '-' ' |  |      
 `-----.-'  /   `---' `----`--'       `-----' `----'`---'`----'`--'  `--' `--' .-'  /       `--' `--'--'   '--'`--`--`--'   `----`--''--'`----`----'`----'      `-----`--' `--'`--`--' `--'  `---' `---'  `--'      
       `---'                                                                   `---'                                                                                                                                
            

       ";

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine (logo);
            Console.ResetColor();

        }


    }
}
