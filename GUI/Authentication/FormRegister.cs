using QuanLyBida.BLL;
using QuanLyBida.DTO;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QuanLyBida.GUI
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            ButtonShowPassword.BringToFront();

            // 1. SẮP XẾP TAB INDEX
            TextBox_username.TabIndex = 0;
            TextBox_email.TabIndex = 1;
            TextBox_password.TabIndex = 2;
            ButtonShowPassword.TabIndex = 3;
            ButtonJoin.TabIndex = 4;

            // 2. GÁN SỰ KIỆN ENTER
            TextBox_username.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { TextBox_email.Focus(); e.SuppressKeyPress = true; } };
            TextBox_email.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { TextBox_password.Focus(); e.SuppressKeyPress = true; } };
            TextBox_password.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { ButtonJoin.PerformClick(); e.SuppressKeyPress = true; } };
        }

        private void ButtonJoin_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Test kết nối trước
                if (!DatabaseHelper.TestConnection())
                {
                    MessageBox.Show("Lỗi kết nối database!", "Lỗi");
                    return;
                }

                // 2. Lấy dữ liệu từ form
                string username = TextBox_username.Text.Trim();
                string email = TextBox_email.Text.Trim();
                string password = TextBox_password.Text;

                // 3. Kiểm tra rỗng
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. [MỚI] Kiểm tra mật khẩu: Ít nhất 8 ký tự, có chữ Hoa và Số
                // Regex: ^(?=.*[A-Z])(?=.*\d).{8,}$
                if (!Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d).{8,}$"))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ in hoa và chữ số!",
                                    "Mật khẩu yếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var taiKhoanDTO = new TaiKhoanDTO
                {
                    TenDangNhap = username,
                    Email = email,
                    MatKhau = password
                };

                // 5. Gọi BLL để đăng ký
                var taiKhoanBLL = new TaiKhoanBLL();
                var registerResult = taiKhoanBLL.Register(taiKhoanDTO);

                if (registerResult.Success)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo");

                    // Kiểm tra ngay trong database (Code cũ của bạn)
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