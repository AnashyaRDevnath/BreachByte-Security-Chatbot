using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BreachByte_SecurityBot
{
    public class BotBrain
    {
        //Declare the dictionary
        private Dictionary<string, string> knowledgeBase;  //while the key is a string, the value is an array of strings. A single text ket will map to a collection of multiple strings
        
        //Constructor {fill dictionary here}
        public BotBrain()
        {
            //initialise dictionary
            knowledgeBase = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            //Password safety
            knowledgeBase.Add("password",
            "Passwords, huh? Having a strong one is crucial. In accordance to Frankenmuth Insurance (2021), here are some golden safety tips:\n" +
    "1. Make passwords a minimum of 10 characters.\n" +
    "2. Don't use real words.\n" +
    "3. Don't use obvious information.\n" +
    "4. Use a different password for every account.\n" +
    "5. Consider a password manager.\n" +
    "6. Use two-factor authentication.\n" +
    "7. Don't enter passwords on public Wi-Fi.\n" +
    "8. See if your passwords have been compromised.\n\n" +
    "(If you want to know more about any of these, just type 'tell me more'!)");

            //Phishing
            knowledgeBase.Add("phishing",
                    "Oh don't get me started on phishing. I see those fake package delivery emails all the time.\n" +//intro
            "It's crazy how real they can look these days!\n" +
            "Here is everything you need to know to stay ahead of those sneaky attacks: \n" +
            "To define it, phishing is a social engineering cyberattack where criminals use emails, texts, or direct messages to steal\n" +
            "sensitive data (like login credentials) and financial information or distribute malware. The attacker masquerades as a trusted \n" +
           "entity-like a bank or a CEO-and uses urgency or fear to trick the victim into clicking a malicious link or downloading an infected attachment. \n\n" + //(Fortinet, n.d)

           "If you'd like to hear about the types of attacks or how to spot them, just type 'tell me more'!)");

            //Safe Browsing
            knowledgeBase.Add("safe browsing",
     "There are hundreds of thousands of rogue or compromised websites on the internet.Therefore, it is essential that you take caution when using the internet.\n" +
                   "Use the following principles to help avoid infecting or compromising your device: " +
            " - Stay to well-known sites. Only trustworthy websites with valid security certifications." +
                             "\n- Watch out for certificate error messages. Make sure the site url begins with 'https' rather than http when entering sensitive information" +
                             "\n- When reviewing pictures in search engines, be wary of the site of where the picture is from. It could be malicious" +
                             "\n- Try to stay away from adult websites as much as you can. These websites are hotspots for security risks and harmful software like pop up advertising." +
                             "\n- When you're asked to provide personal information, such as card details, take extreme caution." +
                             "\n- It's advisable to clear your browser's cache often to free up hard drive space and reduce exposure" +
                             "\n- Take extreme caution when using download managers. As convenient as they are, they can also download malware in the background." +
                             "\n- Avoid downloading files from unknown sites" +
                             "\n- Don't disclose your password and sensitive information to anyone." +
                             "\n- Be wary when using portable storage devices. Viruses and malware may copy themselves onto the drive and infect your devices when plugged in." +
                             "\n- Stay aware of privacy policies so you understand if they share any data you provide." +
                             "\n- Don't click on any pop-ups. Don't even click on the 'x', use alt + F4 to close bad web pages.\n\n " + //(Massachusets College of Pharmacy and Health Sciences, n.d.)

            "That's alot to remember right? If you would like a summarised version type 'tell me more'!" );

            //Other cybercrime topics
            knowledgeBase.Add("topics",
                "Oh, I love a curious mind!\n" +
            "Let's dig deeper and level up your security knowledge." +
                 "\nHere is the advanced stuff you can ask me about: banking scams, malware and ransomware and identity theft.\n\n" +
          
                 "Type any of those names to get started ");

            //Banking scams
            knowledgeBase.Add("banking scams",
                "Banking scams are unfortunately huge in South Africa { userName}, but at least this information will give you an upper hand 😁 " +

                    "\nTo keep it simple cybercrimes in banking involve illegal activites that exploit technology to target financial institutions and their customers." +
                        "Common types of banking cybercrimes include: " +
                        "\n1.Phishing: Fraudsters impersonate banks via emails, luring victims to fake websites to steal personal banking information " +
                        "\n2:Vishing: Scammers place calls pretending to be bank representatives, soliciting sensitive login credentials under the guise of protecting accounts.  " +
                        "\n3.Smishing: Malicious SMS messages trick victims into clicking links or downloading malware that captures sensitive data. " +
                        "\n4.ATM card swapping: Criminals distract victims while swapping ATM cards and observing PIN entry to access accounts " +
                        "\n5.Change of banking details: Fraudsters mislead victims into making payments to incorrect bank accounts, necessitating verification of recipient details" +
                        "\n6.Investment scams:  Scammers promote fraudulent high return investments, often disappearing once funds are sent." +
                        "\n7.Loan scams: Scammers offer low interest loans that require upfront payment, vanishing after receiving the money. \n\n"+

            "To safeguard against such scams, it's advisable to not enter credentials via links in emails, to never share OTPs, to verify investment companies" +
                "and to report any suspected fraud to their bank immediately. "); //(StandardBank, n.d)

            //Malware and Ransomware
            knowledgeBase.Add("malware and ransomeware",
                "Any program that is used maliciously to damage systems is referred to as malware (malicious software). " +
                        "\nIt intentionally harms computer systems. Many thieves aim to disrupt business and profit financially, while their motivations can vary." +
            "\nThe most prevalent and frequently most dangerous type of malware is ransomware. " +
                "\nRansomware typically entails hackers encrypting an organization's files to prevent access. After that, they demand payment to grant" +
                "\naccess to the data. In recent times, several forms of cyber extortion, such as information theft, have been referred to as ransomware. \n\n " +
          

            "As much as 'malware' and ransomware' sound like something out of a hacker movie, it's very much reality 😅 \n\n" +

            "Here's how you can protect your device: "+
            "\n1. Back Up Everything (Offline & Cloud): This is your #1 defense against ransomware. If hackers lock your computer, you can just wipe it and restore your files from your backup." +
                     "\n2. Keep Software Updated: Those annoying OS and app update pop-ups are crucial. They patch the exact security holes that malware uses to sneak in." +
                     "\n3. Use Reputable Antivirus: Have a trusted antivirus or anti-malware program running active scans in the background to catch threats before they execute." +
                     "\n4. Think Before You Download: Malware loves to hide in fake email attachments (like an invoice that is actually a .exe file) or pirated software. Never download from untrusted sources." +
                     "\n5. Beware of Random USB Drives: Never plug a found or untrusted USB stick into your computer. It is a classic hacker trick to spread malware directly onto a device. "); //(Ico, n.d)

            //Identity Theft
            knowledgeBase.Add("identity theft",
                "Your personal information is incredibly valuable, { userName}. Let's make sure it stays personal! \n" +

                    "\tHere is what you need to know: " +
            "\nYour identity can be stolen in any number of ways. The syndicates can intercept banking transactions or hack into sites where you've made a cyber-purchase. " +
                "\nThey can obtain information from your social media profiles; or they can simply steal mail from your postbox or your dustbin - if fact any document, printed or electronic," +
                "\nthat contains your name and any other person information about you puts you at risk of identity theft.Because identity thieves are getting smarter and faster at" +
                "\nstealing consumers' personal information, consumers have to act smart and stay ahead of them. There are steps consumers can take to better protect their personal" +
                "\ninformation, as well as products that keep watch over their identity, even when they can't. Ensure all your private correspondence stays private - lock your" +
                "\npostbox; don't throw old accounts away without first destroying them; don't leave personal documents lying around where others could see them and protect your online identity." + //(TransUnion, n.d.)

            "\nThe most important way to reduce the risk of online identity theft is to have a strong password.");
  }


        

        //main conversation loop
        public void Conversation(string userName)
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

                //Password safety
              /*  else if (input.Contains("password"))
                {
                    Console.WriteLine();
                    ui.PrintHeader("\tPassword Safety");
                    ui.TypingEffect("\tPasswords, huh? Having a strong one is crucial, even though we all have far too many to remember these days." +
                        "\n\tIn accordance to Frankenmuth Insurance (2021), here are some golden safety tips: ");
                    Console.WriteLine();
                    ui.TypingEffect("1. Make passwords a minimum of 10 characters. " +
                                      "\n2. Don't use real words." +
                                      "\n3. Don't use obvious information." +
                                      "\n4. Use a different password for every account." +
                                      "\n5. Consider a password manager." +
                                      "\n6. Use two-factor authentication." +
                                      "\n7. Don't enter passwords on public Wi-Fi." +
                                      "\n8. See if your passwords have been compromised.");
                    Console.WriteLine();
                    ui.TypingEffect($"\tI hope that helped {userName}, let me know if you would like me to go into more detail 😊." +
                        $"\n\t Type 'details' if so, else type 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider();

                    

                }
                else if (input.Contains("details") || input.Contains("detail"))
                {
                    Console.WriteLine();
                    ui.TypingEffect("\tI'm so glad you want to know more! To further explain those 8 tips mentioned in Frankenmuth Insurance (2021): ");

                    ui.TypingEffect("1. Basically, the longer the password the stronger it is. Aim for at least 10 characters");
                    ui.TypingEffect("   and use passphrases mixed with symbols and numbers instead of single words. For example: I3eF!$h!ng_");

                    ui.TypingEffect("2. Try to avoid words found in the dictionary or simple sequences (like 123 or ABC).");
                    ui.TypingEffect("   Random combinations are much harder for hackers to guess!");

                    ui.TypingEffect("3. Never include names, birthdays, phone numbers or addresses. You're making it too easy for attackers😅");

                    ui.TypingEffect("4. If a hacker cracks one account, you don't want them getting the keys to all your other accounts.");
                    ui.TypingEffect("   Try to switch it up a bit.");

                    ui.TypingEffect("5. Use tools like your browser's built-in manager to securely generate and remember complex passwords for you.");

                    ui.TypingEffect("6. 2FA may be an extra step but it adds a massive extra layer of security.");
                    ui.TypingEffect("   It requires a unique code sent to your phone when logging in.");

                    ui.TypingEffect("7. As good as the free public Wi-fi is, don't type in passwords there.");
                    ui.TypingEffect("   Hackers on the same network can easily intercept your data.");

                    ui.TypingEffect("8. Use sites like 'Have I Been Pwned' to check if your accounts were leaked in a data breach.");
                    ui.TypingEffect("   If they were, change those passwords immediately!");

                    ui.TypingEffect($"\n\tI hope this clarified things better for you {userName} 😊. Type 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider();
                }
              */

                //Phishing
               /* else if (input.Contains("phishing"))
                {
                    Console.WriteLine();
                    ui.PrintHeader("\tPhishing");
                    ui.TypingEffect($"\tOh don't get me started on phishing🙄 {userName}. I see those fake package delivery emails all the time.");//intro
                    ui.TypingEffect("\tIt's crazy how real they can look these days!");
                    ui.TypingEffect("\tHere is everything you need to know to stay ahead of those sneaky attacks: ");

                    Console.WriteLine();
                    ui.TypingEffect("To define it, phishing is a social engineering cyberattack where criminals use emails, texts, or direct messages to steal"); 
                    ui.TypingEffect("sensitive data (like login credentials) and financial information or distribute malware. The attacker masquerades as a trusted");
                    ui.TypingEffect("entity-like a bank or a CEO-and uses urgency or fear to trick the victim into clicking a malicious link or downloading an infected attachment."); //(Fortinet, n.d)

                    Console.WriteLine();
                    ui.TypingEffect("\tIf you would like to know about the types phishing attacks and how to spot one, type 'attacks' else type 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider(); 
                }

                else if (input.Contains("attacks") || input.Contains("attack"))
                {
                    Console.WriteLine();
                    Console.WriteLine("\tNow that you understand what phishing is, lets move on to the common types of phishing attacks.");
                    Console.WriteLine();

                    ui.TypingEffect("Cybercriminals use several specialized tactics depending on their target:"); 
                    ui.TypingEffect("-Spear Phishing: Highly targeted attacks customized with the victim's specific personal or professional details."); 
                    ui.TypingEffect("-Whaling: A variant of spear phishing targeting high-level executives (the 'whales') to access highly sensitive corporate data."); 
                    ui.TypingEffect("-Vishing & Angler Phishing: Phishing done over voice calls (Vishing) or via direct messages on social media platforms (Angler)."); 
                    ui.TypingEffect("-Business Email Compromise (BEC): Impersonating senior executives to trick employees into wiring money to fraudulent accounts."); 
                    ui.TypingEffect("-Clone Phishing & Quishing: Replicating legitimate emails exactly but swapping the safe links for malicious ones, or using " +
                        "\nmalicious QR codes (Quishing) to redirect victims to fake sites."); //(Fortinet, n.d)

                    Console.WriteLine();
                    ui.TypingEffect($"\tThis is where i need you to focus {userName}, it's how to identify those red flags of what could be a phishing attempt.");
                    Console.WriteLine();

                    ui.TypingEffect("You should treat every unexpected email with caution. Look out for these common warning signs:" +
                         "\n-Suspicious Sender Addresses: The 'From' address might have slight misspellings or use a domain that doesn't match the actual company" + 
                         "\n-False Urgency: Messages claiming your account will be suspended immediately if you don't click a link. " + 
                         "\n-Poor Grammar and Formatting: Legitimate corporate communications rarely have spelling errors or bizarre formatting." + 
                         "\n-Generic Greetings: Using 'Dear Customer' instead of your actual name." + 
                         "\n-Hidden URLs: Hovering your mouse over a link reveals a strange or unfamiliar web address that does not match the trusted company."); //(Fortinet, n.d)

                    Console.WriteLine();
                    ui.TypingEffect($"\tI hope that taught you something {userName}.If you want to know to protect yourself from phishing type 'protect' else type 'What can i ask' to see other available options or 'bye' to end out conversation.");
                    ui.PrintDivider();
                }

                else if (input.Contains("protect") || input.Contains("protects"))
                {
                    Console.WriteLine();
                    Console.WriteLine("\tI saved the best part for last; how to protect against phishing.");

                    ui.TypingEffect("\nYou can significantly mitigate risks by adopting a combination of strategies: " + 
                        "\n-Implementing Multi-Factor Authentication (MFA) to prevent unauthorized account access. " + 
                        "\n-Employing robust technical safeguards such as updated spam and web filters. " + 
                        "\n-Ensuring that data is encrypted and backed up to protect against ransomware from phishing attacks. " + 
                        "\nand promoting employee vigilance through training to recognize and verify suspicious requests and avoid untrusted links or attachments."); //(Fortinet, n.d)

                    Console.WriteLine();
                    ui.TypingEffect("\tI know that was alot of information to take in, but these scammers are becoming really believable and its important you stay safe." +
                         "\n\tDon't worry about memorizing all of that at once! Just remember my golden rule: 'When in doubt, don't click the link' 😅" +
                         "\n\tType 'What can i ask' to see other available options or 'bye' to end our conversation");
                    ui.PrintDivider();
                } */

                //Safe Browsing
              /*  else if (input.Contains("safe browsing") || input.Contains("browsing"))
                {
                    Console.WriteLine();
                    ui.PrintHeader("\tSafe Browsing");
                    ui.TypingEffect("There are hundreds of thousands of rogue or compromised websites on the internet. Therefore, it is essential that you take caution when using the internet.");
                    ui.TypingEffect("Use the following principles to help avoid infecting or compromising your device: ");
                    ui.TypingEffect(" - Stay to well-known sites. Only trustworthy websites with valid security certifications." +
                                     "\n- Watch out for certificate error messages. Make sure the site url begins with 'https' rather than http when entering sensitive information" +
                                     "\n- When reviewing pictures in search engines, be wary of the site of where the picture is from. It could be malicious" +
                                     "\n- Try to stay away from adult websites as much as you can. These websites are hotspots for security risks and harmful software like pop up advertising." +
                                     "\n- When you're asked to provide personal information, such as card details, take extreme caution." +
                                     "\n- It's advisable to clear your browser's cache often to free up hard drive space and reduce exposure" +
                                     "\n- Take extreme caution when using download managers. As convenient as they are, they can also download malware in the background." +
                                     "\n- Avoid downloading files from unknown sites" +
                                     "\n- Don't disclose your password and sensitive information to anyone." +
                                     "\n- Be wary when using portable storage devices. Viruses and malware may copy themselves onto the drive and infect your devices when plugged in." +
                                     "\n- Stay aware of privacy policies so you understand if they share any data you provide." +
                                     "\n- Don't click on any pop-ups. Don't even click on the 'x', use alt + F4 to close bad web pages. "); //(Massachusets College of Pharmacy and Health Sciences, n.d.)
                    Console.WriteLine();
                    ui.TypingEffect("That's alot to remember right? If you would like a summarised version type 'summary' and I'll give you just that or type 'What can i ask' to see other available options or 'bye' to end out conversation.");
                    ui.PrintDivider();


                }
                else if (input.Contains("summary"))
                {
                    ui.TypingEffect($"I understand {userName}, summaries are just better.");
                    ui.TypingEffect("To enhance online safety, utilize trusted websites with valid security certifications, ensuring URLs begin with 'https' before entering sensitive" +
                        " information. Be cautious of image source origins and adult websites, which often harbor security threats. Exercise extreme caution when sharing personal information," +
                        " frequently clear browser cache, and avoid using download managers as they can introduce malware. Steer clear of downloads from unknown sites, safeguard passwords," +
                        " and be wary of portable storage devices that may carry viruses. Familiarize yourself with privacy policies to understand data sharing practices, and refrain from " +
                        "interacting with pop-ups, using 'alt + F4' instead of clicking close buttons."); //(Massachusets College of Pharmacy and Health Sciences, n.d.)
                    ui.TypingEffect("\tType 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider();
                } */

                //Other cybercrime options
              /*  else if (input.Contains("topics") || input.Contains("topic"))
                {
                    Console.WriteLine();
                    ui.TypingEffect($"\tOh, I love a curious mind {userName}! Let's dig deeper and level up your security knowledge." +
                        $"\n\tHere is the advanced stuff you can ask me about: banking scams, malware and ransomware and identity theft.");
                    ui.TypingEffect("\tType any of those names to get started 😄 or type 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider();
                }
              */
                //Banking scams
                /*else if (input.Contains("banking scams") || input.Contains("banking scam"))
               
                {
                    Console.WriteLine();
                    ui.PrintHeader("\tBanking Scams");
                    ui.TypingEffect($"Banking scams are unfortunately huge in South Africa {userName}, but at least this information will give you an upper hand 😁 ");

                    ui.TypingEffect("\nTo keep it simple cybercrimes in banking involve illegal activites that exploit technology to target financial institutions and their customers." +
                        "Common types of banking cybercrimes include: " +
                        "\n1.Phishing: Fraudsters impersonate banks via emails, luring victims to fake websites to steal personal banking information " +
                        "\n2:Vishing: Scammers place calls pretending to be bank representatives, soliciting sensitive login credentials under the guise of protecting accounts.  " +
                        "\n3.Smishing: Malicious SMS messages trick victims into clicking links or downloading malware that captures sensitive data. " +
                        "\n4.ATM card swapping: Criminals distract victims while swapping ATM cards and observing PIN entry to access accounts " +
                        "\n5.Change of banking details: Fraudsters mislead victims into making payments to incorrect bank accounts, necessitating verification of recipient details" +
                        "\n6.Investment scams:  Scammers promote fraudulent high return investments, often disappearing once funds are sent." +
                        "\n7.Loan scams: Scammers offer low interest loans that require upfront payment, vanishing after receiving the money. ");

                    ui.TypingEffect("To safeguard against such scams, it's advisable to not enter credentials via links in emails, to never share OTPs, to verify investment companies" +
                        "and to report any suspected fraud to their bank immediately. "); //(StandardBank, n.d)
                    ui.TypingEffect("Type 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider();
                } */

                //Malware & ransomware
               /* else if (input.Contains("malware and ransomware") || input.Contains("ransomware and malware"))
               
                {
                    Console.WriteLine();
                    ui.PrintHeader("\tMalware & Ransomware");
                    ui.TypingEffect("Any program that is used maliciously to damage systems is referred to as malware (malicious software). " +
                        "\nIt intentionally harms computer systems. Many thieves aim to disrupt business and profit financially, while their motivations can vary.");
                    Console.WriteLine();

                    ui.TypingEffect("The most prevalent and frequently most dangerous type of malware is ransomware. " +
                        "\nRansomware typically entails hackers encrypting an organization's files to prevent access. After that, they demand payment to grant" +
                        "\naccess to the data. In recent times, several forms of cyber extortion, such as information theft, have been referred to as ransomware. ");
                    Console.WriteLine();

                    ui.TypingEffect("\tAs much as 'malware' and ransomware' sound like something out of a hacker movie, it's very much reality 😅");

                    ui.TypingEffect("\n\tHere's how you can protect your device: ");
                    ui.TypingEffect("1. Back Up Everything (Offline & Cloud): This is your #1 defense against ransomware. If hackers lock your computer, you can just wipe it and restore your files from your backup." +
                             "\n2. Keep Software Updated: Those annoying OS and app update pop-ups are crucial. They patch the exact security holes that malware uses to sneak in." +
                             "\n3. Use Reputable Antivirus: Have a trusted antivirus or anti-malware program running active scans in the background to catch threats before they execute." +
                             "\n4. Think Before You Download: Malware loves to hide in fake email attachments (like an invoice that is actually a .exe file) or pirated software. Never download from untrusted sources." +
                             "\n5. Beware of Random USB Drives: Never plug a found or untrusted USB stick into your computer. It is a classic hacker trick to spread malware directly onto a device. "); //(Ico, n.d)
                   
                    ui.TypingEffect("\tType 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider();
                } */

                //Identity theft 
               /*
                else if (input.Contains("identity theft"))
                {
                    Console.WriteLine();
                    ui.PrintHeader("\tIdentity Theft");
                    ui.TypingEffect($"\tYour personal information is incredibly valuable, {userName}. Let's make sure it stays personal!");

                    ui.TypingEffect("\tHere is what you need to know: ");
                    ui.TypingEffect("\nYour identity can be stolen in any number of ways. The syndicates can intercept banking transactions or hack into sites where you've made a cyber-purchase. " +
                        "\nThey can obtain information from your social media profiles; or they can simply steal mail from your postbox or your dustbin - if fact any document, printed or electronic," +
                        "\nthat contains your name and any other person information about you puts you at risk of identity theft.Because identity thieves are getting smarter and faster at" +
                        "\nstealing consumers' personal information, consumers have to act smart and stay ahead of them. There are steps consumers can take to better protect their personal" +
                        "\ninformation, as well as products that keep watch over their identity, even when they can't. Ensure all your private correspondence stays private - lock your" +
                        "\npostbox; don't throw old accounts away without first destroying them; don't leave personal documents lying around where others could see them and protect your online identity."); //(TransUnion, n.d.)

                    ui.TypingEffect("\nThe most important way to reduce the risk of online identity theft is to have a strong password. Refer to the 'password safety' option to make sure your password is strong!" +
                        "\nAlternatively, you can type 'What can i ask' to see other available options or 'bye' to end our conversation.");
                    ui.PrintDivider();
                }
               */

                //If user is done
                else if (input == "exit" || input == "quit" || input.Contains("bye"))
                {  
                    Console.WriteLine() ;
                    ui.TypingEffect($"\tStay safe out there in the digital world, {userName}! I hope our chat was helpful, goodbye!");
                    isActive = false;
                }

                //Input validation 

                //If user leaves response empty/blank or just presses the space bar
                else if (string.IsNullOrWhiteSpace(input)) //(Ohlando, 2015)
                
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