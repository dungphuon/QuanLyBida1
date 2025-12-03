namespace QuanLyBida.GUI
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.LabelSlogan = new System.Windows.Forms.Label();
            this.PictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.ButtonMaximize = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonMinimize = new System.Windows.Forms.Button();
            this.TableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ButtonShowPassword = new System.Windows.Forms.Button();
            this.TextBox_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.SubtitleLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_Matkhau = new System.Windows.Forms.Label();
            this.ButtonLogin = new Guna.UI2.WinForms.Guna2Button();
            this.LinkForgot = new System.Windows.Forms.LinkLabel();
            this.Textboxpassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.PanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).BeginInit();
            this.PanelRight.SuspendLayout();
            this.TableLayoutPanelMain.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLeft
            // 
            this.PanelLeft.Controls.Add(this.LabelSlogan);
            this.PanelLeft.Controls.Add(this.PictureBoxLogo);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(400, 673);
            this.PanelLeft.TabIndex = 100;
            // 
            // LabelSlogan
            // 
            this.LabelSlogan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelSlogan.BackColor = System.Drawing.Color.Transparent;
            this.LabelSlogan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSlogan.ForeColor = System.Drawing.Color.White;
            this.LabelSlogan.Location = new System.Drawing.Point(60, 403);
            this.LabelSlogan.Name = "LabelSlogan";
            this.LabelSlogan.Size = new System.Drawing.Size(271, 96);
            this.LabelSlogan.TabIndex = 1;
            this.LabelSlogan.Text = "Phần mềm quản lý thông minh ";
            this.LabelSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelSlogan.Click += new System.EventHandler(this.LabelSlogan_Click);
            // 
            // PictureBoxLogo
            // 
            this.PictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxLogo.ErrorImage")));
            this.PictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxLogo.Image")));
            this.PictureBoxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxLogo.InitialImage")));
            this.PictureBoxLogo.Location = new System.Drawing.Point(125, 250);
            this.PictureBoxLogo.Name = "PictureBoxLogo";
            this.PictureBoxLogo.Size = new System.Drawing.Size(150, 150);
            this.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxLogo.TabIndex = 0;
            this.PictureBoxLogo.TabStop = false;
            // 
            // PanelRight
            // 
            this.PanelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.PanelRight.Controls.Add(this.ButtonMaximize);
            this.PanelRight.Controls.Add(this.ButtonClose);
            this.PanelRight.Controls.Add(this.ButtonMinimize);
            this.PanelRight.Controls.Add(this.TableLayoutPanelMain);
            this.PanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRight.Location = new System.Drawing.Point(400, 0);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(652, 673);
            this.PanelRight.TabIndex = 101;
            // 
            // ButtonMaximize
            // 
            this.ButtonMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMaximize.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMaximize.FlatAppearance.BorderSize = 0;
            this.ButtonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMaximize.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.ButtonMaximize.Location = new System.Drawing.Point(572, 0);
            this.ButtonMaximize.Name = "ButtonMaximize";
            this.ButtonMaximize.Size = new System.Drawing.Size(40, 40);
            this.ButtonMaximize.TabIndex = 100;
            this.ButtonMaximize.Text = "□";
            this.ButtonMaximize.UseVisualStyleBackColor = false;
            this.ButtonMaximize.Click += new System.EventHandler(this.ButtonMaximize_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose.FlatAppearance.BorderSize = 0;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.ButtonClose.Location = new System.Drawing.Point(612, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(40, 40);
            this.ButtonClose.TabIndex = 99;
            this.ButtonClose.Text = "✕";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMinimize.FlatAppearance.BorderSize = 0;
            this.ButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMinimize.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.ButtonMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.ButtonMinimize.Location = new System.Drawing.Point(532, 0);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.Size = new System.Drawing.Size(40, 40);
            this.ButtonMinimize.TabIndex = 97;
            this.ButtonMinimize.Text = "—";
            this.ButtonMinimize.UseVisualStyleBackColor = false;
            this.ButtonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);
            // 
            // TableLayoutPanelMain
            // 
            this.TableLayoutPanelMain.ColumnCount = 3;
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelMain.Controls.Add(this.MainPanel, 1, 1);
            this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            this.TableLayoutPanelMain.RowCount = 3;
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelMain.Size = new System.Drawing.Size(652, 673);
            this.TableLayoutPanelMain.TabIndex = 101;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.ButtonShowPassword);
            this.MainPanel.Controls.Add(this.TextBox_username);
            this.MainPanel.Controls.Add(this.SubtitleLabel);
            this.MainPanel.Controls.Add(this.TitleLabel);
            this.MainPanel.Controls.Add(this.label_username);
            this.MainPanel.Controls.Add(this.label_Matkhau);
            this.MainPanel.Controls.Add(this.ButtonLogin);
            this.MainPanel.Controls.Add(this.LinkForgot);
            this.MainPanel.Controls.Add(this.Textboxpassword);
            this.MainPanel.Location = new System.Drawing.Point(116, 66);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(420, 540);
            this.MainPanel.TabIndex = 0;
            // 
            // ButtonShowPassword
            // 
            this.ButtonShowPassword.BackColor = System.Drawing.Color.White;
            this.ButtonShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonShowPassword.FlatAppearance.BorderSize = 0;
            this.ButtonShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShowPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ButtonShowPassword.ForeColor = System.Drawing.Color.Gray;
            this.ButtonShowPassword.Location = new System.Drawing.Point(321, 298);
            this.ButtonShowPassword.Name = "ButtonShowPassword";
            this.ButtonShowPassword.Size = new System.Drawing.Size(40, 40);
            this.ButtonShowPassword.TabIndex = 13;
            this.ButtonShowPassword.TabStop = false;
            this.ButtonShowPassword.Text = "👁";
            this.ButtonShowPassword.UseVisualStyleBackColor = false;
            this.ButtonShowPassword.Click += new System.EventHandler(this.ButtonShowPassword_Click);
            // 
            // TextBox_username
            // 
            this.TextBox_username.BorderRadius = 8;
            this.TextBox_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_username.DefaultText = "";
            this.TextBox_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.TextBox_username.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.TextBox_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.TextBox_username.Location = new System.Drawing.Point(56, 193);
            this.TextBox_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_username.Name = "TextBox_username";
            this.TextBox_username.PlaceholderText = "Nhập tài khoản";
            this.TextBox_username.SelectedText = "";
            this.TextBox_username.Size = new System.Drawing.Size(308, 48);
            this.TextBox_username.TabIndex = 1;
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.SubtitleLabel.Location = new System.Drawing.Point(56, 110);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Size = new System.Drawing.Size(308, 30);
            this.SubtitleLabel.TabIndex = 10;
            this.SubtitleLabel.Text = "Chào mừng bạn quay trở lại";
            this.SubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.TitleLabel.Location = new System.Drawing.Point(48, 50);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(320, 60);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "Đăng nhập";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_username
            // 
            this.label_username.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.label_username.Location = new System.Drawing.Point(56, 165);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(150, 24);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Tên đăng nhập";
            // 
            // label_Matkhau
            // 
            this.label_Matkhau.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Matkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.label_Matkhau.Location = new System.Drawing.Point(56, 267);
            this.label_Matkhau.Name = "label_Matkhau";
            this.label_Matkhau.Size = new System.Drawing.Size(100, 24);
            this.label_Matkhau.TabIndex = 5;
            this.label_Matkhau.Text = "Mật khẩu";
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BorderRadius = 8;
            this.ButtonLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.ButtonLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.White;
            this.ButtonLogin.Location = new System.Drawing.Point(56, 375);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(308, 55);
            this.ButtonLogin.TabIndex = 3;
            this.ButtonLogin.Text = "Đăng nhập";
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // LinkForgot
            // 
            this.LinkForgot.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LinkForgot.AutoSize = true;
            this.LinkForgot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.LinkForgot.Location = new System.Drawing.Point(245, 342);
            this.LinkForgot.Name = "LinkForgot";
            this.LinkForgot.Size = new System.Drawing.Size(116, 20);
            this.LinkForgot.TabIndex = 4;
            this.LinkForgot.TabStop = true;
            this.LinkForgot.Text = "Quên mật khẩu?";
            this.LinkForgot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LinkForgot.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.LinkForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkForgot_LinkClicked);
            // 
            // Textboxpassword
            // 
            this.Textboxpassword.BorderRadius = 8;
            this.Textboxpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Textboxpassword.DefaultText = "";
            this.Textboxpassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Textboxpassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Textboxpassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Textboxpassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Textboxpassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Textboxpassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Textboxpassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.Textboxpassword.Location = new System.Drawing.Point(56, 294);
            this.Textboxpassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Textboxpassword.Name = "Textboxpassword";
            this.Textboxpassword.PlaceholderText = "Nhập mật khẩu";
            this.Textboxpassword.SelectedText = "";
            this.Textboxpassword.Size = new System.Drawing.Size(308, 48);
            this.Textboxpassword.TabIndex = 2;
            this.Textboxpassword.UseSystemPasswordChar = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 673);
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.PanelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.PanelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogo)).EndInit();
            this.PanelRight.ResumeLayout(false);
            this.TableLayoutPanelMain.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Label LabelSlogan;
        private System.Windows.Forms.PictureBox PictureBoxLogo;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Button ButtonMaximize;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonMinimize;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ButtonShowPassword;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_username;
        private System.Windows.Forms.Label SubtitleLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_Matkhau;
        private Guna.UI2.WinForms.Guna2Button ButtonLogin;
        private System.Windows.Forms.LinkLabel LinkForgot;
        private Guna.UI2.WinForms.Guna2TextBox Textboxpassword;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelMain;
    }
}