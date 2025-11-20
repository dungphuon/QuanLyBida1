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
using QuanLyBida.BLL;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormEditProduct : Form
    {
        private bool isEditMode = false;
        private string originalTenHang;
        private string originalLoai;
        private decimal originalGia;
        private int originalSoLuong;
        private int maSP;

        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();

        public FormEditProduct()
        {
            InitializeComponent();
            RegisterEvents();

            this.MinimumSize = new Size(891, 570);

            // Đảm bảo buttons hiển thị
            buttonEdit.Visible = true;
            buttonCancel.Visible = true;
            buttonSave.Visible = false;

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
            // Lấy thông tin đầy đủ từ database
            var sanPham = _sanPhamBLL.GetSanPhamByTen(tenHang);
            if (sanPham != null)
            {
                maSP = sanPham.MaSP;
                originalTenHang = sanPham.TenSP;
                originalGia = sanPham.GiaBan;
                originalSoLuong = sanPham.SoLuongTon;
            }
            else
            {
                // Fallback nếu không tìm thấy
                originalTenHang = tenHang;
                originalGia = gia;
                originalSoLuong = soLuong;
            }

            textBoxTenHang.Text = originalTenHang;
            textBoxGia.Text = originalGia.ToString("N0");
            textBoxSoLuong.Text = originalSoLuong.ToString();

            // Set loại hàng hóa trong combobox
            if (comboBoxLoai.Items.Contains(loai))
            {
                comboBoxLoai.SelectedItem = loai;
                originalLoai = loai;
            }
            else
            {
                comboBoxLoai.SelectedIndex = 0;
                originalLoai = comboBoxLoai.SelectedItem?.ToString() ?? "";
            }

            // Cập nhật tiêu đề
            this.Text = $"Thông tin hàng hóa: {originalTenHang}";
            labelTitle.Text = $"Thông tin hàng hóa: {originalTenHang}";

            SetViewMode();
        }

        // Thiết lập chế độ xem (read-only)
        private void SetViewMode()
        {
            isEditMode = false;

            textBoxTenHang.ReadOnly = true;
            textBoxGia.ReadOnly = true;
            textBoxSoLuong.ReadOnly = true;
            comboBoxLoai.Enabled = false;

            buttonSave.Visible = false;
            buttonEdit.Visible = true;
            buttonCancel.Visible = true;

            buttonCancel.Location = new Point(699, 440);
            buttonEdit.Location = new Point(533, 440);

            buttonCancel.BringToFront();
            buttonEdit.BringToFront();
            this.panelMain.SendToBack();
        }

        // Thiết lập chế độ chỉnh sửa
        private void SetEditMode()
        {
            isEditMode = true;

            textBoxTenHang.ReadOnly = false;
            textBoxGia.ReadOnly = false;
            textBoxSoLuong.ReadOnly = false;
            comboBoxLoai.Enabled = true;

            buttonSave.Visible = true;
            buttonEdit.Visible = false;
            buttonCancel.Visible = true;

            buttonSave.Location = new Point(533, 440);
            buttonCancel.Location = new Point(699, 440);

            buttonSave.BringToFront();
            buttonCancel.BringToFront();
            this.panelMain.SendToBack();

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

            try
            {
                // Cập nhật vào database
                var sanPham = new SanPhamDTO
                {
                    MaSP = maSP,
                    TenSP = textBoxTenHang.Text,
                    LoaiHangHoa = comboBoxLoai.SelectedItem?.ToString() ?? "", // QUAN TRỌNG: THÊM DÒNG NÀY
                    GiaBan = giaBan,
                    SoLuongTon = soLuong
                };

                bool result = _sanPhamBLL.CapNhatSanPham(sanPham);

                if (result)
                {
                    MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật dữ liệu gốc
                    originalTenHang = textBoxTenHang.Text;
                    originalLoai = comboBoxLoai.SelectedItem?.ToString() ?? ""; // CẬP NHẬT LOẠI HÀNG HÓA
                    originalGia = giaBan;
                    originalSoLuong = soLuong;

                    SetViewMode();

                    this.Text = $"Thông tin hàng hóa: {originalTenHang}";
                    labelTitle.Text = $"Thông tin hàng hóa: {originalTenHang}";
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    textBoxTenHang.Text = originalTenHang;
                    textBoxGia.Text = originalGia.ToString("N0");
                    textBoxSoLuong.Text = originalSoLuong.ToString();
                    if (comboBoxLoai.Items.Contains(originalLoai))
                    {
                        comboBoxLoai.SelectedItem = originalLoai;
                    }

                    SetViewMode();

                    this.Text = $"Thông tin hàng hóa: {originalTenHang}";
                    labelTitle.Text = $"Thông tin hàng hóa: {originalTenHang}";
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void comboBoxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic xử lý khi thay đổi loại hàng hóa
        }
    }
}