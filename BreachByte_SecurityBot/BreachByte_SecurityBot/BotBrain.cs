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
        //The random number generator 
        private Random randomiser = new Random();

        //Memory banks
        public string SavedUserName { get; set; } = "User";
        public string FavoriteTopic { get; set; } = "";

        //Tracks the last topic the bot answered (conversation flow)
        public string LastDiscussedTopic { get; set; } = "";

        //Acts as abridge to tell MainWindow what just happened
        public string TopicJustTriggered { get; set; } = "";

        //Declare the dictionary
        private Dictionary<string, string[]> knowledgeBase;  //while the key is a string, the value is an array of strings. A single text key will map to a collection of multiple strings (Microsoft, n.d)

        //Constructor {fill dictionary here}
        public BotBrain()
        {
            //initialise dictionary
            knowledgeBase = new Dictionary<string, string[]>();

            knowledgeBase.Add("how are you", new string[]
        {
            "I'm doing great today, thanks for asking 😄. How are you?",
            "All my systems are running perfectly! 😄 Thanks for asking. What can I help you with?"
        });

            knowledgeBase.Add("purpose", new string[]
            {
            "My purpose is to educate you on cybersecurity topics! I can help you spot cyber threats and provide guidance on avoiding common traps. Type 'ask' to know more."
            });

            knowledgeBase.Add("ask", new string[]
            {
            "You can ask me for tips and guidance on password safety, phishing, and safe browsing. If you would like to know about other cybercrime topics as well, type 'topics' and we can get started [NAME]:)"
            });

            //Password safety
            knowledgeBase.Add("password", new string[]
                {
            "Basically, the longer the password the stronger it is [NAME]. Aim for at least 10 characters and use passphrases mixed with symbols and numbers instead of single words. For example: I3eF!$h!ng_",

            "Try to avoid words found in the dictionary or simple sequences (like 123 or ABC). Random combinations are much harder for hackers to guess [NAME]!",

            "Never include names, birthdays, phone numbers or addresses. You're making it too easy for attackers [NAME]😅",

            "If a hacker cracks one account, you don't want them getting the keys to all your other accounts.Try to switch it up a bit.",

            "Use tools like your browser's built-in manager to securely generate and remember complex passwords for you.",

            "2FA may be an extra step but it adds a massive extra layer of security.It requires a unique code sent to your phone when logging in.",

            "As good as the free public Wi-fi is, don't type in passwords there. Hackers on the same network can easily intercept your data.",

           "Use sites like 'Have I Been Pwned' to check if your accounts were leaked in a data breach. If they were, change those passwords immediately [NAME]!" //Frankenmuth Insurance (2021)
        });

            //Phishing
            knowledgeBase.Add("phishing", new string[]
                {
            "Oh don't get me started on phishing🙄 [NAME]. I see those fake package delivery emails all the time!" +
            "To define it, phishing is a social engineering cyberattack where criminals use emails, texts, or direct messages to steal\n" +
            "sensitive data (like login credentials) and financial information or distribute malware.",
           
            "The attacker masquerades as a trusted entity-like a bank or a CEO-and uses urgency or fear to trick the victim into clicking a malicious link or downloading an infected attachment. \n\n" + //(Fortinet, n.d)
            "If you'd like to hear about the types of attacks or how to spot them, just type attack😊)" });

            knowledgeBase.Add("attack", new string[]
            {
            " Cybercriminals employ various tactics tailored to their targets [NAME], including: Spear Phishing, which involves highly targeted attacks using personal details. ",

            "Whaling, aimed at high-level executives to access sensitive data. " ,

            "Vishing and Angler Phishing, which utilize voice calls and social media messages, respectively where executives are impersonated to divert funds; " +

            "Clone Phishing and Quishing, where legitimate emails are replicated to include malicious links or QR codes leading to fraudulent sites",

            "You have to look out for red flags [NAME]! Suspicious sender addresses, false urgency, poor grammar," +
            " and hidden URLs are classic signs of a phishing attack. Type 'protect' if you want to know how to stay safe."
            });

            knowledgeBase.Add("protect", new string[]
            {
            "I saved the best part for last, [NAME]! You can protect yourself by using Multi-Factor Authentication (MFA) and keeping your spam filters updated. And remember my golden rule: 'When in doubt, don't click the link' 😅",

            "Mitigating risks is key [NAME]! Ensure your data is backed up to protect against ransomware, and always verify suspicious requests. Don't worry about memorizing it all, just remember: think before you click! 😅"
            });


            //Safe Browsing
            knowledgeBase.Add("safe browsing", new string[]
                {
            "There are hundreds of thousands of rogue or compromised websites on the internet.Therefore, it is essential that you take caution when using the internet [NAME].\n" +
            "To enhance online safety, utilize trusted websites with valid security certifications, ensuring URLs begin with 'https' before entering sensitive information.",

            "Be cautious of image source origins and adult websites [NAME], which often harbor security threats." ,

            "Exercise extreme caution when sharing personal information [NAME]." ,

            "Fequently clear browser cache, and avoid using download managers as they can introduce malware " ,

            "Steer clear of downloads from unknown sites, safeguard passwords!",

            "Be wary of portable storage devices that may carry viruses. " ,

            "Familiarize yourself with privacy policies to understand data sharing practices, and refrain from interacting with pop-ups, using 'alt + F4' instead of clicking close buttons." }); //(Massachusets College of Pharmacy and Health Sciences, n.d.)


            //Other cybercrime topics
            knowledgeBase.Add("topics", new string[]
                {
            "Oh, I love a curious mind [NAME]!\n" +
            "Let's dig deeper and level up your security knowledge." +
            "\nHere is the advanced stuff you can ask me about: banking scams, malware and ransomware and identity theft.\n\n" +

            "Type any of those names to get started😊 " });

            //Banking scams
            knowledgeBase.Add("banking scams", new string[]
                {
            "Banking scams are unfortunately huge in South Africa [NAME], but at least this information will give you an upper hand 😁 " +
            "\nTo keep it simple cybercrimes in banking involve illegal activites that exploit technology to target financial institutions and their customers." +
            "There are several types of banking scams.",

            "Phishing: Fraudsters impersonate banks via emails, luring victims to fake websites to steal personal banking information " +

            ":Vishing: Scammers place calls pretending to be bank representatives, soliciting sensitive login credentials under the guise of protecting accounts.  " ,

            ".Smishing: Malicious SMS messages trick victims into clicking links or downloading malware that captures sensitive data. " ,

            ".ATM card swapping: Criminals distract victims while swapping ATM cards and observing PIN entry to access accounts ",

            ".Change of banking details: Fraudsters mislead victims into making payments to incorrect bank accounts, necessitating verification of recipient details" ,

            ".Investment scams:  Scammers promote fraudulent high return investments, often disappearing once funds are sent." ,

            ".Loan scams: Scammers offer low interest loans that require upfront payment, vanishing after receiving the money. \n\n" ,

            "To safeguard against such scams [NAME], it's advisable to not enter credentials via links in emails, to never share OTPs, to verify investment companies" +
            "and to report any suspected fraud to their bank immediately. " }); //(StandardBank, n.d)


            //Malware and Ransomware
            knowledgeBase.Add("malware and ransomware", new string[]
                {
            "Any program that is used maliciously to damage systems is referred to as malware (malicious software) [NAME]. " ,

            "It intentionally harms computer systems. Many thieves aim to disrupt business and profit financially, while their motivations can vary." ,

            "The most prevalent and frequently most dangerous type of malware is ransomware [NAME]. " ,

            "Ransomware typically entails hackers encrypting an organization's files to prevent access. After that, they demand payment to grant access to the data. In recent times, several forms of cyber extortion, such as information theft, have been referred to as ransomware." ,
                //(Ico, n.d)

            "As much as 'malware' and ransomware' sound like something out of a hacker movie, it's very much reality 😅. Type 'How do i protect my device?' to find out how you can [NAME]" });

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
            "Your identity can be stolen in any number of ways [NAME]. The syndicates can intercept banking transactions or hack into sites where you've made a cyber-purchase. " ,

            "Thieves can obtain information from your social media profiles [NAME]; or they can simply steal mail from your postbox or your dustbin - if fact any document, printed or electronic that contains your name and any other person information about you puts you at risk of identity theft. " ,

            "There are steps consumers can take to better protect their personal information, as well as products that keep watch over their identity, even when they can't." ,

            "Ensure all your private correspondence stays private [NAME] - lock your postbox; don't throw old accounts away without first destroying them; don't leave personal documents lying around where others could see them and protect your online identity." , //(TransUnion, n.d.)

            "The most important way to reduce the risk of online identity theft is to have a strong password [NAME]." });
        }

        public string GetBotResponse(string utext)
        {
            //Clean up input
            string input = utext.ToLower().Trim();

            //Memory logic: saving the name
            if (input.Contains("my name is"))
            {
                // Split the sentence exactly at the phrase "my name is "
                string[] parts = input.Split(new string[] { "my name is " }, StringSplitOptions.None);

                if (parts.Length > 1)
                {
                    // Grab the very first word immediately after that phrase
                    string extractedName = parts[1].Split(' ')[0];

                    // Strip away any sneaky periods, commas, or question marks attached to the name
                    extractedName = extractedName.Trim('.', ',', '!', '?');

                    // Capitalize it and save it
                    if (!string.IsNullOrWhiteSpace(extractedName))
                    {
                        SavedUserName = char.ToUpper(extractedName[0]) + extractedName.Substring(1);
                    }
                }

                return $"Nice to meet you, {SavedUserName} 😊 I'll remember that. What cybersecurity topic are you interested in? Type 'What can i ask about?' to see your available options or type 'Bye' to end our conversation😊";

            }

            //Memory logic:Saving the Favorite Topic 
            if (input.Contains("interested in") || input.Contains("favourite is") || input.Contains("favorite is"))
            {
                // Simple logic to grab the topic they mentioned
                string[] words = input.Split(' ');
                FavoriteTopic = words[words.Length - 1];
                return $"Great! I'll remember that you're interested in {FavoriteTopic}. It's a crucial part of staying safe online. ";
            }

            //Sentiment detection
            string empatheticPrefix = "";

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid") || input.Contains("anxious"))
            {
                empatheticPrefix = "It's completely understandable to feel that way [NAME]. The digital world can be scary, but learning the facts keeps you safe! \n\n";
            }
            else if (input.Contains("frustrated") || input.Contains("confused") || input.Contains("annoyed") || input.Contains("overwhelmed"))
            {
                empatheticPrefix = "Take a deep breath! Cybersecurity can be super overwhelming, but we will take it one step at a time together. \n\n";
            }
            else if (input.Contains("curious") || input.Contains("interested"))
            {
                empatheticPrefix = "I love the curiosity [NAME]! Asking questions and staying informed is the absolute best defense. \n\n";
            }
            else if (input.Contains("thanks") || input.Contains("grateful") ||input.Contains("thank you"))
            {
                empatheticPrefix = "You are most welcome [NAME]. We're in this together! Is there anything else you want to talk about?\n\n";
            }

            empatheticPrefix = empatheticPrefix.Replace("[NAME]", SavedUserName);

            //Exit command
            if (input == "exit" || input == "quit" || input.Contains("bye"))
            {
               
                string goodbyeMsg = $"Stay safe out there in the digital world, [NAME]! I hope our chat was helpful, goodbye!";
                return goodbyeMsg.Replace("[NAME]", SavedUserName);

            }

            //Conversation flow
            if (input.Contains("tell me more") || input.Contains("another tip") || input.Contains("explain more") || input.Contains("what else can you tell me"))
            {
                // Check if we actually have a previous topic to talk about
                if (!string.IsNullOrEmpty(LastDiscussedTopic))
                {
                    // Trick the bot into thinking the user typed the last topic again!
                    // This forces it to skip down to the dictionary and grab a new random answer for that topic.
                    input = LastDiscussedTopic;
                }
                else
                {
                    // If they say "tell me more" as their very first message, handle it gracefully
                    return "I'm not sure what you want to hear more about! Type 'What can i ask about' to see avaialble cybercrime topics or type 'bye' to end our conversation😊.";
                }
            }

            //Check if the exact word exists in dictionary

            //To reset trigger
            TopicJustTriggered = "";

            foreach (var key in knowledgeBase.Keys)
            {
                if (input.Contains(key))
                {
                    LastDiscussedTopic = key;

                    TopicJustTriggered = key; 

                    string[] possibleAnswers = knowledgeBase[key];

                    // Pick a random number based on how many answers we have
                    int randomIndex = randomiser.Next(possibleAnswers.Length);

                    // Hold the answer in a temporary variable instead of returning it right away
                    string finalAnswer = possibleAnswers[randomIndex];

                    // Inject the name from memory (Replaces [NAME] with whatever is saved)
                    finalAnswer = finalAnswer.Replace("[NAME]", SavedUserName);

                    //Occasionally remind them of their favorite topic! (For Memory & Recall)
                    if (!string.IsNullOrEmpty(FavoriteTopic) && randomiser.Next(100) < 45) //45% chance it will happen
                    {
                        finalAnswer += $"\n\n(Since you are interested in {FavoriteTopic}, you might want to review the security settings on your accounts!)";
                    }

                    //Now return the fully customized answer!
                    return empatheticPrefix + finalAnswer;
                }
            }
            //If user expressed a feeling but didnt give a topic:
            if (!string.IsNullOrEmpty(empatheticPrefix))
            {
                return empatheticPrefix + "What specific topic is making you feel this way? Try asking me about phishing, passwords, or safe browsing else type 'topics' to know about other cybercrime topics 😊";
            }

            // Return default response
            return "I didn't quite understand that. Could you please rephrase, or double check your spelling?";
        }
    }
}


