using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBida.DTO;
using QuanLyBida.BLL;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormManageProduct : Form
    {
        private List<SanPhamDTO> danhSachSanPham;
        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();

        public FormManageProduct()
        {
            InitializeComponent();
            RegisterEvents();
            LoadDanhSachSanPham();
        }

        private void RegisterEvents()
        {
            this.buttonAdd.Click += ButtonAdd_Click;
            this.buttonNhapHang.Click += ButtonNhapHang_Click;
            this.buttonXuatHuy.Click += ButtonXuatHuy_Click;
            this.textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            this.gridProducts.CellContentClick += GridProducts_CellContentClick;
        }

        private void LoadDanhSachSanPham()
        {
            try
            {
                danhSachSanPham = _sanPhamBLL.GetDanhSachSanPham();
                HienThiDuLieu(danhSachSanPham);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var addProductForm = new FormAddProduct())
            {
                addProductForm.StartPosition = FormStartPosition.CenterParent;
                var result = addProductForm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    LoadDanhSachSanPham(); // Refresh lại danh sách
                }
            }
        }

        private void ButtonNhapHang_Click(object sender, EventArgs e)
        {
            using (var nhapHangForm = new FormNhaphangAdmin())
            {
                nhapHangForm.StartPosition = FormStartPosition.CenterParent;
                var result = nhapHangForm.ShowDialog(this);

                if (result == DialogResult.OK || result == DialogResult.None)
                {
                    LoadDanhSachSanPham(); // Refresh lại danh sách
                }
            }
        }

        private void ButtonXuatHuy_Click(object sender, EventArgs e)
        {
            using (var xuatHuyForm = new FormXuathuyProduct())
            {
                xuatHuyForm.StartPosition = FormStartPosition.CenterParent;
                var result = xuatHuyForm.ShowDialog(this);

                if (result == DialogResult.OK || result == DialogResult.None)
                {
                    LoadDanhSachSanPham(); // Refresh lại danh sách
                }
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                HienThiDuLieu(danhSachSanPham);
            }
            else
            {
                var filteredList = danhSachSanPham.Where(h =>
                    h.TenSP.ToLower().Contains(searchText) ||
                    h.MaSP.ToString().Contains(searchText)
                ).ToList();

                HienThiDuLieu(filteredList);
            }
        }

        private void HienThiDuLieu(List<SanPhamDTO> list)
        {
            gridProducts.Rows.Clear();
            foreach (var sanPham in list)
            {
                gridProducts.Rows.Add(
                    sanPham.TenSP,
                    sanPham.LoaiHangHoa, // Bạn cần thêm trường LoaiHangHoa vào SanPhamDTO
                    sanPham.GiaBan.ToString("N0") + " VNĐ",
                    sanPham.SoLuongTon.ToString(),
                    "Xem",
                    "Xóa"
                );
            }
        }

        // Hàm tạm để xác định loại hàng hóa (cần sửa khi có trường LoaiHangHoa trong database)


        private void GridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (gridProducts.Columns[e.ColumnIndex].Name == "colXem")
            {
                var row = gridProducts.Rows[e.RowIndex];
                string tenSP = row.Cells["colTenHangHoa"].Value?.ToString() ?? "";

                // Tìm sản phẩm trong database
                var sanPham = _sanPhamBLL.GetSanPhamByTen(tenSP);

                if (sanPham != null)
                {
                    using (var editProductForm = new FormEditProduct())
                    {
                        // Truyền dữ liệu thực từ database
                        editProductForm.SetProductData(
                            sanPham.TenSP,
                            sanPham.LoaiHangHoa, // Hoặc lấy từ database nếu có
                            sanPham.GiaBan,
                            sanPham.SoLuongTon
                        );
                        editProductForm.StartPosition = FormStartPosition.CenterParent;
                        editProductForm.ShowDialog(this);

                        // Refresh lại danh sách sau khi chỉnh sửa
                        if (editProductForm.DialogResult == DialogResult.OK)
                        {
                            LoadDanhSachSanPham();
                        }
                    }
                }
            }
            // Kiểm tra nếu click vào cột "Xóa"
            else if (gridProducts.Columns[e.ColumnIndex].Name == "colXoa")
            {
                var row = gridProducts.Rows[e.RowIndex];
                string tenSP = row.Cells["colTenHangHoa"].Value?.ToString() ?? "";

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa sản phẩm '{tenSP}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var sanPham = danhSachSanPham.FirstOrDefault(h => h.TenSP == tenSP);
                        if (sanPham != null)
                        {
                            bool xoaThanhCong = _sanPhamBLL.XoaSanPham(sanPham.MaSP);
                            if (xoaThanhCong)
                            {
                                danhSachSanPham.Remove(sanPham);
                                HienThiDuLieu(danhSachSanPham);
                                MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}