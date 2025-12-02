namespace QuanLyBida.GUI.Main
{
    partial class FormThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelSubTime;
        private System.Windows.Forms.Panel panelSep1;
        private System.Windows.Forms.TableLayoutPanel tableInfo;
        private System.Windows.Forms.Label lblTGTitle;
        private System.Windows.Forms.Label lblTGValue;
        private System.Windows.Forms.Label lblTienBanTitle;
        private System.Windows.Forms.Label lblTienBanValue;
        private System.Windows.Forms.Panel panelSep2;
        private System.Windows.Forms.Label lblTongTitle;
        private System.Windows.Forms.Label lblTongValue;
        private System.Windows.Forms.Label lblPTTTTitle;
        private System.Windows.Forms.Panel panelPaymentMethods;
        private System.Windows.Forms.RadioButton radioTienMat;
        private System.Windows.Forms.RadioButton radioChuyenKhoan;
        private System.Windows.Forms.RadioButton radioTheATM;
        private System.Windows.Forms.RadioButton radioViDienTu;
        private System.Windows.Forms.ListView listItems;
        private System.Windows.Forms.FlowLayoutPanel flowPayments;

        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colSL;
        private System.Windows.Forms.ColumnHeader colDonGia;
        private System.Windows.Forms.ColumnHeader colThanhTien;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel panelFooter;

        // Thêm các control mới cho tìm kiếm khách hàng
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Panel panelKhachHang;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Button btnThemKH;

        // Thêm các control cho giảm giá
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.NumericUpDown numGiamGia;
        private System.Windows.Forms.Label lblPhanTram;
        private System.Windows.Forms.Label lblTienGiamTitle;
        private System.Windows.Forms.Label lblTienGiamValue;

        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelSubTime = new System.Windows.Forms.Label();
            this.panelSep1 = new System.Windows.Forms.Panel();
            this.tableInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTGTitle = new System.Windows.Forms.Label();
            this.lblTGValue = new System.Windows.Forms.Label();
            this.lblTienBanTitle = new System.Windows.Forms.Label();
            this.lblTienBanValue = new System.Windows.Forms.Label();
            this.panelSep2 = new System.Windows.Forms.Panel();
            this.lblTongTitle = new System.Windows.Forms.Label();
            this.lblTongValue = new System.Windows.Forms.Label();
            this.lblPTTTTitle = new System.Windows.Forms.Label();
            this.panelPaymentMethods = new System.Windows.Forms.Panel();
            this.radioViDienTu = new System.Windows.Forms.RadioButton();
            this.radioTheATM = new System.Windows.Forms.RadioButton();
            this.radioChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.radioTienMat = new System.Windows.Forms.RadioButton();
            this.listItems = new System.Windows.Forms.ListView();
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDonGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.flowPayments = new System.Windows.Forms.FlowLayoutPanel();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.panelKhachHang = new System.Windows.Forms.Panel();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.numGiamGia = new System.Windows.Forms.NumericUpDown();
            this.lblPhanTram = new System.Windows.Forms.Label();
            this.lblTienGiamTitle = new System.Windows.Forms.Label();
            this.lblTienGiamValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableInfo.SuspendLayout();
            this.panelPaymentMethods.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.labelHeader.Location = new System.Drawing.Point(0, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(720, 65);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "HÓA ĐƠN THANH TOÁN";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSubTime
            // 
            this.labelSubTime.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelSubTime.ForeColor = System.Drawing.Color.Gray;
            this.labelSubTime.Location = new System.Drawing.Point(4, 89);
            this.labelSubTime.Name = "labelSubTime";
            this.labelSubTime.Size = new System.Drawing.Size(258, 24);
            this.labelSubTime.TabIndex = 1;
            this.labelSubTime.Text = "18:44:53 15/10/2025";
            this.labelSubTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSep1
            // 
            this.panelSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelSep1.Location = new System.Drawing.Point(40, 125);
            this.panelSep1.Name = "panelSep1";
            this.panelSep1.Size = new System.Drawing.Size(640, 1);
            this.panelSep1.TabIndex = 2;
            // 
            // tableInfo
            // 
            this.tableInfo.ColumnCount = 2;
            this.tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableInfo.Controls.Add(this.lblTGTitle, 0, 0);
            this.tableInfo.Controls.Add(this.lblTGValue, 1, 0);
            this.tableInfo.Controls.Add(this.lblTienBanTitle, 0, 1);
            this.tableInfo.Controls.Add(this.lblTienBanValue, 1, 1);
            this.tableInfo.Location = new System.Drawing.Point(40, 275);
            this.tableInfo.Name = "tableInfo";
            this.tableInfo.RowCount = 2;
            this.tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableInfo.Size = new System.Drawing.Size(640, 80);
            this.tableInfo.TabIndex = 3;
            // 
            // lblTGTitle
            // 
            this.lblTGTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTGTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTGTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTGTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTGTitle.Name = "lblTGTitle";
            this.lblTGTitle.Size = new System.Drawing.Size(442, 40);
            this.lblTGTitle.TabIndex = 0;
            this.lblTGTitle.Text = "Thời gian chơi:";
            this.lblTGTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTGValue
            // 
            this.lblTGValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTGValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTGValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTGValue.Location = new System.Drawing.Point(451, 0);
            this.lblTGValue.Name = "lblTGValue";
            this.lblTGValue.Size = new System.Drawing.Size(186, 40);
            this.lblTGValue.TabIndex = 1;
            this.lblTGValue.Text = "00:00:00";
            this.lblTGValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTienBanTitle
            // 
            this.lblTienBanTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienBanTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienBanTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTienBanTitle.Location = new System.Drawing.Point(3, 40);
            this.lblTienBanTitle.Name = "lblTienBanTitle";
            this.lblTienBanTitle.Size = new System.Drawing.Size(442, 40);
            this.lblTienBanTitle.TabIndex = 2;
            this.lblTienBanTitle.Text = "Tiền bàn (Lỗ - 35.000 đ/giờ):";
            this.lblTienBanTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTienBanValue
            // 
            this.lblTienBanValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTienBanValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTienBanValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTienBanValue.Location = new System.Drawing.Point(451, 40);
            this.lblTienBanValue.Name = "lblTienBanValue";
            this.lblTienBanValue.Size = new System.Drawing.Size(186, 40);
            this.lblTienBanValue.TabIndex = 3;
            this.lblTienBanValue.Text = "0 đ";
            this.lblTienBanValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTienBanValue.Click += new System.EventHandler(this.lblTienBanValue_Click);
            // 
            // panelSep2
            // 
            this.panelSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelSep2.Location = new System.Drawing.Point(40, 445);
            this.panelSep2.Name = "panelSep2";
            this.panelSep2.Size = new System.Drawing.Size(640, 1);
            this.panelSep2.TabIndex = 4;
            // 
            // lblTongTitle
            // 
            this.lblTongTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTitle.Location = new System.Drawing.Point(33, 620);
            this.lblTongTitle.Name = "lblTongTitle";
            this.lblTongTitle.Size = new System.Drawing.Size(380, 45);
            this.lblTongTitle.TabIndex = 5;
            this.lblTongTitle.Text = "TỔNG TIỀN:";
            this.lblTongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongValue
            // 
            this.lblTongValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongValue.Location = new System.Drawing.Point(402, 620);
            this.lblTongValue.Name = "lblTongValue";
            this.lblTongValue.Size = new System.Drawing.Size(260, 45);
            this.lblTongValue.TabIndex = 6;
            this.lblTongValue.Text = "0 đ";
            this.lblTongValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongValue.Click += new System.EventHandler(this.lblTongValue_Click);
            // 
            // lblPTTTTitle
            // 
            this.lblPTTTTitle.AutoSize = true;
            this.lblPTTTTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPTTTTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPTTTTitle.Location = new System.Drawing.Point(36, 708);
            this.lblPTTTTitle.Name = "lblPTTTTitle";
            this.lblPTTTTitle.Size = new System.Drawing.Size(250, 28);
            this.lblPTTTTitle.TabIndex = 7;
            this.lblPTTTTitle.Text = "Phương thức thanh toán:";
            this.lblPTTTTitle.Click += new System.EventHandler(this.lblPTTTTitle_Click_1);
            // 
            // panelPaymentMethods
            // 
            this.panelPaymentMethods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelPaymentMethods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPaymentMethods.Controls.Add(this.radioViDienTu);
            this.panelPaymentMethods.Controls.Add(this.radioTheATM);
            this.panelPaymentMethods.Controls.Add(this.radioChuyenKhoan);
            this.panelPaymentMethods.Controls.Add(this.radioTienMat);
            this.panelPaymentMethods.Location = new System.Drawing.Point(38, 755);
            this.panelPaymentMethods.Name = "panelPaymentMethods";
            this.panelPaymentMethods.Size = new System.Drawing.Size(640, 120);
            this.panelPaymentMethods.TabIndex = 8;
            // 
            // radioViDienTu
            // 
            this.radioViDienTu.AutoSize = true;
            this.radioViDienTu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioViDienTu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radioViDienTu.Location = new System.Drawing.Point(340, 68);
            this.radioViDienTu.Name = "radioViDienTu";
            this.radioViDienTu.Size = new System.Drawing.Size(228, 29);
            this.radioViDienTu.TabIndex = 3;
            this.radioViDienTu.Text = "💳 Ví điện tử (Momo,...)";
            this.radioViDienTu.UseVisualStyleBackColor = true;
            // 
            // radioTheATM
            // 
            this.radioTheATM.AutoSize = true;
            this.radioTheATM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioTheATM.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radioTheATM.Location = new System.Drawing.Point(340, 23);
            this.radioTheATM.Name = "radioTheATM";
            this.radioTheATM.Size = new System.Drawing.Size(133, 29);
            this.radioTheATM.TabIndex = 2;
            this.radioTheATM.Text = "💳 Thẻ ATM";
            this.radioTheATM.UseVisualStyleBackColor = true;
            // 
            // radioChuyenKhoan
            // 
            this.radioChuyenKhoan.AutoSize = true;
            this.radioChuyenKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radioChuyenKhoan.Location = new System.Drawing.Point(25, 68);
            this.radioChuyenKhoan.Name = "radioChuyenKhoan";
            this.radioChuyenKhoan.Size = new System.Drawing.Size(180, 29);
            this.radioChuyenKhoan.TabIndex = 1;
            this.radioChuyenKhoan.Text = "🏦 Chuyển khoản";
            this.radioChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // radioTienMat
            // 
            this.radioTienMat.AutoSize = true;
            this.radioTienMat.Checked = true;
            this.radioTienMat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioTienMat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.radioTienMat.Location = new System.Drawing.Point(25, 23);
            this.radioTienMat.Name = "radioTienMat";
            this.radioTienMat.Size = new System.Drawing.Size(132, 29);
            this.radioTienMat.TabIndex = 0;
            this.radioTienMat.TabStop = true;
            this.radioTienMat.Text = "💵 Tiền mặt";
            this.radioTienMat.UseVisualStyleBackColor = true;
            // 
            // listItems
            // 
            this.listItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTen,
            this.colSL,
            this.colDonGia,
            this.colThanhTien});
            this.listItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listItems.FullRowSelect = true;
            this.listItems.GridLines = true;
            this.listItems.HideSelection = false;
            this.listItems.Location = new System.Drawing.Point(38, 379);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(640, 160);
            this.listItems.TabIndex = 9;
            this.listItems.UseCompatibleStateImageBehavior = false;
            this.listItems.View = System.Windows.Forms.View.Details;
            this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
            // 
            // colTen
            // 
            this.colTen.Text = "Tên sản phẩm";
            this.colTen.Width = 300;
            // 
            // colSL
            // 
            this.colSL.Text = "SL";
            this.colSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSL.Width = 70;
            // 
            // colDonGia
            // 
            this.colDonGia.Text = "Đơn giá";
            this.colDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDonGia.Width = 120;
            // 
            // colThanhTien
            // 
            this.colThanhTien.Text = "Thành tiền";
            this.colThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colThanhTien.Width = 145;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelFooter.Controls.Add(this.btnHuy);
            this.panelFooter.Controls.Add(this.btnXacNhan);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 916);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(720, 80);
            this.panelFooter.TabIndex = 10;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnHuy.Location = new System.Drawing.Point(380, 20);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(140, 45);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(540, 20);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(140, 45);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "✓ Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // flowPayments
            // 
            this.flowPayments.AutoScroll = true;
            this.flowPayments.Location = new System.Drawing.Point(48, 374);
            this.flowPayments.Name = "flowPayments";
            this.flowPayments.Size = new System.Drawing.Size(650, 160);
            this.flowPayments.TabIndex = 11;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblKhachHang.Location = new System.Drawing.Point(36, 140);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(128, 28);
            this.lblKhachHang.TabIndex = 20;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // panelKhachHang
            // 
            this.panelKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKhachHang.Controls.Add(this.txtSDT);
            this.panelKhachHang.Controls.Add(this.btnTimKiem);
            this.panelKhachHang.Controls.Add(this.lblTenKH);
            this.panelKhachHang.Controls.Add(this.btnThemKH);
            this.panelKhachHang.Location = new System.Drawing.Point(41, 175);
            this.panelKhachHang.Name = "panelKhachHang";
            this.panelKhachHang.Size = new System.Drawing.Size(640, 85);
            this.panelKhachHang.TabIndex = 21;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSDT.ForeColor = System.Drawing.Color.Gray;
            this.txtSDT.Location = new System.Drawing.Point(15, 15);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(250, 32);
            this.txtSDT.TabIndex = 0;
            this.txtSDT.Text = "Nhập số điện thoại...";
            this.txtSDT.Enter += new System.EventHandler(this.txtSDT_Enter);
            this.txtSDT.Leave += new System.EventHandler(this.txtSDT_Leave);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(280, 15);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 32);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblTenKH
            // 
            this.lblTenKH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTenKH.Location = new System.Drawing.Point(15, 52);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(385, 25);
            this.lblTenKH.TabIndex = 2;
            this.lblTenKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThemKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemKH.FlatAppearance.BorderSize = 0;
            this.btnThemKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemKH.ForeColor = System.Drawing.Color.White;
            this.btnThemKH.Location = new System.Drawing.Point(420, 15);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(200, 32);
            this.btnThemKH.TabIndex = 3;
            this.btnThemKH.Text = "➕ Thêm khách hàng mới";
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGiamGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGiamGia.Location = new System.Drawing.Point(32, 552);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(380, 30);
            this.lblGiamGia.TabIndex = 22;
            this.lblGiamGia.Text = "Giảm giá:";
            this.lblGiamGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numGiamGia
            // 
            this.numGiamGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numGiamGia.Location = new System.Drawing.Point(540, 552);
            this.numGiamGia.Name = "numGiamGia";
            this.numGiamGia.Size = new System.Drawing.Size(100, 32);
            this.numGiamGia.TabIndex = 23;
            this.numGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGiamGia.ValueChanged += new System.EventHandler(this.numGiamGia_ValueChanged);
            // 
            // lblPhanTram
            // 
            this.lblPhanTram.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPhanTram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPhanTram.Location = new System.Drawing.Point(646, 554);
            this.lblPhanTram.Name = "lblPhanTram";
            this.lblPhanTram.Size = new System.Drawing.Size(30, 30);
            this.lblPhanTram.TabIndex = 24;
            this.lblPhanTram.Text = "%";
            this.lblPhanTram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhanTram.Click += new System.EventHandler(this.lblPhanTram_Click);
            // 
            // lblTienGiamTitle
            // 
            this.lblTienGiamTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTienGiamTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTienGiamTitle.Location = new System.Drawing.Point(36, 590);
            this.lblTienGiamTitle.Name = "lblTienGiamTitle";
            this.lblTienGiamTitle.Size = new System.Drawing.Size(380, 30);
            this.lblTienGiamTitle.TabIndex = 25;
            this.lblTienGiamTitle.Text = "Tiền giảm:";
            this.lblTienGiamTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTienGiamTitle.Click += new System.EventHandler(this.lblTienGiamTitle_Click);
            // 
            // lblTienGiamValue
            // 
            this.lblTienGiamValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTienGiamValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTienGiamValue.Location = new System.Drawing.Point(380, 590);
            this.lblTienGiamValue.Name = "lblTienGiamValue";
            this.lblTienGiamValue.Size = new System.Drawing.Size(260, 30);
            this.lblTienGiamValue.TabIndex = 26;
            this.lblTienGiamValue.Text = "- 0 đ";
            this.lblTienGiamValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(253, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nhân viên: Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(500, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Số HĐ: HD0123";
            // 
            // FormThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 996);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.listItems);
            this.Controls.Add(this.panelPaymentMethods);
            this.Controls.Add(this.lblPTTTTitle);
            this.Controls.Add(this.lblTongValue);
            this.Controls.Add(this.lblTongTitle);
            this.Controls.Add(this.lblTienGiamValue);
            this.Controls.Add(this.lblTienGiamTitle);
            this.Controls.Add(this.lblPhanTram);
            this.Controls.Add(this.numGiamGia);
            this.Controls.Add(this.lblGiamGia);
            this.Controls.Add(this.panelSep2);
            this.Controls.Add(this.tableInfo);
            this.Controls.Add(this.panelKhachHang);
            this.Controls.Add(this.lblKhachHang);
            this.Controls.Add(this.panelSep1);
            this.Controls.Add(this.labelSubTime);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.flowPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.FormThanhToan_Load);
            this.tableInfo.ResumeLayout(false);
            this.panelPaymentMethods.ResumeLayout(false);
            this.panelPaymentMethods.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelKhachHang.ResumeLayout(false);
            this.panelKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiamGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Event handlers cho các control mới
        //private void txtSDT_Enter(object sender, System.EventArgs e)
        //{
        //    if (txtSDT.Text == "Nhập số điện thoại...")
        //    {
        //        txtSDT.Text = "";
        //        txtSDT.ForeColor = System.Drawing.Color.Black;
        //    }
        //}

        //private void txtSDT_Leave(object sender, System.EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtSDT.Text))
        //    {
        //        txtSDT.Text = "Nhập số điện thoại...";
        //        txtSDT.ForeColor = System.Drawing.Color.Gray;
        //    }
        //}

        

        //private void numGiamGia_ValueChanged(object sender, System.EventArgs e)
        //{
        //    // TODO: Tính lại tổng tiền khi thay đổi % giảm giá
        //    TinhTongTien();
        //}

        //private void TinhTongTien()
        //{
        //TODO: Implement tính tổng tiền có giảm giá
        //     decimal tongTam = tienBan + tienSanPham;
        //    decimal tienGiam = tongTam * (numGiamGia.Value / 100);
        //    decimal tongCuoi = tongTam - tienGiam;

        //    lblTienGiamValue.Text = "- " + tienGiam.ToString("#,##0") + " đ";
        //    lblTongValue.Text = tongCuoi.ToString("#,##0") + " đ";
        //}

        //private void btnHuy_Click(object sender, System.EventArgs e)
        //{
        //    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        //    this.Close();
        //}

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}