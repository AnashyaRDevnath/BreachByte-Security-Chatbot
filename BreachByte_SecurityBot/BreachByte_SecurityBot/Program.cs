using System.Windows;

namespace BreachByte_SecurityBot
{
    public class Program
    {
        // This tag is strictly required by Windows to load visual graphics
        [STAThread] //(SeeR, 2020)
        static void Main()
        {
            // Tell the app to start up and show your new window
            Application app = new Application();
            app.Run(new MainWindow());


        }

    }
}


