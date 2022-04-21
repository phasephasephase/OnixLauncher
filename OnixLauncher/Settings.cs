using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OnixLauncher
{
    [Serializable]
    public struct Settings
    {
        public bool InsiderMode;
        public string DLLPath;
        public bool MagicGradient;

        public static Settings GetDefault()
        {
            return new Settings()
            {
                InsiderMode = false,
                DLLPath = string.Empty,
                MagicGradient = false
            };
        }

        public static void Save(Settings settings)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(Utils.OnixPath + "\\Settings.dat", FileMode.Create))
            {
                formatter.Serialize(stream, settings);
            }
        }

        public static Settings Load()
        {
            if (!File.Exists(Utils.OnixPath + "\\Settings.dat")) return GetDefault();

            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(Utils.OnixPath + "\\Settings.dat", FileMode.Open, FileAccess.Read))
            {
                var settings = (Settings)formatter.Deserialize(stream);
                return settings;
            }
        }
    }
}
