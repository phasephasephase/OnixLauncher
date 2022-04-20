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
        public Color GradColor1;
        public Color GradColor2;

        public static Settings GetDefault()
        {
            return new Settings()
            {
                InsiderMode = false,
                DLLPath = string.Empty,
                MagicGradient = false,
                GradColor1 = Color.FromArgb(30, 140, 215),
                GradColor2 = Color.FromArgb(1, 254, 218)
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
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream(Utils.OnixPath + "\\Settings.dat", FileMode.Open, FileAccess.Read))
            {
                var settings = (Settings)formatter.Deserialize(stream);
                return settings;
            }
        }
    }
}
