using Guna.UI2.WinForms;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBida.BLL;
namespace QuanLyBida.GUI.Main
{
    public partial class FormMain1 : Form
    {
        private TaiKhoanDTO _taiKhoan;

        // Constructor mới nhận thông tin tài khoản
        public FormMain1(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;

            // Gắn sự kiện Click cho nút TrangchuButton 
            TrangchuButton.Click += TrangchuButton_Click;
            // Load mặc định Trang chủ khi mở FormMain1
            this.Load += FormMain1_Load;

            // Hiển thị tên nhân viên trên sidebar
            DisplayUserInfo();
        }
        private void DisplayUserInfo()
        {
            if (_taiKhoan != null && !string.IsNullOrEmpty(_taiKhoan.TenDangNhap))
            {
                // Hiển thị tên nhân viên lên label2 trong user_information
                label2.Text = _taiKhoan.TenDangNhap;
            }
            else
            {
                label2.Text = "User";
            }
        }

        public FormMain1()
        {
            InitializeComponent();
            // Gắn sự kiện Click cho nút TrangchuButton 
            TrangchuButton.Click += TrangchuButton_Click;
            // Load mặc định Trang chủ khi mở FormMain1
            this.Load += FormMain1_Load;
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
            TableBLL tableBLL = new TableBLL();
            var danhSachBan = tableBLL.GetAllTables();

            // Đếm số bàn đang "Đang sử dụng"
            int banDangChoi = danhSachBan.Count(t => t.TrangThai == "Đang sử dụng");

            if (banDangChoi > 0)
            {
                // Nếu có bàn đang chơi -> Hiện cảnh báo 
                var warnResult = MessageBox.Show(
                    $"Đang có {banDangChoi} bàn chưa thanh toán!\n\n" +
                    "Nếu bạn đăng xuất bây giờ, các bàn này vẫn sẽ tiếp tục tính giờ.\n" +
                    "Bạn có chắc chắn muốn đăng xuất không?",
                    "Cảnh báo bàn đang hoạt động",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2 
                );

                if (warnResult == DialogResult.No)
                {
                    return; 
                }
            }
            else
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn đăng xuất?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }

           
            this.Hide();
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrangchuButton_Click(object sender, EventArgs e)
        {
            FormTrangchu TrangchuForm = new FormTrangchu();

            // Hiển thị FormLogin bên trong guna2GradientPanel1
            LoadFormToPanel(TrangchuForm);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMain1_Load(object sender, EventArgs e)
        {
            // Hiển thị mặc định form Trang chủ khi mở ứng dụng
            LoadFormToPanel(new FormTrangchu());
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            var formQLB = new FormQuanlyban();

            // TRUYỀN CẢ TAIKHOANDTO
            formQLB.CurrentTaiKhoan = _taiKhoan;
            formQLB.CurrentUserName = _taiKhoan?.TenDangNhap ?? "Nhân viên";

            LoadFormToPanel(formQLB);

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void QLKHbutton_Click(object sender, EventArgs e)
        {
            // Load form Quản lý khách hàng vào panelLoad
            LoadFormToPanel(new FormQLKH());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Load form Quản lý dịch vụ ăn uống
            LoadFormToPanel(new FormQuanlydichvuanuong(_taiKhoan));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Xác nhận đăng xuất
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Đóng form chính; luồng đăng xuất/đăng nhập thực tế sẽ xử lý ở nơi khác
                this.Close();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hoadonbutton_Click(object sender, EventArgs e)
        {
            // Load form Quản lý hóa đơn vào panelLoad
            LoadFormToPanel(new FormQLHD());
        }

        private void Helpbutton_Click(object sender, EventArgs e)
        {
            // Load form Trợ giúp vào panelLoad
            LoadFormToPanel(new FormHelp());
        }

        private void buttonFinane_Click(object sender, EventArgs e)
        {
            // Placeholder for financial management
            var formQLQuy = new FormQLQuy(_taiKhoan);
            LoadFormToPanel(formQLQuy);
        }
    }
    }

