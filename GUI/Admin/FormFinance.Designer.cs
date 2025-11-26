namespace GUI.Admin
{
    partial class FormFinance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelKPI1 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI1Value = new System.Windows.Forms.Label();
            this.labelKPI1Trend = new System.Windows.Forms.Label();
            this.labelKPI1Title = new System.Windows.Forms.Label();
            this.panelKPI2 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI2Value = new System.Windows.Forms.Label();
            this.labelKPI2Trend = new System.Windows.Forms.Label();
            this.labelKPI2Title = new System.Windows.Forms.Label();
            this.panelKPI3 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI3Value = new System.Windows.Forms.Label();
            this.labelKPI3Trend = new System.Windows.Forms.Label();
            this.labelKPI3Title = new System.Windows.Forms.Label();
            this.panelKPI4 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI4Value = new System.Windows.Forms.Label();
            this.labelKPI4Desc = new System.Windows.Forms.Label();
            this.labelKPI4Title = new System.Windows.Forms.Label();
            this.panelChart = new Guna.UI2.WinForms.Guna2Panel();
            this.labelChartTitle = new System.Windows.Forms.Label();
            this.panelQuickActions = new Guna.UI2.WinForms.Guna2Panel();
            this.buttonExportReport = new Guna.UI2.WinForms.Guna2Button();
            this.buttonAddExpense = new Guna.UI2.WinForms.Guna2Button();
            this.buttonAddIncome = new Guna.UI2.WinForms.Guna2Button();
            this.labelQuickActionsTitle = new System.Windows.Forms.Label();
            this.gridTransactions = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguoiThucHien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTransactionsTitle = new System.Windows.Forms.Label();
            this.panelKPI1.SuspendLayout();
            this.panelKPI2.SuspendLayout();
            this.panelKPI3.SuspendLayout();
            this.panelKPI4.SuspendLayout();
            this.panelChart.SuspendLayout();
            this.panelQuickActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTitle.Location = new System.Drawing.Point(26, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(243, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Quản Lý Tài Chính";
            // 
            // panelKPI1
            // 
            this.panelKPI1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelKPI1.BorderRadius = 10;
            this.panelKPI1.Controls.Add(this.labelKPI1Value);
            this.panelKPI1.Controls.Add(this.labelKPI1Trend);
            this.panelKPI1.Controls.Add(this.labelKPI1Title);
            this.panelKPI1.Location = new System.Drawing.Point(26, 75);
            this.panelKPI1.Name = "panelKPI1";
            this.panelKPI1.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI1.Size = new System.Drawing.Size(240, 112);
            this.panelKPI1.TabIndex = 5;
            // 
            // labelKPI1Value
            // 
            this.labelKPI1Value.AutoSize = true;
            this.labelKPI1Value.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI1Value.ForeColor = System.Drawing.Color.Green;
            this.labelKPI1Value.Location = new System.Drawing.Point(20, 34);
            this.labelKPI1Value.Name = "labelKPI1Value";
            this.labelKPI1Value.Size = new System.Drawing.Size(145, 31);
            this.labelKPI1Value.TabIndex = 2;
            this.labelKPI1Value.Text = "45,850,000₫";
            // 
            // labelKPI1Trend
            // 
            this.labelKPI1Trend.AutoSize = true;
            this.labelKPI1Trend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI1Trend.ForeColor = System.Drawing.Color.Green;
            this.labelKPI1Trend.Location = new System.Drawing.Point(20, 73);
            this.labelKPI1Trend.Name = "labelKPI1Trend";
            this.labelKPI1Trend.Size = new System.Drawing.Size(183, 20);
            this.labelKPI1Trend.TabIndex = 1;
            this.labelKPI1Trend.Text = "↑ 12.5% so với tháng trước";
            // 
            // labelKPI1Title
            // 
            this.labelKPI1Title.AutoSize = true;
            this.labelKPI1Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelKPI1Title.Location = new System.Drawing.Point(20, 5);
            this.labelKPI1Title.Name = "labelKPI1Title";
            this.labelKPI1Title.Size = new System.Drawing.Size(111, 25);
            this.labelKPI1Title.TabIndex = 0;
            this.labelKPI1Title.Text = "TỔNG THU";
            // 
            // panelKPI2
            // 
            this.panelKPI2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelKPI2.BorderRadius = 10;
            this.panelKPI2.Controls.Add(this.labelKPI2Value);
            this.panelKPI2.Controls.Add(this.labelKPI2Trend);
            this.panelKPI2.Controls.Add(this.labelKPI2Title);
            this.panelKPI2.Location = new System.Drawing.Point(280, 75);
            this.panelKPI2.Name = "panelKPI2";
            this.panelKPI2.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI2.Size = new System.Drawing.Size(240, 112);
            this.panelKPI2.TabIndex = 6;
            // 
            // labelKPI2Value
            // 
            this.labelKPI2Value.AutoSize = true;
            this.labelKPI2Value.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelKPI2Value.Location = new System.Drawing.Point(20, 35);
            this.labelKPI2Value.Name = "labelKPI2Value";
            this.labelKPI2Value.Size = new System.Drawing.Size(145, 31);
            this.labelKPI2Value.TabIndex = 2;
            this.labelKPI2Value.Text = "18,240,000₫";
            // 
            // labelKPI2Trend
            // 
            this.labelKPI2Trend.AutoSize = true;
            this.labelKPI2Trend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI2Trend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelKPI2Trend.Location = new System.Drawing.Point(20, 76);
            this.labelKPI2Trend.Name = "labelKPI2Trend";
            this.labelKPI2Trend.Size = new System.Drawing.Size(175, 20);
            this.labelKPI2Trend.TabIndex = 1;
            this.labelKPI2Trend.Text = "↑ 5.2% so với tháng trước";
            // 
            // labelKPI2Title
            // 
            this.labelKPI2Title.AutoSize = true;
            this.labelKPI2Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelKPI2Title.Location = new System.Drawing.Point(20, 5);
            this.labelKPI2Title.Name = "labelKPI2Title";
            this.labelKPI2Title.Size = new System.Drawing.Size(104, 25);
            this.labelKPI2Title.TabIndex = 0;
            this.labelKPI2Title.Text = "TỔNG CHI";
            // 
            // panelKPI3
            // 
            this.panelKPI3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelKPI3.BorderRadius = 10;
            this.panelKPI3.Controls.Add(this.labelKPI3Value);
            this.panelKPI3.Controls.Add(this.labelKPI3Trend);
            this.panelKPI3.Controls.Add(this.labelKPI3Title);
            this.panelKPI3.Location = new System.Drawing.Point(534, 75);
            this.panelKPI3.Name = "panelKPI3";
            this.panelKPI3.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI3.Size = new System.Drawing.Size(240, 112);
            this.panelKPI3.TabIndex = 7;
            // 
            // labelKPI3Value
            // 
            this.labelKPI3Value.AutoSize = true;
            this.labelKPI3Value.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI3Value.ForeColor = System.Drawing.Color.Navy;
            this.labelKPI3Value.Location = new System.Drawing.Point(20, 37);
            this.labelKPI3Value.Name = "labelKPI3Value";
            this.labelKPI3Value.Size = new System.Drawing.Size(145, 31);
            this.labelKPI3Value.TabIndex = 2;
            this.labelKPI3Value.Text = "27,610,000₫";
            // 
            // labelKPI3Trend
            // 
            this.labelKPI3Trend.AutoSize = true;
            this.labelKPI3Trend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI3Trend.ForeColor = System.Drawing.Color.Navy;
            this.labelKPI3Trend.Location = new System.Drawing.Point(20, 78);
            this.labelKPI3Trend.Name = "labelKPI3Trend";
            this.labelKPI3Trend.Size = new System.Drawing.Size(183, 20);
            this.labelKPI3Trend.TabIndex = 1;
            this.labelKPI3Trend.Text = "↑ 18.3% so với tháng trước";
            // 
            // labelKPI3Title
            // 
            this.labelKPI3Title.AutoSize = true;
            this.labelKPI3Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelKPI3Title.Location = new System.Drawing.Point(20, 5);
            this.labelKPI3Title.Name = "labelKPI3Title";
            this.labelKPI3Title.Size = new System.Drawing.Size(120, 25);
            this.labelKPI3Title.TabIndex = 0;
            this.labelKPI3Title.Text = "LỢI NHUẬN";
            // 
            // panelKPI4
            // 
            this.panelKPI4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelKPI4.BorderRadius = 10;
            this.panelKPI4.Controls.Add(this.labelKPI4Value);
            this.panelKPI4.Controls.Add(this.labelKPI4Desc);
            this.panelKPI4.Controls.Add(this.labelKPI4Title);
            this.panelKPI4.Location = new System.Drawing.Point(788, 75);
            this.panelKPI4.Name = "panelKPI4";
            this.panelKPI4.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI4.Size = new System.Drawing.Size(240, 112);
            this.panelKPI4.TabIndex = 8;
            // 
            // labelKPI4Value
            // 
            this.labelKPI4Value.AutoSize = true;
            this.labelKPI4Value.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelKPI4Value.Location = new System.Drawing.Point(20, 36);
            this.labelKPI4Value.Name = "labelKPI4Value";
            this.labelKPI4Value.Size = new System.Drawing.Size(132, 31);
            this.labelKPI4Value.TabIndex = 2;
            this.labelKPI4Value.Text = "3,820,000₫";
            // 
            // labelKPI4Desc
            // 
            this.labelKPI4Desc.AutoSize = true;
            this.labelKPI4Desc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI4Desc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelKPI4Desc.Location = new System.Drawing.Point(20, 76);
            this.labelKPI4Desc.Name = "labelKPI4Desc";
            this.labelKPI4Desc.Size = new System.Drawing.Size(128, 20);
            this.labelKPI4Desc.TabIndex = 1;
            this.labelKPI4Desc.Text = "Trung bình 12 bàn";
            // 
            // labelKPI4Title
            // 
            this.labelKPI4Title.AutoSize = true;
            this.labelKPI4Title.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelKPI4Title.Location = new System.Drawing.Point(20, 5);
            this.labelKPI4Title.Name = "labelKPI4Title";
            this.labelKPI4Title.Size = new System.Drawing.Size(176, 25);
            this.labelKPI4Title.TabIndex = 0;
            this.labelKPI4Title.Text = "DOANH THU/BÀN";
            // 
            // panelChart
            // 
            this.panelChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChart.BackColor = System.Drawing.Color.White;
            this.panelChart.BorderRadius = 10;
            this.panelChart.Controls.Add(this.labelChartTitle);
            this.panelChart.Location = new System.Drawing.Point(26, 261);
            this.panelChart.Name = "panelChart";
            this.panelChart.Padding = new System.Windows.Forms.Padding(20);
            this.panelChart.Size = new System.Drawing.Size(720, 254);
            this.panelChart.TabIndex = 9;
            // 
            // labelChartTitle
            // 
            this.labelChartTitle.AutoSize = true;
            this.labelChartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelChartTitle.Location = new System.Drawing.Point(2, 6);
            this.labelChartTitle.Name = "labelChartTitle";
            this.labelChartTitle.Size = new System.Drawing.Size(306, 28);
            this.labelChartTitle.TabIndex = 0;
            this.labelChartTitle.Text = "Biểu Đồ Doanh Thu Theo Ngày";
            this.labelChartTitle.Click += new System.EventHandler(this.labelChartTitle_Click);
            // 
            // panelQuickActions
            // 
            this.panelQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelQuickActions.BackColor = System.Drawing.Color.White;
            this.panelQuickActions.BorderRadius = 10;
            this.panelQuickActions.Controls.Add(this.buttonExportReport);
            this.panelQuickActions.Controls.Add(this.buttonAddExpense);
            this.panelQuickActions.Controls.Add(this.buttonAddIncome);
            this.panelQuickActions.Controls.Add(this.labelQuickActionsTitle);
            this.panelQuickActions.Location = new System.Drawing.Point(760, 261);
            this.panelQuickActions.Name = "panelQuickActions";
            this.panelQuickActions.Padding = new System.Windows.Forms.Padding(20);
            this.panelQuickActions.Size = new System.Drawing.Size(268, 256);
            this.panelQuickActions.TabIndex = 10;
            // 
            // buttonExportReport
            // 
            this.buttonExportReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportReport.BorderRadius = 6;
            this.buttonExportReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonExportReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonExportReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonExportReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonExportReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.buttonExportReport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportReport.ForeColor = System.Drawing.Color.White;
            this.buttonExportReport.Location = new System.Drawing.Point(17, 190);
            this.buttonExportReport.Name = "buttonExportReport";
            this.buttonExportReport.Size = new System.Drawing.Size(228, 40);
            this.buttonExportReport.TabIndex = 3;
            this.buttonExportReport.Text = "Xuất Báo Cáo";
            // 
            // buttonAddExpense
            // 
            this.buttonAddExpense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddExpense.BorderRadius = 6;
            this.buttonAddExpense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonAddExpense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonAddExpense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonAddExpense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonAddExpense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.buttonAddExpense.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddExpense.ForeColor = System.Drawing.Color.White;
            this.buttonAddExpense.Location = new System.Drawing.Point(17, 132);
            this.buttonAddExpense.Name = "buttonAddExpense";
            this.buttonAddExpense.Size = new System.Drawing.Size(228, 40);
            this.buttonAddExpense.TabIndex = 2;
            this.buttonAddExpense.Text = "- Thêm Khoản Chi";
            // 
            // buttonAddIncome
            // 
            this.buttonAddIncome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddIncome.BorderRadius = 6;
            this.buttonAddIncome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonAddIncome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonAddIncome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonAddIncome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonAddIncome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(213)))), ((int)(((byte)(115)))));
            this.buttonAddIncome.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddIncome.ForeColor = System.Drawing.Color.White;
            this.buttonAddIncome.Location = new System.Drawing.Point(17, 74);
            this.buttonAddIncome.Name = "buttonAddIncome";
            this.buttonAddIncome.Size = new System.Drawing.Size(228, 40);
            this.buttonAddIncome.TabIndex = 1;
            this.buttonAddIncome.Text = "+ Thêm Khoản Thu";
            // 
            // labelQuickActionsTitle
            // 
            this.labelQuickActionsTitle.AutoSize = true;
            this.labelQuickActionsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuickActionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelQuickActionsTitle.Location = new System.Drawing.Point(47, 20);
            this.labelQuickActionsTitle.Name = "labelQuickActionsTitle";
            this.labelQuickActionsTitle.Size = new System.Drawing.Size(165, 28);
            this.labelQuickActionsTitle.TabIndex = 0;
            this.labelQuickActionsTitle.Text = "Thao Tác Nhanh";
            // 
            // gridTransactions
            // 
            this.gridTransactions.AllowUserToAddRows = false;
            this.gridTransactions.AllowUserToDeleteRows = false;
            this.gridTransactions.AllowUserToResizeRows = false;
            this.gridTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTransactions.BackgroundColor = System.Drawing.Color.White;
            this.gridTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridTransactions.ColumnHeadersHeight = 50;
            this.gridTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgay,
            this.colLoai,
            this.colMoTa,
            this.colSoTien,
            this.colNguoiThucHien});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTransactions.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridTransactions.EnableHeadersVisualStyles = false;
            this.gridTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            this.gridTransactions.Location = new System.Drawing.Point(26, 574);
            this.gridTransactions.MultiSelect = false;
            this.gridTransactions.Name = "gridTransactions";
            this.gridTransactions.ReadOnly = true;
            this.gridTransactions.RowHeadersVisible = false;
            this.gridTransactions.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.gridTransactions.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridTransactions.RowTemplate.Height = 44;
            this.gridTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTransactions.Size = new System.Drawing.Size(1002, 397);
            this.gridTransactions.TabIndex = 12;
            // 
            // colNgay
            // 
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.MinimumWidth = 100;
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // 
            // colLoai
            // 
            this.colLoai.HeaderText = "Loại";
            this.colLoai.MinimumWidth = 80;
            this.colLoai.Name = "colLoai";
            this.colLoai.ReadOnly = true;
            // 
            // colMoTa
            // 
            this.colMoTa.HeaderText = "Mô Tả";
            this.colMoTa.MinimumWidth = 200;
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.ReadOnly = true;
            // 
            // colSoTien
            // 
            this.colSoTien.HeaderText = "Số Tiền";
            this.colSoTien.MinimumWidth = 150;
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.ReadOnly = true;
            // 
            // colNguoiThucHien
            // 
            this.colNguoiThucHien.HeaderText = "Người Thực Hiện";
            this.colNguoiThucHien.MinimumWidth = 150;
            this.colNguoiThucHien.Name = "colNguoiThucHien";
            this.colNguoiThucHien.ReadOnly = true;
            // 
            // labelTransactionsTitle
            // 
            this.labelTransactionsTitle.AutoSize = true;
            this.labelTransactionsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransactionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTransactionsTitle.Location = new System.Drawing.Point(26, 525);
            this.labelTransactionsTitle.Name = "labelTransactionsTitle";
            this.labelTransactionsTitle.Size = new System.Drawing.Size(190, 28);
            this.labelTransactionsTitle.TabIndex = 13;
            this.labelTransactionsTitle.Text = "Giao Dịch Gần Đây";
            // 
            // FormFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1054, 821);
            this.Controls.Add(this.labelTransactionsTitle);
            this.Controls.Add(this.gridTransactions);
            this.Controls.Add(this.panelQuickActions);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelKPI4);
            this.Controls.Add(this.panelKPI3);
            this.Controls.Add(this.panelKPI2);
            this.Controls.Add(this.panelKPI1);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFinance";
            this.Text = "Quản Lý Tài Chính";
            this.panelKPI1.ResumeLayout(false);
            this.panelKPI1.PerformLayout();
            this.panelKPI2.ResumeLayout(false);
            this.panelKPI2.PerformLayout();
            this.panelKPI3.ResumeLayout(false);
            this.panelKPI3.PerformLayout();
            this.panelKPI4.ResumeLayout(false);
            this.panelKPI4.PerformLayout();
            this.panelChart.ResumeLayout(false);
            this.panelChart.PerformLayout();
            this.panelQuickActions.ResumeLayout(false);
            this.panelQuickActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Panel panelKPI1;
        private System.Windows.Forms.Label labelKPI1Title;
        private System.Windows.Forms.Label labelKPI1Trend;
        private System.Windows.Forms.Label labelKPI1Value;
        private Guna.UI2.WinForms.Guna2Panel panelKPI2;
        private System.Windows.Forms.Label labelKPI2Title;
        private System.Windows.Forms.Label labelKPI2Trend;
        private System.Windows.Forms.Label labelKPI2Value;
        private Guna.UI2.WinForms.Guna2Panel panelKPI3;
        private System.Windows.Forms.Label labelKPI3Title;
        private System.Windows.Forms.Label labelKPI3Trend;
        private System.Windows.Forms.Label labelKPI3Value;
        private Guna.UI2.WinForms.Guna2Panel panelKPI4;
        private System.Windows.Forms.Label labelKPI4Title;
        private System.Windows.Forms.Label labelKPI4Desc;
        private System.Windows.Forms.Label labelKPI4Value;
        private Guna.UI2.WinForms.Guna2Panel panelChart;
        private System.Windows.Forms.Label labelChartTitle;
        private Guna.UI2.WinForms.Guna2Panel panelQuickActions;
        private System.Windows.Forms.Label labelQuickActionsTitle;
        private Guna.UI2.WinForms.Guna2Button buttonAddIncome;
        private Guna.UI2.WinForms.Guna2Button buttonAddExpense;
        private Guna.UI2.WinForms.Guna2Button buttonExportReport;
        private System.Windows.Forms.DataGridView gridTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguoiThucHien;
        private System.Windows.Forms.Label labelTransactionsTitle;
    }
}



