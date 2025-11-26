namespace GUI.Admin
{
    partial class FormXuatbaocao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.gridPreview = new System.Windows.Forms.DataGridView();
            this.colMaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiThuChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguoiNopNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelPreview = new System.Windows.Forms.Label();
            this.buttonCancel = new Guna.UI2.WinForms.Guna2Button();
            this.buttonExport = new Guna.UI2.WinForms.Guna2Button();
            this.dateTimePickerTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.labelToDate = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.labelFromDate = new System.Windows.Forms.Label();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.checkBoxChiTietGiaoDich = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxDoanhthu = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxTongChi = new Guna.UI2.WinForms.Guna2CheckBox();
            this.labelContent = new System.Windows.Forms.Label();
            this.radioButtonPDF = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioButtonExcel = new Guna.UI2.WinForms.Guna2RadioButton();
            this.labelFormat = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTitle.Location = new System.Drawing.Point(26, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Xuất Báo Cáo";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderRadius = 10;
            this.panelMain.Controls.Add(this.gridPreview);
            this.panelMain.Controls.Add(this.labelPreview);
            this.panelMain.Controls.Add(this.buttonCancel);
            this.panelMain.Controls.Add(this.buttonExport);
            this.panelMain.Controls.Add(this.dateTimePickerTo);
            this.panelMain.Controls.Add(this.labelToDate);
            this.panelMain.Controls.Add(this.dateTimePickerFrom);
            this.panelMain.Controls.Add(this.labelFromDate);
            this.panelMain.Controls.Add(this.labelDateRange);
            this.panelMain.Controls.Add(this.checkBoxChiTietGiaoDich);
            this.panelMain.Controls.Add(this.checkBoxDoanhthu);
            this.panelMain.Controls.Add(this.checkBoxTongChi);
            this.panelMain.Controls.Add(this.labelContent);
            this.panelMain.Controls.Add(this.radioButtonPDF);
            this.panelMain.Controls.Add(this.radioButtonExcel);
            this.panelMain.Controls.Add(this.labelFormat);
            this.panelMain.Location = new System.Drawing.Point(26, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(1002, 700);
            this.panelMain.TabIndex = 1;
            // 
            // gridPreview
            // 
            this.gridPreview.AllowUserToAddRows = false;
            this.gridPreview.AllowUserToDeleteRows = false;
            this.gridPreview.AllowUserToResizeRows = false;
            this.gridPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPreview.BackgroundColor = System.Drawing.Color.White;
            this.gridPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridPreview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridPreview.ColumnHeadersHeight = 50;
            this.gridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaPhieu,
            this.colThoiGian,
            this.colLoaiThuChi,
            this.colNguoiNopNhan,
            this.colGiaTri});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPreview.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridPreview.EnableHeadersVisualStyles = false;
            this.gridPreview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            this.gridPreview.Location = new System.Drawing.Point(30, 370);
            this.gridPreview.MultiSelect = false;
            this.gridPreview.Name = "gridPreview";
            this.gridPreview.ReadOnly = true;
            this.gridPreview.RowHeadersVisible = false;
            this.gridPreview.RowHeadersWidth = 51;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.gridPreview.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gridPreview.RowTemplate.Height = 44;
            this.gridPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPreview.Size = new System.Drawing.Size(942, 220);
            this.gridPreview.TabIndex = 16;
            // 
            // colMaPhieu
            // 
            this.colMaPhieu.HeaderText = "Mã phiếu";
            this.colMaPhieu.MinimumWidth = 120;
            this.colMaPhieu.Name = "colMaPhieu";
            this.colMaPhieu.ReadOnly = true;
            // 
            // colThoiGian
            // 
            this.colThoiGian.HeaderText = "Thời gian";
            this.colThoiGian.MinimumWidth = 150;
            this.colThoiGian.Name = "colThoiGian";
            this.colThoiGian.ReadOnly = true;
            // 
            // colLoaiThuChi
            // 
            this.colLoaiThuChi.HeaderText = "Loại thu chi";
            this.colLoaiThuChi.MinimumWidth = 150;
            this.colLoaiThuChi.Name = "colLoaiThuChi";
            this.colLoaiThuChi.ReadOnly = true;
            // 
            // colNguoiNopNhan
            // 
            this.colNguoiNopNhan.HeaderText = "Người nộp/nhận";
            this.colNguoiNopNhan.MinimumWidth = 200;
            this.colNguoiNopNhan.Name = "colNguoiNopNhan";
            this.colNguoiNopNhan.ReadOnly = true;
            // 
            // colGiaTri
            // 
            this.colGiaTri.HeaderText = "Giá trị";
            this.colGiaTri.MinimumWidth = 150;
            this.colGiaTri.Name = "colGiaTri";
            this.colGiaTri.ReadOnly = true;
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelPreview.Location = new System.Drawing.Point(30, 340);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(189, 28);
            this.labelPreview.TabIndex = 15;
            this.labelPreview.Text = "Xem trước dữ liệu:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BorderRadius = 6;
            this.buttonCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(852, 627);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Hủy";
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.BorderRadius = 6;
            this.buttonExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(650, 627);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(160, 40);
            this.buttonExport.TabIndex = 14;
            this.buttonExport.Text = "Xuất báo cáo";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.BorderRadius = 6;
            this.dateTimePickerTo.Checked = true;
            this.dateTimePickerTo.FillColor = System.Drawing.Color.White;
            this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(280, 300);
            this.dateTimePickerTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerTo.TabIndex = 13;
            this.dateTimePickerTo.Value = new System.DateTime(2025, 11, 25, 0, 0, 0, 0);
            // 
            // labelToDate
            // 
            this.labelToDate.AutoSize = true;
            this.labelToDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelToDate.Location = new System.Drawing.Point(280, 275);
            this.labelToDate.Name = "labelToDate";
            this.labelToDate.Size = new System.Drawing.Size(87, 23);
            this.labelToDate.TabIndex = 12;
            this.labelToDate.Text = "Đến ngày:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.BorderRadius = 6;
            this.dateTimePickerFrom.Checked = true;
            this.dateTimePickerFrom.FillColor = System.Drawing.Color.White;
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(30, 300);
            this.dateTimePickerFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 36);
            this.dateTimePickerFrom.TabIndex = 11;
            this.dateTimePickerFrom.Value = new System.DateTime(2025, 11, 1, 0, 0, 0, 0);
            // 
            // labelFromDate
            // 
            this.labelFromDate.AutoSize = true;
            this.labelFromDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelFromDate.Location = new System.Drawing.Point(30, 275);
            this.labelFromDate.Name = "labelFromDate";
            this.labelFromDate.Size = new System.Drawing.Size(75, 23);
            this.labelFromDate.TabIndex = 10;
            this.labelFromDate.Text = "Từ ngày:";
            // 
            // labelDateRange
            // 
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelDateRange.Location = new System.Drawing.Point(30, 230);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(181, 28);
            this.labelDateRange.TabIndex = 9;
            this.labelDateRange.Text = "Khoảng thời gian:";
            // 
            // checkBoxChiTietGiaoDich
            // 
            this.checkBoxChiTietGiaoDich.AutoSize = true;
            this.checkBoxChiTietGiaoDich.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.checkBoxChiTietGiaoDich.CheckedState.BorderRadius = 3;
            this.checkBoxChiTietGiaoDich.CheckedState.BorderThickness = 0;
            this.checkBoxChiTietGiaoDich.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.checkBoxChiTietGiaoDich.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxChiTietGiaoDich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.checkBoxChiTietGiaoDich.Location = new System.Drawing.Point(30, 170);
            this.checkBoxChiTietGiaoDich.Name = "checkBoxChiTietGiaoDich";
            this.checkBoxChiTietGiaoDich.Size = new System.Drawing.Size(162, 27);
            this.checkBoxChiTietGiaoDich.TabIndex = 8;
            this.checkBoxChiTietGiaoDich.Text = "Chi tiết giao dịch";
            this.checkBoxChiTietGiaoDich.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkBoxChiTietGiaoDich.UncheckedState.BorderRadius = 3;
            this.checkBoxChiTietGiaoDich.UncheckedState.BorderThickness = 2;
            this.checkBoxChiTietGiaoDich.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.checkBoxChiTietGiaoDich.CheckedChanged += new System.EventHandler(this.checkBoxChiTietGiaoDich_CheckedChanged);
            // 
            // checkBoxDoanhthu
            // 
            this.checkBoxDoanhthu.AutoSize = true;
            this.checkBoxDoanhthu.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.checkBoxDoanhthu.CheckedState.BorderRadius = 3;
            this.checkBoxDoanhthu.CheckedState.BorderThickness = 0;
            this.checkBoxDoanhthu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.checkBoxDoanhthu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxDoanhthu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.checkBoxDoanhthu.Location = new System.Drawing.Point(385, 170);
            this.checkBoxDoanhthu.Name = "checkBoxDoanhthu";
            this.checkBoxDoanhthu.Size = new System.Drawing.Size(114, 27);
            this.checkBoxDoanhthu.TabIndex = 7;
            this.checkBoxDoanhthu.Text = "Doanh thu";
            this.checkBoxDoanhthu.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkBoxDoanhthu.UncheckedState.BorderRadius = 3;
            this.checkBoxDoanhthu.UncheckedState.BorderThickness = 2;
            this.checkBoxDoanhthu.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            // 
            // checkBoxTongChi
            // 
            this.checkBoxTongChi.AutoSize = true;
            this.checkBoxTongChi.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.checkBoxTongChi.CheckedState.BorderRadius = 3;
            this.checkBoxTongChi.CheckedState.BorderThickness = 0;
            this.checkBoxTongChi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.checkBoxTongChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxTongChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.checkBoxTongChi.Location = new System.Drawing.Point(229, 170);
            this.checkBoxTongChi.Name = "checkBoxTongChi";
            this.checkBoxTongChi.Size = new System.Drawing.Size(98, 27);
            this.checkBoxTongChi.TabIndex = 6;
            this.checkBoxTongChi.Text = "Tổng chi";
            this.checkBoxTongChi.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.checkBoxTongChi.UncheckedState.BorderRadius = 3;
            this.checkBoxTongChi.UncheckedState.BorderThickness = 2;
            this.checkBoxTongChi.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelContent.Location = new System.Drawing.Point(30, 130);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(185, 28);
            this.labelContent.TabIndex = 4;
            this.labelContent.Text = "Nội dung báo cáo:";
            // 
            // radioButtonPDF
            // 
            this.radioButtonPDF.AutoSize = true;
            this.radioButtonPDF.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.radioButtonPDF.CheckedState.BorderThickness = 0;
            this.radioButtonPDF.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.radioButtonPDF.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioButtonPDF.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioButtonPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.radioButtonPDF.Location = new System.Drawing.Point(130, 70);
            this.radioButtonPDF.Name = "radioButtonPDF";
            this.radioButtonPDF.Size = new System.Drawing.Size(61, 27);
            this.radioButtonPDF.TabIndex = 2;
            this.radioButtonPDF.Text = "PDF";
            this.radioButtonPDF.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioButtonPDF.UncheckedState.BorderThickness = 2;
            this.radioButtonPDF.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioButtonPDF.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radioButtonExcel
            // 
            this.radioButtonExcel.AutoSize = true;
            this.radioButtonExcel.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.radioButtonExcel.CheckedState.BorderThickness = 0;
            this.radioButtonExcel.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.radioButtonExcel.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioButtonExcel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioButtonExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.radioButtonExcel.Location = new System.Drawing.Point(30, 70);
            this.radioButtonExcel.Name = "radioButtonExcel";
            this.radioButtonExcel.Size = new System.Drawing.Size(69, 27);
            this.radioButtonExcel.TabIndex = 1;
            this.radioButtonExcel.Text = "Excel";
            this.radioButtonExcel.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioButtonExcel.UncheckedState.BorderThickness = 2;
            this.radioButtonExcel.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioButtonExcel.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelFormat.Location = new System.Drawing.Point(30, 30);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(152, 28);
            this.labelFormat.TabIndex = 0;
            this.labelFormat.Text = "Định dạng file:";
            // 
            // FormXuatbaocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1054, 800);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormXuatbaocao";
            this.Text = "Xuất Báo Cáo";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label labelFormat;
        private Guna.UI2.WinForms.Guna2RadioButton radioButtonExcel;
        private Guna.UI2.WinForms.Guna2RadioButton radioButtonPDF;
        private System.Windows.Forms.Label labelContent;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxTongChi;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxDoanhthu;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxChiTietGiaoDich;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.Label labelFromDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePickerTo;
        private Guna.UI2.WinForms.Guna2Button buttonExport;
        private Guna.UI2.WinForms.Guna2Button buttonCancel;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.DataGridView gridPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiThuChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguoiNopNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTri;
    }
}
