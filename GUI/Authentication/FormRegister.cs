using QuanLyBida.BLL;
using QuanLyBida.DTO;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBida.GUI
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
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
        
    }
}