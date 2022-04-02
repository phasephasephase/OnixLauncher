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
            Directory.CreateDirectory(Utils.OnixPath + "\\Logs\\Previous");
            if (File.Exists(Utils.OnixPath + "\\Logs\\Current.log"))
            {
                File.Move(Utils.OnixPath + "\\Logs\\Current.log", Utils.OnixPath + "\\Logs\\" + DateTime.Now.ToBinary() + ".log");
            }
        }

        public static void Write(string text)
        {
            Debug.WriteLine(text);
            _logText += text + Environment.NewLine;
            File.WriteAllText(Utils.OnixPath + "\\Logs\\Current.log", _logText);
        }
    }
}