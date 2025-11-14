using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Admin;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormMainAdmin : Form
    {
        private Form activeChildForm;

        public FormMainAdmin()
        {
            InitializeComponent();
            RegisterEvents();
            // Load dashboard mặc định khi form được mở
            OpenChildForm(new FormDashBoardAdmin());
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
