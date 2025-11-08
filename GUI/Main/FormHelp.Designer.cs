namespace QuanLyBida.GUI.Main
{
    partial class FormHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelContact = new Guna.UI2.WinForms.Guna2Panel();
            this.labelContactHeader = new System.Windows.Forms.Label();
            this.pictureBoxPhone = new System.Windows.Forms.PictureBox();
            this.labelContactIntro = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelHotline = new System.Windows.Forms.Label();
            this.labelWorkingHours = new System.Windows.Forms.Label();
            this.labelWorkingHoursValue = new System.Windows.Forms.Label();
            this.labelHotlineValue = new System.Windows.Forms.Label();
            this.labelEmailValue = new System.Windows.Forms.Label();
            this.labelSection3Content = new System.Windows.Forms.Label();
            this.labelSection2Content = new System.Windows.Forms.Label();
            this.labelSection3Header = new System.Windows.Forms.Label();
            this.panelLine3 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelSection2Header = new System.Windows.Forms.Label();
            this.panelLine2 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelIntro = new System.Windows.Forms.Label();
            this.labelSection1Header = new System.Windows.Forms.Label();
            this.panelLine1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panelMain.SuspendLayout();
            this.panelContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhone)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.panelContact);
            this.panelMain.Controls.Add(this.labelSection3Content);
            this.panelMain.Controls.Add(this.labelSection2Content);
            this.panelMain.Controls.Add(this.labelSection3Header);
            this.panelMain.Controls.Add(this.panelLine3);
            this.panelMain.Controls.Add(this.labelSection2Header);
            this.panelMain.Controls.Add(this.panelLine2);
            this.panelMain.Controls.Add(this.labelIntro);
            this.panelMain.Controls.Add(this.labelSection1Header);
            this.panelMain.Controls.Add(this.panelLine1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(889, 653);
            this.panelMain.TabIndex = 0;
            // 
            // panelContact
            // 
            this.panelContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.panelContact.BorderRadius = 10;
            this.panelContact.Controls.Add(this.labelContactHeader);
            this.panelContact.Controls.Add(this.pictureBoxPhone);
            this.panelContact.Controls.Add(this.labelContactIntro);
            this.panelContact.Controls.Add(this.labelEmail);
            this.panelContact.Controls.Add(this.labelHotline);
            this.panelContact.Controls.Add(this.labelWorkingHours);
            this.panelContact.Controls.Add(this.labelWorkingHoursValue);
            this.panelContact.Controls.Add(this.labelHotlineValue);
            this.panelContact.Controls.Add(this.labelEmailValue);
            this.panelContact.Location = new System.Drawing.Point(20, 565);
            this.panelContact.Name = "panelContact";
            this.panelContact.Size = new System.Drawing.Size(849, 200);
            this.panelContact.TabIndex = 10;
            // 
            // labelContactHeader
            // 
            this.labelContactHeader.AutoSize = true;
            this.labelContactHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContactHeader.Location = new System.Drawing.Point(30, 20);
            this.labelContactHeader.Name = "labelContactHeader";
            this.labelContactHeader.Size = new System.Drawing.Size(230, 28);
            this.labelContactHeader.TabIndex = 0;
            this.labelContactHeader.Text = "Liên hệ hỗ trợ kỹ thuật";
            // 
            // pictureBoxPhone
            // 
            this.pictureBoxPhone.Location = new System.Drawing.Point(8, 15);
            this.pictureBoxPhone.Name = "pictureBoxPhone";
            this.pictureBoxPhone.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhone.TabIndex = 1;
            this.pictureBoxPhone.TabStop = false;
            // 
            // labelContactIntro
            // 
            this.labelContactIntro.AutoSize = true;
            this.labelContactIntro.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContactIntro.Location = new System.Drawing.Point(30, 55);
            this.labelContactIntro.Name = "labelContactIntro";
            this.labelContactIntro.Size = new System.Drawing.Size(401, 21);
            this.labelContactIntro.TabIndex = 2;
            this.labelContactIntro.Text = "Nếu bạn gặp lỗi hoặc cần trợ giúp thêm, vui lòng liên hệ:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(30, 85);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(57, 21);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Email:";
            // 
            // labelHotline
            // 
            this.labelHotline.AutoSize = true;
            this.labelHotline.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHotline.Location = new System.Drawing.Point(30, 115);
            this.labelHotline.Name = "labelHotline";
            this.labelHotline.Size = new System.Drawing.Size(71, 21);
            this.labelHotline.TabIndex = 4;
            this.labelHotline.Text = "Hotline:";
            // 
            // labelWorkingHours
            // 
            this.labelWorkingHours.AutoSize = true;
            this.labelWorkingHours.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkingHours.Location = new System.Drawing.Point(30, 145);
            this.labelWorkingHours.Name = "labelWorkingHours";
            this.labelWorkingHours.Size = new System.Drawing.Size(108, 21);
            this.labelWorkingHours.TabIndex = 5;
            this.labelWorkingHours.Text = "Giờ làm việc:";
            // 
            // labelWorkingHoursValue
            // 
            this.labelWorkingHoursValue.AutoSize = true;
            this.labelWorkingHoursValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkingHoursValue.Location = new System.Drawing.Point(145, 145);
            this.labelWorkingHoursValue.Name = "labelWorkingHoursValue";
            this.labelWorkingHoursValue.Size = new System.Drawing.Size(172, 21);
            this.labelWorkingHoursValue.TabIndex = 8;
            this.labelWorkingHoursValue.Text = "8h00 - 21h00 (T2 - CN)";
            // 
            // labelHotlineValue
            // 
            this.labelHotlineValue.AutoSize = true;
            this.labelHotlineValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHotlineValue.Location = new System.Drawing.Point(109, 115);
            this.labelHotlineValue.Name = "labelHotlineValue";
            this.labelHotlineValue.Size = new System.Drawing.Size(108, 21);
            this.labelHotlineValue.TabIndex = 7;
            this.labelHotlineValue.Text = "0909 123 456";
            // 
            // labelEmailValue
            // 
            this.labelEmailValue.AutoSize = true;
            this.labelEmailValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailValue.Location = new System.Drawing.Point(93, 85);
            this.labelEmailValue.Name = "labelEmailValue";
            this.labelEmailValue.Size = new System.Drawing.Size(176, 21);
            this.labelEmailValue.TabIndex = 6;
            this.labelEmailValue.Text = "support@quanlybida.vn";
            // 
            // labelSection3Content
            // 
            this.labelSection3Content.AutoSize = true;
            this.labelSection3Content.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSection3Content.Location = new System.Drawing.Point(20, 440);
            this.labelSection3Content.MaximumSize = new System.Drawing.Size(850, 0);
            this.labelSection3Content.Name = "labelSection3Content";
            this.labelSection3Content.Size = new System.Drawing.Size(640, 69);
            this.labelSection3Content.TabIndex = 9;
            this.labelSection3Content.Text = resources.GetString("labelSection3Content.Text");
            // 
            // labelSection2Content
            // 
            this.labelSection2Content.AutoSize = true;
            this.labelSection2Content.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSection2Content.Location = new System.Drawing.Point(20, 216);
            this.labelSection2Content.MaximumSize = new System.Drawing.Size(850, 0);
            this.labelSection2Content.Name = "labelSection2Content";
            this.labelSection2Content.Size = new System.Drawing.Size(764, 92);
            this.labelSection2Content.TabIndex = 4;
            this.labelSection2Content.Text = resources.GetString("labelSection2Content.Text");
            this.labelSection2Content.Click += new System.EventHandler(this.labelSection2Content_Click);
            // 
            // labelSection3Header
            // 
            this.labelSection3Header.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelSection3Header.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSection3Header.ForeColor = System.Drawing.Color.White;
            this.labelSection3Header.Location = new System.Drawing.Point(20, 380);
            this.labelSection3Header.Name = "labelSection3Header";
            this.labelSection3Header.Padding = new System.Windows.Forms.Padding(10);
            this.labelSection3Header.Size = new System.Drawing.Size(849, 47);
            this.labelSection3Header.TabIndex = 7;
            this.labelSection3Header.Text = "3  Câu hỏi thường gặp (FAQ)";
            this.labelSection3Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLine3
            // 
            this.panelLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(193)))));
            this.panelLine3.Location = new System.Drawing.Point(20, 425);
            this.panelLine3.Name = "panelLine3";
            this.panelLine3.Size = new System.Drawing.Size(849, 2);
            this.panelLine3.TabIndex = 6;
            // 
            // labelSection2Header
            // 
            this.labelSection2Header.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelSection2Header.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSection2Header.ForeColor = System.Drawing.Color.White;
            this.labelSection2Header.Location = new System.Drawing.Point(20, 140);
            this.labelSection2Header.Name = "labelSection2Header";
            this.labelSection2Header.Padding = new System.Windows.Forms.Padding(10);
            this.labelSection2Header.Size = new System.Drawing.Size(849, 60);
            this.labelSection2Header.TabIndex = 5;
            this.labelSection2Header.Text = "2  Hướng dẫn sử dụng nhanh";
            this.labelSection2Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLine2
            // 
            this.panelLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(193)))));
            this.panelLine2.Location = new System.Drawing.Point(20, 185);
            this.panelLine2.Name = "panelLine2";
            this.panelLine2.Size = new System.Drawing.Size(849, 2);
            this.panelLine2.TabIndex = 4;
            // 
            // labelIntro
            // 
            this.labelIntro.AutoSize = true;
            this.labelIntro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntro.Location = new System.Drawing.Point(20, 77);
            this.labelIntro.MaximumSize = new System.Drawing.Size(850, 0);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(817, 46);
            this.labelIntro.TabIndex = 8;
            this.labelIntro.Text = "Trang này giúp bạn hiểu cách sử dụng phần mềm quản lý quán bida, xử lý sự cố và l" +
    "iên hệ hỗ trợ khi cần thiết.";
            this.labelIntro.Click += new System.EventHandler(this.labelIntro_Click);
            // 
            // labelSection1Header
            // 
            this.labelSection1Header.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelSection1Header.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSection1Header.ForeColor = System.Drawing.Color.White;
            this.labelSection1Header.Location = new System.Drawing.Point(20, 5);
            this.labelSection1Header.Name = "labelSection1Header";
            this.labelSection1Header.Padding = new System.Windows.Forms.Padding(10);
            this.labelSection1Header.Size = new System.Drawing.Size(849, 60);
            this.labelSection1Header.TabIndex = 3;
            this.labelSection1Header.Text = "1  Giới thiệu";
            this.labelSection1Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLine1
            // 
            this.panelLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(193)))));
            this.panelLine1.Location = new System.Drawing.Point(20, 95);
            this.panelLine1.Name = "panelLine1";
            this.panelLine1.Size = new System.Drawing.Size(849, 2);
            this.panelLine1.TabIndex = 2;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(889, 653);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHelp";
            this.Text = "FormHelp";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelContact.ResumeLayout(false);
            this.panelContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private Guna.UI2.WinForms.Guna2Panel panelLine1;
        private System.Windows.Forms.Label labelSection1Header;
        private Guna.UI2.WinForms.Guna2Panel panelLine2;
        private System.Windows.Forms.Label labelSection2Header;
        private Guna.UI2.WinForms.Guna2Panel panelLine3;
        private System.Windows.Forms.Label labelSection3Header;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.Label labelSection2Content;
        private System.Windows.Forms.Label labelSection3Content;
        private Guna.UI2.WinForms.Guna2Panel panelContact;
        private System.Windows.Forms.Label labelContactHeader;
        private System.Windows.Forms.PictureBox pictureBoxPhone;
        private System.Windows.Forms.Label labelContactIntro;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelHotline;
        private System.Windows.Forms.Label labelWorkingHours;
        private System.Windows.Forms.Label labelEmailValue;
        private System.Windows.Forms.Label labelHotlineValue;
        private System.Windows.Forms.Label labelWorkingHoursValue;
    }
}