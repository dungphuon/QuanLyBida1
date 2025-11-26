using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace GUI.Admin
{
    public partial class FormBaotrisuco : Form
    {
        private TableBLL tableBLL;

        public FormBaotrisuco()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
            RegisterEvents();
            LoadTables();
            LoadSampleData();
            
            // Set default value và trigger event để hiển thị/ẩn controls
            if (comboBoxType.Items.Count > 0)
            {
                comboBoxType.SelectedIndex = 0;
            }
        }

        private void RegisterEvents()
        {
            this.comboBoxType.SelectedIndexChanged += ComboBoxType_SelectedIndexChanged;
        }

        private void LoadTables()
        {
            try
            {
                var danhSachBan = tableBLL.GetAllTables();
                comboBoxTable.Items.Clear();
                foreach (var ban in danhSachBan)
                {
                    comboBoxTable.Items.Add(ban.TenBan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null) return;

            string selectedType = comboBoxType.SelectedItem.ToString();
            
            if (selectedType == "Bàn")
            {
                // Hiển thị combobox Bàn, ẩn textbox Thiết bị
                labelTable.Visible = true;
                comboBoxTable.Visible = true;
                labelDevice.Visible = false;
                textBoxDevice.Visible = false;
            }
            else if (selectedType == "Thiết bị")
            {
                // Hiển thị textbox Thiết bị, ẩn combobox Bàn
                labelTable.Visible = false;
                comboBoxTable.Visible = false;
                labelDevice.Visible = true;
                textBoxDevice.Visible = true;
            }
        }

        private void LoadSampleData()
        {
            // Xóa dữ liệu cũ
            gridIncidents.Rows.Clear();

            // Thêm dữ liệu giả lập
            gridIncidents.Rows.Add("1", "Bàn số 5", "Bóng bàn hỏng", "Đang xử lý", "Cập nhật");
            gridIncidents.Rows.Add("2", "Máy tính tiền", "Lỗi phần mềm", "Đã xử lý", "Cập nhật");
            gridIncidents.Rows.Add("3", "Bàn số 8", "Mua bị mới cho bàn 8", "Chờ xử lý", "Cập nhật");
            gridIncidents.Rows.Add("4", "Máy lạnh", "Không hoạt động", "Đang xử lý", "Cập nhật");
            gridIncidents.Rows.Add("5", "Bàn số 2", "Bàn bị nứt", "Đã xử lý", "Cập nhật");

            // Tô màu cho cột Trạng thái
            foreach (DataGridViewRow row in gridIncidents.Rows)
            {
                if (row.Cells["colStatus"].Value != null)
                {
                    string status = row.Cells["colStatus"].Value.ToString();
                    if (status == "Đang xử lý")
                    {
                        row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(255, 159, 67); // Màu cam
                    }
                    else if (status == "Đã xử lý")
                    {
                        row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(46, 213, 115); // Màu xanh lá
                    }
                    else if (status == "Chờ xử lý")
                    {
                        row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(107, 114, 128); // Màu xám
                    }
                }
            }
        }
    }
}
