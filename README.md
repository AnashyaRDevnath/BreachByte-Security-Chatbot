**BreachByte Security Bot: CyberSecurity Awareness ChatBot**

**Description:** 
BreachByte is a modern Windows-based application designed to provide interactive cybersecurity education. Transitioning from a console environment to a fully realized Graphical User Interface (GUI), the program uses a terminal-themed dashboard to teach users about digital threats like phishing, malware, and identity theft. By combining empathetic sentiment detection with a personalized memory system, the bot offers a tailored learning experience aimed at improving general security literacy.

**Demo Video Link:**

*POE PART 1*
Video 1: https://youtu.be/J-gknWy8jFw
Video 2: https://youtu.be/7bY_fkM7akc 

*POE PART 2*
https://youtu.be/9fAQj6BUcyk 

**Working action screenshots:**
<img width="1435" height="700" alt="Screenshot 2026-03-31 234321" src="https://github.com/user-attachments/assets/d4d5e595-12a1-4a7f-8d55-fd337c0828f9" />
<img width="1435" height="700" alt="Screenshot 2026-03-31 234321" src="https://github.com/user-attachments/assets/d4d5e595-12a1-4a7f-8d55-fd337c0828f9" />
<img width="1892" height="963" alt="Screenshot 2026-03-31 234243" src="https://github.com/user-attachments/assets/88c35463-e646-4e48-a894-3c2f0881ff01" />
<img width="1892" height="963" alt="Screenshot 2026-03-31 234243" src="https://github.com/user-attachments/assets/88c35463-e646-4e48-a894-3c2f0881ff01" />
<img width="1906" height="967" alt="Screenshot 2026-03-31 234228" src="https://github.com/user-attachments/assets/68879b3e-d990-4bff-ab72-ac084062b5a8" />
<img width="1906" height="967" alt="Screenshot 2026-03-31 234228" src="https://github.com/user-attachments/assets/68879b3e-d990-4bff-ab72-ac084062b5a8" />
<img width="1918" height="958" alt="Screenshot 2026-03-31 234329" src="https://github.com/user-attachments/assets/799f8ae6-8341-42d5-8ea9-3c4fbec2068f" />
<img width="1918" height="958" alt="Screenshot 2026-03-31 234329" src="https://github.com/user-attachments/assets/799f8ae6-8341-42d5-8ea9-3c4fbec2068f" />

**System Setup:**
1. Software Requirements: Ensure you have Visual Studio 2022 installed with the .NET Desktop Development workload enabled.
   Download: Clone or download this repository as a ZIP file and extract it to a folder.
2. Open Project: Navigate to the folder and double-click the .sln file to launch the project in Visual Studio.
3. Audio Asset: Ensure the file VoiceGreeting.wav is present in the project folder. In Visual Studio, right-click this         file, select Properties, and set Copy to Output Directory to "Copy if newer".
4. Run: Press F5 or click the green Start button at the top of the screen.

**Usage Instructions:**
Once the terminal initializes and asks for your name, you can interact with BreachByte by typing commands into the input box and pressing Enter.

*Standard Commands:*
-Purpose - Displays the bot's core educational mission.
-Topics - Shows a list of all cybersecurity subjects you can learn about.
-Bye - Ends the session with a personalized closing message.

*Educational Topics (Copy & Paste):*
-Phishing - Triggers an in-depth guide on identifying malicious emails and links.
-Password safety - Provides tips on creating strong, unhackable passwords.
-Safe Browsing - Explains how to protect your device while surfing the web.
-Banking scam - Details specific financial fraud tactics common in South Africa.
-Malware and Ransomware - Breaks down how viruses work and how to prevent infection.
-Identity Theft - Teaches the signs of identity fraud and recovery steps.

**Current Functionalities:**
-Advanced WPF GUI: A custom-styled dashboard featuring linear gradients, drop-shadow glows, and rounded corners.
-Asynchronous Typing Effect: Simulates a real-time conversation by rendering text letter-by-letter without freezing the      application window.
-Contextual Memory: Extracts the user's name at the start and uses it throughout the session, with the name dynamically      bolded for emphasis.
-Sentiment Analysis: Detects user emotions (Happy, Worried, Sad) and responds with empathetic prefixes before providing      technical data.
-Robust Input Validation: Detects empty inputs or whitespace and provides a system-level warning to guide the user.

**Stage of the project:**
The current stage is just Part 2 out of Part 3. The core logic and graphical interface are fully integrated.

**Future Advancements:**
Part 3 will focus on adding interactive elements, such as a cybersecurity task list or a mini-game, alongside a final professional video presentation.

**Reference List:**

CodeWith { Parveen Yadav }, 2023. Add emojis in VS code| Add emojis in Visual Studio | csharp | Dotnet | Dotnetcore | Javascript [video online]. Available at: <https://www.youtube.com/watch?v=hKeKLxvU9Ew > [Accessed 25 March 2026].
    
Frankenmuth Insurance.,2021. 8 password safety tips. Frankenmuth Insurance blog, [blog] 21 October. Available at:<https://www.fmins.com/blog/password-safety-tips/> [Accessed 25 March 2026].

