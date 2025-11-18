namespace QuanLyBida.GUI
{
    partial class FormRegister
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
            this.components = new System.ComponentModel.Container();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LabelUsername = new System.Windows.Forms.Label();
            this.TextBox_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.TextBox_email = new Guna.UI2.WinForms.Guna2TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.TextBox_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.ButtonJoin = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonShowPassword = new System.Windows.Forms.Button();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ButtonMinimize = new System.Windows.Forms.Button();
            this.ButtonMaximize = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.TitleLabel.Location = new System.Drawing.Point(100, 42);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(253, 45);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Tạo tài khoản mới";
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // LabelUsername
            // 
            this.LabelUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LabelUsername.Location = new System.Drawing.Point(79, 108);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(167, 27);
            this.LabelUsername.TabIndex = 1;
            this.LabelUsername.Text = "Tên đăng nhập";
            this.LabelUsername.Click += new System.EventHandler(this.LabelUsername_Click);
            // 
            // TextBox_username
            // 
            this.TextBox_username.BorderRadius = 10;
            this.TextBox_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_username.DefaultText = "";
            this.TextBox_username.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_username.Location = new System.Drawing.Point(83, 132);
            this.TextBox_username.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TextBox_username.Name = "TextBox_username";
            this.TextBox_username.PlaceholderText = "johndoe";
            this.TextBox_username.SelectedText = "";
            this.TextBox_username.Size = new System.Drawing.Size(270, 49);
            this.TextBox_username.TabIndex = 2;
            // 
            // LabelEmail
            // 
            this.LabelEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LabelEmail.Location = new System.Drawing.Point(89, 200);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(100, 20);
            this.LabelEmail.TabIndex = 3;
            this.LabelEmail.Text = "Email:";
            // 
            // TextBox_email
            // 
            this.TextBox_email.BorderRadius = 10;
            this.TextBox_email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_email.DefaultText = "";
            this.TextBox_email.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_email.Location = new System.Drawing.Point(83, 225);
            this.TextBox_email.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TextBox_email.Name = "TextBox_email";
            this.TextBox_email.PlaceholderText = "inbox@gmail.com";
            this.TextBox_email.SelectedText = "";
            this.TextBox_email.Size = new System.Drawing.Size(270, 46);
            this.TextBox_email.TabIndex = 4;
            // 
            // LabelPassword
            // 
            this.LabelPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LabelPassword.Location = new System.Drawing.Point(89, 276);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(100, 20);
            this.LabelPassword.TabIndex = 5;
            this.LabelPassword.Text = "Mật khẩu";
            // 
            // TextBox_password
            // 
            this.TextBox_password.BorderRadius = 10;
            this.TextBox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_password.DefaultText = "";
            this.TextBox_password.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_password.Location = new System.Drawing.Point(83, 301);
            this.TextBox_password.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TextBox_password.Name = "TextBox_password";
            this.TextBox_password.PasswordChar = '●';
            this.TextBox_password.PlaceholderText = "";
            this.TextBox_password.SelectedText = "";
            this.TextBox_password.Size = new System.Drawing.Size(270, 47);
            this.TextBox_password.TabIndex = 6;
            // 
            // ButtonJoin
            // 
            this.ButtonJoin.BorderRadius = 20;
            this.ButtonJoin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ButtonJoin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonJoin.ForeColor = System.Drawing.Color.White;
            this.ButtonJoin.Location = new System.Drawing.Point(129, 355);
            this.ButtonJoin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonJoin.Name = "ButtonJoin";
            this.ButtonJoin.Size = new System.Drawing.Size(165, 41);
            this.ButtonJoin.TabIndex = 1;
            this.ButtonJoin.Text = "Đăng kí";
            this.ButtonJoin.Click += new System.EventHandler(this.ButtonJoin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.ButtonShowPassword);
            this.panel1.Controls.Add(this.ButtonJoin);
            this.panel1.Controls.Add(this.LabelPassword);
            this.panel1.Controls.Add(this.LabelEmail);
            this.panel1.Controls.Add(this.TextBox_password);
            this.panel1.Controls.Add(this.TextBox_email);
            this.panel1.Controls.Add(this.TextBox_username);
            this.panel1.Controls.Add(this.LabelUsername);
            this.panel1.Controls.Add(this.TitleLabel);
            this.panel1.Location = new System.Drawing.Point(307, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 426);
            this.panel1.TabIndex = 7;
            // 
            // ButtonShowPassword
            // 
            this.ButtonShowPassword.BackColor = System.Drawing.Color.White;
            this.ButtonShowPassword.FlatAppearance.BorderSize = 0;
            this.ButtonShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShowPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ButtonShowPassword.ForeColor = System.Drawing.Color.Black;
            this.ButtonShowPassword.Location = new System.Drawing.Point(286, 306);
            this.ButtonShowPassword.Name = "ButtonShowPassword";
            this.ButtonShowPassword.Size = new System.Drawing.Size(51, 34);
            this.ButtonShowPassword.TabIndex = 7;
            this.ButtonShowPassword.Text = "👁";
            this.ButtonShowPassword.UseVisualStyleBackColor = false;
            this.ButtonShowPassword.Click += new System.EventHandler(this.ButtonShowPassword_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMinimize.FlatAppearance.BorderSize = 0;
            this.ButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonMinimize.ForeColor = System.Drawing.Color.Gray;
            this.ButtonMinimize.Location = new System.Drawing.Point(1140, 3);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.Size = new System.Drawing.Size(40, 40);
            this.ButtonMinimize.TabIndex = 98;
            this.ButtonMinimize.Text = "─";
            this.ButtonMinimize.UseVisualStyleBackColor = false;
            this.ButtonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);
            this.ButtonMinimize.MouseEnter += new System.EventHandler(this.ButtonMinimize_MouseEnter);
            this.ButtonMinimize.MouseLeave += new System.EventHandler(this.ButtonMinimize_MouseLeave);
            // 
            // ButtonMaximize
            // 
            this.ButtonMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMaximize.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMaximize.FlatAppearance.BorderSize = 0;
            this.ButtonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMaximize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonMaximize.ForeColor = System.Drawing.Color.Gray;
            this.ButtonMaximize.Location = new System.Drawing.Point(1180, 3);
            this.ButtonMaximize.Name = "ButtonMaximize";
            this.ButtonMaximize.Size = new System.Drawing.Size(40, 40);
            this.ButtonMaximize.TabIndex = 99;
            this.ButtonMaximize.Text = "□";
            this.ButtonMaximize.UseVisualStyleBackColor = false;
            this.ButtonMaximize.Click += new System.EventHandler(this.ButtonMaximize_Click);
            this.ButtonMaximize.MouseEnter += new System.EventHandler(this.ButtonMaximize_MouseEnter);
            this.ButtonMaximize.MouseLeave += new System.EventHandler(this.ButtonMaximize_MouseLeave);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose.FlatAppearance.BorderSize = 0;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonClose.ForeColor = System.Drawing.Color.Gray;
            this.ButtonClose.Location = new System.Drawing.Point(1220, 3);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(40, 40);
            this.ButtonClose.TabIndex = 100;
            this.ButtonClose.Text = "✕";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            this.ButtonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.ButtonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.ButtonMinimize);
            this.Controls.Add(this.ButtonMaximize);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label LabelUsername;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_username;
        private System.Windows.Forms.Label LabelEmail;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_email;
        private System.Windows.Forms.Label LabelPassword;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_password;
        private Guna.UI2.WinForms.Guna2Button ButtonJoin;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Button ButtonMinimize;
        private System.Windows.Forms.Button ButtonMaximize;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonShowPassword;
    }
}