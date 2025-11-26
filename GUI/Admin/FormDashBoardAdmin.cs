using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormDashBoardAdmin : Form
    {
        private const int KPI_PANEL_MIN_WIDTH = 195;
        private const int KPI_PANEL_SPACING = 15;
        private const int KPI_PANEL_HEIGHT = 130;

        public FormDashBoardAdmin()
        {
            InitializeComponent();
            LoadSampleActivities();
            AdjustKPIPanels();
        }

        private void LoadSampleActivities()
        {
            // Xóa dữ liệu cũ
            gridActivities.Rows.Clear();

            // Thêm dữ liệu giả lập
            gridActivities.Rows.Add("14:30 - 19/11/2024", "Thêm mới sản phẩm: Bia Tiger", "Nguyễn Văn A");
            gridActivities.Rows.Add("13:15 - 19/11/2024", "Cập nhật trạng thái bàn số 5", "Trần Thị B");
            gridActivities.Rows.Add("12:00 - 19/11/2024", "Tạo hóa đơn mới #HD001234", "Lê Văn C");
            gridActivities.Rows.Add("11:45 - 19/11/2024", "Thêm nhân viên mới: Phạm Thị D", "Nguyễn Văn A");
            gridActivities.Rows.Add("10:30 - 19/11/2024", "Cập nhật giá sản phẩm: Nước ngọt", "Trần Thị B");
            gridActivities.Rows.Add("09:20 - 19/11/2024", "Xóa sản phẩm: Bia 333", "Lê Văn C");
            gridActivities.Rows.Add("08:15 - 19/11/2024", "Đăng nhập hệ thống", "Nguyễn Văn A");
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
            
            // Tính toán kích thước panel, đảm bảo không vượt quá không gian có sẵn
            int panelWidth = availableWidth / panelCount;
            
            // Nếu kích thước tính được nhỏ hơn minimum, sử dụng minimum và đảm bảo không tràn
            if (panelWidth < KPI_PANEL_MIN_WIDTH)
            {
                panelWidth = KPI_PANEL_MIN_WIDTH;
                // Kiểm tra xem có đủ không gian không
                int requiredWidth = (panelWidth * panelCount) + totalSpacing;
                if (requiredWidth > totalWidth)
                {
                    // Nếu không đủ, giảm kích thước để vừa
                    panelWidth = (totalWidth - totalSpacing) / panelCount;
                    if (panelWidth < 100) panelWidth = 100; // Minimum width để hiển thị
                }
            }

            // Điều chỉnh kích thước và vị trí các panel
            panelKPI1.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI1.Location = new Point(0, 0);

            panelKPI2.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI2.Location = new Point(panelWidth + KPI_PANEL_SPACING, 0);

            panelKPI3.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI3.Location = new Point((panelWidth + KPI_PANEL_SPACING) * 2, 0);

            // Panel cuối cùng: đảm bảo không tràn ra ngoài
            int panel4X = (panelWidth + KPI_PANEL_SPACING) * 3;
            int panel4MaxWidth = totalWidth - panel4X;
            int panel4Width = Math.Min(panelWidth, panel4MaxWidth);
            
            panelKPI4.Size = new Size(panel4Width > 0 ? panel4Width : panelWidth, KPI_PANEL_HEIGHT);
            panelKPI4.Location = new Point(panel4X, 0);
        }
    }
}
