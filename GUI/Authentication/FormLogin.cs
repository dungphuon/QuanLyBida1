using QuanLyBida.BLL;
using QuanLyBida.DAL;
using QuanLyBida.DTO;
using QuanLyBida.GUI.Admin;
using QuanLyBida.GUI.Main;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBida.GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            MakeRoundedControls();

            // 1. SẮP XẾP LẠI THỨ TỰ TAB (Để bấm Tab nó nhảy đúng thứ tự)
            TextBox_username.TabIndex = 0; // Đầu tiên
            Textboxpassword.TabIndex = 1;  // Thứ hai
            ButtonShowPassword.TabIndex = 2; // Nút hiện pass (nếu cần tab qua)
            ButtonLogin.TabIndex = 3;      // Cuối cùng là nút Login

            // Các link bên dưới
            LinkForgot.TabIndex = 4;
            LinkSignup.TabIndex = 5;

            // 2. GÁN SỰ KIỆN PHÍM ENTER (Để bấm Enter thì nhảy xuống hoặc Login)
            TextBox_username.KeyDown += TextBox_username_KeyDown;
            Textboxpassword.KeyDown += Textboxpassword_KeyDown;

            // Gán sự kiện Click cho ButtonLogin
            this.ButtonLogin.Click -= ButtonLogin_Click;
            this.ButtonLogin.Click += ButtonLogin_Click;
        }
        // --- THÊM MỚI: Xử lý khi bấm Enter ở ô Tài khoản ---
        private void TextBox_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Bấm Enter ở ô Username thì nhảy xuống ô Password
                Textboxpassword.Focus();
                e.SuppressKeyPress = true; // Tắt tiếng "ting" của windows
            }
        }

        // --- THÊM MỚI: Xử lý khi bấm Enter ở ô Mật khẩu ---
        private void Textboxpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Bấm Enter ở ô Password thì thực hiện Đăng nhập luôn
                ButtonLogin.PerformClick();
                e.SuppressKeyPress = true; // Tắt tiếng "ting"
            }
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
                    MessageBox.Show($"Đăng nhập thành công! Chào {taiKhoan.TenDangNhap}", "Thành công");

                    // Kiểm tra quyền theo VaiTro
                    if (IsAdminRole(taiKhoan.VaiTro))
                    {
                        // Mở form admin cho tài khoản có vai trò admin
                        this.Hide();
                        var adminForm = new FormMainAdmin(taiKhoan);
                        adminForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Mở form main thông thường cho nhân viên
                        this.Hide();
                        var mainForm = new FormMain1(taiKhoan);
                        mainForm.ShowDialog();
                        this.Close();
                    }
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
        private bool IsAdminRole(string vaiTro)
        {
            // Tuỳ chỉnh các vai trò được phép vào admin
            string[] adminRoles = { "Admin" };
            return adminRoles.Contains(vaiTro?.Trim(), StringComparer.OrdinalIgnoreCase);
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
            // Cập nhật vị trí các nút
            ButtonClose.Left = this.ClientSize.Width - ButtonClose.Width - 10;
            ButtonClose.Top = 10;
            ButtonMaximize.Left = ButtonClose.Left - ButtonMaximize.Width - 5;
            ButtonMaximize.Top = 10;
            ButtonMinimize.Left = ButtonMaximize.Left - ButtonMinimize.Width - 5;
            ButtonMinimize.Top = 10;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            FormLogin_Resize(sender, e); // Đảm bảo panel căn giữa khi load
            // Đảm bảo button hiển thị trên textbox
            ButtonShowPassword.BringToFront();
            TextBox_username.Focus();
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

        private void ButtonShowPassword_Click(object sender, EventArgs e)
        {
            if (Textboxpassword.PasswordChar == '●')
            {
                // Hiển thị mật khẩu
                Textboxpassword.PasswordChar = '\0';
                ButtonShowPassword.Text = "👁‍🗨";
            }
            else
            {
                // Ẩn mật khẩu bằng chấm tròn
                Textboxpassword.PasswordChar = '●';
                ButtonShowPassword.Text = "👁";
            }
        }
        
    }
}