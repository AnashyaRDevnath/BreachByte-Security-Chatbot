BreachByte Security Bot: CyberSecurity Awareness ChatBot

Description: 
This is a console based app that displays a voice greeting alongside ascii art to welcome the user. It's a chatbot that responds based on user input.
It's purpose is to educate users on cybercrimes such as phishing, password safety, safe browsing and more.

Demo Video Link: 


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

  
