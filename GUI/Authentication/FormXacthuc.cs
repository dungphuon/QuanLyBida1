using System;
using System.Windows.Forms;

namespace QuanLyBida.GUI
{
    public partial class FormXacthuc : Form
    {
        public FormXacthuc()
        {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string code = TextBox_Code.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Vui lòng nhập mã xác thực!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Thêm logic xác thực mã nếu cần
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

