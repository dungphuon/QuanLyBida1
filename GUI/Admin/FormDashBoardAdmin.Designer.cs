namespace QuanLyBida.GUI.Admin
{
    partial class FormDashBoardAdmin
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
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.labelChucNgay = new System.Windows.Forms.Label();
            this.labelMoTa = new System.Windows.Forms.Label();
            this.labelChaoMung = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderRadius = 10;
            this.panelMain.Controls.Add(this.labelChucNgay);
            this.panelMain.Controls.Add(this.labelMoTa);
            this.panelMain.Controls.Add(this.labelChaoMung);
            this.panelMain.Location = new System.Drawing.Point(32, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(40);
            this.panelMain.Size = new System.Drawing.Size(827, 456);
            this.panelMain.TabIndex = 0;
            // 
            // labelChucNgay
            // 
            this.labelChucNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChucNgay.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChucNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelChucNgay.Location = new System.Drawing.Point(40, 350);
            this.labelChucNgay.Name = "labelChucNgay";
            this.labelChucNgay.Size = new System.Drawing.Size(747, 66);
            this.labelChucNgay.TabIndex = 2;
            this.labelChucNgay.Text = "Chúc bạn một ngày làm việc hiệu quả";
            this.labelChucNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMoTa
            // 
            this.labelMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMoTa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelMoTa.Location = new System.Drawing.Point(40, 120);
            this.labelMoTa.Name = "labelMoTa";
            this.labelMoTa.Size = new System.Drawing.Size(747, 200);
            this.labelMoTa.TabIndex = 1;
            this.labelMoTa.Text = "Chào mừng bạn đến với hệ thống quản lý quán bida. Tại đây bạn có thể nhanh chóng quản lý bàn, hàng hóa, nhân viên và các thông tin cần thiết.";
            // 
            // labelChaoMung
            // 
            this.labelChaoMung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChaoMung.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChaoMung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelChaoMung.Location = new System.Drawing.Point(40, 40);
            this.labelChaoMung.Name = "labelChaoMung";
            this.labelChaoMung.Size = new System.Drawing.Size(747, 50);
            this.labelChaoMung.TabIndex = 0;
            this.labelChaoMung.Text = "Xin chào, Admin 👋";
            this.labelChaoMung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDashBoardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(891, 618);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashBoardAdmin";
            this.Text = "Dashboard";
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label labelChaoMung;
        private System.Windows.Forms.Label labelMoTa;
        private System.Windows.Forms.Label labelChucNgay;
    }
}
