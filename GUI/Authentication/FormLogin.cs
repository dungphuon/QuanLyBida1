using QuanLyBida.BLL;
using QuanLyBida.DAL;
using QuanLyBida.DTO;
using QuanLyBida.GUI.Main;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBida.GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            MakeRoundedControls();

            // Gán sự kiện Click cho ButtonLogin
            this.ButtonLogin.Click -= ButtonLogin_Click;
            this.ButtonLogin.Click += ButtonLogin_Click;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = TextBox_username.Text.Trim();
                string password = Textboxpassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                    return;
                }

                var taiKhoanBLL = new TaiKhoanBLL();
                var loginResult = taiKhoanBLL.Login(username, password);

                if (loginResult.Success)
                {
                    var taiKhoan = loginResult.Data as TaiKhoanDTO;
                    MessageBox.Show($"Đăng nhập thành công! Chào {taiKhoan.HoTenNV}", "Thành công");

                    this.Hide();
                    var mainForm = new FormMain1(taiKhoan);
                    mainForm.ShowDialog();
                    this.Close(); // Đóng form login sau khi form main đóng
                }
                else
                {
                    MessageBox.Show(loginResult.Message, "Lỗi đăng nhập");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống");
            }
        }

        // Các method cũ giữ nguyên
        private void MakeRoundedControls()
        {
            // Bo tròn Button
            MakeRoundedButton(ButtonLogin, 25);
        }

        private void MakeRoundedButton(Button button, int radius)
        {
            button.Region = CreateRoundedRegion(button.Width, button.Height, radius);
        }

        private Region CreateRoundedRegion(int width, int height, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(width - radius * 2, height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        // Các method khác giữ nguyên
        private void LinkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForgetPassword forgetForm = new FormForgetPassword();
            forgetForm.ShowDialog();
        }

        private void LinkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new FormRegister();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }

        // Các method khác giữ nguyên...
        private void TitleLabel_Click(object sender, EventArgs e) { }
        private void MainPanel_Paint(object sender, PaintEventArgs e) { }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            // Căn giữa panel
            MainPanel.Left = (this.ClientSize.Width - MainPanel.Width) / 2;
            MainPanel.Top = (this.ClientSize.Height - MainPanel.Height) / 2;
            ButtonClose.Location = new Point(this.ClientSize.Width - ButtonClose.Width - 10, 10);
            ButtonClose.Left = this.ClientSize.Width - ButtonClose.Width - 10;
            ButtonClose.Top = 10;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            FormLogin_Resize(sender, e); // Đảm bảo panel căn giữa khi load
        }
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            ButtonClose.BackColor = Color.LightGray; // hoặc màu bạn muốn khi hover
        }



        
    }
}