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
    public partial class FormEditTable : Form
    {
        private bool isEditMode = false;
        private TableDTO currentTable;
        private TableBLL tableBLL;

        public FormEditTable()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
            RegisterEvents();

            this.MinimumSize = new Size(891, 570);

            // Ẩn phần trạng thái
            comboBoxTrangThai.Visible = false;
            labelTrangThai.Visible = false;

            // Load loại bàn từ database
            LoadLoaiBanOptions();

            // Đảm bảo buttons hiển thị
            if (buttonEdit != null)
            {
                buttonEdit.Visible = true;
                buttonEdit.BringToFront();
            }

            if (buttonCancel != null)
            {
                buttonCancel.Visible = true;
                buttonCancel.BringToFront();
            }

            if (buttonSave != null)
            {
                buttonSave.Visible = false;
                buttonSave.BringToFront();
            }

            this.panelMain.SendToBack();
        }

        private void RegisterEvents()
        {
            this.buttonEdit.Click += ButtonEdit_Click;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải loại bàn: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method mới nhận đối tượng TableDTO
        public void SetTableData(TableDTO table)
        {
            currentTable = table;

            if (currentTable != null)
            {
                textBoxTenBan.Text = currentTable.TenBan;
                textBoxGiaBan.Text = currentTable.GiaGio.ToString("N0");

                // Set loại bàn
                if (comboBoxLoaiBan.Items.Contains(currentTable.LoaiBan))
                {
                    comboBoxLoaiBan.SelectedItem = currentTable.LoaiBan;
                }
                else
                {
                    // Nếu loại bàn không có trong danh sách, thêm vào và chọn
                    comboBoxLoaiBan.Items.Add(currentTable.LoaiBan);
                    comboBoxLoaiBan.SelectedItem = currentTable.LoaiBan;
                }

                this.Text = $"Xem thông tin bàn: {currentTable.TenBan}";
                labelTitle.Text = $"Xem thông tin bàn: {currentTable.TenBan}";
            }

            SetViewMode();
        }

        // Giữ lại method cũ để tương thích
        public void SetTableData(string tenBan, string loaiBan, decimal giaGio)
        {
            currentTable = new TableDTO
            {
                TenBan = tenBan,
                LoaiBan = loaiBan,
                GiaGio = giaGio,
                TrangThai = "Trống"
            };

            SetTableData(currentTable);
        }

        private void SetViewMode()
        {
            isEditMode = false;

            textBoxTenBan.ReadOnly = true;
            textBoxGiaBan.ReadOnly = true;
            comboBoxLoaiBan.Enabled = false;

            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonCancel.Visible = true;

            buttonCancel.Location = new Point(699, 440);
            buttonEdit.Location = new Point(533, 440);

            buttonCancel.BringToFront();
            buttonEdit.BringToFront();
            this.panelMain.SendToBack();
        }

        private void SetEditMode()
        {
            isEditMode = true;

            textBoxTenBan.ReadOnly = false;
            textBoxGiaBan.ReadOnly = false;
            comboBoxLoaiBan.Enabled = true;

            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonCancel.Visible = true;

            buttonSave.Location = new Point(533, 440);
            buttonCancel.Location = new Point(699, 440);

            buttonSave.BringToFront();
            buttonCancel.BringToFront();
            this.panelMain.SendToBack();

            this.Text = $"Sửa thông tin bàn: {currentTable.TenBan}";
            labelTitle.Text = $"Sửa thông tin bàn: {currentTable.TenBan}";
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(textBoxTenBan.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(textBoxGiaBan.Text.Replace(",", ""), out decimal giaGio))
                {
                    MessageBox.Show("Giá bàn phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật thông tin
                currentTable.TenBan = textBoxTenBan.Text.Trim();
                currentTable.LoaiBan = comboBoxLoaiBan.SelectedItem?.ToString() ?? "";
                currentTable.GiaGio = giaGio;

                // Lưu vào database
                bool success = tableBLL.UpdateTable(currentTable);

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin bàn thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetViewMode();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin bàn!", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                var result = MessageBox.Show(
                    "Bạn có muốn hủy các thay đổi?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Khôi phục dữ liệu gốc
                    SetTableData(currentTable);
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}