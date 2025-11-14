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
    public partial class FormEditProduct : Form
    {
        private bool isEditMode = false; // Trạng thái: false = xem, true = chỉnh sửa
        private string originalTenHang;
        private string originalLoai;
        private decimal originalGia;
        private int originalSoLuong;

        public FormEditProduct()
        {
            InitializeComponent();
            RegisterEvents();
            
            // Thiết lập kích thước tối thiểu cho form
            this.MinimumSize = new Size(891, 570);
            
            // Đảm bảo buttons luôn hiển thị ngay từ đầu
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
        public void SetProductData(string tenHang, string loai, decimal gia, int soLuong)
        {
            // Lưu dữ liệu gốc
            originalTenHang = tenHang;
            originalLoai = loai;
            originalGia = gia;
            originalSoLuong = soLuong;

            textBoxTenHang.Text = tenHang;
            textBoxGia.Text = gia.ToString("N0");
            textBoxSoLuong.Text = soLuong.ToString();
            
            // Set loại hàng hóa trong combobox
            if (comboBoxLoai.Items.Contains(loai))
            {
                comboBoxLoai.SelectedItem = loai;
            }
            else
            {
                comboBoxLoai.SelectedIndex = 0; // Mặc định chọn item đầu tiên
            }

            // Cập nhật tiêu đề form và label
            this.Text = $"Thông tin hàng hóa: {tenHang}";
            labelTitle.Text = $"Thông tin hàng hóa: {tenHang}";
            
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
            textBoxTenHang.ReadOnly = true;
            textBoxGia.ReadOnly = true;
            textBoxSoLuong.ReadOnly = true;
            comboBoxLoai.Enabled = false;

            // Ẩn nút Lưu, hiện nút Sửa
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
            textBoxTenHang.ReadOnly = false;
            textBoxGia.ReadOnly = false;
            textBoxSoLuong.ReadOnly = false;
            comboBoxLoai.Enabled = true;

            // Hiện nút Lưu, ẩn nút Sửa
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
            this.Text = $"Sửa thông tin hàng hóa: {originalTenHang}";
            labelTitle.Text = $"Sửa thông tin hàng hóa: {originalTenHang}";
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(textBoxTenHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hàng hóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTenHang.Focus();
                return;
            }

            if (comboBoxLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại hàng hóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxLoai.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxGia.Text))
            {
                MessageBox.Show("Vui lòng nhập giá bán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxGia.Focus();
                return;
            }

            if (!decimal.TryParse(textBoxGia.Text.Replace(",", ""), out decimal giaBan))
            {
                MessageBox.Show("Giá bán phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxGia.Focus();
                return;
            }

            if (giaBan <= 0)
            {
                MessageBox.Show("Giá bán phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxGia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng trong kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoLuong.Focus();
                return;
            }

            if (!int.TryParse(textBoxSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Số lượng phải là một số nguyên hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoLuong.Focus();
                return;
            }

            if (soLuong < 0)
            {
                MessageBox.Show("Số lượng không được âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSoLuong.Focus();
                return;
            }

            // TODO: Implement logic to save product data to database
            MessageBox.Show("Dữ liệu hàng hóa đã được cập nhật (chức năng lưu vào DB chưa triển khai).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Quay lại chế độ xem sau khi lưu
            SetViewMode();
            
            // Cập nhật dữ liệu gốc
            originalTenHang = textBoxTenHang.Text;
            originalLoai = comboBoxLoai.SelectedItem?.ToString() ?? "";
            originalGia = giaBan;
            originalSoLuong = soLuong;
            
            // Cập nhật tiêu đề
            this.Text = $"Thông tin hàng hóa: {originalTenHang}";
            labelTitle.Text = $"Thông tin hàng hóa: {originalTenHang}";
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
                    textBoxTenHang.Text = originalTenHang;
                    textBoxGia.Text = originalGia.ToString("N0");
                    textBoxSoLuong.Text = originalSoLuong.ToString();
                    if (comboBoxLoai.Items.Contains(originalLoai))
                    {
                        comboBoxLoai.SelectedItem = originalLoai;
                    }
                    
                    // Quay lại chế độ xem
                    SetViewMode();
                    
                    // Cập nhật tiêu đề
                    this.Text = $"Thông tin hàng hóa: {originalTenHang}";
                    labelTitle.Text = $"Thông tin hàng hóa: {originalTenHang}";
                }
            }
            else
            {
                // Nếu đang ở chế độ xem, đóng form
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void comboBoxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
