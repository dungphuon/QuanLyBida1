using QuanLyBida.BLL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormXuathuyProduct : Form
    {
        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        private List<SanPhamDTO> _danhSachSanPham = new List<SanPhamDTO>();
        private List<SanPhamNhapDTO> _sanPhamXuat = new List<SanPhamNhapDTO>();
        private int _maNV;
        private string _tenNV;

        public FormXuathuyProduct(int maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;
        }

        public FormXuathuyProduct()
        {
            InitializeComponent();
            _maNV = 1; // Mặc định
            _tenNV = "Admin";
        }

        private void FormXuathuyProduct_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            SetupDataGridView();
            guna2TextBoxTimKiem.KeyDown += guna2TextBoxTimKiem_KeyDown;
        }

        private void LoadDanhSachSanPham()
        {
            try
            {
                _danhSachSanPham = _sanPhamBLL.GetDanhSachSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách sản phẩm: {ex.Message}", "Lỗi");
            }
        }

        private void SetupDataGridView()
        {
            guna2DataGridViewSanPham.Columns.Clear();

            // Cột Tên sản phẩm
            DataGridViewTextBoxColumn colTenSanPham = new DataGridViewTextBoxColumn();
            colTenSanPham.Name = "TenSanPham";
            colTenSanPham.HeaderText = "Tên Sản phẩm";
            colTenSanPham.Width = 250;
            colTenSanPham.ReadOnly = true;
            guna2DataGridViewSanPham.Columns.Add(colTenSanPham);

            // Cột Số lượng
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.Name = "SoLuong";
            colSoLuong.HeaderText = "Số Lượng Xuất";
            colSoLuong.Width = 120;
            colSoLuong.ReadOnly = false;
            guna2DataGridViewSanPham.Columns.Add(colSoLuong);

            // Cột Đơn vị
            DataGridViewTextBoxColumn colDonViTinh = new DataGridViewTextBoxColumn();
            colDonViTinh.Name = "DonViTinh";
            colDonViTinh.HeaderText = "Đơn vị";
            colDonViTinh.Width = 80;
            colDonViTinh.ReadOnly = true;
            guna2DataGridViewSanPham.Columns.Add(colDonViTinh);

            // Cột Xóa
            DataGridViewButtonColumn colXoa = new DataGridViewButtonColumn();
            colXoa.Name = "Xoa";
            colXoa.HeaderText = "Xóa";
            colXoa.Text = "Xóa";
            colXoa.UseColumnTextForButtonValue = true;
            colXoa.Width = 60;
            guna2DataGridViewSanPham.Columns.Add(colXoa);

            guna2DataGridViewSanPham.ReadOnly = false;
            guna2DataGridViewSanPham.AllowUserToAddRows = false;

            guna2DataGridViewSanPham.CellContentClick += Guna2DataGridViewSanPham_CellContentClick;
            guna2DataGridViewSanPham.CellEndEdit += Guna2DataGridViewSanPham_CellEndEdit;
        }

        private void guna2TextBoxTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TimKiemVaThemSanPham();
            }
        }

        private void TimKiemVaThemSanPham()
        {
            string searchText = guna2TextBoxTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo");
                return;
            }

            try
            {
                var ketQua = _danhSachSanPham
                    .Where(sp => sp.TenSP.ToLower().Contains(searchText.ToLower()))
                    .OrderBy(sp => sp.TenSP.ToLower().StartsWith(searchText.ToLower()) ? 0 : 1)
                    .ThenBy(sp => sp.TenSP.Length)
                    .ToList();

                if (ketQua.Count == 1)
                {
                    ThemSanPhamVaoDanhSach(ketQua.First());
                }
                else if (ketQua.Count > 1)
                {
                    HienThiDanhSachLuaChon(ketQua, searchText);
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm với từ khóa: '{searchText}'", "Thông báo");
                    guna2TextBoxTimKiem.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi");
            }
        }

        private void ThemSanPhamVaoDanhSach(SanPhamDTO sanPham)
        {
            if (!_sanPhamXuat.Any(sp => sp.MaSP == sanPham.MaSP))
            {
                var sanPhamXuat = new SanPhamNhapDTO
                {
                    MaSP = sanPham.MaSP,
                    TenSP = sanPham.TenSP,
                    DonViTinh = sanPham.DonViTinh,
                    GiaNhap = sanPham.GiaNhap,
                    SoLuongNhap = 1
                };
                _sanPhamXuat.Add(sanPhamXuat);

                guna2DataGridViewSanPham.Rows.Add(
                    sanPham.TenSP,
                    "1",
                    sanPham.DonViTinh
                );

                guna2TextBoxTimKiem.Text = "";
                guna2TextBoxTimKiem.Focus();
            }
            else
            {
                MessageBox.Show("Sản phẩm đã có trong danh sách xuất hủy!", "Thông báo");
                guna2TextBoxTimKiem.Text = "";
                guna2TextBoxTimKiem.Focus();
            }
        }

        private void HienThiDanhSachLuaChon(List<SanPhamDTO> danhSach, string searchText)
        {
            string message = $"Tìm thấy {danhSach.Count} sản phẩm với từ khóa '{searchText}':\n\n";
            for (int i = 0; i < danhSach.Count; i++)
            {
                message += $"{i + 1}. {danhSach[i].TenSP}\n";
            }
            message += "\nVui lòng nhập cụ thể hơn!";
            MessageBox.Show(message, "Kết quả tìm kiếm");
            guna2TextBoxTimKiem.Focus();
            guna2TextBoxTimKiem.SelectAll();
        }

        private void Guna2DataGridViewSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && guna2DataGridViewSanPham.Columns[e.ColumnIndex].Name == "Xoa")
            {
                string tenSanPham = guna2DataGridViewSanPham.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
                DialogResult result = MessageBox.Show($"Xóa {tenSanPham} khỏi danh sách?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    guna2DataGridViewSanPham.Rows.RemoveAt(e.RowIndex);
                    _sanPhamXuat.RemoveAll(sp => sp.TenSP == tenSanPham);
                }
            }
        }

        private void Guna2DataGridViewSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && guna2DataGridViewSanPham.Columns[e.ColumnIndex].Name == "SoLuong")
            {
                string value = guna2DataGridViewSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                string tenSanPham = guna2DataGridViewSanPham.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();

                if (!string.IsNullOrEmpty(value))
                {
                    int soLuong;
                    if (int.TryParse(value, out soLuong))
                    {
                        if (soLuong <= 0)
                        {
                            MessageBox.Show("Số lượng phải lớn hơn 0! Đã đặt về 1.", "Cảnh báo");
                            guna2DataGridViewSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "1";
                            soLuong = 1;
                        }
                        else if (soLuong > 9999)
                        {
                            MessageBox.Show("Số lượng tối đa là 9999! Đã đặt về 9999.", "Cảnh báo");
                            guna2DataGridViewSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "9999";
                            soLuong = 9999;
                        }

                        var sanPham = _sanPhamXuat.FirstOrDefault(sp => sp.TenSP == tenSanPham);
                        if (sanPham != null)
                        {
                            sanPham.SoLuongNhap = soLuong;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số hợp lệ! Đã đặt về 1.", "Cảnh báo");
                        guna2DataGridViewSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "1";
                    }
                }
                else
                {
                    guna2DataGridViewSanPham.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "1";
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_sanPhamXuat.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm!", "Thông báo");
                return;
            }

            try
            {
                // Kiểm tra số lượng tồn kho trước khi xuất
                foreach (var sp in _sanPhamXuat)
                {
                    var sanPham = _danhSachSanPham.FirstOrDefault(s => s.MaSP == sp.MaSP);
                    if (sanPham != null && sanPham.SoLuongTon < sp.SoLuongNhap)
                    {
                        MessageBox.Show($"Sản phẩm '{sp.TenSP}' không đủ số lượng tồn kho!\nSố lượng tồn: {sanPham.SoLuongTon}, Số lượng xuất: {sp.SoLuongNhap}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // CẬP NHẬT SỐ LƯỢNG TỒN (giảm số lượng)
                foreach (var sp in _sanPhamXuat)
                {
                    _sanPhamBLL.CapNhatSoLuongTon(sp.MaSP, -sp.SoLuongNhap); // Truyền số âm để giảm
                }

                // THÔNG BÁO THÀNH CÔNG
                string thongBao = $"✅ XUẤT HỦY HÀNG HÓA THÀNH CÔNG!\n\n";
                thongBao += $"📦 Đã xuất hủy:\n";
                foreach (var sp in _sanPhamXuat)
                {
                    thongBao += $"   - {sp.TenSP}: -{sp.SoLuongNhap} {sp.DonViTinh}\n";
                }

                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất hủy hàng hóa: {ex.Message}", "Lỗi");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}