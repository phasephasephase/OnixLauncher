using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Log.Write("gaming");
            Application.EnableVisualStyles();
            // THIS LINE CAUSES PROBLEMS!!!!
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}