using System;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormDatBan : Form
    {
        public DateTime StartAt => dtpStart.Value;
        public DateTime EndAt => dtpEnd.Value;
        public string CustomerName => txtKhach.Text.Trim();

        public FormDatBan()
        {
            InitializeComponent();
            dtpStart.ShowUpDown = true;
            dtpEnd.ShowUpDown = true;
            dtpStart.Value = DateTime.Now.AddMinutes(10);
            dtpEnd.Value = DateTime.Now.AddHours(2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustomerName))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                return;
            }
            if (EndAt <= StartAt)
            {
                MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}


