using System.Drawing;

namespace OnixLauncher
{
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
    }
}
