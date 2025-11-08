using System;
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace QuanLyBida.GUI.Main
{
    public partial class FormPhieuThu : Form
    {
        private PhieuThuChiBLL _phieuBLL = new PhieuThuChiBLL();
        private int _maNV;
        private string _tenNV;

        public FormPhieuThu(int maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;
            Load += FormPhieuThu_Load;
        }

        public FormPhieuThu(string tenNhanVien = "")
        {
            InitializeComponent();
            _tenNV = tenNhanVien;
            Load += FormPhieuThu_Load;
        }

        private void FormPhieuThu_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định
            dtpNgayLap.Value = DateTime.Now;

            // Tạo số phiếu tự động theo thời gian
            TaoSoPhieuTuDong();

            // Điền tên người lập nếu có
            if (!string.IsNullOrEmpty(_tenNV))
            {
                txtNguoiLap.Text = _tenNV;
            }

            // Gán sự kiện cho các nút
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            btnInPhieu.Click += BtnInPhieu_Click;

            // Định dạng textbox số tiền
            txtSoTien.TextChanged += TxtSoTien_TextChanged;
        }

        // 🔥 SỬA: Tạo số phiếu tự động đơn giản
        private void TaoSoPhieuTuDong()
        {
            try
            {
                // Tạo số phiếu theo thời gian
                string soPhieuMoi = "PT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                txtSoPhieu.Text = soPhieuMoi;
            }
            catch (Exception ex)
            {
                // Fallback đơn giản
                txtSoPhieu.Text = "PT_" + DateTime.Now.Ticks.ToString();
                Console.WriteLine($"Lỗi tạo số phiếu: {ex.Message}");
            }
        }

        private void TxtSoTien_TextChanged(object sender, EventArgs e)
        {
            // Format số tiền khi nhập
            if (decimal.TryParse(txtSoTien.Text.Replace(",", "").Replace(".", ""), out decimal soTien))
            {
                txtSoTien.Text = soTien.ToString("N0");
                txtSoTien.SelectionStart = txtSoTien.Text.Length;
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (!KiemTraDuLieuHopLe())
                    return;

                // Lấy dữ liệu từ form
                decimal soTien = decimal.Parse(txtSoTien.Text.Replace(",", "").Replace(".", ""));
                string lyDo = txtLyDo.Text.Trim();
                string phuongThuc = "Tiền mặt";

                Console.WriteLine($"✅ Lưu phiếu thu với MaNV = {_maNV}");

                // 🔥 SỬA: Gọi phương thức với 4 tham số (bỏ số phiếu)
                bool result = _phieuBLL.ThemPhieuThu(soTien, lyDo, phuongThuc, _maNV);

                if (result)
                {
                    MessageBox.Show("Lưu phiếu thu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu phiếu thu!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDuLieuHopLe()
        {
            // Kiểm tra số tiền
            if (string.IsNullOrEmpty(txtSoTien.Text) || !decimal.TryParse(txtSoTien.Text.Replace(",", "").Replace(".", ""), out decimal soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return false;
            }

            if (soTien <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return false;
            }

            // Kiểm tra lý do
            if (string.IsNullOrEmpty(txtLyDo.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập lý do!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return false;
            }

            // Kiểm tra người lập
            if (string.IsNullOrEmpty(txtNguoiLap.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập người lập phiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiLap.Focus();
                return false;
            }

            return true;
        }

        private void BtnInPhieu_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuHopLe())
                return;

            try
            {
                // Tạo nội dung phiếu thu để in
                string noiDungPhieu = TaoNoiDungPhieuThu();

                // Hiển thị form in (tạm thời hiển thị messagebox)
                MessageBox.Show(noiDungPhieu, "Nội dung phiếu thu",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in phiếu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn hủy? Mọi thay đổi sẽ không được lưu.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private string TaoNoiDungPhieuThu()
        {
            decimal soTien = decimal.Parse(txtSoTien.Text.Replace(",", "").Replace(".", ""));

            return $@"PHIẾU THU
══════════════════════════════
Số phiếu: {txtSoPhieu.Text}
Ngày: {dtpNgayLap.Value:dd/MM/yyyy}
Số tiền: {soTien:N0} đ
Lý do: {txtLyDo.Text}
Người lập: {txtNguoiLap.Text}
Phương thức: Tiền mặt
──────────────────────────────
            Phiếu thu này đã được ghi nhận vào sổ quỹ.
══════════════════════════════";
        }

        // Sự kiện khi nhấn Enter trong txtSoTien
        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}