using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Admin
{
    public partial class FormFinance : Form
    {
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
            AdjustKPIPanels();
        }

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
                form.ShowDialog(this);
            }
        }

        private void ButtonAddExpense_Click(object sender, EventArgs e)
        {
            using (var form = new FormPhieuChiAdmin())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
            }
        }

        private void ButtonExportReport_Click(object sender, EventArgs e)
        {
            // Tìm FormMainAdmin từ TopLevelControl hoặc Parent
            Form mainForm = null;
            
            // Thử tìm từ TopLevelControl
            if (this.TopLevelControl is Form topForm)
            {
                mainForm = topForm;
            }
            
            // Nếu không tìm thấy, tìm từ Parent control
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
            
            // Nếu vẫn không tìm thấy, thử tìm từ Application.OpenForms
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
            
            // Nếu tìm thấy từ TopLevelControl
            if (mainForm is QuanLyBida.GUI.Admin.FormMainAdmin formMainAdmin)
            {
                formMainAdmin.LoadFormToPanel(new FormXuatbaocao());
            }
        }

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
                    if (panelWidth < 150) panelWidth = 150; // Minimum width để hiển thị
                }
            }

            // Điều chỉnh kích thước và vị trí các panel
            panelKPI1.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI1.Location = new Point(KPI_PANEL_START_X, KPI_PANEL_START_Y);

            panelKPI2.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI2.Location = new Point(KPI_PANEL_START_X + panelWidth + KPI_PANEL_SPACING, KPI_PANEL_START_Y);

            panelKPI3.Size = new Size(panelWidth, KPI_PANEL_HEIGHT);
            panelKPI3.Location = new Point(KPI_PANEL_START_X + (panelWidth + KPI_PANEL_SPACING) * 2, KPI_PANEL_START_Y);

            // Panel cuối cùng: đảm bảo không tràn ra ngoài
            int panel4X = KPI_PANEL_START_X + (panelWidth + KPI_PANEL_SPACING) * 3;
            int panel4MaxWidth = this.ClientSize.Width - KPI_PANEL_START_X - panel4X;
            int panel4Width = Math.Min(panelWidth, panel4MaxWidth);
            
            panelKPI4.Size = new Size(panel4Width > 0 ? panel4Width : panelWidth, KPI_PANEL_HEIGHT);
            panelKPI4.Location = new Point(panel4X, KPI_PANEL_START_Y);
        }

        private void labelChartTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
