using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace OnixLauncher
{
    public partial class SettingsForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }

        public SettingsForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            Hide();
        }

        private void InsiderToggle_CheckedChanged(object sender, EventArgs e)
        {
            Utils.CurrentSettings.InsiderMode = InsiderToggle.Checked;
            InsiderSelect.Enabled = InsiderToggle.Checked;
            Utils.UpdateSettings();
        }

        private void MagicToggle_CheckedChanged(object sender, EventArgs e)
        {
            Utils.CurrentSettings.MagicGradient = MagicToggle.Checked;
            Utils.UpdateSettings();
        }

        private void InsiderSelect_Click(object sender, EventArgs e) => Utils.OpenFile();

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            Winapi.ReleaseCapture();
            Winapi.SendMessage(Handle, Winapi.WM_NCLBUTTONDOWN, Winapi.HT_CAPTION, 0);
        }

        private void LogsButton_Click(object sender, EventArgs e)
        {
            Process.Start(Log.LogPath);
        }
    }
}
