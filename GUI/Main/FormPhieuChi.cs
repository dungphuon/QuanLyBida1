using System;
using System.Windows.Forms;
using System.Drawing;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace QuanLyBida.GUI.Main
{
    public partial class FormPhieuChi : Form
    {
        private PhieuThuChiBLL _phieuBLL = new PhieuThuChiBLL();
        private int _maNV;
        private string _tenNV;

        public FormPhieuChi(int maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;
            Load += FormPhieuChi_Load;
        }

        public FormPhieuChi(string tenNhanVien = "")
        {
            InitializeComponent();
            _tenNV = tenNhanVien;
            Load += FormPhieuChi_Load;
        }

        private void FormPhieuChi_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định
            dtpNgayLap.Value = DateTime.Now;

            // Tạo số phiếu tự động
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
            txtSoTien.KeyPress += TxtSoTien_KeyPress;

            // Đặt tab order
            SetTabOrder();
        }

        private void TaoSoPhieuTuDong()
        {
            try
            {
                // Tạo số phiếu theo thời gian
                string soPhieuMoi = "PC_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                txtSoPhieu.Text = soPhieuMoi;
            }
            catch (Exception ex)
            {
                // Fallback đơn giản
                txtSoPhieu.Text = "PC_" + DateTime.Now.Ticks.ToString();
                Console.WriteLine($"Lỗi tạo số phiếu: {ex.Message}");
            }
        }

        private void SetTabOrder()
        {
            txtSoPhieu.TabStop = false; // Vì là readonly
            dtpNgayLap.TabIndex = 0;
            txtNguoiNop.TabIndex = 1;
            txtLyDo.TabIndex = 2;
            txtSoTien.TabIndex = 3;
            txtNguoiLap.TabIndex = 4;
            btnLuu.TabIndex = 5;
            btnInPhieu.TabIndex = 6;
            btnHuy.TabIndex = 7;
        }

        private void TxtSoTien_TextChanged(object sender, EventArgs e)
        {
            // Format số tiền khi nhập
            FormatCurrencyTextBox();
        }

        private void TxtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormatCurrencyTextBox()
        {
            if (string.IsNullOrWhiteSpace(txtSoTien.Text))
                return;

            // Loại bỏ các dấu phẩy hiện có
            string text = txtSoTien.Text.Replace(",", "").Replace(".", "");

            // Parse thành số
            if (decimal.TryParse(text, out decimal value))
            {
                // Định dạng lại với dấu phẩy ngăn cách hàng nghìn
                txtSoTien.Text = value.ToString("N0");

                // Đặt vị trí con trỏ về cuối
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


                // Gọi BLL để thêm phiếu chi
                bool result = _phieuBLL.ThemPhieuChi(soTien, lyDo, phuongThuc, _maNV);

                if (result)
                {
                    MessageBox.Show("Lưu phiếu chi thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu phiếu chi!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu chi: {ex.Message}", "Lỗi",
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
                MessageBox.Show("Vui lòng nhập lý do chi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return false;
            }

            // Kiểm tra loại phiếu chi
            if (string.IsNullOrEmpty(txtNguoiNop.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập loại phiếu chi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiNop.Focus();
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
            if (!KiemTraDuLieuHopLe()) return;

            try
            {
                string noiDungPhieu = TaoNoiDungPhieuChi();
                ShowPreview(noiDungPhieu, "PHIẾU CHI TIỀN");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in phiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string TaoNoiDungPhieuChi()
        {
            // Format lại cho đẹp giống Admin
            return $@"
       BIDA CLUB - PHIẾU CHI
    ════════════════════════════
    Số phiếu:  {txtSoPhieu.Text}
    Ngày lập:  {dtpNgayLap.Value:dd/MM/yyyy HH:mm}
    ----------------------------
    Người nhận: {txtNguoiNop.Text}
    Lý do chi:  {txtLyDo.Text}
    
    SỐ TIỀN:    {txtSoTien.Text} VND
    ----------------------------
    Người lập:  {txtNguoiLap.Text}
    
    (Ký, ghi rõ họ tên)
    
    
    ════════════════════════════";
        }

        private void ShowPreview(string content, string title)
        {
            Form previewForm = new Form();
            previewForm.Text = title;
            previewForm.Size = new Size(400, 550);
            previewForm.StartPosition = FormStartPosition.CenterParent;
            previewForm.BackColor = Color.White;

            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.Text = content;
            rtb.Font = new Font("Courier New", 11, FontStyle.Regular);
            rtb.ReadOnly = true;
            rtb.BorderStyle = BorderStyle.None;

            // Căn giữa tiêu đề
            rtb.SelectionAlignment = HorizontalAlignment.Left;
            rtb.Select(0, content.IndexOf("════"));
            rtb.SelectionAlignment = HorizontalAlignment.Center;

            Button btnClose = new Button();
            btnClose.Text = "Đóng / In";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 40;
            btnClose.Click += (s, e) => previewForm.Close();

            previewForm.Controls.Add(rtb);
            previewForm.Controls.Add(btnClose);
            previewForm.ShowDialog();
        }

        // Property để lấy thông tin phiếu chi (nếu cần)
        public object GetPhieuChiInfo()
        {
            return new
            {
                SoPhieu = txtSoPhieu.Text,
                NgayLap = dtpNgayLap.Value,
                LoaiPhieuChi = txtNguoiNop.Text.Trim(),
                LyDo = txtLyDo.Text.Trim(),
                SoTien = decimal.Parse(txtSoTien.Text.Replace(",", "").Replace(".", "")),
                NguoiLap = txtNguoiLap.Text.Trim()
            };
        }
    }
}