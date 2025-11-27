namespace QuanLyBida.GUI.Main
{
    partial class FormTrangchu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.layoutTopCards = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.lblDesc1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.lblDesc3 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle4 = new System.Windows.Forms.Label();
            this.lblValue4 = new System.Windows.Forms.Label();
            this.lblDesc4 = new System.Windows.Forms.Label();
            this.layoutCharts = new System.Windows.Forms.TableLayoutPanel();
            this.panelChart1 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTitle1 = new System.Windows.Forms.Label();
            this.panelChart2 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartTyLe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTitle2 = new System.Windows.Forms.Label();
            this.panelTable = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.layoutMain.SuspendLayout();
            this.layoutTopCards.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.layoutCharts.SuspendLayout();
            this.panelChart1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panelChart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTyLe)).BeginInit();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.layoutTopCards, 0, 0);
            this.layoutMain.Controls.Add(this.layoutCharts, 0, 1);
            this.layoutMain.Controls.Add(this.panelTable, 0, 2);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(12, 64);
            this.layoutMain.MinimumSize = new System.Drawing.Size(960, 650);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 3;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.layoutMain.Size = new System.Drawing.Size(976, 674);
            this.layoutMain.TabIndex = 1;
            // 
            // layoutTopCards
            // 
            this.layoutTopCards.ColumnCount = 4;
            this.layoutTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTopCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutTopCards.Controls.Add(this.guna2Panel1, 0, 0);
            this.layoutTopCards.Controls.Add(this.guna2Panel2, 1, 0);
            this.layoutTopCards.Controls.Add(this.guna2Panel3, 2, 0);
            this.layoutTopCards.Controls.Add(this.guna2Panel4, 3, 0);
            this.layoutTopCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTopCards.Location = new System.Drawing.Point(3, 3);
            this.layoutTopCards.Name = "layoutTopCards";
            this.layoutTopCards.RowCount = 1;
            this.layoutTopCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutTopCards.Size = new System.Drawing.Size(970, 144);
            this.layoutTopCards.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 15;
            this.guna2Panel1.Controls.Add(this.lblTitle1);
            this.guna2Panel1.Controls.Add(this.lblValue1);
            this.guna2Panel1.Controls.Add(this.lblDesc1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(232, 134);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.BackColor = System.Drawing.Color.White;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTitle1.Location = new System.Drawing.Point(15, 15);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(200, 23);
            this.lblTitle1.TabIndex = 0;
            this.lblTitle1.Text = "DOANH THU HÔM NAY";
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.BackColor = System.Drawing.Color.White;
            this.lblValue1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblValue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblValue1.Location = new System.Drawing.Point(15, 40);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(163, 38);
            this.lblValue1.TabIndex = 1;
            this.lblValue1.Text = "2.450.000đ";
            // 
            // lblDesc1
            // 
            this.lblDesc1.AutoSize = true;
            this.lblDesc1.BackColor = System.Drawing.Color.White;
            this.lblDesc1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc1.ForeColor = System.Drawing.Color.Green;
            this.lblDesc1.Location = new System.Drawing.Point(15, 95);
            this.lblDesc1.Name = "lblDesc1";
            this.lblDesc1.Size = new System.Drawing.Size(165, 20);
            this.lblDesc1.TabIndex = 2;
            this.lblDesc1.Text = "↑ 12.5% so với hôm qua";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.Controls.Add(this.lblTitle2);
            this.guna2Panel2.Controls.Add(this.lblValue2);
            this.guna2Panel2.Controls.Add(this.lblDesc2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(247, 0);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(232, 134);
            this.guna2Panel2.TabIndex = 1;
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.BackColor = System.Drawing.Color.White;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTitle2.Location = new System.Drawing.Point(15, 15);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(210, 23);
            this.lblTitle2.TabIndex = 0;
            this.lblTitle2.Text = "BÀN ĐANG HOẠT ĐỘNG";
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.BackColor = System.Drawing.Color.White;
            this.lblValue2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblValue2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblValue2.Location = new System.Drawing.Point(15, 40);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(77, 38);
            this.lblValue2.TabIndex = 1;
            this.lblValue2.Text = "8/12";
            // 
            // lblDesc2
            // 
            this.lblDesc2.AutoSize = true;
            this.lblDesc2.BackColor = System.Drawing.Color.White;
            this.lblDesc2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc2.ForeColor = System.Drawing.Color.Green;
            this.lblDesc2.Location = new System.Drawing.Point(15, 95);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(167, 20);
            this.lblDesc2.TabIndex = 2;
            this.lblDesc2.Text = "↑ 1 bàn so với 1 giờ qua";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderRadius = 15;
            this.guna2Panel3.Controls.Add(this.lblTitle3);
            this.guna2Panel3.Controls.Add(this.lblValue3);
            this.guna2Panel3.Controls.Add(this.lblDesc3);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.FillColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(489, 0);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(232, 134);
            this.guna2Panel3.TabIndex = 2;
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.BackColor = System.Drawing.Color.White;
            this.lblTitle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTitle3.Location = new System.Drawing.Point(15, 15);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(172, 23);
            this.lblTitle3.TabIndex = 0;
            this.lblTitle3.Text = "ĐẶT BÀN HÔM NAY";
            // 
            // lblValue3
            // 
            this.lblValue3.AutoSize = true;
            this.lblValue3.BackColor = System.Drawing.Color.White;
            this.lblValue3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblValue3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblValue3.Location = new System.Drawing.Point(15, 40);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(49, 38);
            this.lblValue3.TabIndex = 1;
            this.lblValue3.Text = "15";
            // 
            // lblDesc3
            // 
            this.lblDesc3.AutoSize = true;
            this.lblDesc3.BackColor = System.Drawing.Color.White;
            this.lblDesc3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc3.ForeColor = System.Drawing.Color.Green;
            this.lblDesc3.Location = new System.Drawing.Point(15, 95);
            this.lblDesc3.Name = "lblDesc3";
            this.lblDesc3.Size = new System.Drawing.Size(158, 20);
            this.lblDesc3.TabIndex = 2;
            this.lblDesc3.Text = "↑ 3 lần so với hôm qua";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BorderRadius = 15;
            this.guna2Panel4.Controls.Add(this.lblTitle4);
            this.guna2Panel4.Controls.Add(this.lblValue4);
            this.guna2Panel4.Controls.Add(this.lblDesc4);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.FillColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(736, 0);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(234, 134);
            this.guna2Panel4.TabIndex = 3;
            // 
            // lblTitle4
            // 
            this.lblTitle4.AutoSize = true;
            this.lblTitle4.BackColor = System.Drawing.Color.White;
            this.lblTitle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTitle4.Location = new System.Drawing.Point(15, 15);
            this.lblTitle4.Name = "lblTitle4";
            this.lblTitle4.Size = new System.Drawing.Size(125, 23);
            this.lblTitle4.TabIndex = 0;
            this.lblTitle4.Text = "KHÁCH HÀNG";
            // 
            // lblValue4
            // 
            this.lblValue4.AutoSize = true;
            this.lblValue4.BackColor = System.Drawing.Color.White;
            this.lblValue4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblValue4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblValue4.Location = new System.Drawing.Point(15, 40);
            this.lblValue4.Name = "lblValue4";
            this.lblValue4.Size = new System.Drawing.Size(49, 38);
            this.lblValue4.TabIndex = 1;
            this.lblValue4.Text = "42";
            // 
            // lblDesc4
            // 
            this.lblDesc4.AutoSize = true;
            this.lblDesc4.BackColor = System.Drawing.Color.White;
            this.lblDesc4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesc4.ForeColor = System.Drawing.Color.Green;
            this.lblDesc4.Location = new System.Drawing.Point(15, 95);
            this.lblDesc4.Name = "lblDesc4";
            this.lblDesc4.Size = new System.Drawing.Size(108, 20);
            this.lblDesc4.TabIndex = 2;
            this.lblDesc4.Text = "↑ 15 khách mới";
            // 
            // layoutCharts
            // 
            this.layoutCharts.ColumnCount = 2;
            this.layoutCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutCharts.Controls.Add(this.panelChart1, 0, 0);
            this.layoutCharts.Controls.Add(this.panelChart2, 1, 0);
            this.layoutCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutCharts.Location = new System.Drawing.Point(3, 153);
            this.layoutCharts.Name = "layoutCharts";
            this.layoutCharts.RowCount = 1;
            this.layoutCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutCharts.Size = new System.Drawing.Size(970, 282);
            this.layoutCharts.TabIndex = 1;
            // 
            // panelChart1
            // 
            this.panelChart1.BorderRadius = 15;
            this.panelChart1.Controls.Add(this.chartDoanhThu);
            this.panelChart1.Controls.Add(this.lblChartTitle1);
            this.panelChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart1.FillColor = System.Drawing.Color.White;
            this.panelChart1.Location = new System.Drawing.Point(0, 0);
            this.panelChart1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panelChart1.Name = "panelChart1";
            this.panelChart1.Padding = new System.Windows.Forms.Padding(10);
            this.panelChart1.Size = new System.Drawing.Size(475, 272);
            this.panelChart1.TabIndex = 0;
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Location = new System.Drawing.Point(10, 40);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            series1.Name = "DoanhThu";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(455, 222);
            this.chartDoanhThu.TabIndex = 5;
            // 
            // lblChartTitle1
            // 
            this.lblChartTitle1.BackColor = System.Drawing.Color.White;
            this.lblChartTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle1.Location = new System.Drawing.Point(10, 10);
            this.lblChartTitle1.Name = "lblChartTitle1";
            this.lblChartTitle1.Size = new System.Drawing.Size(455, 30);
            this.lblChartTitle1.TabIndex = 6;
            this.lblChartTitle1.Text = "📊 Doanh Thu 7 Ngày Gần Nhất";
            this.lblChartTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelChart2
            // 
            this.panelChart2.BorderRadius = 15;
            this.panelChart2.Controls.Add(this.chartTyLe);
            this.panelChart2.Controls.Add(this.lblChartTitle2);
            this.panelChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart2.FillColor = System.Drawing.Color.White;
            this.panelChart2.Location = new System.Drawing.Point(490, 0);
            this.panelChart2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 10);
            this.panelChart2.Name = "panelChart2";
            this.panelChart2.Padding = new System.Windows.Forms.Padding(10);
            this.panelChart2.Size = new System.Drawing.Size(480, 272);
            this.panelChart2.TabIndex = 1;
            // 
            // chartTyLe
            // 
            chartArea2.Name = "ChartArea2";
            this.chartTyLe.ChartAreas.Add(chartArea2);
            this.chartTyLe.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Segoe UI", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "LegendTyLe";
            this.chartTyLe.Legends.Add(legend1);
            this.chartTyLe.Location = new System.Drawing.Point(10, 40);
            this.chartTyLe.Name = "chartTyLe";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "LegendTyLe";
            series2.Name = "TyLe";
            this.chartTyLe.Series.Add(series2);
            this.chartTyLe.Size = new System.Drawing.Size(460, 222);
            this.chartTyLe.TabIndex = 7;
            // 
            // lblChartTitle2
            // 
            this.lblChartTitle2.BackColor = System.Drawing.Color.White;
            this.lblChartTitle2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle2.Location = new System.Drawing.Point(10, 10);
            this.lblChartTitle2.Name = "lblChartTitle2";
            this.lblChartTitle2.Size = new System.Drawing.Size(460, 30);
            this.lblChartTitle2.TabIndex = 8;
            this.lblChartTitle2.Text = "🥧 Tỷ Lệ Sử Dụng Bàn";
            this.lblChartTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTable
            // 
            this.panelTable.BorderRadius = 15;
            this.panelTable.Controls.Add(this.dgvDanhSach);
            this.panelTable.Controls.Add(this.lblTableTitle);
            this.panelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTable.FillColor = System.Drawing.Color.White;
            this.panelTable.Location = new System.Drawing.Point(0, 438);
            this.panelTable.Margin = new System.Windows.Forms.Padding(0);
            this.panelTable.Name = "panelTable";
            this.panelTable.Padding = new System.Windows.Forms.Padding(10);
            this.panelTable.Size = new System.Drawing.Size(976, 236);
            this.panelTable.TabIndex = 2;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.AllowUserToResizeRows = false;
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSach.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSach.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeight = 50;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.EnableHeadersVisualStyles = false;
            this.dgvDanhSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            this.dgvDanhSach.Location = new System.Drawing.Point(10, 45);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDanhSach.RowTemplate.Height = 44;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(956, 181);
            this.dgvDanhSach.TabIndex = 9;
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.BackColor = System.Drawing.Color.White;
            this.lblTableTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTableTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(956, 35);
            this.lblTableTitle.TabIndex = 10;
            this.lblTableTitle.Text = "📋 Danh Sách Đặt Bàn Hôm Nay";
            this.lblTableTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblPageTitle.Location = new System.Drawing.Point(12, 12);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.lblPageTitle.Size = new System.Drawing.Size(142, 52);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Trang chủ";
            // 
            // FormTrangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.layoutMain);
            this.Controls.Add(this.lblPageTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTrangchu";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "Trang Chủ";
            this.layoutMain.ResumeLayout(false);
            this.layoutTopCards.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.layoutCharts.ResumeLayout(false);
            this.panelChart1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panelChart2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTyLe)).EndInit();
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.TableLayoutPanel layoutTopCards;
        private System.Windows.Forms.TableLayoutPanel layoutCharts;
        private System.Windows.Forms.Label lblPageTitle;
        
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel panelChart1;
        private Guna.UI2.WinForms.Guna2Panel panelChart2;
        private Guna.UI2.WinForms.Guna2Panel panelTable;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTyLe;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.Label lblDesc1;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Label lblDesc2;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.Label lblDesc3;
        private System.Windows.Forms.Label lblTitle4;
        private System.Windows.Forms.Label lblValue4;
        private System.Windows.Forms.Label lblDesc4;
        private System.Windows.Forms.Label lblChartTitle1;
        private System.Windows.Forms.Label lblChartTitle2;
        private System.Windows.Forms.Label lblTableTitle;

        // Khai báo các cột
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
    }
}