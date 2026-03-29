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
                    Console.WriteLine();

                }
                else if (input.Contains("ask you about") || input.Contains("what can i ask"))
                {
                    Console.WriteLine("You can ask me for tips and guidance on password safety, phishing and safe browsing. " +
                        "If you would like to know about other topics as well, type 'topics' and we can get started :)");
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
                    Console.WriteLine($"I hope that helped {userName}, let me know if you would like me to go into more detail 😊. Type 'details' if so.");
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
                else if (input.Contains("phishing"))
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

                    Console.WriteLine("\nI saved the best part for last; how to protect against phishing.");

                    Console.WriteLine("\nYou can significantly mitigate risks by adopting a combination of strategies: " +
                        "\nImplementing Multi-Factor Authentication (MFA) to prevent unauthorized account access; " +
                        "\nEmploying robust technical safeguards such as updated spam and web filters; " +
                        "\nEnsuring that data is encrypted and backed up to protect against ransomware from phishing attacks; " +
                        "\nand promoting employee vigilance through training to recognize and verify suspicious requests and avoid untrusted links or attachments.");

                    Console.WriteLine("I know that was alot of information to take in, but these scammers are becoming really believable and its important you stay safe." +
                        "\nDont worry about memorizing all of that at once! Just remember my golden rule: 'When in doubt, don't click the link' 😅");

                }
                else if (input.Contains("safe browsing"))
                {
                    Console.WriteLine("There are hundreds of thousands of rogue or compromised websites on the internet. Therefore, it is essential that you take caution when using the internet.");
                    Console.WriteLine("Use the followigng principles to help avoid infectinf or compromising your device: ");
                    Console.WriteLine(" - Stay to well-known sites. Only trustworthy websites with valid security certifications. Watch out for certificate error messages" +
                                     "\n- Make sure the site url begins with 'https' rarther than http when entering sensitive information" +
                                     "\n- When reviewing pictues in search engines, be wary of the site of where the picture is from. It could be malicious" +
                                     "\n- Try to stay away from adult websites as much as you can. These websites are hotspots for security risks and harmful softwar like pop up advertising." +
                                     "\n- When you're asked to provide personal information, such as card details, take extreme caution." +
                                     "\n- It's advisable to clear your browser's cache often to free up hard drive space and reduce exposure" +
                                     "\n- Take extreme caution when using download managers. As convenient as they are, they can also download malware in the background." +
                                     "\n- Avoid downloading files from unknown sites" +
                                     "\n- Don't disclose your password and sensitive information to anyone." +
                                     "\n- Be wary when using portable storage devices. Viruses and malware may copy themselves onto the drive and infect your devices when plugged in." +
                                     "\n- Stay aware of privacy policies so you understand if they share any data you provide." +
                                     "\n- Don't click on any pop-ups. Dont even click on the 'x', use alt + F4 to close bad web pages. ");
                    Console.WriteLine();
                    Console.WriteLine("Thats alot to take in right? If you would like a summarised version type 'summary' and I'll give you just that.");
                    Console.WriteLine();

                    //CITE https://www.mcphs.edu/information-services/security/best-practices/safe-browsing-principles

                }
                else if (input.Contains("summary"))
                {
                    Console.WriteLine($"I feel you {userName}, summaries are just better.");
                    Console.WriteLine("To enhance online safety, utilize trusted websites with valid security certifications, ensuring URLs begin with 'https' before entering sensitive" +
                        " information. Be cautious of image source origins and adult websites, which often harbor security threats. Exercise extreme caution when sharing personal information," +
                        " frequently clear browser cache, and avoid using download managers as they can introduce malware. Steer clear of downloads from unknown sites, safeguard passwords," +
                        " and be wary of portable storage devices that may carry viruses. Familiarize yourself with privacy policies to understand data sharing practices, and refrain from " +
                        "interacting with pop-ups, using 'alt + F4' instead of clicking close buttons.");
                }
                else if (input.Contains("topics"))
                {
                    Console.WriteLine($"Oh, I love a curious mind {userName}! Let's dig deeper and level up your security knowledge." +
                        $"Here is the advanced stuff you can ask me about: banking scams, malware and ransomwar, identity theft and suspicious links!");
                    Console.WriteLine("Type any of those names to get started.");
                }
                else if (input.Contains("banking") || input.Contains("scam"))
               // https://www.standardbank.co.za/southafrica/personal/about-us/financial-education/cybercrime-and-fraud/types-of-online-fraud
                    {
                    Console.WriteLine($"Banking scams are unfortunately huge in South Africa {userName}, but at least this information will give you an upper hand ");
                    Console.WriteLine("To keep it simple cybercrimes in banking involve illegal activites that exploit technology to target financial institutions and their customers." +
                        "Common types of banking cybercrimes include: " +
                        "\n1.Phishing: Fraudsters impersonate banks via emails, luring victims to fake websites to steal personal banking information " +
                        "\n2:Vishing: Scammers place calls pretending to be bank representatives, soliciting sensitive login credentials under the guise of protecting accounts.  " +
                        "\n3.Smishing: Malicious SMS messages trick victims into clicking links or downloading malware that captures sensitive data. " +
                        "\n4.ATM card swapping: Criminals distract victims while swapping ATM cards and observing PIN entry to access accounts " +
                        "\n5.Change of banking details: Fraudsters mislead victims into making payments to incorrect bank accounts, necessitating verification of recipient details" +
                        "\n6.Investment scams:  Scammers promote fraudulent high return investments, often disappearing once funds are sent." +
                        "\n7.Loan scams: Scammers offer low interest loans that require upfront payment, vanishing after receiving the money. ");

                    Console.WriteLine("To safeguard against such scams, it's advisable to not enter credentials via links in emails, to never share OTPs, to verify investment companies" +
                        "and to report any suspected fraud to their bank immediately. ");
                } 
                else if(input.Contains("malware and ransomware") || input.Contains("ransomware and malware"))
                //https://ico.org.uk/about-the-ico/research-reports-impact-and-evaluation/research-and-reports/learning-from-the-mistakes-of-others-a-retrospective-review/malware-and-ransomware/
                {
                    Console.WriteLine("Any program that is used maliciously to damage systems is referred to as malware (malicious software). It intentionally harms computer systems. Many thieves aim to disrupt business and profit financially, while their motivations can vary.");
                    Console.WriteLine("The most prevalent and frequently most dangerous type of malware is ransomware. Ransomware typically entails hackers encrypting an organization's files to prevent access. After then, they demand payment to grant access to the data. In recent times, several forms of cyber extortion, such as information theft, have been referred to as ransomware. ");

                    Console.WriteLine("1. Back Up Everything (Offline & Cloud): This is your #1 defense against ransomware. If hackers lock your computer, you can just wipe it and restore your files from your backup." +
                        " \r\n    2. Keep Software Updated: Those annoying OS and app update pop-ups are crucial. They patch the exact security holes that malware uses to sneak in." +
                        "\r\n    3. Use Reputable Antivirus: Have a trusted antivirus or anti-malware program running active scans in the background to catch threats before they execute." +
                        "\r\n    4. Think Before You Download: Malware loves to hide in fake email attachments (like an invoice that is actually a .exe file) or pirated software. Never download from untrusted sources." +
                        "\r\n    5. Beware of Random USB Drives: Never plug a found or untrusted USB stick into your computer. It is a classic hacker trick to spread malware directly onto a device. ");
                }
                else if(input.Contains("identity theft"))
                {
                    Console.WriteLine("Your identity can be stolen in any number of ways. The syndicates can intercept banking transactions or hack into sites where you've made a cyber-purchase; they can obtain information from your social media profiles; or they can simply steal mail from your postbox or your dustbin - if fact any document, printed or electronic, that contains your name and any other person information about you puts you at risk of identity theft.\r\n\r\nBecause identity thieves are getting smarter and faster at stealing consumers' personal information, consumers have to act smart and stay ahead of them. There are steps consumers can take to better protect their personal information, as well as products that keep watch over their identity, even when they can't.\r\n\r\nEnsure all your private correspondence stays private - lock your postbox; don't throw old accounts away without first destroying them; don't leave personal documents lying around where others could see them; and protect your online identity.");
                    Console.WriteLine("The most important way to reduce the risk of online indentity theft is to have a stromg password. Refer to the password safety option to make sure your password is strong!");
                }
                else if(input == "exit" || input == "quit" || input.Contains("bye"))
                {
                    Console.WriteLine($"\nStay safe out there in the digital world, {userName}! I hope our chat was helpful, goodbye!");
                    isActive = false;
                }
                //input validation 
           


            }
        }

    }
}
