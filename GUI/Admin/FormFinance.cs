using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// Thêm thư viện biểu đồ
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyBida.BLL;
using QuanLyBida.DTO;
using QuanLyBida.GUI.Admin; // Để gọi FormXuatBaoCao nếu cần

namespace GUI.Admin
{
    public partial class FormFinance : Form
    {
        // Khởi tạo BLL
        private readonly PhieuThuChiBLL _bll = new PhieuThuChiBLL();

        // Các hằng số giao diện (Giữ nguyên code cũ của bạn)
        private const int KPI_PANEL_MIN_WIDTH = 240;
        private const int KPI_PANEL_SPACING = 15;
        private const int KPI_PANEL_HEIGHT = 130;
        private const int KPI_PANEL_START_X = 26;
        private const int KPI_PANEL_START_Y = 75;

        public FormFinance()
        {
            InitializeComponent();
            RegisterEvents();
            this.Resize += FormFinance_Resize;
            this.Load += FormFinance_Load; // Thêm sự kiện Load
        }

        private void FormFinance_Load(object sender, EventArgs e)
        {
            AdjustKPIPanels();
            LoadDashboardData(); // Hàm tải dữ liệu chính
        }

        // --- PHẦN XỬ LÝ DỮ LIỆU ---

        private void LoadDashboardData()
        {
            try
            {
                // 1. Xác định thời gian (Tháng này và Tháng trước)
                DateTime now = DateTime.Now;
                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1);

                DateTime startOfLastMonth = startOfMonth.AddMonths(-1);
                DateTime endOfLastMonth = startOfMonth.AddSeconds(-1);

                // 2. Lấy số liệu từ BLL
                decimal thuThangNay = _bll.TinhTongThu(startOfMonth, endOfMonth);
                decimal thuThangTruoc = _bll.TinhTongThu(startOfLastMonth, endOfLastMonth);

                decimal chiThangNay = _bll.TinhTongChi(startOfMonth, endOfMonth);
                decimal chiThangTruoc = _bll.TinhTongChi(startOfLastMonth, endOfLastMonth);

                decimal loiNhuanThangNay = thuThangNay - chiThangNay;
                decimal loiNhuanThangTruoc = thuThangTruoc - chiThangTruoc;

                // 3. Cập nhật UI cho các KPI
                // KPI 1: Tổng Thu
                UpdateKPI(labelKPI1Value, labelKPI1Trend, thuThangNay, thuThangTruoc, true);

                // KPI 2: Tổng Chi
                UpdateKPI(labelKPI2Value, labelKPI2Trend, chiThangNay, chiThangTruoc, false); // Chi tăng là Xấu (False)

                // KPI 3: Lợi Nhuận
                UpdateKPI(labelKPI3Value, labelKPI3Trend, loiNhuanThangNay, loiNhuanThangTruoc, true);

                // KPI 4: Doanh thu trung bình/ngày (Ví dụ)
                int daysPassed = now.Day;
                decimal avgRevenue = daysPassed > 0 ? thuThangNay / daysPassed : 0;
                labelKPI4Value.Text = string.Format("{0:N0}₫", avgRevenue);
                labelKPI4Desc.Text = "Trung bình ngày (Tháng này)";

                // 4. Load Biểu đồ và Grid
                LoadChart();
                LoadTransactionGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu tài chính: " + ex.Message);
            }
        }

