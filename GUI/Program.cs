using QuanLyBida.GUI;
using QuanLyBida.GUI.Authentication;
using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //GUI.Properties.Settings.Default.Reset();

            string savedConnStr = global::GUI.Properties.Settings.Default.MyConnectionString;
            bool isConnected = false;

            if (!string.IsNullOrEmpty(savedConnStr))
            {
                if (DatabaseHelper.TestConnection(savedConnStr))
                {
                    isConnected = true;
                }
            }

            if (isConnected)
            {
                DatabaseHelper.SetConnectionString(savedConnStr);
                Application.Run(new FormLogin());
            }
            else
            {
                if (!string.IsNullOrEmpty(savedConnStr))
                {
                    MessageBox.Show("Không thể kết nối đến Cơ sở dữ liệu.\nVui lòng cấu hình lại hệ thống.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Application.Run(new FormCauHinh());
            }
        }
    }
}