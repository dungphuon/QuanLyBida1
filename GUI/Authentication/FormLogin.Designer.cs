namespace QuanLyBida.GUI
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Textboxpassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.TextBox_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.SubtitleLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_Matkhau = new System.Windows.Forms.Label();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.LinkForgot = new System.Windows.Forms.LinkLabel();
            this.LinkSignup = new System.Windows.Forms.LinkLabel();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.MainPanel.Controls.Add(this.Textboxpassword);
            this.MainPanel.Controls.Add(this.TextBox_username);
            this.MainPanel.Controls.Add(this.SubtitleLabel);
            this.MainPanel.Controls.Add(this.TitleLabel);
            this.MainPanel.Controls.Add(this.label_username);
            this.MainPanel.Controls.Add(this.label_Matkhau);
            this.MainPanel.Controls.Add(this.ButtonLogin);
            this.MainPanel.Controls.Add(this.LinkForgot);
            this.MainPanel.Controls.Add(this.LinkSignup);
            this.MainPanel.Location = new System.Drawing.Point(266, 51);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(420, 540);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // Textboxpassword
            // 
            this.Textboxpassword.BorderRadius = 20;
            this.Textboxpassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Textboxpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Textboxpassword.DefaultText = "";
            this.Textboxpassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Textboxpassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Textboxpassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Textboxpassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Textboxpassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Textboxpassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Textboxpassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Textboxpassword.Location = new System.Drawing.Point(56, 289);
            this.Textboxpassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Textboxpassword.Name = "Textboxpassword";
            this.Textboxpassword.PlaceholderText = "Nhập mật khẩu";
            this.Textboxpassword.SelectedText = "";
            this.Textboxpassword.Size = new System.Drawing.Size(308, 51);
            this.Textboxpassword.TabIndex = 12;
            // 
            // TextBox_username
            // 
            this.TextBox_username.BorderRadius = 20;
            this.TextBox_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_username.DefaultText = "";
            this.TextBox_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBox_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_username.Location = new System.Drawing.Point(56, 193);
            this.TextBox_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_username.Name = "TextBox_username";
            this.TextBox_username.PlaceholderText = "Nhập tài khoản";
            this.TextBox_username.SelectedText = "";
            this.TextBox_username.Size = new System.Drawing.Size(308, 51);
            this.TextBox_username.TabIndex = 11;
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.SubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.SubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.SubtitleLabel.Location = new System.Drawing.Point(50, 108);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Size = new System.Drawing.Size(320, 40);
            this.SubtitleLabel.TabIndex = 10;
            this.SubtitleLabel.Text = "Chào mừng bạn quay trở lại";
            this.SubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.TitleLabel.Location = new System.Drawing.Point(50, 42);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(320, 60);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "ĐĂNG NHẬP";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // label_username
            // 
            this.label_username.BackColor = System.Drawing.Color.Transparent;
            this.label_username.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_username.Location = new System.Drawing.Point(56, 162);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(308, 40);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Tên đăng nhập";
            // 
            // label_Matkhau
            // 
            this.label_Matkhau.BackColor = System.Drawing.Color.Transparent;
            this.label_Matkhau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label_Matkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_Matkhau.Location = new System.Drawing.Point(56, 260);
            this.label_Matkhau.Name = "label_Matkhau";
            this.label_Matkhau.Size = new System.Drawing.Size(308, 40);
            this.label_Matkhau.TabIndex = 5;
            this.label_Matkhau.Text = "Mật khẩu";
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLogin.Location = new System.Drawing.Point(56, 375);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(308, 55);
            this.ButtonLogin.TabIndex = 1;
            this.ButtonLogin.Text = "Đăng nhập";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // LinkForgot
            // 
            this.LinkForgot.AutoSize = true;
            this.LinkForgot.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LinkForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.LinkForgot.Location = new System.Drawing.Point(227, 455);
            this.LinkForgot.Name = "LinkForgot";
            this.LinkForgot.Size = new System.Drawing.Size(137, 23);
            this.LinkForgot.TabIndex = 7;
            this.LinkForgot.TabStop = true;
            this.LinkForgot.Text = "Quên mật khẩu?";
            this.LinkForgot.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.LinkForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkForgot_LinkClicked);
            // 
            // LinkSignup
            // 
            this.LinkSignup.AutoSize = true;
            this.LinkSignup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LinkSignup.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.LinkSignup.Location = new System.Drawing.Point(98, 485);
            this.LinkSignup.Name = "LinkSignup";
            this.LinkSignup.Size = new System.Drawing.Size(224, 23);
            this.LinkSignup.TabIndex = 8;
            this.LinkSignup.TabStop = true;
            this.LinkSignup.Text = "Chưa có tài khoản? Đăng ký";
            this.LinkSignup.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.LinkSignup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSignup_LinkClicked);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose.FlatAppearance.BorderSize = 0;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonClose.ForeColor = System.Drawing.Color.Gray;
            this.ButtonClose.Location = new System.Drawing.Point(1009, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(40, 40);
            this.ButtonClose.TabIndex = 99;
            this.ButtonClose.Text = "✕";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            this.ButtonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1052, 673);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Click += new System.EventHandler(this.ButtonLogin_Click);
            this.Resize += new System.EventHandler(this.FormLogin_Resize);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_Matkhau;
        private System.Windows.Forms.LinkLabel LinkForgot;
        private System.Windows.Forms.LinkLabel LinkSignup;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label SubtitleLabel;
        private Guna.UI2.WinForms.Guna2TextBox Textboxpassword;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_username;
        private System.Windows.Forms.Button ButtonLogin;
    }
}
