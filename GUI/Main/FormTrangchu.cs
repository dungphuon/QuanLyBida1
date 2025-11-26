using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormTrangchu : Form
    {
        public FormTrangchu()
        {
            InitializeComponent();
            this.Load += FormTrangchu_Load;
        }

        private void FormTrangchu_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu biểu đồ doanh thu
            LoadChartDoanhThu();
            
            // Tải dữ liệu biểu đồ tỷ lệ sử dụng bàn
            LoadChartTyLe();
            
            // Tải dữ liệu danh sách đặt bàn
            LoadDanhSachDatBan();
        }

        /// <summary>
        /// Tải dữ liệu cho biểu đồ doanh thu 7 ngày
        /// </summary>
        private void LoadChartDoanhThu()
        {
            chartDoanhThu.Series[0].Points.Clear();
            
            // Dữ liệu mẫu: 7 ngày gần nhất
            string[] days = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            double[] revenues = { 2500000, 3200000, 2800000, 3500000, 4200000, 5100000, 4800000 };

            for (int i = 0; i < days.Length; i++)
            {
                chartDoanhThu.Series[0].Points.AddXY(days[i], revenues[i]);
            }

            // Định dạng chart
            chartDoanhThu.Series[0].ChartType = SeriesChartType.Area;
            chartDoanhThu.Series[0].Color = Color.FromArgb(52, 152, 219);
            chartDoanhThu.Series[0].BorderColor = Color.FromArgb(52, 152, 219);
        }

        /// <summary>
        /// Tải dữ liệu cho biểu đồ tỷ lệ sử dụng bàn (Doughnut)
        /// </summary>
        private void LoadChartTyLe()
        {
            chartTyLe.Series[0].Points.Clear();

            // Dữ liệu mẫu
            chartTyLe.Series[0].Points.AddXY("Đang sử dụng", 8);
            chartTyLe.Series[0].Points.AddXY("Trống", 3);
            chartTyLe.Series[0].Points.AddXY("Bảo trì", 1);

            // Định dạng chart
            chartTyLe.Series[0].ChartType = SeriesChartType.Doughnut;
            chartTyLe.Series[0].Points[0].Color = Color.FromArgb(46, 204, 113);  // Xanh
            chartTyLe.Series[0].Points[1].Color = Color.FromArgb(189, 195, 199); // Xám
            chartTyLe.Series[0].Points[2].Color = Color.FromArgb(230, 126, 34);  // Cam

            // Hiển thị label
            chartTyLe.Series[0].IsValueShownAsLabel = true;
        }

        /// <summary>
        /// Tải dữ liệu cho DataGridView danh sách đặt bàn
        /// </summary>
        private void LoadDanhSachDatBan()
        {
            // Khởi tạo các cột
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.Columns.Add("MaDatBan", "Mã Đặt Bàn");
            dgvDanhSach.Columns.Add("KhachHang", "Khách Hàng");
            dgvDanhSach.Columns.Add("SoBan", "Số Bàn");
            dgvDanhSach.Columns.Add("GioDen", "Giờ Đến");
            dgvDanhSach.Columns.Add("ThoiGian", "Thời Gian");
            //dgvDanhSach.Columns.Add("SoNguoi", "Số Người");
            dgvDanhSach.Columns.Add("TrangThai", "Trạng Thái");

            // Dữ liệu mẫu
            dgvDanhSach.Rows.Add("#B001", "Nguyễn Văn A", "Bàn 3", "09:00", "2 giờ", "Sắp tới");
            dgvDanhSach.Rows.Add("#B002", "Trần Thị B", "Bàn 5", "10:30", "1.5 giờ", "Sắp tới");
            dgvDanhSach.Rows.Add("#B003", "Lê Văn C", "Bàn 1", "14:00", "3 giờ", "Sắp tới");

            // Định dạng cột
            dgvDanhSach.AutoResizeColumns();
            dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDanhSach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Định dạng hàng
            dgvDanhSach.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvDanhSach.DefaultCellStyle.Padding = new Padding(5);
            dgvDanhSach.RowTemplate.Height = 30;
        }

        private void labelDashboard_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click
        }

        private void panelDoanhThu_Paint(object sender, PaintEventArgs e)
        {
            // Xử lý vẽ panel nếu cần
        }
    }
}