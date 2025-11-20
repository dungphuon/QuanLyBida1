using System;
using System.Windows.Forms;
using QuanLyBida.DTO;
using QuanLyBida.BLL;

namespace GUI.Admin
{
    public partial class FormAddNV : Form
    {
        private NhanVienDTO nhanVien;
        private bool isEditMode;
        private bool isViewMode;

        // Constructor cho thêm mới
        public FormAddNV()
        {
            InitializeComponent();
            this.Text = "Thêm nhân viên";
            isEditMode = true;
            isViewMode = false;
            KhoiTaoGiaTriMacDinh();
            SetMode();
        }

        // Constructor cho xem/sửa
        public FormAddNV(NhanVienDTO nv, bool isEdit = false)
        {
            InitializeComponent();
            this.nhanVien = nv;
            this.isEditMode = isEdit;
            this.isViewMode = !isEdit;

            if (isEdit)
                this.Text = "Chỉnh sửa nhân viên";
            else
                this.Text = "Thông tin nhân viên";

            KhoiTaoGiaTriMacDinh();
            HienThiThongTinNhanVien();
            SetMode();
        }

        private void KhoiTaoGiaTriMacDinh()
        {
            // Thiết lập giá trị mặc định
            cmbCaLamViec.SelectedIndex = 0; // "Ca sáng"
            cmbTrangThai.SelectedIndex = 0; // "Đang làm việc"
            cmbGioiTinh.SelectedIndex = 0; // "Chọn giới tính"
            cmbChucVu.SelectedIndex = 0; // "Chọn chức vụ"

            // Thiết lập ngày sinh mặc định
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);

            // Tự động sinh mã nhân viên nếu là thêm mới
            if (nhanVien == null)
            {
                SinhMaNhanVienTuDong();
            }
        }

        private void SinhMaNhanVienTuDong()
        {
            try
            {
                NhanVienBLL nhanVienBLL = new NhanVienBLL();
                int maNVTiepTheo = nhanVienBLL.LayMaNhanVienTiepTheo();
                txtMaNV.Text = maNVTiepTheo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sinh mã nhân viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Text = "Tự động";
            }
        }

        private void HienThiThongTinNhanVien()
        {
            if (nhanVien == null) return;

            // Hiển thị thông tin nhân viên lên form
            txtMaNV.Text = nhanVien.MaNV.ToString();
            txtHoTen.Text = nhanVien.HoTen;

            // ComboBox giới tính
            if (!string.IsNullOrEmpty(nhanVien.GioiTinh))
                cmbGioiTinh.SelectedItem = nhanVien.GioiTinh;
            else
                cmbGioiTinh.SelectedIndex = 0;

            // Ngày sinh
            if (nhanVien.NgaySinh.HasValue)
                dtpNgaySinh.Value = nhanVien.NgaySinh.Value;

            // ComboBox chức vụ
            if (!string.IsNullOrEmpty(nhanVien.ChucVu))
                cmbChucVu.SelectedItem = nhanVien.ChucVu;

            txtSoDienThoai.Text = nhanVien.SoDienThoai ?? "";
            txtEmail.Text = nhanVien.Email ?? "";
            txtDiaChi.Text = nhanVien.DiaChi ?? "";
            txtLuong.Text = nhanVien.Luong?.ToString("N0") ?? "";

            // ComboBox ca làm việc
            if (!string.IsNullOrEmpty(nhanVien.CaLamViec))
                cmbCaLamViec.SelectedItem = nhanVien.CaLamViec;

            // ComboBox trạng thái
            if (!string.IsNullOrEmpty(nhanVien.TrangThai))
                cmbTrangThai.SelectedItem = nhanVien.TrangThai;
        }

