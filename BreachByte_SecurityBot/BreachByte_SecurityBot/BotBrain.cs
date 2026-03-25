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

        public void Conversation(string userName)
        {
            bool isActive = true;
            //site yt video for emoji: https://www.youtube.com/watch?v=hKeKLxvU9Ew 
            Console.WriteLine($"How can i help you today {userName} ? If you wish to end our conversation, type 'exit'. 😊");

            while (isActive)
            {
                //get users response
                Console.Write($"{userName}:");
                string input = Console.ReadLine().ToLower();

                //bots response system
                if (input.Contains("how are you"))
                {
                    Console.WriteLine("I'm doing great today, thanks for asking 😄. How are you? ");
                    Console.WriteLine();

                }
                else if (input.Contains("purpose"))
                {
                    Console.WriteLine("My purpose is to educate you on cybersecurity topics, such as if you encounter cyber threats and provide guidance on avoiding common traps.");
                    Console.WriteLine() ;

                }
                else if (input.Contains("ask you about") || input.Contains("what can i ask"))
                {
                    Console.WriteLine("You can ask me for tips and guidance on password safety, phishing, banking scams, malware and ransomware," +
                        "\nidentity theft, and suspicious links.");
                    Console.WriteLine();

                }
                else if (input.Contains("password"))
                {
                    Console.WriteLine("Passwords, huh? Having a strong one is crucial, even though we all have far too many to remember these days. Here are some golden safety tips: ");
                    Console.WriteLine();
                    Console.WriteLine("1. Make passwords a minimum of 10 characters. " +
                                      "\n2. Dont use real words" +
                                      "\n3. Don't use obvious information" +
                                      "\n4. Use a different password for every account" +
                                      "\n5. Consider a password manager" +
                                      "\n6. Use two-factor authentication" +
                                      "\n7. Don't enter passwords on public Wi-Fi" +
                                      "\n8. See ig your passwords have been compromised");
                    Console.WriteLine();
                    Console.WriteLine($"I hope that helped {userName}, let me know if you would like me to go into more detail 😊. Type 'details' if so." );
                    Console.WriteLine();

                    //cite https://www.fmins.com/blog/password-safety-tips/

                }
                else if (input.Contains("details"))
                {
                    Console.WriteLine("I'm so glad you want to know more! To further explain those 8 tips:" +
                        "1. Basically, the longer the password the stronger it is. Aim for at least 10 characters and use passphrases " +
                        "mixed with symbols and numbers instead of single words. For example: I3eF!$h!ng_" +
                       "\n2. Try to avoid words found in the dictionary or simple sequencee (like 123 or ABC). Random combinations are much harded for hackers to guess!" +
                       "\n3. Never include names, birthdays, phone numbers or addresses. You're making it too easy for attackers😅" +
                       "\n4. If a hacker cracks one account, you dont want them getting the keys to all your other accounts. Try to switch it up abit." +
                       "\n5. Use tools like your broswers built in manager to securely generate and remember your complex passwords for you." +
                       "\n6. 2FA may be an extra step but it adds a massive extra layer of security. It requires a unique code sent to your phone when logging in." +
                       "\n7. As good as the free public Wi-fi is, don't type in passwords there. Hackers on the same networl can easily intercept your data." +
                       "\n8. Use sites like 'Have I Been Pwned' to check if your accounts were leaked in a data breach. If they were, chamge those passwords immediately!" +
                       $"\n I hope this clarified things better for you {userName}😊");
                    Console.WriteLine();

                } 
                else if(input.Contains("phishing"))
                {
                    Console.WriteLine($"Oh dont get me started on phishing🙄 {userName}. I see those fake package delivery emails all the time. It is crazy how real they can look these days!" +
                        "Here is everything you need to know to stay ahead of those sneaky attacks: ");
                   
                    Console.WriteLine("\nPhishing is a social engineering cyberattack where criminals use emails, texts, or direct messages to steal sensitive data (like login credentials and financial info) " +
                        "\nor distribute malware. The attacker masquerades as a trusted entity-like a bank or a CEO-and uses urgency or fear to trick the victim into clicking a malicious link or downloading an infected attachment.");

                    Console.WriteLine("\nNow that you understand what phishing is, lets move on to the common types of phishing attacks.");

                    Console.WriteLine("\nCybercriminals use several specialized tactics depending on their target:\nSpear Phishing: Highly targeted attacks customized with the victim's specific personal or professional details." +
                        "\nWhaling: A variant of spear phishing targeting high-level executives (the 'whales') to access highly sensitive corporate data." +
                        "\nVishing & Angler Phishing: Phishing done over voice calls (Vishing) or via direct messages on social media platforms (Angler)." +
                        "\nBusiness Email Compromise (BEC): Impersonating senior executives to trick employees into wiring money to fraudulent accounts." +
                        "\nClone Phishing & Quishing: Replicating legitimate emails exactly but swapping the safe links for malicious ones, or using malicious QR codes (Quishing) to redirect victims to fake sites.");

                    Console.WriteLine($"\nThis is where i need you to focus {userName}, it's how to identify those red flags of what could be a phishing attempt.");

                    Console.WriteLine("\nYou should treat every unexpected email with caution. Look out for these common warning signs:" +
                        "\nSuspicious Sender Addresses: The 'From' address might have slight misspellings or use a domain that doesn't match the actual company" +
                        "\nFalse Urgency: Messages claiming your account will be suspended immediately if you don't click a link. " +
                        "\nPoor Grammar and Formatting: Legitimate corporate communications rarely have spelling errors or bizarre formatting." +
                        "\nGeneric Greetings: Using \"Dear Customer\" instead of your actual name." +
                        "\nHidden URLs: Hovering your mouse over a link reveals a strange or unfamiliar web address that does not match the trusted company.");

                    Console.WriteLine("\nI saved the best part for last; how to protect against phishing.") ;

                    Console.WriteLine("\nYou can significantly mitigate risks by adopting a combination of strategies: " +
                        "\nImplementing Multi-Factor Authentication (MFA) to prevent unauthorized account access; " +
                        "\nEmploying robust technical safeguards such as updated spam and web filters; " +
                        "\nEnsuring that data is encrypted and backed up to protect against ransomware from phishing attacks; " +
                        "\nand promoting employee vigilance through training to recognize and verify suspicious requests and avoid untrusted links or attachments.");

                    Console.WriteLine("I know that was alot of information to take in, but these scammers are becoming really believable and its important you stay safe." +
                        "\nDont worry about memorizing all of that at once! Just remember my golden rule: 'When in doubt, don't click the link' 😅");

                }



            }
        }

    }
}
