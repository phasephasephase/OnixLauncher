using System.ComponentModel;

namespace OnixLauncher
{
    partial class MessageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.TitleBar = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.CloseButton = new Guna.UI2.WinForms.Guna2Button();
            this.MessageTitle = new System.Windows.Forms.Label();
            this.MessageSubtitle = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.Okay = new Guna.UI2.WinForms.Guna2GradientButton();
            this.OnixLogo = new System.Windows.Forms.PictureBox();
            this.TitleBar.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OnixLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TitleBar.Controls.Add(this.TitleText);
            this.TitleBar.Controls.Add(this.CloseButton);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(310, 30);
            this.TitleBar.TabIndex = 2;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(7, 7);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(56, 15);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Message";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Animated = true;
            this.CloseButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.HoverState.FillColor = System.Drawing.Color.Red;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageSize = new System.Drawing.Size(30, 30);
            this.CloseButton.Location = new System.Drawing.Point(280, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MessageTitle
            // 
            this.MessageTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageTitle.ForeColor = System.Drawing.Color.White;
            this.MessageTitle.Location = new System.Drawing.Point(69, 39);
            this.MessageTitle.Name = "MessageTitle";
            this.MessageTitle.Size = new System.Drawing.Size(211, 24);
            this.MessageTitle.TabIndex = 4;
            this.MessageTitle.Text = "Title";
            // 
            // MessageSubtitle
            // 
            this.MessageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageSubtitle.ForeColor = System.Drawing.Color.White;
            this.MessageSubtitle.Location = new System.Drawing.Point(70, 62);
            this.MessageSubtitle.Name = "MessageSubtitle";
            this.MessageSubtitle.Size = new System.Drawing.Size(210, 33);
            this.MessageSubtitle.TabIndex = 5;
            this.MessageSubtitle.Text = "Subtitle\r\nsecond line :)";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ButtonPanel.Controls.Add(this.Okay);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 110);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(310, 40);
            this.ButtonPanel.TabIndex = 4;
            // 
            // Okay
            // 
            this.Okay.Animated = true;
            this.Okay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Okay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Okay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Okay.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Okay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Okay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(254)))), ((int)(((byte)(218)))));
            this.Okay.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.Okay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Okay.ForeColor = System.Drawing.Color.White;
            this.Okay.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.Okay.Location = new System.Drawing.Point(229, 7);
            this.Okay.Name = "Okay";
            this.Okay.Size = new System.Drawing.Size(75, 25);
            this.Okay.TabIndex = 2;
            this.Okay.Text = "Okay";
            this.Okay.TextOffset = new System.Drawing.Point(0, -1);
            this.Okay.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            this.Okay.Click += new System.EventHandler(this.Okay_Click);
            // 
            // OnixLogo
            // 
            this.OnixLogo.Image = ((System.Drawing.Image)(resources.GetObject("OnixLogo.Image")));
            this.OnixLogo.Location = new System.Drawing.Point(13, 43);
            this.OnixLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OnixLogo.Name = "OnixLogo";
            this.OnixLogo.Size = new System.Drawing.Size(50, 50);
            this.OnixLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OnixLogo.TabIndex = 6;
            this.OnixLogo.TabStop = false;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(310, 150);
            this.Controls.Add(this.OnixLogo);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.MessageSubtitle);
            this.Controls.Add(this.MessageTitle);
            this.Controls.Add(this.TitleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageForm";
            this.ShowInTaskbar = false;
            this.Text = "MessageForm";
            this.TitleBar.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OnixLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2GradientButton Okay;

        private System.Windows.Forms.Label MessageSubtitle;

        private System.Windows.Forms.PictureBox OnixLogo;

        private System.Windows.Forms.Panel ButtonPanel;

        private System.Windows.Forms.Label MessageTitle;

        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Label TitleText;
        private Guna.UI2.WinForms.Guna2Button CloseButton;

        #endregion
    }
}