        private void SetMode()
        {
            // Điều khiển trạng thái các control theo chế độ
            bool enabled = isEditMode;

            txtMaNV.Enabled = false;
            txtMaNV.ReadOnly = true;
            txtHoTen.Enabled = enabled;
            cmbGioiTinh.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            cmbChucVu.Enabled = enabled;
            txtSoDienThoai.Enabled = enabled;
            txtEmail.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            txtLuong.Enabled = enabled;
            cmbCaLamViec.Enabled = enabled;
            cmbTrangThai.Enabled = enabled;

            // Điều khiển nút
            if (isViewMode)
            {
                // Chế độ xem: Ẩn nút Lưu, đổi tên nút Hủy thành Sửa
                btnLuu.Visible = false;
                btnHuy.Text = "Sửa";
                btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250))))); // Màu xanh
            }
            else
            {
                // Chế độ chỉnh sửa/thêm mới: Hiện nút Lưu, đổi tên nút Hủy thành Hủy
                btnLuu.Visible = true;
                btnHuy.Text = "Hủy";
                btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60))))); // Màu đỏ
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuHopLe())
            {
                try
                {
                    if (nhanVien == null)
                    {
                        // THÊM MỚI
                        ThemNhanVienMoi();
                    }
                    else
                    {
                        // CẬP NHẬT
                        CapNhatNhanVien();
                    }
                }
                catch (Exception ex)
                {
                    string action = nhanVien == null ? "thêm" : "cập nhật";
                    MessageBox.Show($"Lỗi khi {action} nhân viên: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ThemNhanVienMoi()
        {
            // Tạo đối tượng nhân viên mới từ dữ liệu form
            NhanVienDTO nv = new NhanVienDTO
            {
                MaNV = int.Parse(txtMaNV.Text.Trim()),
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = cmbGioiTinh.SelectedIndex > 0 ? cmbGioiTinh.SelectedItem.ToString() : null,
                NgaySinh = dtpNgaySinh.Value,
                ChucVu = cmbChucVu.SelectedIndex > 0 ? cmbChucVu.SelectedItem.ToString() : "",
                SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim(),
                Luong = string.IsNullOrWhiteSpace(txtLuong.Text) ? (decimal?)null : decimal.Parse(txtLuong.Text.Trim()),
                CaLamViec = cmbCaLamViec.SelectedItem.ToString(),
                LichSuLamViec = null,
                TrangThai = cmbTrangThai.SelectedItem.ToString()
            };

            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            string result = nhanVienBLL.ThemNhanVien(nv);

            if (result == "Thành công")
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatNhanVien()
        {
            // Cập nhật thông tin từ form vào đối tượng
            nhanVien.HoTen = txtHoTen.Text.Trim();
            nhanVien.GioiTinh = cmbGioiTinh.SelectedIndex > 0 ? cmbGioiTinh.SelectedItem.ToString() : null;
            nhanVien.NgaySinh = dtpNgaySinh.Value;
            nhanVien.ChucVu = cmbChucVu.SelectedIndex > 0 ? cmbChucVu.SelectedItem.ToString() : "";
            nhanVien.SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text.Trim();
            nhanVien.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            nhanVien.DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim();
            nhanVien.Luong = string.IsNullOrWhiteSpace(txtLuong.Text) ? (decimal?)null : decimal.Parse(txtLuong.Text.Trim());
            nhanVien.CaLamViec = cmbCaLamViec.SelectedItem.ToString();
            nhanVien.TrangThai = cmbTrangThai.SelectedItem.ToString();

            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            string result = nhanVienBLL.CapNhatNhanVien(nhanVien);

            if (result == "Thành công")
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (isViewMode)
            {
                // Nếu đang ở chế độ xem, nút này là "Sửa"
                // Chuyển sang chế độ chỉnh sửa
                isEditMode = true;
                isViewMode = false;
                this.Text = "Chỉnh sửa nhân viên";
                SetMode();
            }
            else
            {
                // Nếu đang ở chế độ chỉnh sửa/thêm mới, nút này là "Hủy"
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private bool KiemTraDuLieuHopLe()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra chức vụ
            if (cmbChucVu.SelectedIndex == 0 || cmbChucVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbChucVu.Focus();
                return false;
            }

            // Kiểm tra số điện thoại (nếu có)
            if (!string.IsNullOrWhiteSpace(txtSoDienThoai.Text) && !IsValidPhoneNumber(txtSoDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            // Kiểm tra email (nếu có)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra lương (nếu có)
            if (!string.IsNullOrWhiteSpace(txtLuong.Text) && (!decimal.TryParse(txtLuong.Text, out decimal luong) || luong < 0))
            {
                MessageBox.Show("Lương phải là số và lớn hơn hoặc bằng 0!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuong.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^(0[3|5|7|8|9])+([0-9]{8,9})\b$");
        }
    }
}