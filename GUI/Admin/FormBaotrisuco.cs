using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace GUI.Admin
{
    public partial class FormBaotrisuco : Form
    {
        private TableBLL _tableBLL;
        private BaoTriBLL _baoTriBLL;

        public FormBaotrisuco()
        {
            InitializeComponent();
            _tableBLL = new TableBLL();
            _baoTriBLL = new BaoTriBLL();

            // Cài đặt sự kiện
            Load += FormBaotrisuco_Load;
            comboBoxType.SelectedIndexChanged += ComboBoxType_SelectedIndexChanged;
            buttonAddIncident.Click += ButtonAddIncident_Click;
            gridIncidents.CellContentClick += GridIncidents_CellContentClick; 
        }

        private void FormBaotrisuco_Load(object sender, EventArgs e)
        {
            LoadTables();
            LoadIncidentList();

            // Set mặc định
            if (comboBoxType.Items.Count > 0) comboBoxType.SelectedIndex = 0;
            if (comboBoxStatus.Items.Count > 0) comboBoxStatus.SelectedIndex = 2;
        }

        private void LoadTables()
        {
            try
            {
                var danhSachBan = _tableBLL.GetAllTables();
                comboBoxTable.Items.Clear();
                foreach (var ban in danhSachBan)
                {
                    // Lưu tên bàn (ví dụ: Bàn 1, Bàn 2...)
                    comboBoxTable.Items.Add($"Bàn {ban.MaBan}");
                }
                if (comboBoxTable.Items.Count > 0) comboBoxTable.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải bàn: {ex.Message}");
            }
        }

        private void LoadIncidentList()
        {
            try
            {
                var list = _baoTriBLL.LayDanhSachSuCo();
                gridIncidents.Rows.Clear();

                foreach (var item in list)
                {
                    int index = gridIncidents.Rows.Add();
                    var row = gridIncidents.Rows[index];

                    row.Cells["colID"].Value = item.MaSuCo;
                    row.Cells["colDeviceTable"].Value = item.TenDoiTuong;
                    row.Cells["colDescription"].Value = item.MoTa;
                    row.Cells["colStatus"].Value = item.TrangThai;

                    // Đặt màu sắc cho trạng thái
                    SetStatusColor(row, item.TrangThai);
                }
            }
            catch (Exception ex)
            {
                // Không hiện lỗi nếu chưa có bảng trong DB, chỉ log console
                Console.WriteLine("Lỗi load danh sách sự cố: " + ex.Message);
            }
        }

        private void SetStatusColor(DataGridViewRow row, string status)
        {
            var cell = row.Cells["colStatus"];
            if (status == "Đang xử lý")
                cell.Style.ForeColor = Color.FromArgb(255, 159, 67); // Cam
            else if (status == "Đã xử lý")
                cell.Style.ForeColor = Color.FromArgb(46, 213, 115); // Xanh lá
            else
                cell.Style.ForeColor = Color.FromArgb(107, 114, 128); // Xám (Chờ xử lý)
        }

        private void ButtonAddIncident_Click(object sender, EventArgs e)
        {
            string type = comboBoxType.SelectedItem?.ToString();
            string targetName = "";

            // Xác định đối tượng bị lỗi
            if (type == "Bàn")
            {
                targetName = comboBoxTable.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(targetName))
                {
                    MessageBox.Show("Vui lòng chọn bàn!");
                    return;
                }
            }
            else // Thiết bị
            {
                targetName = textBoxDevice.Text.Trim();
                if (string.IsNullOrEmpty(targetName))
                {
                    MessageBox.Show("Vui lòng nhập tên thiết bị!");
                    return;
                }
            }

            string description = textBoxDescription.Text.Trim();
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Vui lòng nhập mô tả sự cố!");
                return;
            }

            string status = comboBoxStatus.SelectedItem?.ToString() ?? "Chờ xử lý";

            try
            {
                bool result = _baoTriBLL.ThemSuCoMoi(type, targetName, description, status);
                if (result)
                {
                    // Nếu sự cố liên quan đến bàn → chuyển bàn sang Bảo trì
                    if (comboBoxType.SelectedItem.ToString() == "Bàn")
                    {
                        int maBan = int.Parse(comboBoxTable.SelectedItem.ToString().Replace("Bàn", "").Trim());
                        _tableBLL.UpdateTableStatus(maBan, "Bảo trì");
                    }

                    MessageBox.Show("Thêm sự cố thành công!", "Thông báo");
                    LoadIncidentList();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void GridIncidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == gridIncidents.Columns["colAction"].Index)
            {
                int maSuCo = Convert.ToInt32(gridIncidents.Rows[e.RowIndex].Cells["colID"].Value);
                string currentStatus = gridIncidents.Rows[e.RowIndex].Cells["colStatus"].Value.ToString();

                string deviceOrTable = gridIncidents.Rows[e.RowIndex].Cells["colDeviceTable"].Value.ToString();

                // Xác định có phải sự cố của BÀN không
                bool isTableIncident = deviceOrTable.StartsWith("Bàn");

                // Nếu sự cố thuộc bàn → target = "Bàn 5"
                string targetName = deviceOrTable;

                // Nếu đã xử lý rồi -> không làm nữa
                if (currentStatus == "Đã xử lý")
                {
                    MessageBox.Show("Sự cố này đã hoàn thành!");
                    return;
                }

                // Xác nhận chuyển trạng thái tiếp theo
                var confirm = MessageBox.Show(
                    $"Bạn muốn chuyển trạng thái từ '{currentStatus}' sang bước tiếp theo?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    bool success = _baoTriBLL.ChuyenTrangThaiTiepTheo(maSuCo, currentStatus);

                    if (success)
                    {
                        // Lấy trạng thái mới từ DB
                        string newStatus = _baoTriBLL.LayTrangThaiHienTai(maSuCo);


                        if (isTableIncident)
                        {
                            // Tách số bàn từ "Bàn 5"
                            int maBan = int.Parse(targetName.Replace("Bàn", "").Trim());
                            TableBLL tableBLL = new TableBLL();

                            if (newStatus == "Chờ xử lý" || newStatus == "Đang xử lý")
                            {
                                // Khi sự cố đang tồn tại -> bàn = Bảo trì
                                tableBLL.UpdateTableStatus(maBan, "Bảo trì");
                            }
                            else if (newStatus == "Đã xử lý")
                            {
                                // Khi sự cố được xử lý -> bàn hoạt động lại
                                tableBLL.UpdateTableStatus(maBan, "Trống");
                            }
                        }

                        // Refresh grid
                        LoadIncidentList();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật trạng thái.");
                    }
                }
            }
        }



        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null) return;

            string selectedType = comboBoxType.SelectedItem.ToString();

            if (selectedType == "Bàn")
            {
                labelTable.Visible = true;
                comboBoxTable.Visible = true;
                labelDevice.Visible = false;
                textBoxDevice.Visible = false;
            }
            else if (selectedType == "Thiết bị")
            {
                labelTable.Visible = false;
                comboBoxTable.Visible = false;
                labelDevice.Visible = true;
                textBoxDevice.Visible = true;
            }
        }
    }
}