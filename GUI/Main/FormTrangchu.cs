using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLyBida.BLL;

namespace QuanLyBida.GUI.Main
{
    public partial class FormTrangchu : Form
    {
        private HomeBLL _bll = new HomeBLL();

        public FormTrangchu()
        {
            InitializeComponent();
            this.Load += FormTrangchu_Load;
        }

        private void FormTrangchu_Load(object sender, EventArgs e)
        {
            LoadTopCards();
            LoadChartDoanhThu();
            LoadChartTyLe();
            LoadDanhSachDatBan();
        }

        private void LoadTopCards()
        {
            try
            {
                // 1. Card Doanh Thu
                var revenueStats = _bll.GetRevenueStats();
                lblValue1.Text = string.Format("{0:N0}đ", revenueStats.TodayRevenue);
                string arrowRev = revenueStats.GrowthPercent >= 0 ? "↑" : "↓";
                Color colorRev = revenueStats.GrowthPercent >= 0 ? Color.Green : Color.Red;
                lblDesc1.Text = $"{arrowRev} {Math.Abs(revenueStats.GrowthPercent):F1}% so với hôm qua";
                lblDesc1.ForeColor = colorRev;

                // 2. Card Bàn đang hoạt động
                var tableStats = _bll.GetTableStats();
                lblValue2.Text = $"{tableStats.Active}/{tableStats.Total}";
                // Tính % sử dụng
                double usagePercent = tableStats.Total > 0 ? ((double)tableStats.Active / tableStats.Total * 100) : 0;
                lblDesc2.Text = $"Công suất: {usagePercent:F1}%";

                // 3. Card Đặt bàn
                var bookingStats = _bll.GetBookingStats();
                lblValue3.Text = bookingStats.TodayCount.ToString();
                int diff = bookingStats.TodayCount - bookingStats.YesterdayCount;
                string arrowBook = diff >= 0 ? "↑" : "↓";
                lblDesc3.Text = $"{arrowBook} {Math.Abs(diff)} lượt so với hôm qua";
                lblDesc3.ForeColor = diff >= 0 ? Color.Green : Color.OrangeRed;

                // 4. Card Khách hàng
                int totalCustomers = _bll.GetTotalCustomers();
                lblValue4.Text = totalCustomers.ToString();
                lblDesc4.Text = "Tổng khách hàng";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi load Cards: " + ex.Message);
            }
        }

        private void LoadChartDoanhThu()
        {
            try
            {
                chartDoanhThu.Series[0].Points.Clear();
                DataTable dt = _bll.GetChartRevenueData();

                // Tạo Dictionary để đảm bảo đủ 7 ngày (kể cả ngày 0 doanh thu)
                var dataMap = new Dictionary<DateTime, decimal>();
                for (int i = 6; i >= 0; i--)
                {
                    dataMap[DateTime.Today.AddDays(-i)] = 0;
                }

                // Map dữ liệu từ DB vào
                foreach (DataRow row in dt.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["Ngay"]);
                    if (dataMap.ContainsKey(date))
                    {
                        dataMap[date] = Convert.ToDecimal(row["DoanhThu"]);
                    }
                }

                // Vẽ lên chart
                foreach (var item in dataMap)
                {
                    // Hiển thị: Thứ (hoặc ngày/tháng)
                    string label = item.Key.ToString("dd/MM");
                    chartDoanhThu.Series[0].Points.AddXY(label, item.Value);
                }

                // Định dạng
                chartDoanhThu.Series[0].ChartType = SeriesChartType.Area;
                chartDoanhThu.Series[0].Color = Color.FromArgb(100, 52, 152, 219); // Màu xanh trong suốt
                chartDoanhThu.Series[0].BorderColor = Color.FromArgb(52, 152, 219);
                chartDoanhThu.Series[0].BorderWidth = 2;
                chartDoanhThu.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartDoanhThu.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:N0}"; // Format số trục Y
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi biểu đồ doanh thu: " + ex.Message);
            }
        }

        private void LoadChartTyLe()
        {
            try
            {
                chartTyLe.Series[0].Points.Clear();
                var data = _bll.GetChartTableData();

                foreach (var item in data)
                {
                    // Chỉ add nếu số lượng > 0 để biểu đồ đẹp
                    if (item.Value > 0)
                    {
                        int index = chartTyLe.Series[0].Points.AddXY(item.Key, item.Value);

                        // Tô màu theo trạng thái
                        DataPoint point = chartTyLe.Series[0].Points[index];
                        if (item.Key == "Đang sử dụng") point.Color = Color.FromArgb(46, 204, 113);
                        else if (item.Key == "Trống") point.Color = Color.FromArgb(189, 195, 199);
                        else if (item.Key == "Bảo trì") point.Color = Color.FromArgb(231, 76, 60);
                        else point.Color = Color.FromArgb(52, 152, 219); // Màu mặc định
                    }
                }

                chartTyLe.Series[0].ChartType = SeriesChartType.Doughnut;
                chartTyLe.Series[0].IsValueShownAsLabel = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi biểu đồ tỷ lệ: " + ex.Message);
            }
        }

        private void LoadDanhSachDatBan()
        {
            try
            {
                // Cấu hình cột (nếu chưa có thì tạo, có rồi thì clear rows)
                dgvDanhSach.Columns.Clear();
                dgvDanhSach.Columns.Add("MaDatBan", "Mã Đặt");
                dgvDanhSach.Columns.Add("KhachHang", "Khách Hàng");
                dgvDanhSach.Columns.Add("SoBan", "Bàn");
                dgvDanhSach.Columns.Add("GioDen", "Giờ Đến");
                dgvDanhSach.Columns.Add("ThoiGian", "Thời Gian Chơi");
                dgvDanhSach.Columns.Add("TrangThai", "Trạng Thái");

                DataTable dt = _bll.GetTodayBookings();

                foreach (DataRow row in dt.Rows)
                {
                    string ma = "BD" + row["MaDatBan"].ToString();
                    string khach = row["KhachHang"].ToString();
                    string ban = row["SoBan"].ToString();

                    DateTime start = Convert.ToDateTime(row["ThoiGianBatDau"]);
                    DateTime end = Convert.ToDateTime(row["ThoiGianKetThuc"]);
                    string gioDen = start.ToString("HH:mm");

                    // Tính thời gian chơi
                    TimeSpan duration = end - start;
                    string thoiGian = $"{duration.TotalHours:F1} giờ";

                    string trangThai = row["TrangThai"].ToString();

                    dgvDanhSach.Rows.Add(ma, khach, ban, gioDen, thoiGian, trangThai);
                }

                // Style
                dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
                dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvDanhSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvDanhSach.EnableHeadersVisualStyles = false;
                dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDanhSach.RowTemplate.Height = 35;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi danh sách đặt bàn: " + ex.Message);
            }
        }

        // Các event handlers khác giữ nguyên hoặc để trống nếu không dùng
        private void labelDashboard_Click(object sender, EventArgs e) { }
        private void panelDoanhThu_Paint(object sender, PaintEventArgs e) { }
    }
}