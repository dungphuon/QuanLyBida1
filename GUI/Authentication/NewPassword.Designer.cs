namespace QuanLyBida.GUI
{
    partial class NewPassword
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.ButtonShowNewPassword = new System.Windows.Forms.Button();
            this.TextBox_newPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.TextBox_confirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.ButtonChange = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonShowConfirmPassword = new System.Windows.Forms.Button();
            this.ButtonMinimize = new System.Windows.Forms.Button();
            this.ButtonMaximize = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.TextBox_confirmPassword);
            this.MainPanel.Controls.Add(this.TitleLabel);
            this.MainPanel.Controls.Add(this.InfoLabel);
            this.MainPanel.Controls.Add(this.ButtonShowNewPassword);
            this.MainPanel.Controls.Add(this.TextBox_newPassword);
            this.MainPanel.Controls.Add(this.ButtonChange);
            this.MainPanel.Controls.Add(this.ButtonShowConfirmPassword);
            this.MainPanel.Location = new System.Drawing.Point(294, 96);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(459, 400);
            this.MainPanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.TitleLabel.Location = new System.Drawing.Point(68, 16);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(340, 58);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Mật khẩu mới";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(245)))), ((int)(((byte)(234)))));
            this.InfoLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.InfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(119)))));
            this.InfoLabel.Location = new System.Drawing.Point(87, 84);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(300, 72);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "Vui lòng tạo mật khẩu có ít nhất 8 kí tự, trong đó chứa chữ cái in hoa và chữ số";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonShowNewPassword
            // 
            this.ButtonShowNewPassword.BackColor = System.Drawing.Color.White;
            this.ButtonShowNewPassword.FlatAppearance.BorderSize = 0;
            this.ButtonShowNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShowNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ButtonShowNewPassword.ForeColor = System.Drawing.Color.Black;
            this.ButtonShowNewPassword.Location = new System.Drawing.Point(317, 187);
            this.ButtonShowNewPassword.Name = "ButtonShowNewPassword";
            this.ButtonShowNewPassword.Size = new System.Drawing.Size(49, 35);
            this.ButtonShowNewPassword.TabIndex = 5;
            this.ButtonShowNewPassword.Text = "👁";
            this.ButtonShowNewPassword.UseVisualStyleBackColor = false;
            this.ButtonShowNewPassword.Click += new System.EventHandler(this.ButtonShowNewPassword_Click);
            // 
            // TextBox_newPassword
            // 
            this.TextBox_newPassword.BorderRadius = 8;
            this.TextBox_newPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_newPassword.DefaultText = "";
            this.TextBox_newPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_newPassword.Location = new System.Drawing.Point(95, 175);
            this.TextBox_newPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_newPassword.Name = "TextBox_newPassword";
            this.TextBox_newPassword.PasswordChar = '●';
            this.TextBox_newPassword.PlaceholderText = "Nhập mật khẩu mới";
            this.TextBox_newPassword.SelectedText = "";
            this.TextBox_newPassword.Size = new System.Drawing.Size(280, 55);
            this.TextBox_newPassword.TabIndex = 2;
            // 
            // TextBox_confirmPassword
            // 
            this.TextBox_confirmPassword.BorderRadius = 8;
            this.TextBox_confirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_confirmPassword.DefaultText = "";
            this.TextBox_confirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_confirmPassword.Location = new System.Drawing.Point(95, 250);
            this.TextBox_confirmPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_confirmPassword.Name = "TextBox_confirmPassword";
            this.TextBox_confirmPassword.PasswordChar = '●';
            this.TextBox_confirmPassword.PlaceholderText = "Xác nhận lại mật khẩu";
            this.TextBox_confirmPassword.SelectedText = "";
            this.TextBox_confirmPassword.Size = new System.Drawing.Size(280, 57);
            this.TextBox_confirmPassword.TabIndex = 3;
            // 
            // ButtonChange
            // 
            this.ButtonChange.BorderRadius = 8;
            this.ButtonChange.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ButtonChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonChange.ForeColor = System.Drawing.Color.White;
            this.ButtonChange.Location = new System.Drawing.Point(147, 332);
            this.ButtonChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonChange.Name = "ButtonChange";
            this.ButtonChange.Size = new System.Drawing.Size(169, 44);
            this.ButtonChange.TabIndex = 4;
            this.ButtonChange.Text = "Thay đổi";
            this.ButtonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // ButtonShowConfirmPassword
            // 
            this.ButtonShowConfirmPassword.BackColor = System.Drawing.Color.White;
            this.ButtonShowConfirmPassword.FlatAppearance.BorderSize = 0;
            this.ButtonShowConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShowConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ButtonShowConfirmPassword.ForeColor = System.Drawing.Color.Black;
            this.ButtonShowConfirmPassword.Location = new System.Drawing.Point(326, 263);
            this.ButtonShowConfirmPassword.Name = "ButtonShowConfirmPassword";
            this.ButtonShowConfirmPassword.Size = new System.Drawing.Size(37, 34);
            this.ButtonShowConfirmPassword.TabIndex = 6;
            this.ButtonShowConfirmPassword.Text = "👁";
            this.ButtonShowConfirmPassword.UseVisualStyleBackColor = false;
            this.ButtonShowConfirmPassword.Click += new System.EventHandler(this.ButtonShowConfirmPassword_Click);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMinimize.FlatAppearance.BorderSize = 0;
            this.ButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonMinimize.ForeColor = System.Drawing.Color.Gray;
            this.ButtonMinimize.Location = new System.Drawing.Point(925, 1);
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
            this.ButtonMaximize.Location = new System.Drawing.Point(965, 1);
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
            this.ButtonClose.Location = new System.Drawing.Point(1015, 1);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(40, 40);
            this.ButtonClose.TabIndex = 100;
            this.ButtonClose.Text = "✕";
            this.ButtonClose.UseVisualStyleBackColor = false;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            this.ButtonClose.MouseEnter += new System.EventHandler(this.ButtonClose_MouseEnter);
            this.ButtonClose.MouseLeave += new System.EventHandler(this.ButtonClose_MouseLeave);
            // 
            // NewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1056, 639);
            this.Controls.Add(this.ButtonMinimize);
            this.Controls.Add(this.ButtonMaximize);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NewPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Password";
            this.Load += new System.EventHandler(this.NewPassword_Load);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label InfoLabel;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_newPassword;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_confirmPassword;
        private Guna.UI2.WinForms.Guna2Button ButtonChange;
        private System.Windows.Forms.Button ButtonMinimize;
        private System.Windows.Forms.Button ButtonMaximize;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonShowNewPassword;
        private System.Windows.Forms.Button ButtonShowConfirmPassword;
    }
}