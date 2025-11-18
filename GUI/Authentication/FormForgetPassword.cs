using System;
using System.Drawing;
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
        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            try
            {
                string email = TextBox_email.Text.Trim();

                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng nhập email!", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi BLL để kiểm tra email
                var taiKhoanBLL = new TaiKhoanBLL();
                var result = taiKhoanBLL.CheckEmailExists(email);

                if (result.Success)
                {
                    this.Hide();
                    var newPasswordForm = new NewPassword(email); // Truyền email sang form mới
                    newPasswordForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Không tìm thấy email",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e) { }

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