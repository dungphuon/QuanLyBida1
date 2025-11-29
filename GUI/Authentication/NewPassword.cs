using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;
using System.Text.RegularExpressions;

namespace QuanLyBida.GUI
{
    public partial class NewPassword : Form
    {
        private string _email;

        public NewPassword(string email)
        {
            InitializeComponent();
            _email = email;
            ButtonShowNewPassword.BringToFront();
            ButtonShowConfirmPassword.BringToFront();

            // 1. SẮP XẾP TAB INDEX
            TextBox_newPassword.TabIndex = 0;
            TextBox_confirmPassword.TabIndex = 1;
            ButtonShowNewPassword.TabIndex = 2;
            ButtonShowConfirmPassword.TabIndex = 3;
            ButtonChange.TabIndex = 4;

            // 2. GÁN SỰ KIỆN ENTER
            TextBox_newPassword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { TextBox_confirmPassword.Focus(); e.SuppressKeyPress = true; } };
            TextBox_confirmPassword.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ButtonChange.PerformClick(); e.SuppressKeyPress = true; } };
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            try
            {
                string newPassword = TextBox_newPassword.Text;
                string confirmPassword = TextBox_confirmPassword.Text;

                // 1. Kiểm tra rỗng
                if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Kiểm tra nhập lại có khớp không
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp!", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. [MỚI] Kiểm tra mật khẩu: Ít nhất 8 ký tự, có chữ Hoa và Số
                // Regex: ^(?=.*[A-Z])(?=.*\d).{8,}$
                if (!Regex.IsMatch(newPassword, @"^(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ in hoa và chữ số!",
                                    "Mật khẩu yếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Gọi BLL để đổi mật khẩu
                var taiKhoanBLL = new TaiKhoanBLL();
                var result = taiKhoanBLL.ChangePassword(_email, newPassword);

                if (result.Success)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var loginForm = new FormLogin();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Lỗi đổi mật khẩu",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TitleLabel_Click(object sender, EventArgs e) { }
        private void NewPassword_Load(object sender, EventArgs e) { }

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

        private void ButtonShowNewPassword_Click(object sender, EventArgs e)
        {
            if (TextBox_newPassword.PasswordChar == '●')
            {
                // Hiển thị mật khẩu
                TextBox_newPassword.PasswordChar = '\0';
                ButtonShowNewPassword.Text = "👁‍🗨";
            }
            else
            {
                // Ẩn mật khẩu bằng chấm tròn
                TextBox_newPassword.PasswordChar = '●';
                ButtonShowNewPassword.Text = "👁";
            }
        }

        private void ButtonShowConfirmPassword_Click(object sender, EventArgs e)
        {
            if (TextBox_confirmPassword.PasswordChar == '●')
            {
                // Hiển thị mật khẩu
                TextBox_confirmPassword.PasswordChar = '\0';
                ButtonShowConfirmPassword.Text = "👁‍🗨";
            }
            else
            {
                // Ẩn mật khẩu bằng chấm tròn
                TextBox_confirmPassword.PasswordChar = '●';
                ButtonShowConfirmPassword.Text = "👁";
            }
        }
    }
}