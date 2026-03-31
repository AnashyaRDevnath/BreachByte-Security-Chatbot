BreachByte Security Bot: CyberSecurity Awareness ChatBot

Description: 
This is a console based app that displays a voice greeting alongside ascii art to welcome the user. It's a chatbot that responds based on user input.
It's purpose is to educate users on cybercrimes such as phishing, password safety, safe browsing and more.

Demo Video Link: 
Part 1: https://youtu.be/J-gknWy8jFw
Part 2: https://youtu.be/7bY_fkM7akc 


System Setup:
To run this application on your local machine, follow these simple steps:
  1.Ensure you have the latest version of Visual Studio and the .Net SDK installed.
  2.Clone or download this GitHub repository to your local machine.
  3.Open the downloaded folder and double click the '.slnx'file to open the project in Visual Studio.
  4.The project requires no external database. Simply press CTRL + F5, or click the green arrow button at the top to compile and run the application.
  5. *NB: Ensure that your volume is up to hear the voice greeting.

Usage Instructions:
Once the bot has initialised and asked for your name, you can test the output responses by typing any of the following commands:
-How are you: The system respons with a friendly response back.
-Purpose: Explains the bot's core functions.
-What can i ask/What do you do: Informs user on the cybercrime topics they can enquire about. 
-Password/Password safety: Triggers a guide on password safety tips.
-Phishing: Triggers a guide on in depth information about phishing .
-Safe Browsing: Triggers an in depth guide on how users can protect their device.
-Topics/topic: Informs user on other cybercrime topics they can learn about.
-Banking scam: Informs users on the types of banking scams in South Africa and a short safeguard note.
-Malware and Ransomware: Triggers a guide on what the topic is about and how to protect your device.
-Identity Theft: Triggers a guide on what a user needs to know about the topic.
-*NB: Within some of the topics there are other commands mentioned to either display a summary or extended information on the topic.

Current Functionalities: 
*Keyword based conversational routing: The BotBrain class can detect specific keywords (like 'purpose') and respond accordingly.
*Custom UserInterface class: This dedicated class handles all the presentation logic, such as the voice greeting, ascii art, typing effect, section headings and dividers.
*Themed console formatting: The console uses dark magenta, dark cyan and cyan text colours, structured with clean borders, headers and dividers.
*Integrated media playback: Automatically plays voiceGreeting.wav audio file when the app runs.
*Graceful error handling: The try-catch block added to ensure the bot continues running smoothly even if the audio file goes missing or fails to play.
*Input validation: The console replies with a default message to inform the user it doesn't understand and informs user when they have left their response blank or just left a space. It also accounts for if a user uses a plural or other similar keywords to the ones recommended.

Stage of the project:
The current stage is just Part 1 out of Part 3.

Future Advancements:
-Update the command-line application to have a Graphic User interface using Windows Presentation Foundation (WPF) or Windows Forms. The bot should be able to recognise specific topics related to cybersecurity. (This is part 2)
-Extend the existing GUI from the previous advancement (part 2) and add advanced features, including interactive elemtns like a simple game or task list for cybersecurity tips. Create a professional and engaging 8-10 minute video presentation. (Part 3)

Reference List: 
Reference List
*CodeWith { Parveen Yadav }, 2023. Add emojis in VS code| Add emojis in Visual Studio | csharp | Dotnet | Dotnetcore | Javascript [video online]. Available at:** <https://www.youtube.com/watch?v=hKeKLxvU9Ew > [Accessed 25 March 2026].
    
 * Frankenmuth Insurance.,2021. 8 password safety tips. Frankenmuth Insurance blog, [blog] 21 October. 
 * Available at:<https://www.fmins.com/blog/password-safety-tips/> [Accessed 25 March 2026].

*fe02x, 2014. How to make text be "typed out" in console application?.[Online] Available at: <https://stackoverflow.com/questions/25337336/how-to-make-text-be-typed-out-in-console-application > [Accessed 25 March 2026].

 *Fortinet, n.d. What Is Phishing? [Online] Available at:<https://www.fortinet.com/resources/cyberglossary/phishing> [Accessed 25 March 2026].
  
  *Gillespie. P, n.d. Text to ASCII Art Generator (TAAG). [Online]. Available at: <https://patorjk.com/software/taag/#p=display&f=Cybermedium&t=BreachByte%0ASecurity+Bot&x=none&v=4&h=4&w=80&we=false> 
   & Available at:<https://patorjk.com/software/taag/#p=display&f=Soft&t=I%27m+here+to+assist+you+%3A%29&x=none&v=4&h=4&w=80&we=false> [Accessed 23 March 2026].

 * Ico, n.d. Malware and ransomware. [Online]. 
 * Available at: <https://ico.org.uk/about-the-ico/research-reports-impact-and-evaluation/research-and-reports/learning-from-the-mistakes-of-others-a-retrospective-review/malware-and-ransomware/> [Accessed 29 March 2026].
 * 
 * 
 * Massachusets College of Pharmacy and Health Sciences, n.d. Safe Browsing Principles. [Online].
 * Available at: <https://www.mcphs.edu/information-services/security/best-practices/safe-browsing-principles> [Accesssed 29 March 2026].

 * Miken32, 2024. How to show emoji in c# console output? [Online]. Available at:<https://stackoverflow.com/questions/67508469/how-to-show-emoji-in-c-sharp-console-output> [Accessed 30 March 2026].
*/
 * 
 * Ohlando, 2015. C# - How to handle empty user input? [Online]. Available at: <https://stackoverflow.com/questions/30654625/c-sharp-how-to-handle-empty-user-input> [Accessed 29 March 2026].
 * 
 * Standard Bank, n.d. Common scams in South African banking. [Online]. 
 * Available at <https://www.standardbank.co.za/southafrica/personal/about-us/financial-education/cybercrime-and-fraud/types-of-online-fraud> [Accessed 29 March 2026].
 *
 * 
 * TransUnion, n.d. Protect you Identity today with TrueIdentity. [Online]. Available at:<https://www.transunion.co.za/education/identity-theft> [Accessed 29 March 2926].
 * 

Annexure A: Disclosure of AI Usage in my Assessment.
*Section within the assessment AI was used:
Part 1
*Name of AI tool
Gemini
*Purpose/intention behind use	
To breakdown assignment and generate pseudo code, how to save .wav file in repo, general questions and questions about structure and formatting, ci.yml file help.
*Date used
23-29 March 2026
*Link
https://gemini.google.com/app/43d0d836d6eb23f2?utm_source=app_launcher&utm_medium=owned&utm_campaign=base_all 

*Section used
Part 1, Brainbot.cs
*Name of AI tool
Quillbot
*Purpose/intention behind use
To paraphrase and summarise info
Date used:
23-29 March 2026
Link:
https://quillbot.com/paraphrasing-tool  




  
