using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace QuanLyBida.GUI
{
    public partial class FormForgetPassword : Form
    {
        public FormForgetPassword()
        {
            InitializeComponent();

            // 1. SẮP XẾP TAB INDEX
            TextBox_email.TabIndex = 0;
            ButtonContinue.TabIndex = 1;

            // 2. GÁN SỰ KIỆN ENTER
            TextBox_email.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ButtonContinue.PerformClick(); e.SuppressKeyPress = true; } };

            this.PanelLeft.Paint += new PaintEventHandler(PanelLeft_Paint);

        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            try
            {
                string email = TextBox_email.Text.Trim();
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng nhập email!");
                    return;
                }

                TaiKhoanBLL bll = new TaiKhoanBLL();

                // 1. Kiểm tra email có trong hệ thống không
                var checkResult = bll.CheckEmailExists(email);
                if (!checkResult.Success)
                {
                    MessageBox.Show("Email này không tồn tại trong hệ thống!", "Lỗi");
                    return;
                }

                // 2. Tạo mã OTP ngẫu nhiên (Tại GUI hoặc BLL đều được, ở đây để GUI cho tiện truyền)
                Random rnd = new Random();
                string otp = rnd.Next(100000, 999999).ToString();

                // 3. Gọi BLL để gửi mail
                this.Cursor = Cursors.WaitCursor; // Hiển thị chuột xoay
                bool guithanhcong = bll.GuiMaOTP(email, otp);
                this.Cursor = Cursors.Default;

                if (guithanhcong)
                {
                    MessageBox.Show("Đã gửi mã OTP vào email. Vui lòng kiểm tra!");

                    // 4. Chuyển sang form Nhập mã OTP (Truyền mã OTP + Email qua)
                    FormXacthuc frm = new FormXacthuc(otp, email);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gửi mail thất bại. Vui lòng kiểm tra lại mạng hoặc email!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e) { }
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