        private void UpdateKPI(Label lblValue, Label lblTrend, decimal current, decimal last, bool isPositiveGood)
        {
            // Hiển thị giá trị tiền tệ
            lblValue.Text = string.Format("{0:N0}₫", current);

            // Tính % tăng trưởng
            double percent = 0;
            if (last > 0)
                percent = (double)((current - last) / last) * 100;
            else if (current > 0)
                percent = 100; // Nếu tháng trước 0, tháng này có tiền là tăng 100%

            // Xác định mũi tên và màu sắc
            string arrow = percent >= 0 ? "↑" : "↓";
            lblTrend.Text = $"{arrow} {Math.Abs(percent):F1}% so với tháng trước";

            // Logic màu: 
            // Nếu isPositiveGood = true (Thu, Lợi nhuận): Tăng là Xanh, Giảm là Đỏ
            // Nếu isPositiveGood = false (Chi): Tăng là Đỏ, Giảm là Xanh
            bool isGood = isPositiveGood ? (percent >= 0) : (percent <= 0);

            Color goodColor = Color.Green;
            Color badColor = Color.FromArgb(192, 0, 0); // Đỏ đậm

            lblTrend.ForeColor = isGood ? goodColor : badColor;
            lblValue.ForeColor = isGood ? goodColor : badColor;
        }

        private void LoadChart()
        {
            // Xóa các control cũ trong panel (trừ label tiêu đề)
            var controlsToRemove = new List<Control>();
            foreach (Control c in panelChart.Controls)
            {
                if (c != labelChartTitle) controlsToRemove.Add(c);
            }
            foreach (Control c in controlsToRemove) panelChart.Controls.Remove(c);

            // Tạo Chart mới bằng Code
            Chart chart = new Chart();
            chart.Dock = DockStyle.Bottom;
            chart.Height = panelChart.Height - 40;

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            chart.ChartAreas.Add(area);

            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(92, 124, 250); // Màu xanh dương
            series.IsValueShownAsLabel = true;

            // Lấy dữ liệu 7 ngày gần nhất
            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddDays(-6);

            // Lấy toàn bộ phiếu trong khoảng thời gian này
            var listPhieu = _bll.LayDanhSachPhieu(startDate, endDate);

            // Group by theo ngày để tính tổng thu từng ngày
            var dataChart = listPhieu
                .Where(p => p.LoaiPhieu == "Thu" || p.LoaiPhieu == "THU")
                .GroupBy(p => p.NgayTao.Date)
                .ToDictionary(g => g.Key, g => g.Sum(p => p.SoTien));

            // Đổ dữ liệu vào Chart (đảm bảo hiện đủ 7 ngày kể cả ngày ko có doanh thu)
            for (int i = 6; i >= 0; i--)
            {
                DateTime date = endDate.Date.AddDays(-i);
                decimal value = dataChart.ContainsKey(date) ? dataChart[date] : 0;
                series.Points.AddXY(date.ToString("dd/MM"), value);
            }

            chart.Series.Add(series);
            panelChart.Controls.Add(chart);
        }

        // Trong FormFinance.cs

        private void LoadTransactionGrid()
        {
            // Lấy danh sách phiếu (DAL đã tự lấy tên NV rồi)
            var list = _bll.LayDanhSachPhieu();

            gridTransactions.Rows.Clear();
            foreach (var item in list)
            {
                int index = gridTransactions.Rows.Add();
                var row = gridTransactions.Rows[index];

                row.Cells["colNgay"].Value = item.NgayTao.ToString("dd/MM/yyyy HH:mm");
                row.Cells["colLoai"].Value = item.LoaiPhieu;
                row.Cells["colMoTa"].Value = item.LyDo;
                row.Cells["colSoTien"].Value = string.Format("{0:N0}₫", item.SoTien);

                // 🔥 SỬA: Hiển thị tên nhân viên thay vì mã
                row.Cells["colNguoiThucHien"].Value = item.TenNhanVien;

                // Tô màu: Thu màu Xanh, Chi màu Đỏ
                if (item.LoaiPhieu.ToUpper() == "THU")
                {
                    row.Cells["colSoTien"].Style.ForeColor = Color.Green;
                    row.Cells["colLoai"].Style.ForeColor = Color.Green;
                }
                else
                {
                    row.Cells["colSoTien"].Style.ForeColor = Color.Red;
                    row.Cells["colLoai"].Style.ForeColor = Color.Red;
                }
            }
        }
        // --- CÁC SỰ KIỆN NÚT BẤM (GIỮ NGUYÊN LOGIC CỦA BẠN) ---

