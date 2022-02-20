using System;
using System.Windows.Forms;

namespace OnixLauncher
{
    public partial class MessageForm : Form
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
        public static bool DetectedSecondLauncher;
        public MessageForm(string title, string subtitle)
        {
            InitializeComponent();

            MessageTitle.Text = title;
            MessageSubtitle.Text = subtitle;
            StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
        }

        public void SetTitleAndSubtitle(string title, string subtitle)
        {
            MessageTitle.Text = title;
            MessageSubtitle.Text = subtitle;
            Show();
            if (DetectedSecondLauncher)
                MainForm.Instance.Hide();
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            if (DetectedSecondLauncher)
                MainForm.Instance.Close();
            Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (DetectedSecondLauncher)
                MainForm.Instance.Close();
            Hide();
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            Winapi.ReleaseCapture();
            Winapi.SendMessage(Handle, Winapi.WM_NCLBUTTONDOWN, Winapi.HT_CAPTION, 0);
        }
    }
}