using QuanLyBida.BLL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormQuanlydichvuanuong : Form
    {
        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        private List<SanPhamDTO> _currentSanPhamList = new List<SanPhamDTO>();
        private TaiKhoanDTO _taiKhoan;

        public FormQuanlydichvuanuong(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
        }
        public FormQuanlydichvuanuong()
        {
            InitializeComponent();
        }

        private void FormQuanlydichvuanuong_Load(object sender, EventArgs e)
        {
            // Thiết lập DataGridView
            SetupDataGridView();

            // Load dữ liệu từ database
            LoadDataFromDatabase();
        }

        private void SetupDataGridView()
        {
            // Xóa các cột cũ
            guna2DataGridViewHangHoa.Columns.Clear();

            // Thiết lập style cho DataGridView
            guna2DataGridViewHangHoa.AllowUserToAddRows = false;
            guna2DataGridViewHangHoa.AllowUserToDeleteRows = false;
            guna2DataGridViewHangHoa.AllowUserToResizeRows = false;
            guna2DataGridViewHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridViewHangHoa.BackgroundColor = Color.White;
            guna2DataGridViewHangHoa.BorderStyle = BorderStyle.None;
            guna2DataGridViewHangHoa.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridViewHangHoa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            guna2DataGridViewHangHoa.RowHeadersVisible = false;
            guna2DataGridViewHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            guna2DataGridViewHangHoa.MultiSelect = false;

            // Thiết lập header style
            guna2DataGridViewHangHoa.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 246, 253);
            guna2DataGridViewHangHoa.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(45, 53, 69);
            guna2DataGridViewHangHoa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            guna2DataGridViewHangHoa.ColumnHeadersHeight = 50;
            guna2DataGridViewHangHoa.EnableHeadersVisualStyles = false;

            // Thiết lập cell style
            guna2DataGridViewHangHoa.DefaultCellStyle.BackColor = Color.White;
            guna2DataGridViewHangHoa.DefaultCellStyle.ForeColor = Color.FromArgb(45, 53, 69);
            guna2DataGridViewHangHoa.DefaultCellStyle.Font = new Font("Segoe UI", 10.2F);
            guna2DataGridViewHangHoa.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 237, 250);
            guna2DataGridViewHangHoa.DefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 53, 69);
            guna2DataGridViewHangHoa.GridColor = Color.FromArgb(232, 237, 250);

            // Thêm các cột (ĐÃ BỎ CỘT MÔ TẢ)
            guna2DataGridViewHangHoa.Columns.Add("MaSP", "Mã SP");
            guna2DataGridViewHangHoa.Columns.Add("TenSP", "Tên Sản Phẩm");
            guna2DataGridViewHangHoa.Columns.Add("GiaBan", "Giá (VNĐ)");
            guna2DataGridViewHangHoa.Columns.Add("SoLuongTon", "Số lượng tồn");
            guna2DataGridViewHangHoa.Columns.Add("DonViTinh", "Đơn vị");

            // CHỈ CÒN CỘT XÓA - ĐÃ BỎ CỘT SỬA
            DataGridViewLinkColumn colDelete = new DataGridViewLinkColumn();
            colDelete.ActiveLinkColor = Color.IndianRed;
            colDelete.HeaderText = "Xóa";
            colDelete.LinkColor = Color.IndianRed;
            colDelete.MinimumWidth = 60;
            colDelete.Name = "Delete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Xóa";
            colDelete.UseColumnTextForLinkValue = true;
            colDelete.VisitedLinkColor = Color.IndianRed;
            guna2DataGridViewHangHoa.Columns.Add(colDelete);
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                _currentSanPhamList = _sanPhamBLL.GetDanhSachSanPham();
                BindDataToGrid(_currentSanPhamList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid(List<SanPhamDTO> sanPhamList)
        {
            guna2DataGridViewHangHoa.Rows.Clear();

            int stt = 1;
            foreach (var sp in sanPhamList)
            {
                if (sp.MaSP <= 0) continue;
                guna2DataGridViewHangHoa.Rows.Add(
                    sp.MaSP,
                    sp.TenSP,
                    string.Format("{0:N0}", sp.GiaBan),
                    sp.SoLuongTon,
                    sp.DonViTinh,
                    "Xóa"  // CHỈ CÒN NÚT XÓA
                );
                stt++;
            }

            // Hiển thị tổng số sản phẩm
            labelTitle.Text = $"Quản Lý Dịch Vụ & Ẩm Thực ({sanPhamList.Count} sản phẩm)";
        }

        private void guna2DataGridViewHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maSP = Convert.ToInt32(guna2DataGridViewHangHoa.Rows[e.RowIndex].Cells["MaSP"].Value);
                string tenSP = guna2DataGridViewHangHoa.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();

                // CHỈ XỬ LÝ SỰ KIỆN XÓA
                if (guna2DataGridViewHangHoa.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show($"Bạn có muốn xóa sản phẩm {tenSP}?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            bool success = _sanPhamBLL.XoaSanPham(maSP);
                            if (success)
                            {
                                guna2DataGridViewHangHoa.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show($"Đã xóa sản phẩm {tenSP} thành công!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Cập nhật lại tổng số sản phẩm
                                labelTitle.Text = $"Quản Lý Dịch Vụ & Ẩm Thực ({guna2DataGridViewHangHoa.Rows.Count} sản phẩm)";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void guna2TextBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = guna2TextBoxTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadDataFromDatabase();
                return;
            }

            try
            {
                var searchResults = _sanPhamBLL.TimKiemSanPham(searchText);
                BindDataToGrid(searchResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonNhapHang_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔥 LẤY THÔNG TIN TỪ _taiKhoan VÀ TRUYỀN XUỐNG
                int maNV = _taiKhoan?.MaNV ?? 1;
                string tenNV = _taiKhoan?.TenDangNhap ?? "Nhân viên";

                // Hiển thị popup nhập hàng với thông tin nhân viên
                FormNhapHang formNhapHang = new FormNhapHang(maNV, tenNV);
                formNhapHang.ShowDialog();

                // Load lại dữ liệu sau khi nhập hàng
                LoadDataFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form nhập hàng: {ex.Message}", "Lỗi");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Code xử lý cho button khác (nếu có)
        }
    }
}