        private void RegisterEvents()
        {
            this.buttonAddIncome.Click += ButtonAddIncome_Click;
            this.buttonAddExpense.Click += ButtonAddExpense_Click;
            this.buttonExportReport.Click += ButtonExportReport_Click;
        }

        private void ButtonAddIncome_Click(object sender, EventArgs e)
        {
            using (var form = new FormPhieuThuAdmin())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDashboardData(); // Reload lại dữ liệu sau khi thêm
                }
            }
        }

        private void ButtonAddExpense_Click(object sender, EventArgs e)
        {
            using (var form = new FormPhieuChiAdmin())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDashboardData(); // Reload lại dữ liệu sau khi thêm
                }
            }
        }

        private void ButtonExportReport_Click(object sender, EventArgs e)
        {
            // Logic tìm form cha để mở tab báo cáo (giữ nguyên code của bạn)
            Form mainForm = null;
            if (this.TopLevelControl is Form topForm) mainForm = topForm;

            if (mainForm == null || !(mainForm is QuanLyBida.GUI.Admin.FormMainAdmin))
            {
                Control parent = this.Parent;
                while (parent != null)
                {
                    if (parent is QuanLyBida.GUI.Admin.FormMainAdmin adminForm)
                    {
                        adminForm.LoadFormToPanel(new FormXuatbaocao());
                        return;
                    }
                    parent = parent.Parent;
                }
            }

            if (mainForm == null || !(mainForm is QuanLyBida.GUI.Admin.FormMainAdmin))
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is QuanLyBida.GUI.Admin.FormMainAdmin adminForm)
                    {
                        adminForm.LoadFormToPanel(new FormXuatbaocao());
                        return;
                    }
                }
            }

            if (mainForm is QuanLyBida.GUI.Admin.FormMainAdmin formMainAdmin)
            {
                formMainAdmin.LoadFormToPanel(new FormXuatbaocao());
            }
        }

        // --- PHẦN GIAO DIỆN / RESIZE (GIỮ NGUYÊN) ---

        private void FormFinance_Resize(object sender, EventArgs e)
        {
            AdjustKPIPanels();
        }

        private void AdjustKPIPanels()
        {
            if (this.Width <= 0) return;

            int totalWidth = this.ClientSize.Width - (KPI_PANEL_START_X * 2);
            int panelCount = 4;
            int totalSpacing = KPI_PANEL_SPACING * (panelCount - 1);
            int availableWidth = totalWidth - totalSpacing;

            int panelWidth = availableWidth / panelCount;

            if (panelWidth < KPI_PANEL_MIN_WIDTH)
            {
                panelWidth = KPI_PANEL_MIN_WIDTH;
                int requiredWidth = (panelWidth * panelCount) + totalSpacing;
                if (requiredWidth > totalWidth)
                {
                    panelWidth = (totalWidth - totalSpacing) / panelCount;
                    if (panelWidth < 150) panelWidth = 150;
                }
            }

            panelKPI1.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI1.Location = new Point(KPI_PANEL_START_X, KPI_PANEL_START_Y);

            panelKPI2.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI2.Location = new Point(KPI_PANEL_START_X + panelWidth + KPI_PANEL_SPACING, KPI_PANEL_START_Y);

            panelKPI3.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI3.Location = new Point(KPI_PANEL_START_X + (panelWidth + KPI_PANEL_SPACING) * 2, KPI_PANEL_START_Y);

            int panel4X = KPI_PANEL_START_X + (panelWidth + KPI_PANEL_SPACING) * 3;
            int panel4MaxWidth = this.ClientSize.Width - KPI_PANEL_START_X - panel4X;
            int panel4Width = Math.Min(panelWidth, panel4MaxWidth);

            panelKPI4.Size = new Size(panel4Width > 0 ? panel4Width : panelWidth, KPI_PANEL_HEIGHT);
            panelKPI4.Location = new Point(panel4X, KPI_PANEL_START_Y);
        }

        private void labelChartTitle_Click(object sender, EventArgs e) { }
    }
}