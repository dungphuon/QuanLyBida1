using Guna.UI2.WinForms;
using QuanLyBida.DTO;
using QuanLyBida.GUI.Main;
using QuanLyBida.GUI.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormMainAdmin : Form
    {
        private TaiKhoanDTO _taiKhoan;

        // Constructor nhận thông tin tài khoản
        public FormMainAdmin(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;

            // Gắn sự kiện Click cho nút TrangchuButton 
            TrangchuButton.Click += TrangchuButton_Click;
            // Load mặc định Trang chủ khi mở FormMainAdmin
            this.Load += FormMainAdmin_Load;

            // Hiển thị tên admin trên sidebar
            DisplayUserInfo();
        }

        private void DisplayUserInfo()
        {
            if (_taiKhoan != null && !string.IsNullOrEmpty(_taiKhoan.TenDangNhap))
            {
                // Hiển thị tên admin lên label2 trong user_information
                label2.Text = _taiKhoan.TenDangNhap + " (Admin)";
            }
            else
            {
                label2.Text = "Admin";
            }
        }

        public FormMainAdmin()
        {
            InitializeComponent();
            // Gắn sự kiện Click cho nút TrangchuButton 
            TrangchuButton.Click += TrangchuButton_Click;
            // Load mặc định Trang chủ khi mở FormMainAdmin
            this.Load += FormMainAdmin_Load;
        }

        private void LoadFormToPanel(Form form)
        {
            // Xóa control cũ nếu có
            panelLoad.Controls.Clear();

            // Thiết lập form con hiển thị trong panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Thêm form con vào panel
            panelLoad.Controls.Add(form);
            form.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // Xác nhận đăng xuất
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Quay lại form đăng nhập
                FormLogin loginForm = new FormLogin();
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void FormMainAdmin_Load(object sender, EventArgs e)
        {
            // Hiển thị mặc định form Quản lý bàn khi mở ứng dụng
            Quanlybanbutton_Click(null, null);
        }

        private void Quanlybanbutton_Click(object sender, EventArgs e)
        {
            var formQLB = new FormQuanlyban();

            // TRUYỀN CẢ TAIKHOANDTO
            formQLB.CurrentTaiKhoan = _taiKhoan;
            formQLB.CurrentUserName = _taiKhoan?.TenDangNhap ?? "Admin";

            LoadFormToPanel(formQLB);
        }

        private void ButtonHanghoa_Click(object sender, EventArgs e)
        {
            // Load form Quản lý dịch vụ ăn uống
            LoadFormToPanel(new FormQuanlydichvuanuong(_taiKhoan));
        }

        private void buttonFinane_Click(object sender, EventArgs e)
        {
            // Quản lý quỹ
            var formQLQuy = new FormQLQuy(_taiKhoan);
            LoadFormToPanel(formQLQuy);
        }

        private void ButtonNhanVien_Click(object sender, EventArgs e)
        {
            // TODO: Load form Quản lý nhân viên (cần tạo form này)
            MessageBox.Show("Chức năng Quản lý nhân viên đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonBaoTri_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chế độ bảo trì: quản lý bảo trì bàn/bảo dưỡng thiết bị sẽ được bổ sung.", "Bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonBaoCao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Báo cáo - Thống kê: doanh thu, lượt chơi, sản phẩm... sắp có.", "Báo cáo - Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