fe02x, 2014. How to make text be "typed out" in console application?.[Online] Available at: <https://stackoverflow.com/questions/25337336/how-to-make-text-be-typed-out-in-console-application > [Accessed 25 March 2026].

Fortinet, n.d. What Is Phishing? [Online] Available at:<https://www.fortinet.com/resources/cyberglossary/phishing> [Accessed 25 March 2026].
  
Gillespie. P, n.d. Text to ASCII Art Generator (TAAG). [Online]. Available at: <https://patorjk.com/software/taag/#p=display&f=Cybermedium&t=BreachByte%0ASecurity+Bot&x=none&v=4&h=4&w=80&we=false> & Available at:<https://patorjk.com/software/taag/#p=display&f=Soft&t=I%27m+here+to+assist+you+%3A%29&x=none&v=4&h=4&w=80&we=false> [Accessed 23 March 2026].

Ico, n.d. Malware and ransomware. [Online].  Available at: <https://ico.org.uk/about-the-ico/research-reports-impact-and-evaluation/research-and-reports/learning-from-the-mistakes-of-others-a-retrospective-review/malware-and-ransomware/> [Accessed 29 March 2026].
 
Massachusets College of Pharmacy and Health Sciences, n.d. Safe Browsing Principles. [Online].Available at: <https://www.mcphs.edu/information-services/security/best-practices/safe-browsing-principles> [Accesssed 29 March 2026].

Microsoft, 2024. Asynchronous programming with async and await. Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/> [Accessed: 14 May 2026].

Microsoft, n.d. Border.CornerRadius Property. Microsoft Learn. Available at: <https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.border.cornerradius?view=netframework-4.8.1> [Accessed 14 May 2026]. 

Microsoft, 2024. Dictionary<TKey,TValue> Class. Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2> [Accessed: 11 May 2026] 

Microsoft, n.d. DropShadowEffect Class. Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.effects.dropshadoweffect?view=netframework-4.8.1> [Accessed 14 May 2026]. 

Microsoft, 2025. Input Overview. Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/desktop/wpf/advanced/input-overview> [Accessed 12 May 2026]  

Microsoft, n.d. Keyboard Class. Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/api/system.windows.input.keyboard?view=netframework-4.8.1&viewFallbackFrom=windowsdesktop-10.0> [Accessed 12 May 2026]. 

Microsoft, 2024. LinearGradientBrush Class (System.Windows.Media). Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.lineargradientbrush> [Accessed: 14 May 2026]. 

Microsoft, 2025. Routed events overview. Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/desktop/wpf/events/routed-events-overview> [Accessed 12 May 20206].

Microsoft, 2025. Xml:space Handling in XAML. Microsoft Learn. [Online]. Available at: <https://learn.microsoft.com/en-us/dotnet/desktop/xaml-services/xml-space-handling> [Accessed 12 May 2026]

Miken32, 2024. How to show emoji in c# console output? [Online]. Available at:<https://stackoverflow.com/questions/67508469/how-to-show-emoji-in-c-sharp-console-output> [Accessed 30 March 2026].

Ohlando, 2015. C# - How to handle empty user input? [Online]. Available at: <https://stackoverflow.com/questions/30654625/c-sharp-how-to-handle-empty-user-input> [Accessed 29 March 2026].

SeeR, 2020. What does [STAThread] do? [Online]. Available at: <https://stackoverflow.com/questions/1361033/what-does-stathread-do> [Accessed 13 May 2026].

Standard Bank, n.d. Common scams in South African banking. [Online]. Available at <https://www.standardbank.co.za/southafrica/personal/about-us/financial-education/cybercrime-and-fraud/types-of-online-fraud> [Accessed 29 March 2026].

TransUnion, n.d. Protect you Identity today with TrueIdentity. [Online]. Available at:<https://www.transunion.co.za/education/identity-theft> [Accessed 29 March 2926].

**Annexure A: Disclosure of AI Usage in my Assessment**

*Section within the assessment AI was used:*
Part 1
*Name of AI tool*
Gemini
*Purpose/intention behind use*	
To breakdown assignment and generate pseudo code, how to save .wav file in repo, general questions and questions about structure and formatting, ci.yml file help.
*Date used*
23-29 March 2026
*Link*
<https://gemini.google.com/app/43d0d836d6eb23f2?utm_source=app_launcher&utm_medium=owned&utm_campaign=base_all> 

*Section within the assessment AI was used:*
Part 1, Brainbot.cs
*Name of AI tool*
Quillbot
*Purpose/intention behind use*
To paraphrase and summarise information
*Date used:*
23-29 March 2026
*Link:*
<https://quillbot.com/paraphrasing-tool>  

*Section within the assessment AI was used:*
Part 2
*Name of AI tool*
Gemini
*Purpose/intention behind use*
To breakdown assignment and generation of pseudo code, brainstorm ideas and general questions.
*Date used:*
11-14 May 2026
*Link:*
<https://gemini.google.com/app/b2835caefca66d12?utm_source=app_launcher&utm_medium=owned&utm_campaign=base_all> 


  
