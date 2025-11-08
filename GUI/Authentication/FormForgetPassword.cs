using System;
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
    }
}