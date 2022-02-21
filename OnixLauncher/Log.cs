using System;
using System.Diagnostics;
using System.IO;

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
            Debug.WriteLine(text);
            _logText += text + Environment.NewLine;
            File.WriteAllText(Utils.OnixPath + "\\Logs\\Current.log", _logText);
        }
    }
}