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
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
            RegisterEvents();
            
            // Thiết lập giá trị mặc định cho comboBox Loại
            comboBoxLoai.SelectedIndex = 0; // Chọn "Đồ ăn" mặc định
        }

        private void RegisterEvents()
        {
            this.buttonSave.Click += ButtonSave_Click;
            this.buttonCancel.Click += ButtonCancel_Click;
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
            string loaiHangHoa = comboBoxLoai.SelectedItem?.ToString() ?? "";
            
            MessageBox.Show(
                $"Đã lưu thông tin hàng hóa:\n\n" +
                $"Tên hàng: {textBoxTenHang.Text}\n" +
                $"Loại: {loaiHangHoa}\n" +
                $"Giá bán: {giaBan:N0} VNĐ\n" +
                $"Số lượng: {soLuong}\n\n" +
                $"(Chức năng lưu vào database sẽ được triển khai sau)",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Đóng form sau khi lưu thành công
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
