using System.Windows;

namespace BreachByte_SecurityBot
{
    public class Program
    {
        // This tag is strictly required by Windows to load visual graphics
        [STAThread]
        static void Main()
        {
            // Tell the app to start up and show your new window
            Application app = new Application();
            app.Run(new MainWindow());

          
        }
                
            }
    }


/* Reference list
 * Miken32, 2024. How to show emoji in c# console output? [Online]. Available at:<https://stackoverflow.com/questions/67508469/how-to-show-emoji-in-c-sharp-console-output> [Accessed 30 March 2026].
*/