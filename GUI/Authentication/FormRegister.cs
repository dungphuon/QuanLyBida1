using QuanLyBida.BLL;
using QuanLyBida.DTO;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBida.GUI
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            // Đảm bảo button hiển thị trên textbox
            ButtonShowPassword.BringToFront();
        }

        private void ButtonJoin_Click(object sender, EventArgs e)
        {
            try
            {
                // Test kết nối trước
                if (!DatabaseHelper.TestConnection())
                {
                    MessageBox.Show("Lỗi kết nối database!", "Lỗi");
                    return;
                }

                // Lấy dữ liệu từ form
                var taiKhoanDTO = new TaiKhoanDTO
                {
                    TenDangNhap = TextBox_username.Text.Trim(),
                    Email = TextBox_email.Text.Trim(),
                    MatKhau = TextBox_password.Text
                };


                // Gọi BLL để đăng ký
                var taiKhoanBLL = new TaiKhoanBLL();
                var registerResult = taiKhoanBLL.Register(taiKhoanDTO);

                if (registerResult.Success)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo");

                    // Kiểm tra ngay trong database
                    CheckUserInDatabase(taiKhoanDTO.TenDangNhap);

                    var loginForm = new FormLogin();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(registerResult.Message, "Lỗi đăng ký");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.ToString()}", "Lỗi hệ thống");
            }
        }

        private void CheckUserInDatabase(string username)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @Username", conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra: {ex.Message}", "Lỗi");
            }
        }

        private void TitleLabel_Click(object sender, EventArgs e) { }

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

        private void ButtonShowPassword_Click(object sender, EventArgs e)
        {
            if (TextBox_password.PasswordChar == '●')
            {
                // Hiển thị mật khẩu
                TextBox_password.PasswordChar = '\0';
                ButtonShowPassword.Text = "👁‍🗨";
            }
            else
            {
                // Ẩn mật khẩu bằng chấm tròn
                TextBox_password.PasswordChar = '●';
                ButtonShowPassword.Text = "👁";
            }
        }

        private void LabelUsername_Click(object sender, EventArgs e)
        {

        }
    }
}