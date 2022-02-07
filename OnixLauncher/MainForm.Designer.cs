using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OnixLauncher
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation2 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TitleBar = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.OnixLogo = new System.Windows.Forms.PictureBox();
            this.MinimizeButton = new Guna.UI2.WinForms.Guna2Button();
            this.CloseButton = new Guna.UI2.WinForms.Guna2Button();
            this.LaunchButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.BigOnixLogo = new System.Windows.Forms.PictureBox();
            this.OnixTitle = new System.Windows.Forms.Label();
            this.LaunchProgress = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.PresenceTimer = new System.Timers.Timer();
            this.TaskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ProgressTransition = new Guna.UI2.WinForms.Guna2Transition();
            this.CustomDLLCheckBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.CreditsButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.discord = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OnixLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigOnixLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PresenceTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TitleBar.Controls.Add(this.TitleText);
            this.TitleBar.Controls.Add(this.OnixLogo);
            this.TitleBar.Controls.Add(this.MinimizeButton);
            this.TitleBar.Controls.Add(this.CloseButton);
            this.ProgressTransition.SetDecoration(this.TitleBar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(600, 30);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // TitleText
            // 
            this.ProgressTransition.SetDecoration(this.TitleText, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TitleText.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(30, 8);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(88, 14);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Onix Launcher";
            // 
            // OnixLogo
            // 
            this.ProgressTransition.SetDecoration(this.OnixLogo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.OnixLogo.Image = ((System.Drawing.Image)(resources.GetObject("OnixLogo.Image")));
            this.OnixLogo.Location = new System.Drawing.Point(5, 5);
            this.OnixLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OnixLogo.Name = "OnixLogo";
            this.OnixLogo.Size = new System.Drawing.Size(20, 20);
            this.OnixLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OnixLogo.TabIndex = 1;
            this.OnixLogo.TabStop = false;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.Animated = true;
            this.MinimizeButton.CheckedState.Parent = this.MinimizeButton;
            this.MinimizeButton.CustomImages.Parent = this.MinimizeButton;
            this.ProgressTransition.SetDecoration(this.MinimizeButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.MinimizeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.MinimizeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.MinimizeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.MinimizeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.MinimizeButton.DisabledState.Parent = this.MinimizeButton;
            this.MinimizeButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MinimizeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimizeButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeButton.HoverState.Parent = this.MinimizeButton;
            this.MinimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeButton.Image")));
            this.MinimizeButton.ImageOffset = new System.Drawing.Point(0, 1);
            this.MinimizeButton.ImageSize = new System.Drawing.Size(30, 29);
            this.MinimizeButton.Location = new System.Drawing.Point(540, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.ShadowDecoration.Parent = this.MinimizeButton;
            this.MinimizeButton.Size = new System.Drawing.Size(30, 30);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.TextOffset = new System.Drawing.Point(1, 0);
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Animated = true;
            this.CloseButton.CheckedState.Parent = this.CloseButton;
            this.CloseButton.CustomImages.Parent = this.CloseButton;
            this.ProgressTransition.SetDecoration(this.CloseButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.CloseButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseButton.DisabledState.Parent = this.CloseButton;
            this.CloseButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.HoverState.FillColor = System.Drawing.Color.Red;
            this.CloseButton.HoverState.Parent = this.CloseButton;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageSize = new System.Drawing.Size(30, 30);
            this.CloseButton.Location = new System.Drawing.Point(570, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.ShadowDecoration.Parent = this.CloseButton;
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LaunchButton
            // 
            this.LaunchButton.Animated = true;
            this.LaunchButton.CheckedState.BorderColor = System.Drawing.Color.DarkGray;
            this.LaunchButton.CheckedState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LaunchButton.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.LaunchButton.CheckedState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.LaunchButton.CheckedState.ForeColor = System.Drawing.Color.DimGray;
            this.LaunchButton.CheckedState.Parent = this.LaunchButton;
            this.LaunchButton.CustomImages.Parent = this.LaunchButton;
            this.ProgressTransition.SetDecoration(this.LaunchButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.LaunchButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LaunchButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LaunchButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.LaunchButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.LaunchButton.DisabledState.ForeColor = System.Drawing.Color.DimGray;
            this.LaunchButton.DisabledState.Parent = this.LaunchButton;
            this.LaunchButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(254)))), ((int)(((byte)(218)))));
            this.LaunchButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.LaunchButton.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaunchButton.ForeColor = System.Drawing.Color.White;
            this.LaunchButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.LaunchButton.HoverState.Parent = this.LaunchButton;
            this.LaunchButton.Location = new System.Drawing.Point(191, 231);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.ShadowDecoration.Parent = this.LaunchButton;
            this.LaunchButton.Size = new System.Drawing.Size(160, 50);
            this.LaunchButton.TabIndex = 1;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.TextOffset = new System.Drawing.Point(0, -1);
            this.LaunchButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // BigOnixLogo
            // 
            this.ProgressTransition.SetDecoration(this.BigOnixLogo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.BigOnixLogo.Image = ((System.Drawing.Image)(resources.GetObject("BigOnixLogo.Image")));
            this.BigOnixLogo.Location = new System.Drawing.Point(95, 96);
            this.BigOnixLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BigOnixLogo.Name = "BigOnixLogo";
            this.BigOnixLogo.Size = new System.Drawing.Size(100, 100);
            this.BigOnixLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BigOnixLogo.TabIndex = 4;
            this.BigOnixLogo.TabStop = false;
            this.BigOnixLogo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BigOnixLogo_MouseDoubleClick);
            // 
            // OnixTitle
            // 
            this.ProgressTransition.SetDecoration(this.OnixTitle, Guna.UI2.AnimatorNS.DecorationType.None);
            this.OnixTitle.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnixTitle.ForeColor = System.Drawing.Color.White;
            this.OnixTitle.Location = new System.Drawing.Point(212, 115);
            this.OnixTitle.Name = "OnixTitle";
            this.OnixTitle.Size = new System.Drawing.Size(290, 63);
            this.OnixTitle.TabIndex = 4;
            this.OnixTitle.Text = "Onix Client";
            // 
            // LaunchProgress
            // 
            this.ProgressTransition.SetDecoration(this.LaunchProgress, Guna.UI2.AnimatorNS.DecorationType.None);
            this.LaunchProgress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.LaunchProgress.Location = new System.Drawing.Point(191, 287);
            this.LaunchProgress.Name = "LaunchProgress";
            this.LaunchProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(254)))), ((int)(((byte)(218)))));
            this.LaunchProgress.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.LaunchProgress.ShadowDecoration.Parent = this.LaunchProgress;
            this.LaunchProgress.Size = new System.Drawing.Size(216, 10);
            this.LaunchProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.LaunchProgress.TabIndex = 5;
            this.LaunchProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.LaunchProgress.Value = 10;
            this.LaunchProgress.Visible = false;
            // 
            // PresenceTimer
            // 
            this.PresenceTimer.Enabled = true;
            this.PresenceTimer.Interval = 2000D;
            this.PresenceTimer.SynchronizingObject = this;
            this.PresenceTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.PresenceTimer_Elapsed);
            // 
            // TaskbarIcon
            // 
            this.TaskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TaskbarIcon.Icon")));
            this.TaskbarIcon.Text = "Onix Launcher";
            this.TaskbarIcon.Visible = true;
            this.TaskbarIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TaskbarIcon_MouseClick);
            // 
            // ProgressTransition
            // 
            this.ProgressTransition.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            this.ProgressTransition.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 1F;
            this.ProgressTransition.DefaultAnimation = animation2;
            // 
            // CustomDLLCheckBox
            // 
            this.CustomDLLCheckBox.Animated = true;
            this.CustomDLLCheckBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomDLLCheckBox.CheckedState.BorderRadius = 0;
            this.CustomDLLCheckBox.CheckedState.BorderThickness = 0;
            this.CustomDLLCheckBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.ProgressTransition.SetDecoration(this.CustomDLLCheckBox, Guna.UI2.AnimatorNS.DecorationType.None);
            this.CustomDLLCheckBox.ForeColor = System.Drawing.Color.White;
            this.CustomDLLCheckBox.Location = new System.Drawing.Point(475, 330);
            this.CustomDLLCheckBox.Name = "CustomDLLCheckBox";
            this.CustomDLLCheckBox.Size = new System.Drawing.Size(113, 18);
            this.CustomDLLCheckBox.TabIndex = 6;
            this.CustomDLLCheckBox.Text = "Use Custom DLL";
            this.CustomDLLCheckBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.CustomDLLCheckBox.UncheckedState.BorderRadius = 0;
            this.CustomDLLCheckBox.UncheckedState.BorderThickness = 0;
            this.CustomDLLCheckBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.CustomDLLCheckBox.Visible = false;
            // 
            // CreditsButton
            // 
            this.CreditsButton.Animated = true;
            this.CreditsButton.CheckedState.Parent = this.CreditsButton;
            this.CreditsButton.CustomImages.Parent = this.CreditsButton;
            this.ProgressTransition.SetDecoration(this.CreditsButton, Guna.UI2.AnimatorNS.DecorationType.None);
            this.CreditsButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CreditsButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CreditsButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CreditsButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CreditsButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CreditsButton.DisabledState.Parent = this.CreditsButton;
            this.CreditsButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(254)))), ((int)(((byte)(218)))));
            this.CreditsButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.CreditsButton.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsButton.ForeColor = System.Drawing.Color.White;
            this.CreditsButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.CreditsButton.HoverState.Parent = this.CreditsButton;
            this.CreditsButton.Image = ((System.Drawing.Image)(resources.GetObject("CreditsButton.Image")));
            this.CreditsButton.ImageSize = new System.Drawing.Size(35, 35);
            this.CreditsButton.Location = new System.Drawing.Point(357, 231);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.ShadowDecoration.Parent = this.CreditsButton;
            this.CreditsButton.Size = new System.Drawing.Size(50, 50);
            this.CreditsButton.TabIndex = 2;
            this.CreditsButton.TextOffset = new System.Drawing.Point(0, -1);
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // discord
            // 
            this.discord.Animated = true;
            this.discord.CheckedState.Parent = this.discord;
            this.discord.CustomImages.Parent = this.discord;
            this.ProgressTransition.SetDecoration(this.discord, Guna.UI2.AnimatorNS.DecorationType.None);
            this.discord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.discord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.discord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.discord.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.discord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.discord.DisabledState.Parent = this.discord;
            this.discord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.discord.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.discord.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold);
            this.discord.ForeColor = System.Drawing.Color.White;
            this.discord.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.discord.HoverState.Parent = this.discord;
            this.discord.Image = ((System.Drawing.Image)(resources.GetObject("discord.Image")));
            this.discord.ImageSize = new System.Drawing.Size(35, 35);
            this.discord.Location = new System.Drawing.Point(12, 298);
            this.discord.Name = "discord";
            this.discord.ShadowDecoration.Parent = this.discord;
            this.discord.Size = new System.Drawing.Size(50, 50);
            this.discord.TabIndex = 7;
            this.discord.TextOffset = new System.Drawing.Point(0, -1);
            this.discord.Click += new System.EventHandler(this.discord_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.ControlBox = false;
            this.Controls.Add(this.discord);
            this.Controls.Add(this.CustomDLLCheckBox);
            this.Controls.Add(this.LaunchProgress);
            this.Controls.Add(this.OnixTitle);
            this.Controls.Add(this.BigOnixLogo);
            this.Controls.Add(this.CreditsButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.TitleBar);
            this.ProgressTransition.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Onix Launcher";
            this.TitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OnixLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigOnixLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PresenceTimer)).EndInit();
            this.ResumeLayout(false);

        }

        private void TaskbarIcon_MouseClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Guna.UI2.WinForms.Guna2CheckBox CustomDLLCheckBox;

        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;

        private Guna.UI2.WinForms.Guna2Transition ProgressTransition;

        private System.Windows.Forms.NotifyIcon TaskbarIcon;

        private System.Timers.Timer PresenceTimer;

        private Guna.UI2.WinForms.Guna2ProgressBar LaunchProgress;

        private System.Windows.Forms.Label OnixTitle;

        private System.Windows.Forms.PictureBox BigOnixLogo;

        private Guna.UI2.WinForms.Guna2GradientButton LaunchButton;

        private System.Windows.Forms.Label TitleText;

        private System.Windows.Forms.PictureBox OnixLogo;

        private Guna.UI2.WinForms.Guna2Button MinimizeButton;

        private Guna.UI2.WinForms.Guna2Button CloseButton;

        private System.Windows.Forms.Panel TitleBar;

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton CreditsButton;
        private Guna.UI2.WinForms.Guna2GradientButton discord;
    }
}