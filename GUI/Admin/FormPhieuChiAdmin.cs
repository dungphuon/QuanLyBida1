using System;
using System.Drawing; // Cần thêm thư viện này
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace GUI.Admin
{
    public partial class FormPhieuChiAdmin : Form
    {
        private PhieuThuChiBLL _phieuBLL = new PhieuThuChiBLL();

        public FormPhieuChiAdmin()
        {
            InitializeComponent();
            Load += FormPhieuChiAdmin_Load;
        }

        private void FormPhieuChiAdmin_Load(object sender, EventArgs e)
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
                txtSoPhieu.Text = "PC_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            }
            catch
            {
                txtSoPhieu.Text = "PC_" + DateTime.Now.Ticks;
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
                MessageBox.Show("Vui lòng nhập lý do chi.");
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
                string nguoiNhan = txtNguoiNhan.Text.Trim();
                string fullLyDo = $"{lyDo} (Người nhận: {nguoiNhan})";

                bool ketQua = _phieuBLL.ThemPhieuChi(soTien, fullLyDo, "Tiền mặt", null);

                if (ketQua)
                {
                    MessageBox.Show("Thêm phiếu chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ShowPreview(noiDung, "PHIẾU CHI TIỀN");
        }

        private string TaoNoiDungPhieu()
        {
            return $@"
       BIDA CLUB - PHIẾU CHI
    ════════════════════════════
    Số phiếu:  {txtSoPhieu.Text}
    Ngày lập:  {dtpNgayLap.Value:dd/MM/yyyy HH:mm}
    ----------------------------
    Người nhận: {txtNguoiNhan.Text}
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
            // Không căn giữa để giống phiếu chi truyền thống hơn (hoặc tùy bạn)
            rtb.SelectionAlignment = HorizontalAlignment.Left;
            // Hack nhỏ để căn giữa tiêu đề
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
    }
}