using System;
using System.Collections.Generic;
using System.Text;

namespace BreachByte_SecurityBot
{
    internal class BotBrain
    {
        /*
        METHOD START_CONVERSATION_LOOP
    SET Chat_Active to TRUE
    
    WHILE Chat_Active is TRUE
        DISPLAY "-----------------------------------"
        DISPLAY "What would you like to ask me? (Type 'exit' to quit)"
        GET User_Question
        
        IF User_Question is EMPTY
            DISPLAY "I didn't hear anything. Please type a question."
        
        ELSE IF User_Question contains "how are you"
            DISPLAY "I'm just a bunch of code, but I'm doing great!"
            
        ELSE IF User_Question contains "purpose"
            DISPLAY "I am here to teach you about safe passwords and phishing!"
            
        ELSE IF User_Question contains "password"
            DISPLAY "Always use a mix of letters, numbers, and symbols for passwords."
            
        ELSE IF User_Question contains "exit"
            DISPLAY "Stay safe out there! Goodbye!"
            SET Chat_Active to FALSE
            
        ELSE
            DISPLAY "I didn't quite understand that. Could you rephrase?"
        END IF
    END WHILE
END METHOD
         */
    }
}
