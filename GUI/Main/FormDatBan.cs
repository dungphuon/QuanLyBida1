using System;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormDatBan : Form
    {
        public DateTime StartAt => dtpStart.Value;
        public DateTime EndAt => dtpEnd.Value;
        public string CustomerName => txtKhach.Text.Trim();

        public FormDatBan()
        {
            InitializeComponent();

            // Cấu hình DateTimePicker 
            dtpStart.ShowUpDown = true;
            dtpEnd.ShowUpDown = true;
            dtpStart.Value = DateTime.Now.AddMinutes(10);
            dtpEnd.Value = DateTime.Now.AddHours(2);

            // --- 1. SẮP XẾP THỨ TỰ TAB  ---
            dtpStart.TabIndex = 0;
            dtpEnd.TabIndex = 1;
            txtKhach.TabIndex = 2;
            btnSave.TabIndex = 3;

            // --- 2. XỬ LÝ PHÍM ENTER ---

            // Chỉnh xong Giờ bắt đầu -> Enter -> Nhảy sang Giờ kết thúc
            dtpStart.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) { dtpEnd.Focus(); e.SuppressKeyPress = true; }
            };

            // Chỉnh xong Giờ kết thúc -> Enter -> Nhảy sang nhập Tên khách
            dtpEnd.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) { txtKhach.Focus(); e.SuppressKeyPress = true; }
            };

            // Nhập Tên khách xong -> Enter -> Bấm nút Lưu luôn
            txtKhach.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter) { btnSave.PerformClick(); e.SuppressKeyPress = true; }
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustomerName))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                txtKhach.Focus();
                return;
            }
            if (EndAt <= StartAt)
            {
                MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}


