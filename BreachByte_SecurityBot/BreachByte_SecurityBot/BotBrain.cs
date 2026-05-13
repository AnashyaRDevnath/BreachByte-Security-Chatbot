using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BreachByte_SecurityBot
{
    public class BotBrain
    { 
            //Declare the dictionary
        private Dictionary<string, string[]> knowledgeBase;  //while the key is a string, the value is an array of strings. A single text ket will map to a collection of multiple strings

        //The random number generator 
        private Random randomiser = new Random();

        

        //Constructor {fill dictionary here}
        public BotBrain()
        {
            //initialise dictionary
            knowledgeBase = new Dictionary<string, string[]>();

            //Password safety
            knowledgeBase.Add("password", new string[]
                {
            "Basically, the longer the password the stronger it is. Aim for at least 10 characters and use passphrases mixed with symbols and numbers instead of single words. For example: I3eF!$h!ng_",

            "Try to avoid words found in the dictionary or simple sequences (like 123 or ABC). Random combinations are much harder for hackers to guess!",

            "Never include names, birthdays, phone numbers or addresses. You're making it too easy for attackers😅",

            "If a hacker cracks one account, you don't want them getting the keys to all your other accounts.Try to switch it up a bit.",

            "Use tools like your browser's built-in manager to securely generate and remember complex passwords for you.",

            "2FA may be an extra step but it adds a massive extra layer of security.It requires a unique code sent to your phone when logging in.",

            "As good as the free public Wi-fi is, don't type in passwords there. Hackers on the same network can easily intercept your data.",

           "Use sites like 'Have I Been Pwned' to check if your accounts were leaked in a data breach. If they were, change those passwords immediately!" //Frankenmuth Insurance (2021)
        });

            //Phishing
            knowledgeBase.Add("phishing", new string[]
                {
            "Oh don't get me started on phishing🙄 [NAME]. I see those fake package delivery emails all the time!" +
            "To define it, phishing is a social engineering cyberattack where criminals use emails, texts, or direct messages to steal\n" +
            "sensitive data (like login credentials) and financial information or distribute malware. The attacker masquerades as a trusted \n" +
            "entity-like a bank or a CEO-and uses urgency or fear to trick the victim into clicking a malicious link or downloading an infected attachment. \n\n" + //(Fortinet, n.d)

           "If you'd like to hear about the types of attacks or how to spot them, just type attack)" });

            knowledgeBase.Add("attack", new string[]
            {
            " Cybercriminals employ various tactics tailored to their targets, including: Spear Phishing, which involves highly targeted attacks using personal details " +
            "Whaling, aimed at high-level executives to access sensitive data; Vishing and Angler Phishing, which utilize voice calls and social media messages, respectively " +
            "Business Email Compromise (BEC), where executives are impersonated to divert funds; and Clone Phishing and Quishing, where legitimate emails are replicated to" +
            "include malicious links or QR codes leading to fraudulent sites. You have to look out for red flags! Suspicious sender addresses, false urgency, poor grammar," +
            " and hidden URLs are classic signs of a phishing attack. Type 'protect' if you want to know how to stay safe."
            });

            knowledgeBase.Add("protect", new string[]
            {
            "I saved the best part for last, [NAME]! You can protect yourself by using Multi-Factor Authentication (MFA) and keeping your spam filters updated. And remember my golden rule: 'When in doubt, don't click the link' 😅",
            "Mitigating risks is key! Ensure your data is backed up to protect against ransomware, and always verify suspicious requests. Don't worry about memorizing it all, just remember: think before you click! 😅"
            });

            
            //Safe Browsing
            knowledgeBase.Add("safe browsing", new string[]
                {
            "There are hundreds of thousands of rogue or compromised websites on the internet.Therefore, it is essential that you take caution when using the internet.\n" +
            "To enhance online safety, utilize trusted websites with valid security certifications, ensuring URLs begin with 'https' before entering sensitive information.",
           
            "Be cautious of image source origins and adult websites, which often harbor security threats." ,
                
            "Exercise extreme caution when sharing personal information" ,
                       
            "Fequently clear browser cache, and avoid using download managers as they can introduce malware, " +
                       
            "Steer clear of downloads from unknown sites, safeguard passwords",
                        
            "Be wary of portable storage devices that may carry viruses. " ,
                       
            "Familiarize yourself with privacy policies to understand data sharing practices, and refrain from interacting with pop-ups, using 'alt + F4' instead of clicking close buttons." }); //(Massachusets College of Pharmacy and Health Sciences, n.d.)
                                                                                    

            //Other cybercrime topics
            knowledgeBase.Add("topics", new string[]
                {
            "Oh, I love a curious mind!\n" +
            "Let's dig deeper and level up your security knowledge." +
            "\nHere is the advanced stuff you can ask me about: banking scams, malware and ransomware and identity theft.\n\n" +

            "Type any of those names to get started " });

            //Banking scams
            knowledgeBase.Add("banking scams", new string[]
                {
            "Banking scams are unfortunately huge in South Africa { userName}, but at least this information will give you an upper hand 😁 " +
            "\nTo keep it simple cybercrimes in banking involve illegal activites that exploit technology to target financial institutions and their customers." +
            "There are several types of banking scams.", 
                        
            "Phishing: Fraudsters impersonate banks via emails, luring victims to fake websites to steal personal banking information " +
                        
            ":Vishing: Scammers place calls pretending to be bank representatives, soliciting sensitive login credentials under the guise of protecting accounts.  " ,
                       
            ".Smishing: Malicious SMS messages trick victims into clicking links or downloading malware that captures sensitive data. " ,
                        
            ".ATM card swapping: Criminals distract victims while swapping ATM cards and observing PIN entry to access accounts ",
                       
            ".Change of banking details: Fraudsters mislead victims into making payments to incorrect bank accounts, necessitating verification of recipient details" ,
                     
            ".Investment scams:  Scammers promote fraudulent high return investments, often disappearing once funds are sent." ,
            
            ".Loan scams: Scammers offer low interest loans that require upfront payment, vanishing after receiving the money. \n\n" ,

            "To safeguard against such scams, it's advisable to not enter credentials via links in emails, to never share OTPs, to verify investment companies" +
            "and to report any suspected fraud to their bank immediately. " }); //(StandardBank, n.d)


            //Malware and Ransomware
            knowledgeBase.Add("malware and ransomware", new string[]
                {
            "Any program that is used maliciously to damage systems is referred to as malware (malicious software). " ,
            
            "It intentionally harms computer systems. Many thieves aim to disrupt business and profit financially, while their motivations can vary." ,
           
            "The most prevalent and frequently most dangerous type of malware is ransomware. " ,
                
            "Ransomware typically entails hackers encrypting an organization's files to prevent access. After that, they demand payment to grant access to the data. In recent times, several forms of cyber extortion, such as information theft, have been referred to as ransomware." ,
                //(Ico, n.d)

            "As much as 'malware' and ransomware' sound like something out of a hacker movie, it's very much reality 😅. Type 'How do i protect my device?' to find out how you can" });

            knowledgeBase.Add("how do i protect my device", new string[]
                {
            "Back Up Everything (Offline & Cloud): This is your #1 defense against ransomware. If hackers lock your computer, you can just wipe it and restore your files from your backup." ,
                    
            "Keep Software Updated: Those annoying OS and app update pop-ups are crucial. They patch the exact security holes that malware uses to sneak in." ,
               
            "Use Reputable Antivirus: Have a trusted antivirus or anti-malware program running active scans in the background to catch threats before they execute." ,
            
            "Think Before You Download: Malware loves to hide in fake email attachments (like an invoice that is actually a .exe file) or pirated software. Never download from untrusted sources." ,
            
            "Beware of Random USB Drives: Never plug a found or untrusted USB stick into your computer. It is a classic hacker trick to spread malware directly onto a device. " }); //(Ico, n.d)

            //Identity Theft
            knowledgeBase.Add("identity theft", new string[]
                {
            "Your identity can be stolen in any number of ways. The syndicates can intercept banking transactions or hack into sites where you've made a cyber-purchase. " ,
                
            "Thieves can obtain information from your social media profiles; or they can simply steal mail from your postbox or your dustbin - if fact any document, printed or electronic that contains your name and any other person information about you puts you at risk of identity theft. " ,
            
            "There are steps consumers can take to better protect their personal information, as well as products that keep watch over their identity, even when they can't." ,
            
            "Ensure all your private correspondence stays private - lock your postbox; don't throw old accounts away without first destroying them; don't leave personal documents lying around where others could see them and protect your online identity." , //(TransUnion, n.d.)

            "The most important way to reduce the risk of online identity theft is to have a strong password." });
        }

        public string GetBotResponse(string utext)
        {
            //Clean up input
            string input = utext.ToLower().Trim();

            //Check if the exact word exists in dictionary
            foreach (var key in knowledgeBase.Keys)
            {
                if (input.Contains(key))
                {
                    string[] possibleAnswers = knowledgeBase[key];

                    // Pick a random number based on how many answers we have
                    int randomIndex = randomiser.Next(possibleAnswers.Length);

                    // Return that random answer!
                    return possibleAnswers[randomIndex];

                }
            }
            // Return default response
            return "I didnt't quite understand that. Could you please rephrase, or double check your spelling?";
        }
    }
}

        //main conversation loop
      /*  public void Conversation(string userName)
        {
            
            UserInterface ui = new UserInterface();
            bool isActive = true;
            ui.TypingEffect($"How can i help you today {userName}? If you would like to find out more type 'purpose', or to end our conversation type 'exit' or 'bye'. 😊"); //(CodeWith { Parveen Yadav }, 2023.)

            while (isActive)
            {
                //get users response 
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{userName}:");
                string input = Console.ReadLine().ToLower();
                Console.ResetColor();

                //bots response system

                if (input.Contains("how are you"))
                {
                    Console.WriteLine();
                    ui.TypingEffect("I'm doing great today, thanks for asking 😄. How are you?");
                    ui.PrintDivider();  
                }

                //Purpose
                else if (input.Contains("purpose"))
                {
                    Console.WriteLine();
                    ui.TypingEffect("\tMy purpose is to educate you on cybersecurity topics, such" +
                        " \n\tas if you encounter cyber threats and provide guidance on avoiding common traps. Type 'What can i ask' to know more.");
                    ui.PrintDivider();

                }

                //What can the user ask about
                else if (input.Contains("ask you about") || input.Contains("what can i ask") || input.Contains("ask") || input.Contains("what do you do"))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    ui.TypingEffect("\tYou can ask me for tips and guidance on either password safety, phishing and safe browsing." +
                        "\n\tIf you would like to know about other cybercrime topics as well, type 'topics' and we can get started :)");
                    ui.PrintDivider();

                }

                //If user is done
              /*  else if (input == "exit" || input == "quit" || input.Contains("bye"))
                {  
                    Console.WriteLine() ;
                    ui.TypingEffect($"\tStay safe out there in the digital world, {userName}! I hope our chat was helpful, goodbye!");
                    isActive = false;
                }

                //Input validation 

                //If user leaves response empty/blank or just presses the space bar
               /* else if (string.IsNullOrWhiteSpace(input)) //(Ohlando, 2015)
                
                {
                    Console.WriteLine();
                    ui.TypingEffect("\tOops! You didn't type anything.");
                    ui.TypingEffect("\tIf you arent sure what to ask, type 'What can i ask' to know more or type 'exit' if you're done 😊");
                    Console.WriteLine();
                }

                //If user responds with an unsupported query
                else
                {
                    Console.WriteLine();
                    ui.TypingEffect("I didnt quite understand that? Could you please rephrase, or double check your spelling?");
                    Console.WriteLine();
                }
           }
        
        
        
        }



    }
}

/* Reference List
 * 
 * CodeWith { Parveen Yadav }, 2023. Add emojis in VS code| Add emojis in Visual Studio | csharp | Dotnet | Dotnetcore | Javascript
 * [video online]. Available at:<https://www.youtube.com/watch?v=hKeKLxvU9Ew > [Accessed 25 March 2026].
 * 
 * 
 * Fortinet, n.d. What Is Phishing? [Online] Available at:<https://www.fortinet.com/resources/cyberglossary/phishing> [Accessed 25 March 2026].
 * 
 * 
 * Frankenmuth Insurance.,2021. 8 password safety tips. Frankenmuth Insurance blog, [blog] 21 October. 
 * Available at:<https://www.fmins.com/blog/password-safety-tips/> [Accessed 25 March 2026].
 * 
 * 
 * Ico, n.d. Malware and ransomware. [Online]. 
 * Available at: <https://ico.org.uk/about-the-ico/research-reports-impact-and-evaluation/research-and-reports/learning-from-the-mistakes-of-others-a-retrospective-review/malware-and-ransomware/> [Accessed 29 March 2026].
 * 
 * 
 * Massachusets College of Pharmacy and Health Sciences, n.d. Safe Browsing Principles. [Online].
 * Available at: <https://www.mcphs.edu/information-services/security/best-practices/safe-browsing-principles> [Accesssed 29 March 2026].
 * 
 * Ohlando, 2015. C# - How to handle empty user input? [Online]. Available at: <https://stackoverflow.com/questions/30654625/c-sharp-how-to-handle-empty-user-input> [Accessed 29 March 2026].
 * 
 * Standard Bank, n.d. Common scams in South African banking. [Online]. 
 * Available at <https://www.standardbank.co.za/southafrica/personal/about-us/financial-education/cybercrime-and-fraud/types-of-online-fraud> [Accessed 29 March 2026].
 * 
 * TransUnion, n.d. Protect you Identity today with TrueIdentity. [Online]. Available at:<https://www.transunion.co.za/education/identity-theft> [Accessed 29 March 2926].
 * 
 * */