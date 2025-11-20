using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBida.DTO;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormAddTable : Form
    {
        private TableBLL tableBLL;

        public FormAddTable()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
            RegisterEvents();

            // Ẩn phần trạng thái
            comboBoxTrangThai.Visible = false;
            labelTrangThai.Visible = false;

            // Load loại bàn từ database
            LoadLoaiBanOptions();
        }

        private void RegisterEvents()
        {
            this.buttonSave.Click += ButtonSave_Click;
            this.buttonCancel.Click += ButtonCancel_Click;
        }

        private void LoadLoaiBanOptions()
        {
            try
            {
                // Lấy danh sách bàn từ database để lấy các loại bàn
                var tables = tableBLL.GetAllTables();
                var loaiBanList = tables
                    .Select(b => b.LoaiBan)
                    .Distinct()
                    .OrderBy(l => l)
                    .ToList();

                // Xóa items cũ
                comboBoxLoaiBan.Items.Clear();

                // Thêm các loại bàn vào combobox
                foreach (var loaiBan in loaiBanList)
                {
                    comboBoxLoaiBan.Items.Add(loaiBan);
                }

                // Chọn item đầu tiên nếu có
                if (comboBoxLoaiBan.Items.Count > 0)
                {
                    comboBoxLoaiBan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải loại bàn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate dữ liệu
                if (string.IsNullOrWhiteSpace(textBoxTenBan.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxTenBan.Focus();
                    return;
                }

                if (comboBoxLoaiBan.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại bàn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxLoaiBan.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxGiaBan.Text) || !decimal.TryParse(textBoxGiaBan.Text.Replace(",", ""), out decimal giaGio))
                {
                    MessageBox.Show("Giá bàn không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxGiaBan.Focus();
                    return;
                }

                // Tạo đối tượng bàn mới
                var newTable = new TableDTO
                {
                    TenBan = textBoxTenBan.Text.Trim(),
                    LoaiBan = comboBoxLoaiBan.SelectedItem.ToString(),
                    GiaGio = giaGio,
                    TrangThai = "Trống" // Mặc định trạng thái là "Trống"
                };

                // Thêm vào database
                bool success = tableBLL.AddTable(newTable);

                if (success)
                {
                    MessageBox.Show("Thêm bàn mới thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm bàn mới!", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm bàn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}