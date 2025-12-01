using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyBida.GUI
{
    public partial class FormXacthuc : Form
    {
        private string _otpHeThong; // Mã OTP đúng (được truyền từ form trước)
        private string _email;      // Email người dùng
        public FormXacthuc(string otp, string email)
        {
            InitializeComponent();
            _otpHeThong = otp;
            _email = email;

            // 1. SẮP XẾP TAB INDEX
            TextBox_Code.TabIndex = 0;
            ButtonConfirm.TabIndex = 1;

            // 2. GÁN SỰ KIỆN ENTER
            TextBox_Code.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ButtonConfirm.PerformClick(); e.SuppressKeyPress = true; } };
            this.PanelLeft.Paint += new PaintEventHandler(PanelLeft_Paint);

        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string otpNhap = TextBox_Code.Text.Trim();

            if (string.IsNullOrEmpty(otpNhap))
            {
                MessageBox.Show("Vui lòng nhập mã xác thực!");
                return;
            }

            // So sánh mã nhập vào với mã hệ thống
            if (otpNhap == _otpHeThong)
            {
                MessageBox.Show("Xác thực thành công!");

                // Mở form đổi mật khẩu
                NewPassword frm = new NewPassword(_email);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã xác thực không đúng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PanelLeft_Paint(object sender, PaintEventArgs e)
        {
            Color color1 = Color.FromArgb(26, 34, 65);
            Color color2 = Color.FromArgb(41, 128, 185);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                this.PanelLeft.ClientRectangle,
                color1,
                color2,
                LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(gradientBrush, this.PanelLeft.ClientRectangle);
        }
        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonMinimize_MouseEnter(object sender, EventArgs e)
        {
            ButtonMinimize.BackColor = Color.LightGray;
        }

        private void ButtonMinimize_MouseLeave(object sender, EventArgs e)
        {
            ButtonMinimize.BackColor = Color.Transparent;
        }

        private void ButtonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                ButtonMaximize.Text = "□";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                ButtonMaximize.Text = "❐";
            }
        }

        private void ButtonMaximize_MouseEnter(object sender, EventArgs e)
        {
            ButtonMaximize.BackColor = Color.LightGray;
        }

        private void ButtonMaximize_MouseLeave(object sender, EventArgs e)
        {
            ButtonMaximize.BackColor = Color.Transparent;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            ButtonClose.BackColor = Color.Red;
            ButtonClose.ForeColor = Color.White;
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            ButtonClose.BackColor = Color.Transparent;
            ButtonClose.ForeColor = Color.Gray;
        }
    }
}

