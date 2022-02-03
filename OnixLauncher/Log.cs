using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OnixLauncher
{
    public static class Log
    {
        private static string _logText = string.Empty;
        public static void CreateLog()
        {
            Directory.CreateDirectory(Utils.OnixPath + "\\Logs");
            if (File.Exists(Utils.OnixPath + "\\Logs\\Current.log"))
                File.Delete(Utils.OnixPath + "\\Logs\\Current.log");
        }

        public static void Write(string text)
        {
            _logText += text + Environment.NewLine;
            File.WriteAllText(Utils.OnixPath + "\\Logs\\Current.log", _logText);
        }
    }
}