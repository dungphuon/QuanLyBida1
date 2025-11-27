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
            // 1. Lấy chuỗi kết nối đã lưu trong Settings
            // (Lưu ý: Phải làm Bước 0 thì mới có dòng này)
            string savedConnStr = global::GUI.Properties.Settings.Default.MyConnectionString;
            // 2. Kiểm tra kết nối
            bool isConnected = false;

            if (!string.IsNullOrEmpty(savedConnStr))
            {
                // Thử kết nối với chuỗi đã lưu
                if (DatabaseHelper.TestConnection(savedConnStr))
                {
                    isConnected = true;
                }
            }

            // 3. Điều hướng
            if (isConnected)
            {
                // Nếu kết nối OK -> Nạp vào Helper và mở Form Login
                DatabaseHelper.SetConnectionString(savedConnStr);
                Application.Run(new FormLogin());
            }
            else
            {
                // Nếu chưa có cấu hình hoặc kết nối lỗi -> Mở Form Cấu Hình
                if (!string.IsNullOrEmpty(savedConnStr))
                {
                    MessageBox.Show("Không thể kết nối đến Cơ sở dữ liệu.\nVui lòng cấu hình lại hệ thống.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Application.Run(new FormCauHinh());
            }
        }
    }
}