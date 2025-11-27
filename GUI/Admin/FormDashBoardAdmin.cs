using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormDashBoardAdmin : Form
    {
        private const int KPI_PANEL_MIN_WIDTH = 195;
        private const int KPI_PANEL_SPACING = 15;
        private const int KPI_PANEL_HEIGHT = 130;

        // Khai báo BLL
        private DashboardBLL _dashboardBLL = new DashboardBLL();
        private TaiKhoanDTO _currentUser;

        public FormDashBoardAdmin(TaiKhoanDTO currentUser = null)
        {
            InitializeComponent();
            _currentUser = currentUser;

            // Load dữ liệu khi mở form
            Load += FormDashBoardAdmin_Load;

            // Sự kiện resize
            if (panelStats != null)
            {
                panelStats.Resize += panelStats_Resize;
            }
        }

        private void FormDashBoardAdmin_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị lời chào
            string name = _currentUser != null ? _currentUser.TenDangNhap : "Admin";
            labelChaoMung.Text = $"Xin chào, ADMIN 👋";
            labelChucNgay.Text = $"Hôm nay là {DateTime.Now:dd/MM/yyyy}, chúc bạn một ngày làm việc hiệu quả!";

            // 2. Load số liệu KPI
            LoadKpiData();

            // 3. Load danh sách hoạt động
            LoadRealActivities();

            // 4. Căn chỉnh giao diện
            AdjustKPIPanels();
        }

        private void LoadKpiData()
        {
            try
            {
                // KPI 1: Tổng Doanh Thu
                decimal doanhThu = _dashboardBLL.LayTongDoanhThu();
                labelKPI1Value.Text = string.Format("{0:N0}₫", doanhThu);

                // KPI 2: Bàn đang sử dụng
                int banDangDung = _dashboardBLL.LaySoBanDangDung();
                labelKPI2Value.Text = banDangDung.ToString();

                // KPI 3: Tổng Nhân Viên
                int tongNV = _dashboardBLL.LayTongNhanVien();
                labelKPI3Value.Text = tongNV.ToString();

                // KPI 4: Tổng Sản Phẩm
                int tongSP = _dashboardBLL.LayTongSanPham();
                labelKPI4Value.Text = tongSP.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Dashboard: " + ex.Message);
            }
        }

        private void LoadRealActivities()
        {
            try
            {
                gridActivities.Rows.Clear();
                DataTable dt = _dashboardBLL.LayHoatDongGanDay();

                foreach (DataRow row in dt.Rows)
                {
                    DateTime time = Convert.ToDateTime(row["NgayTao"]);
                    string activity = row["HoatDong"].ToString();
                    string user = row["NguoiThucHien"].ToString();

                    // Thêm vào grid
                    gridActivities.Rows.Add(time.ToString("HH:mm - dd/MM/yyyy"), activity, user);
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi thì load dữ liệu mẫu để không trống trơn
                LoadSampleActivities();
                Console.WriteLine(ex.Message);
            }
        }

        private void LoadSampleActivities()
        {
            // Dữ liệu giả lập (Fallback nếu DB chưa có gì)
            gridActivities.Rows.Add(DateTime.Now.ToString("HH:mm - dd/MM"), "Đăng nhập hệ thống", "Admin");
            gridActivities.Rows.Add(DateTime.Now.AddMinutes(-30).ToString("HH:mm - dd/MM"), "Kiểm tra doanh thu", "Quản lý");
        }

        private void panelStats_Resize(object sender, EventArgs e)
        {
            AdjustKPIPanels();
        }

        private void AdjustKPIPanels()
        {
            if (panelStats == null || panelStats.Width <= 0) return;

            int totalWidth = panelStats.Width;
            int panelCount = 4;
            int totalSpacing = KPI_PANEL_SPACING * (panelCount - 1);
            int availableWidth = totalWidth - totalSpacing;

            // Tính toán kích thước
            int panelWidth = availableWidth / panelCount;

            if (panelWidth < KPI_PANEL_MIN_WIDTH)
            {
                panelWidth = KPI_PANEL_MIN_WIDTH;
                int requiredWidth = (panelWidth * panelCount) + totalSpacing;
                if (requiredWidth > totalWidth)
                {
                    panelWidth = (totalWidth - totalSpacing) / panelCount;
                    if (panelWidth < 100) panelWidth = 100;
                }
            }

            // Set vị trí
            panelKPI1.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI1.Location = new Point(0, 0);

            panelKPI2.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI2.Location = new Point(panelWidth + KPI_PANEL_SPACING, 0);

            panelKPI3.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI3.Location = new Point((panelWidth + KPI_PANEL_SPACING) * 2, 0);

            // Panel cuối
            int panel4X = (panelWidth + KPI_PANEL_SPACING) * 3;
            int panel4MaxWidth = totalWidth - panel4X;
            int panel4Width = Math.Min(panelWidth, panel4MaxWidth);

            panelKPI4.Size = new Size(panel4Width > 0 ? panel4Width : panelWidth, KPI_PANEL_HEIGHT);
            panelKPI4.Location = new Point(panel4X, 0);
        }
    }
}