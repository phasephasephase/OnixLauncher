namespace OnixLauncher
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.InsiderDescription = new System.Windows.Forms.Label();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.CloseButton = new Guna.UI2.WinForms.Guna2Button();
            this.InsiderSelect = new Guna.UI2.WinForms.Guna2GradientButton();
            this.InsiderToggle = new Guna.UI2.WinForms.Guna2CheckBox();
            this.Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.MagicToggle = new Guna.UI2.WinForms.Guna2CheckBox();
            this.MagicDescription = new System.Windows.Forms.Label();
            this.shushing_face = new System.Windows.Forms.Label();
            this.TitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // InsiderDescription
            // 
            this.InsiderDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsiderDescription.ForeColor = System.Drawing.Color.White;
            this.InsiderDescription.Location = new System.Drawing.Point(13, 74);
            this.InsiderDescription.Name = "InsiderDescription";
            this.InsiderDescription.Size = new System.Drawing.Size(230, 17);
            this.InsiderDescription.TabIndex = 10;
            this.InsiderDescription.Text = "This will only work with Onix Client DLLs.";
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
            this.TitleBar.Size = new System.Drawing.Size(247, 30);
            this.TitleBar.TabIndex = 7;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(7, 7);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(56, 18);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Settings";
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
            this.CloseButton.Location = new System.Drawing.Point(217, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // InsiderSelect
            // 
            this.InsiderSelect.Animated = true;
            this.InsiderSelect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.InsiderSelect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.InsiderSelect.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.InsiderSelect.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.InsiderSelect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.InsiderSelect.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(254)))), ((int)(((byte)(218)))));
            this.InsiderSelect.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.InsiderSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.InsiderSelect.ForeColor = System.Drawing.Color.White;
            this.InsiderSelect.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.InsiderSelect.Location = new System.Drawing.Point(150, 44);
            this.InsiderSelect.Name = "InsiderSelect";
            this.InsiderSelect.Size = new System.Drawing.Size(80, 25);
            this.InsiderSelect.TabIndex = 2;
            this.InsiderSelect.Text = "Select";
            this.InsiderSelect.TextOffset = new System.Drawing.Point(0, -1);
            this.InsiderSelect.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            this.InsiderSelect.Click += new System.EventHandler(this.InsiderSelect_Click);
            // 
            // InsiderToggle
            // 
            this.InsiderToggle.Animated = true;
            this.InsiderToggle.AutoSize = true;
            this.InsiderToggle.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.InsiderToggle.CheckedState.BorderRadius = 0;
            this.InsiderToggle.CheckedState.BorderThickness = 0;
            this.InsiderToggle.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.InsiderToggle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.InsiderToggle.ForeColor = System.Drawing.Color.White;
            this.InsiderToggle.Location = new System.Drawing.Point(12, 45);
            this.InsiderToggle.Name = "InsiderToggle";
            this.InsiderToggle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InsiderToggle.Size = new System.Drawing.Size(129, 25);
            this.InsiderToggle.TabIndex = 11;
            this.InsiderToggle.Text = "Insider Mode";
            this.InsiderToggle.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InsiderToggle.UncheckedState.BorderRadius = 0;
            this.InsiderToggle.UncheckedState.BorderThickness = 0;
            this.InsiderToggle.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.InsiderToggle.CheckedChanged += new System.EventHandler(this.InsiderToggle_CheckedChanged);
            // 
            // Separator1
            // 
            this.Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Separator1.Location = new System.Drawing.Point(12, 94);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(225, 10);
            this.Separator1.TabIndex = 12;
            // 
            // MagicToggle
            // 
            this.MagicToggle.Animated = true;
            this.MagicToggle.AutoSize = true;
            this.MagicToggle.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.MagicToggle.CheckedState.BorderRadius = 0;
            this.MagicToggle.CheckedState.BorderThickness = 0;
            this.MagicToggle.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(215)))));
            this.MagicToggle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.MagicToggle.ForeColor = System.Drawing.Color.White;
            this.MagicToggle.Location = new System.Drawing.Point(12, 110);
            this.MagicToggle.Name = "MagicToggle";
            this.MagicToggle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MagicToggle.Size = new System.Drawing.Size(146, 25);
            this.MagicToggle.TabIndex = 13;
            this.MagicToggle.Text = "Magic Gradient";
            this.MagicToggle.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MagicToggle.UncheckedState.BorderRadius = 0;
            this.MagicToggle.UncheckedState.BorderThickness = 0;
            this.MagicToggle.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.MagicToggle.CheckedChanged += new System.EventHandler(this.MagicToggle_CheckedChanged);
            // 
            // MagicDescription
            // 
            this.MagicDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MagicDescription.ForeColor = System.Drawing.Color.White;
            this.MagicDescription.Location = new System.Drawing.Point(13, 138);
            this.MagicDescription.Name = "MagicDescription";
            this.MagicDescription.Size = new System.Drawing.Size(223, 32);
            this.MagicDescription.TabIndex = 14;
            this.MagicDescription.Text = "Adds a neat color transition to all buttons.";
            // 
            // shushing_face
            // 
            this.shushing_face.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shushing_face.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.shushing_face.Location = new System.Drawing.Point(0, 167);
            this.shushing_face.Name = "shushing_face";
            this.shushing_face.Size = new System.Drawing.Size(223, 15);
            this.shushing_face.TabIndex = 17;
            this.shushing_face.Text = "thanks to hmmm#9008 for being funny";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(247, 182);
            this.Controls.Add(this.MagicDescription);
            this.Controls.Add(this.shushing_face);
            this.Controls.Add(this.MagicToggle);
            this.Controls.Add(this.Separator1);
            this.Controls.Add(this.InsiderToggle);
            this.Controls.Add(this.InsiderSelect);
            this.Controls.Add(this.InsiderDescription);
            this.Controls.Add(this.TitleBar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SettingsForm";
            this.TitleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InsiderDescription;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Label TitleText;
        private Guna.UI2.WinForms.Guna2Button CloseButton;
        private Guna.UI2.WinForms.Guna2Separator Separator1;
        private System.Windows.Forms.Label MagicDescription;
        private System.Windows.Forms.Label shushing_face;
        public Guna.UI2.WinForms.Guna2CheckBox InsiderToggle;
        public Guna.UI2.WinForms.Guna2CheckBox MagicToggle;
        public Guna.UI2.WinForms.Guna2GradientButton InsiderSelect;
    }
}