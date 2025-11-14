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
    public partial class FormEditTable : Form
    {
        private bool isEditMode = false; // Trạng thái: false = xem, true = chỉnh sửa
        private string originalTenBan;
        private string originalLoaiBan;
        private decimal originalGiaBan;

        public FormEditTable()
        {
            InitializeComponent();
            RegisterEvents();
            
            // Thiết lập kích thước tối thiểu cho form
            this.MinimumSize = new Size(891, 570);
            
            // Đảm bảo buttons luôn hiển thị ngay từ đầu - FORCE SET
            if (buttonEdit != null)
            {
                buttonEdit.Visible = true;
                buttonEdit.Show();
                buttonEdit.BringToFront();
            }
            
            if (buttonCancel != null)
            {
                buttonCancel.Visible = true;
                buttonCancel.Show();
                buttonCancel.BringToFront();
            }
            
            if (buttonSave != null)
            {
                buttonSave.Visible = false; // Ẩn mặc định
                buttonSave.BringToFront();
            }
            
            // Đảm bảo buttons không bị ẩn bởi panel
            this.panelMain.SendToBack();
        }

        private void RegisterEvents()
        {
            this.buttonEdit.Click += ButtonEdit_Click;
            this.buttonSave.Click += ButtonSave_Click;
            this.buttonCancel.Click += ButtonCancel_Click;
        }

        // Method để nhận dữ liệu từ form khác
        public void SetTableData(string tenBan, string loaiBan, decimal giaBan)
        {
            
            // Lưu dữ liệu gốc
            originalTenBan = tenBan;
            originalLoaiBan = loaiBan;
            originalGiaBan = giaBan;

            textBoxTenBan.Text = tenBan;
            textBoxGiaBan.Text = giaBan.ToString("N0");
            
            // Set loại bàn trong combobox
            if (comboBoxLoaiBan.Items.Contains(loaiBan))
            {
                comboBoxLoaiBan.SelectedItem = loaiBan;
            }
            else
            {
                comboBoxLoaiBan.SelectedIndex = 0; // Mặc định chọn item đầu tiên
            }

            // Set trạng thái mặc định
            comboBoxTrangThai.SelectedIndex = 0; // "Đang hoạt động"
            
            // Cập nhật tiêu đề form và label
            this.Text = $"Xem thông tin bàn: {tenBan}";
            labelTitle.Text = $"Xem thông tin bàn: {tenBan}";
            
            // Sau khi set dữ liệu, thiết lập chế độ xem
            SetViewMode();
            
            // FORCE hiển thị buttons
            buttonEdit.Visible = true;
            buttonEdit.Show();
            buttonCancel.Visible = true;
            buttonCancel.Show();
            buttonEdit.BringToFront();
            buttonCancel.BringToFront();
            buttonSave.BringToFront();
            this.panelMain.SendToBack();
        }

        // Thiết lập chế độ xem (read-only)
        private void SetViewMode()
        {
            isEditMode = false;
            
            // Vô hiệu hóa các trường nhập liệu
            textBoxTenBan.ReadOnly = true;
            textBoxGiaBan.ReadOnly = true;
            comboBoxLoaiBan.Enabled = false;
            comboBoxTrangThai.Enabled = false;

            // Ẩn nút Lưu, hiện nút Sửa - FORCE SET
            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonEdit.Show();
            buttonCancel.Visible = true;
            buttonCancel.Show();
            
            // Đảm bảo vị trí đúng
            buttonCancel.Location = new Point(699, 440);
            buttonEdit.Location = new Point(533, 440);
            
            // Đảm bảo buttons ở trên cùng
            buttonCancel.BringToFront();
            buttonEdit.BringToFront();
            this.panelMain.SendToBack();
        }

        // Thiết lập chế độ chỉnh sửa
        private void SetEditMode()
        {
            isEditMode = true;
            
            // Kích hoạt các trường nhập liệu
            textBoxTenBan.ReadOnly = false;
            textBoxGiaBan.ReadOnly = false;
            comboBoxLoaiBan.Enabled = true;
            comboBoxTrangThai.Enabled = true;

            // Hiện nút Lưu, ẩn nút Sửa - FORCE SET
            buttonSave.Visible = true;
            buttonSave.Show();
            buttonEdit.Visible = false;
            buttonCancel.Visible = true;
            buttonCancel.Show();
            
            // Đảm bảo vị trí đúng
            buttonSave.Location = new Point(533, 440);
            buttonCancel.Location = new Point(699, 440);
            
            // Đảm bảo buttons ở trên cùng
            buttonSave.BringToFront();
            buttonCancel.BringToFront();
            this.panelMain.SendToBack();
            
            // Cập nhật tiêu đề
            this.Text = $"Sửa thông tin bàn: {originalTenBan}";
            labelTitle.Text = $"Sửa thông tin bàn: {originalTenBan}";
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(textBoxTenBan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập giá bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxGiaBan.Text.Replace(",", ""), out decimal giaBan))
            {
                MessageBox.Show("Giá bàn phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: Implement logic to save table data to database
            MessageBox.Show("Dữ liệu bàn đã được cập nhật (chức năng lưu vào DB chưa triển khai).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Quay lại chế độ xem sau khi lưu
            SetViewMode();
            
            // Cập nhật dữ liệu gốc
            originalTenBan = textBoxTenBan.Text;
            originalLoaiBan = comboBoxLoaiBan.SelectedItem?.ToString() ?? "";
            originalGiaBan = giaBan;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // Nếu đang ở chế độ chỉnh sửa, hỏi xác nhận
                var result = MessageBox.Show(
                    "Bạn có muốn hủy các thay đổi?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Khôi phục dữ liệu gốc
                    textBoxTenBan.Text = originalTenBan;
                    textBoxGiaBan.Text = originalGiaBan.ToString("N0");
                    if (comboBoxLoaiBan.Items.Contains(originalLoaiBan))
                    {
                        comboBoxLoaiBan.SelectedItem = originalLoaiBan;
                    }
                    
                    // Quay lại chế độ xem
                    SetViewMode();
                }
            }
            else
            {
                // Nếu đang ở chế độ xem, đóng form
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
