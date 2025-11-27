using System;
using System.Data.SqlClient;
using System.Drawing; // Để dùng Color
using System.Windows.Forms;

namespace QuanLyBida.GUI.Authentication
{
    public partial class FormCauHinh : Form
    {
        public FormCauHinh()
        {
            InitializeComponent();

            // Cài đặt ComboBox
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Windows Authentication");
            comboBox1.Items.Add("SQL Server Authentication");
            comboBox1.SelectedIndex = 0; // Mặc định chọn cái đầu

            // Gán sự kiện
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            guna2Button1.Click += BtnKiemTra_Click; // Nút Kiểm tra (nút xám)
            guna2Button2.Click += BtnLuu_Click;     // Nút Lưu (nút xanh)
        }

        // Xử lý ẩn/hiện ô nhập liệu
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Windows Authentication")
            {
                // Khóa và làm mờ
                guna2TextBox3.Enabled = false; // User
                guna2TextBox4.Enabled = false; // Pass
                guna2TextBox3.FillColor = Color.WhiteSmoke;
                guna2TextBox4.FillColor = Color.WhiteSmoke;
            }
            else
            {
                // Mở khóa
                guna2TextBox3.Enabled = true;
                guna2TextBox4.Enabled = true;
                guna2TextBox3.FillColor = Color.White;
                guna2TextBox4.FillColor = Color.White;
            }
        }

        // Hàm tạo chuỗi kết nối từ các ô nhập liệu
        private string GetConnectionStringFromForm()
        {
            string server = guna2TextBox1.Text.Trim(); // Server
            string db = guna2TextBox2.Text.Trim();     // Database

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(db)) return "";

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = db;

            if (comboBox1.SelectedItem.ToString() == "Windows Authentication")
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = guna2TextBox3.Text.Trim(); // User
                builder.Password = guna2TextBox4.Text.Trim(); // Pass
            }

            return builder.ConnectionString;
        }

        // Nút Kiểm tra kết nối
        private void BtnKiemTra_Click(object sender, EventArgs e)
        {
            string connStr = GetConnectionStringFromForm();

            if (string.IsNullOrEmpty(connStr))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Server và Database!");
                return;
            }

            if (DatabaseHelper.TestConnection(connStr))
            {
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kết nối thất bại. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Lưu
        // Trong file FormCauHinh.cs

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string connStr = GetConnectionStringFromForm();

            if (!DatabaseHelper.TestConnection(connStr))
            {
                MessageBox.Show("Kết nối không hợp lệ. Vui lòng kiểm tra lại trước khi lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- SỬA ĐOẠN NÀY ---
            // Thêm "global::GUI." vào trước để trỏ đúng vào Project GUI
            global::GUI.Properties.Settings.Default.MyConnectionString = connStr;
            global::GUI.Properties.Settings.Default.Save();
            // --------------------

            DatabaseHelper.SetConnectionString(connStr);

            MessageBox.Show("Lưu cấu hình thành công!", "Thông báo");

            this.Hide();
            FormLogin login = new FormLogin();
            login.ShowDialog();
            this.Close();
        }

        // Giữ nguyên code giao diện cũ của bạn
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void ButtonMinimize_Click(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }
        private void ButtonMinimize_MouseEnter(object sender, EventArgs e) { ButtonMinimize.BackColor = Color.LightGray; }
        private void ButtonMinimize_MouseLeave(object sender, EventArgs e) { ButtonMinimize.BackColor = Color.Transparent; }
        private void ButtonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; ButtonMaximize.Text = "□"; }
            else { this.WindowState = FormWindowState.Maximized; ButtonMaximize.Text = "❐"; }
        }
        private void ButtonMaximize_MouseEnter(object sender, EventArgs e) { ButtonMaximize.BackColor = Color.LightGray; }
        private void ButtonMaximize_MouseLeave(object sender, EventArgs e) { ButtonMaximize.BackColor = Color.Transparent; }
        private void ButtonClose_Click(object sender, EventArgs e) { Application.Exit(); }
        private void ButtonClose_MouseEnter(object sender, EventArgs e) { ButtonClose.BackColor = Color.Red; ButtonClose.ForeColor = Color.White; }
        private void ButtonClose_MouseLeave(object sender, EventArgs e) { ButtonClose.BackColor = Color.Transparent; ButtonClose.ForeColor = Color.Gray; }
    }
}