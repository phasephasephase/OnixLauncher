using System;
using System.Windows.Forms;

namespace OnixLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Log.CreateLog();
            Log.Write("Begin");

            Application.EnableVisualStyles();
            // THIS LINE CAUSES PROBLEMS!!!!
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}