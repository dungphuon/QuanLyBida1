using System;
using System.Drawing; // Cần thêm thư viện này để vẽ giao diện in
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace GUI.Admin
{
    public partial class FormPhieuThuAdmin : Form
    {
        private PhieuThuChiBLL _phieuBLL = new PhieuThuChiBLL();

        public FormPhieuThuAdmin()
        {
            InitializeComponent();
            Load += FormPhieuThuAdmin_Load;
        }

        private void FormPhieuThuAdmin_Load(object sender, EventArgs e)
        {
            dtpNgayLap.Value = DateTime.Now;
            txtNguoiLap.Text = "Admin";
            txtNguoiLap.ReadOnly = true;

            TaoSoPhieuTuDong();

            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            btnInPhieu.Click += BtnInPhieu_Click;
            txtSoTien.TextChanged += TxtSoTien_TextChanged;
            txtSoTien.KeyPress += TxtSoTien_KeyPress;
        }

        private void TaoSoPhieuTuDong()
        {
            try
            {
                txtSoPhieu.Text = "PT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            }
            catch
            {
                txtSoPhieu.Text = "PT_" + DateTime.Now.Ticks;
            }
        }

        private void TxtSoTien_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTien.Text)) return;
            string text = txtSoTien.Text.Replace(",", "").Replace(".", "");
            if (decimal.TryParse(text, out decimal value))
            {
                txtSoTien.Text = value.ToString("N0");
                txtSoTien.SelectionStart = txtSoTien.Text.Length;
            }
        }

        private void TxtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrEmpty(txtSoTien.Text) || txtSoTien.Text == "0")
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ.");
                return false;
            }
            if (string.IsNullOrEmpty(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do.");
                return false;
            }
            return true;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraDuLieu()) return;

                decimal soTien = decimal.Parse(txtSoTien.Text.Replace(",", "").Replace(".", ""));
                string lyDo = txtLyDo.Text.Trim();
                string nguoiNop = txtNguoiThu.Text.Trim();
                string fullLyDo = $"{lyDo} (Người nộp: {nguoiNop})";

                bool ketQua = _phieuBLL.ThemPhieuThu(soTien, fullLyDo, "Tiền mặt", null);

                if (ketQua)
                {
                    MessageBox.Show("Thêm phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- CHỨC NĂNG IN PHIẾU ---
        private void BtnInPhieu_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            string noiDung = TaoNoiDungPhieu();
            ShowPreview(noiDung, "PHIẾU THU TIỀN");
        }

        private string TaoNoiDungPhieu()
        {
            return $@"
       BIDA CLUB - PHIẾU THU
    ════════════════════════════
    Số phiếu:  {txtSoPhieu.Text}
    Ngày lập:  {dtpNgayLap.Value:dd/MM/yyyy HH:mm}
    ----------------------------
    Người nộp: {txtNguoiThu.Text}
    Lý do thu: {txtLyDo.Text}
    
    SỐ TIỀN:   {txtSoTien.Text} VND
    ----------------------------
    Người lập: {txtNguoiLap.Text}
    
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
            rtb.Font = new Font("Courier New", 11, FontStyle.Regular); // Font máy in
            rtb.ReadOnly = true;
            rtb.BorderStyle = BorderStyle.None;
            rtb.SelectionAlignment = HorizontalAlignment.Center; // Căn giữa

            Button btnClose = new Button();
            btnClose.Text = "Đóng / In";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 40;
            btnClose.Click += (s, e) => previewForm.Close();

            previewForm.Controls.Add(rtb);
            previewForm.Controls.Add(btnClose);
            previewForm.ShowDialog();
        }
    }
}