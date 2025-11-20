using GUI.Admin;
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

namespace QuanLyBida.GUI.Admin
{
    public partial class FormMainAdmin : Form
    {
        private Form activeChildForm;
        private TaiKhoanDTO currentUser;

        public FormMainAdmin(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            currentUser = taiKhoan;
            RegisterEvents();
            LoadUserInfo();

            // Kiểm tra quyền ngay khi khởi tạo
            if (!CheckAdminPermission())
            {
                MessageBox.Show("Bạn không có quyền truy cập trang quản trị!", "Từ chối truy cập",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            OpenChildForm(new FormDashBoardAdmin());
        }

        private void LoadUserInfo()
        {
            // Hiển thị thông tin người dùng
            
            labelRole.Text = currentUser.VaiTro; // Hiển thị VaiTro thay vì ChucVu
        }

        private bool CheckAdminPermission()
        {
            // Kiểm tra quyền theo VaiTro
            string[] allowedRoles = { "Admin"};
            return allowedRoles.Contains(currentUser.VaiTro?.Trim(), StringComparer.OrdinalIgnoreCase);
        }

        private void RegisterEvents()
        {
            this.buttonTrangchu.Click += ButtonTrangchu_Click;
            this.buttonQuanlyban.Click += ButtonQuanlyban_Click;
            this.buttonQuanlyNhanVien.Click += ButtonQuanlyNhanVien_Click;
            this.buttonHanghoa.Click += ButtonHanghoa_Click;
        }

        private void ButtonTrangchu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDashBoardAdmin());
        }

        private void ButtonQuanlyban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQLBanAdmin());
        }

        private void ButtonQuanlyNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQLNV());
        }

        private void ButtonHanghoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormManageProduct());
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
            }

            activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.panelAdminLoad.Controls.Clear();
            this.panelAdminLoad.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
