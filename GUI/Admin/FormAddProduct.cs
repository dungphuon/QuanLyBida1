using QuanLyBida.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormAddProduct : Form
    {
        private SanPhamDAL _sanPhamDAL = new SanPhamDAL();

        public FormAddProduct()
        {
            InitializeComponent();
            RegisterEvents();
            comboBoxLoai.SelectedIndex = 0;
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

            try
            {
                // Thêm sản phẩm vào database
                bool result = ThemSanPhamVaoDatabase(
                    textBoxTenHang.Text,
                    comboBoxLoai.SelectedItem?.ToString() ?? "",
                    giaBan,
                    soLuong
                );

                if (result)
                {
                    MessageBox.Show("Đã thêm sản phẩm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ThemSanPhamVaoDatabase(string tenSP, string loai, decimal giaBan, int soLuong)
        {
            // Bạn cần thêm phương thức này vào SanPhamDAL
            // Tạm thời sử dụng stored procedure hoặc query trực tiếp
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO DichVu_SanPham (TenSP, DonViTinh, GiaNhap, GiaBan, SoLuongTon)
                    VALUES (@TenSP, @DonViTinh, @GiaNhap, @GiaBan, @SoLuongTon)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", tenSP);
                    cmd.Parameters.AddWithValue("@DonViTinh", "Cái"); // Hoặc lấy từ combobox
                    cmd.Parameters.AddWithValue("@GiaNhap", giaBan * 0.8m); // Giả sử giá nhập = 80% giá bán
                    cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", soLuong);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}