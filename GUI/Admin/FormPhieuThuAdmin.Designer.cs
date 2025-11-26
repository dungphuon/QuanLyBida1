namespace GUI.Admin
{
    partial class FormPhieuThuAdmin
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
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblLoaiPhieu = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtSoPhieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNgayLap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtNguoiThu = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLyDo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.txtNguoiLap = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnInPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoPhieu.Location = new System.Drawing.Point(32, 30);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(67, 20);
            this.lblSoPhieu.TabIndex = 0;
            this.lblSoPhieu.Text = "Số phiếu";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayLap.Location = new System.Drawing.Point(324, 30);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(69, 20);
            this.lblNgayLap.TabIndex = 1;
            this.lblNgayLap.Text = "Ngày lập";
            // 
            // lblLoaiPhieu
            // 
            this.lblLoaiPhieu.AutoSize = true;
            this.lblLoaiPhieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoaiPhieu.Location = new System.Drawing.Point(616, 30);
            this.lblLoaiPhieu.Name = "lblLoaiPhieu";
            this.lblLoaiPhieu.Size = new System.Drawing.Size(103, 20);
            this.lblLoaiPhieu.TabIndex = 2;
            this.lblLoaiPhieu.Text = "Loại phiếu thu";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChu.Location = new System.Drawing.Point(32, 98);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(58, 20);
            this.lblGhiChu.TabIndex = 3;
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoPhieu.DefaultText = "";
            this.txtSoPhieu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSoPhieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSoPhieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoPhieu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoPhieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoPhieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoPhieu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoPhieu.Location = new System.Drawing.Point(32, 52);
            this.txtSoPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.PlaceholderText = "Tự động...";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.SelectedText = "";
            this.txtSoPhieu.Size = new System.Drawing.Size(260, 34);
            this.txtSoPhieu.TabIndex = 4;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Checked = true;
            this.dtpNgayLap.FillColor = System.Drawing.Color.White;
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(324, 52);
            this.dtpNgayLap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayLap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(260, 34);
            this.dtpNgayLap.TabIndex = 5;
            this.dtpNgayLap.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // txtNguoiThu
            // 
            this.txtNguoiThu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNguoiThu.DefaultText = "";
            this.txtNguoiThu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNguoiThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNguoiThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNguoiThu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNguoiThu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNguoiThu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNguoiThu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNguoiThu.Location = new System.Drawing.Point(616, 52);
            this.txtNguoiThu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiThu.Name = "txtNguoiThu";
            this.txtNguoiThu.PlaceholderText = "Nhập tại đây";
            this.txtNguoiThu.SelectedText = "";
            this.txtNguoiThu.Size = new System.Drawing.Size(236, 34);
            this.txtNguoiThu.TabIndex = 6;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLyDo.DefaultText = "";
            this.txtLyDo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLyDo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLyDo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLyDo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLyDo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLyDo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLyDo.Location = new System.Drawing.Point(32, 120);
            this.txtLyDo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.PlaceholderText = "Nhập nội dung...";
            this.txtLyDo.SelectedText = "";
            this.txtLyDo.Size = new System.Drawing.Size(820, 85);
            this.txtLyDo.TabIndex = 7;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoTien.Location = new System.Drawing.Point(32, 225);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(100, 20);
            this.lblSoTien.TabIndex = 8;
            this.lblSoTien.Text = "Số tiền (VND)";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoTien.DefaultText = "0";
            this.txtSoTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSoTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSoTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSoTien.Location = new System.Drawing.Point(32, 247);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.PlaceholderText = "Nhập số tiền";
            this.txtSoTien.SelectedText = "";
            this.txtSoTien.Size = new System.Drawing.Size(330, 38);
            this.txtSoTien.TabIndex = 9;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.AutoSize = true;
            this.lblNguoiLap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNguoiLap.Location = new System.Drawing.Point(524, 225);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(117, 20);
            this.lblNguoiLap.TabIndex = 10;
            this.lblNguoiLap.Text = "Người lập phiếu";
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNguoiLap.DefaultText = "";
            this.txtNguoiLap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNguoiLap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNguoiLap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNguoiLap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNguoiLap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNguoiLap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNguoiLap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNguoiLap.Location = new System.Drawing.Point(528, 247);
            this.txtNguoiLap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.PlaceholderText = "Tên người lập";
            this.txtNguoiLap.SelectedText = "";
            this.txtNguoiLap.Size = new System.Drawing.Size(324, 38);
            this.txtNguoiLap.TabIndex = 11;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(213)))), ((int)(((byte)(115)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(90, 330);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(183, 47);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.BorderRadius = 10;
            this.btnInPhieu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInPhieu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInPhieu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInPhieu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnInPhieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInPhieu.ForeColor = System.Drawing.Color.White;
            this.btnInPhieu.Location = new System.Drawing.Point(329, 330);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(183, 47);
            this.btnInPhieu.TabIndex = 13;
            this.btnInPhieu.Text = "In phiếu";
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 10;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(568, 330);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(183, 47);
            this.btnHuy.TabIndex = 14;
            this.btnHuy.Text = "Hủy";
            // 
            // FormPhieuThuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 416);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtNguoiLap);
            this.Controls.Add(this.lblNguoiLap);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.txtNguoiThu);
            this.Controls.Add(this.dtpNgayLap);
            this.Controls.Add(this.txtSoPhieu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblLoaiPhieu);
            this.Controls.Add(this.lblNgayLap);
            this.Controls.Add(this.lblSoPhieu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPhieuThuAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phiếu Thu (Admin)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.Label lblLoaiPhieu;
        private System.Windows.Forms.Label lblGhiChu;
        private Guna.UI2.WinForms.Guna2TextBox txtSoPhieu;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayLap;
        private Guna.UI2.WinForms.Guna2TextBox txtNguoiThu;
        private Guna.UI2.WinForms.Guna2TextBox txtLyDo;
        private System.Windows.Forms.Label lblSoTien;
        private Guna.UI2.WinForms.Guna2TextBox txtSoTien;
        private System.Windows.Forms.Label lblNguoiLap;
        private Guna.UI2.WinForms.Guna2TextBox txtNguoiLap;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnInPhieu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}