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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.labelChucNgay = new System.Windows.Forms.Label();
            this.labelMoTa = new System.Windows.Forms.Label();
            this.labelChaoMung = new System.Windows.Forms.Label();
            this.panelActivities = new Guna.UI2.WinForms.Guna2Panel();
            this.gridActivities = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelActivitiesTitle = new System.Windows.Forms.Label();
            this.panelStats = new Guna.UI2.WinForms.Guna2Panel();
            this.panelKPI4 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI4Value = new System.Windows.Forms.Label();
            this.labelKPI4Title = new System.Windows.Forms.Label();
            this.panelKPI3 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI3Value = new System.Windows.Forms.Label();
            this.labelKPI3Title = new System.Windows.Forms.Label();
            this.panelKPI2 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI2Value = new System.Windows.Forms.Label();
            this.labelKPI2Title = new System.Windows.Forms.Label();
            this.panelKPI1 = new Guna.UI2.WinForms.Guna2Panel();
            this.labelKPI1Value = new System.Windows.Forms.Label();
            this.labelKPI1Title = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActivities)).BeginInit();
            this.panelStats.SuspendLayout();
            this.panelKPI4.SuspendLayout();
            this.panelKPI3.SuspendLayout();
            this.panelKPI2.SuspendLayout();
            this.panelKPI1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderRadius = 10;
            this.panelMain.Controls.Add(this.labelChucNgay);
            this.panelMain.Controls.Add(this.labelMoTa);
            this.panelMain.Controls.Add(this.labelChaoMung);
            this.panelMain.Location = new System.Drawing.Point(32, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(40);
            this.panelMain.Size = new System.Drawing.Size(827, 180);
            this.panelMain.TabIndex = 0;
            // 
            // labelChucNgay
            // 
            this.labelChucNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChucNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChucNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelChucNgay.Location = new System.Drawing.Point(40, 120);
            this.labelChucNgay.Name = "labelChucNgay";
            this.labelChucNgay.Size = new System.Drawing.Size(747, 40);
            this.labelChucNgay.TabIndex = 2;
            this.labelChucNgay.Text = "Chúc bạn một ngày làm việc hiệu quả";
            this.labelChucNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMoTa
            // 
            this.labelMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMoTa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelMoTa.Location = new System.Drawing.Point(40, 80);
            this.labelMoTa.Name = "labelMoTa";
            this.labelMoTa.Size = new System.Drawing.Size(747, 30);
            this.labelMoTa.TabIndex = 1;
            this.labelMoTa.Text = "Chào mừng bạn đến với hệ thống quản lý quán bida. Tại đây bạn có thể nhanh chóng " +
    "quản lý bàn, hàng hóa, nhân viên và các thông tin cần thiết.";
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
            // panelActivities
            // 
            this.panelActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActivities.BackColor = System.Drawing.Color.White;
            this.panelActivities.BorderRadius = 10;
            this.panelActivities.Controls.Add(this.gridActivities);
            this.panelActivities.Controls.Add(this.labelActivitiesTitle);
            this.panelActivities.Location = new System.Drawing.Point(32, 445);
            this.panelActivities.Name = "panelActivities";
            this.panelActivities.Padding = new System.Windows.Forms.Padding(30);
            this.panelActivities.Size = new System.Drawing.Size(827, 300);
            this.panelActivities.TabIndex = 2;
            // 
            // gridActivities
            // 
            this.gridActivities.AllowUserToAddRows = false;
            this.gridActivities.AllowUserToDeleteRows = false;
            this.gridActivities.AllowUserToResizeRows = false;
            this.gridActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridActivities.BackgroundColor = System.Drawing.Color.White;
            this.gridActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridActivities.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridActivities.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridActivities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridActivities.ColumnHeadersHeight = 50;
            this.gridActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridActivities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colActivity,
            this.colUser});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridActivities.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridActivities.EnableHeadersVisualStyles = false;
            this.gridActivities.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            this.gridActivities.Location = new System.Drawing.Point(30, 80);
            this.gridActivities.MultiSelect = false;
            this.gridActivities.Name = "gridActivities";
            this.gridActivities.ReadOnly = true;
            this.gridActivities.RowHeadersVisible = false;
            this.gridActivities.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.gridActivities.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridActivities.RowTemplate.Height = 40;
            this.gridActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridActivities.Size = new System.Drawing.Size(767, 190);
            this.gridActivities.TabIndex = 1;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Thời gian";
            this.colTime.MinimumWidth = 150;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colActivity
            // 
            this.colActivity.HeaderText = "Hoạt động";
            this.colActivity.MinimumWidth = 300;
            this.colActivity.Name = "colActivity";
            this.colActivity.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.HeaderText = "Người thực hiện";
            this.colUser.MinimumWidth = 150;
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // labelActivitiesTitle
            // 
            this.labelActivitiesTitle.AutoSize = true;
            this.labelActivitiesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActivitiesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelActivitiesTitle.Location = new System.Drawing.Point(30, 30);
            this.labelActivitiesTitle.Name = "labelActivitiesTitle";
            this.labelActivitiesTitle.Size = new System.Drawing.Size(242, 32);
            this.labelActivitiesTitle.TabIndex = 0;
            this.labelActivitiesTitle.Text = "Hoạt Động Gần Đây";
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStats.BackColor = System.Drawing.Color.Transparent;
            this.panelStats.Controls.Add(this.panelKPI4);
            this.panelStats.Controls.Add(this.panelKPI3);
            this.panelStats.Controls.Add(this.panelKPI2);
            this.panelStats.Controls.Add(this.panelKPI1);
            this.panelStats.Location = new System.Drawing.Point(32, 275);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(827, 150);
            this.panelStats.TabIndex = 1;
            this.panelStats.Resize += new System.EventHandler(this.panelStats_Resize);
            // 
            // panelKPI4
            // 
            this.panelKPI4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI4.BackColor = System.Drawing.Color.White;
            this.panelKPI4.BorderRadius = 10;
            this.panelKPI4.Controls.Add(this.labelKPI4Value);
            this.panelKPI4.Controls.Add(this.labelKPI4Title);
            this.panelKPI4.Location = new System.Drawing.Point(630, 0);
            this.panelKPI4.Name = "panelKPI4";
            this.panelKPI4.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI4.Size = new System.Drawing.Size(195, 130);
            this.panelKPI4.TabIndex = 3;
            // 
            // labelKPI4Value
            // 
            this.labelKPI4Value.AutoSize = true;
            this.labelKPI4Value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.labelKPI4Value.Location = new System.Drawing.Point(20, 60);
            this.labelKPI4Value.Name = "labelKPI4Value";
            this.labelKPI4Value.Size = new System.Drawing.Size(48, 28);
            this.labelKPI4Value.TabIndex = 1;
            this.labelKPI4Value.Text = "156";
            // 
            // labelKPI4Title
            // 
            this.labelKPI4Title.AutoSize = true;
            this.labelKPI4Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelKPI4Title.Location = new System.Drawing.Point(20, 20);
            this.labelKPI4Title.Name = "labelKPI4Title";
            this.labelKPI4Title.Size = new System.Drawing.Size(135, 23);
            this.labelKPI4Title.TabIndex = 0;
            this.labelKPI4Title.Text = "Tổng Sản Phẩm";
            // 
            // panelKPI3
            // 
            this.panelKPI3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI3.BackColor = System.Drawing.Color.White;
            this.panelKPI3.BorderRadius = 10;
            this.panelKPI3.Controls.Add(this.labelKPI3Value);
            this.panelKPI3.Controls.Add(this.labelKPI3Title);
            this.panelKPI3.Location = new System.Drawing.Point(420, 0);
            this.panelKPI3.Name = "panelKPI3";
            this.panelKPI3.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI3.Size = new System.Drawing.Size(195, 130);
            this.panelKPI3.TabIndex = 2;
            // 
            // labelKPI3Value
            // 
            this.labelKPI3Value.AutoSize = true;
            this.labelKPI3Value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
            this.labelKPI3Value.Location = new System.Drawing.Point(20, 60);
            this.labelKPI3Value.Name = "labelKPI3Value";
            this.labelKPI3Value.Size = new System.Drawing.Size(36, 28);
            this.labelKPI3Value.TabIndex = 1;
            this.labelKPI3Value.Text = "25";
            // 
            // labelKPI3Title
            // 
            this.labelKPI3Title.AutoSize = true;
            this.labelKPI3Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelKPI3Title.Location = new System.Drawing.Point(20, 20);
            this.labelKPI3Title.Name = "labelKPI3Title";
            this.labelKPI3Title.Size = new System.Drawing.Size(138, 23);
            this.labelKPI3Title.TabIndex = 0;
            this.labelKPI3Title.Text = "Tổng Nhân Viên";
            // 
            // panelKPI2
            // 
            this.panelKPI2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI2.BackColor = System.Drawing.Color.White;
            this.panelKPI2.BorderRadius = 10;
            this.panelKPI2.Controls.Add(this.labelKPI2Value);
            this.panelKPI2.Controls.Add(this.labelKPI2Title);
            this.panelKPI2.Location = new System.Drawing.Point(210, 0);
            this.panelKPI2.Name = "panelKPI2";
            this.panelKPI2.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI2.Size = new System.Drawing.Size(195, 130);
            this.panelKPI2.TabIndex = 1;
            // 
            // labelKPI2Value
            // 
            this.labelKPI2Value.AutoSize = true;
            this.labelKPI2Value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.labelKPI2Value.Location = new System.Drawing.Point(20, 60);
            this.labelKPI2Value.Name = "labelKPI2Value";
            this.labelKPI2Value.Size = new System.Drawing.Size(36, 28);
            this.labelKPI2Value.TabIndex = 1;
            this.labelKPI2Value.Text = "12";
            // 
            // labelKPI2Title
            // 
            this.labelKPI2Title.AutoSize = true;
            this.labelKPI2Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelKPI2Title.Location = new System.Drawing.Point(20, 20);
            this.labelKPI2Title.Name = "labelKPI2Title";
            this.labelKPI2Title.Size = new System.Drawing.Size(163, 23);
            this.labelKPI2Title.TabIndex = 0;
            this.labelKPI2Title.Text = "Bàn Đang Sử Dụng";
            // 
            // panelKPI1
            // 
            this.panelKPI1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelKPI1.BackColor = System.Drawing.Color.White;
            this.panelKPI1.BorderRadius = 10;
            this.panelKPI1.Controls.Add(this.labelKPI1Value);
            this.panelKPI1.Controls.Add(this.labelKPI1Title);
            this.panelKPI1.Location = new System.Drawing.Point(0, 0);
            this.panelKPI1.Name = "panelKPI1";
            this.panelKPI1.Padding = new System.Windows.Forms.Padding(20);
            this.panelKPI1.Size = new System.Drawing.Size(195, 130);
            this.panelKPI1.TabIndex = 0;
            // 
            // labelKPI1Value
            // 
            this.labelKPI1Value.AutoSize = true;
            this.labelKPI1Value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(213)))), ((int)(((byte)(115)))));
            this.labelKPI1Value.Location = new System.Drawing.Point(20, 60);
            this.labelKPI1Value.Name = "labelKPI1Value";
            this.labelKPI1Value.Size = new System.Drawing.Size(143, 28);
            this.labelKPI1Value.TabIndex = 1;
            this.labelKPI1Value.Text = "125,500,000₫";
            // 
            // labelKPI1Title
            // 
            this.labelKPI1Title.AutoSize = true;
            this.labelKPI1Title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKPI1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelKPI1Title.Location = new System.Drawing.Point(20, 20);
            this.labelKPI1Title.Name = "labelKPI1Title";
            this.labelKPI1Title.Size = new System.Drawing.Size(143, 23);
            this.labelKPI1Title.TabIndex = 0;
            this.labelKPI1Title.Text = "Tổng Doanh Thu";
            // 
            // FormDashBoardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(891, 780);
            this.Controls.Add(this.panelActivities);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashBoardAdmin";
            this.Text = "Dashboard";
            this.panelMain.ResumeLayout(false);
            this.panelActivities.ResumeLayout(false);
            this.panelActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActivities)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.panelKPI4.ResumeLayout(false);
            this.panelKPI4.PerformLayout();
            this.panelKPI3.ResumeLayout(false);
            this.panelKPI3.PerformLayout();
            this.panelKPI2.ResumeLayout(false);
            this.panelKPI2.PerformLayout();
            this.panelKPI1.ResumeLayout(false);
            this.panelKPI1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label labelChaoMung;
        private System.Windows.Forms.Label labelMoTa;
        private System.Windows.Forms.Label labelChucNgay;
        private Guna.UI2.WinForms.Guna2Panel panelStats;
        private Guna.UI2.WinForms.Guna2Panel panelKPI1;
        private System.Windows.Forms.Label labelKPI1Title;
        private System.Windows.Forms.Label labelKPI1Value;
        private Guna.UI2.WinForms.Guna2Panel panelKPI2;
        private System.Windows.Forms.Label labelKPI2Title;
        private System.Windows.Forms.Label labelKPI2Value;
        private Guna.UI2.WinForms.Guna2Panel panelKPI3;
        private System.Windows.Forms.Label labelKPI3Title;
        private System.Windows.Forms.Label labelKPI3Value;
        private Guna.UI2.WinForms.Guna2Panel panelKPI4;
        private System.Windows.Forms.Label labelKPI4Title;
        private System.Windows.Forms.Label labelKPI4Value;
        private Guna.UI2.WinForms.Guna2Panel panelActivities;
        private System.Windows.Forms.Label labelActivitiesTitle;
        private System.Windows.Forms.DataGridView gridActivities;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
    }
}
