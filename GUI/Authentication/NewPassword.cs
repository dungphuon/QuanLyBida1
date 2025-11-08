using System;
using System.Windows.Forms;
using QuanLyBida.BLL;
using QuanLyBida.DTO;

namespace QuanLyBida.GUI
{
    public partial class NewPassword : Form
    {
        private string _email;

        public NewPassword(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            try
            {
                string newPassword = TextBox_newPassword.Text;
                string confirmPassword = TextBox_confirmPassword.Text;

                // Validate
                if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp!", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newPassword.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Cảnh báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi BLL để đổi mật khẩu
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
    }
}