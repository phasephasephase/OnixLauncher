using System;
using System.Diagnostics;
using System.IO;

namespace OnixLauncher
{
    public static class Log
    {
        public static string LogPath = Utils.OnixPath + "\\Logs";

        private static string _logText = string.Empty;

        public static void CreateLog()
        {
            Directory.CreateDirectory(LogPath + "\\Previous");
            if (File.Exists(LogPath + "\\Current.log"))
            {
                File.Move(LogPath + "\\Current.log", LogPath + "\\" + DateTime.Now.ToBinary() + ".log");
            }
        }

        public static void Write(string text)
        {
            Debug.WriteLine(text);
            Console.WriteLine(text); // ok
            _logText += text + Environment.NewLine;
            File.WriteAllText(LogPath + "\\Current.log", _logText);
        }
    }
}