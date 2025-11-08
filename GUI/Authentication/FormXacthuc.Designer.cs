namespace QuanLyBida.GUI
{
    partial class FormXacthuc
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SubtitleLabel = new System.Windows.Forms.Label();
            this.TextBox_Code = new Guna.UI2.WinForms.Guna2TextBox();
            this.ButtonConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.TitleLabel);
            this.MainPanel.Controls.Add(this.SubtitleLabel);
            this.MainPanel.Controls.Add(this.TextBox_Code);
            this.MainPanel.Controls.Add(this.ButtonConfirm);
            this.MainPanel.Location = new System.Drawing.Point(317, 96);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(459, 348);
            this.MainPanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.TitleLabel.Location = new System.Drawing.Point(64, 51);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(340, 44);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Xác thực";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.SubtitleLabel.ForeColor = System.Drawing.Color.Black;
            this.SubtitleLabel.Location = new System.Drawing.Point(23, 105);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Size = new System.Drawing.Size(413, 56);
            this.SubtitleLabel.TabIndex = 1;
            this.SubtitleLabel.Text = "Vui lòng nhập mã xác thực đã được gửi qua email cho bạn";
            this.SubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBox_Code
            // 
            this.TextBox_Code.BorderRadius = 10;
            this.TextBox_Code.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_Code.DefaultText = "";
            this.TextBox_Code.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_Code.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_Code.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_Code.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_Code.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_Code.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_Code.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_Code.Location = new System.Drawing.Point(86, 175);
            this.TextBox_Code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBox_Code.Name = "TextBox_Code";
            this.TextBox_Code.PlaceholderText = "Nhập mã xác thực";
            this.TextBox_Code.SelectedText = "";
            this.TextBox_Code.Size = new System.Drawing.Size(280, 44);
            this.TextBox_Code.TabIndex = 2;
            this.TextBox_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.BorderRadius = 20;
            this.ButtonConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ButtonConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonConfirm.ForeColor = System.Drawing.Color.White;
            this.ButtonConfirm.Location = new System.Drawing.Point(133, 252);
            this.ButtonConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(200, 47);
            this.ButtonConfirm.TabIndex = 3;
            this.ButtonConfirm.Text = "Xác nhận";
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // FormXacthuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormXacthuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác thực";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label SubtitleLabel;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_Code;
        private Guna.UI2.WinForms.Guna2Button ButtonConfirm;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}