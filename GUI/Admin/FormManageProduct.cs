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
        // Class để lưu dữ liệu hàng hóa với loại hàng hóa
        private class HangHoaMau
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }
            public string LoaiHangHoa { get; set; }
            public decimal GiaBan { get; set; }
            public int SoLuongTon { get; set; }
        }

        private List<HangHoaMau> danhSachHangHoa;
        private SanPhamBLL _sanPhamBLL = new SanPhamBLL();

        public FormManageProduct()
        {
            InitializeComponent();
            RegisterEvents();
            TaoDuLieuMau();
            HienThiDuLieu();
        }

        private void RegisterEvents()
        {
            this.buttonAdd.Click += ButtonAdd_Click;
            this.buttonNhapHang.Click += ButtonNhapHang_Click;
            this.buttonXuatHuy.Click += ButtonXuatHuy_Click;
            this.textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            this.gridProducts.CellContentClick += GridProducts_CellContentClick;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var addProductForm = new FormAddProduct())
            {
                addProductForm.StartPosition = FormStartPosition.CenterParent;
                var result = addProductForm.ShowDialog(this);
                
                // Nếu lưu thành công, refresh lại danh sách
                if (result == DialogResult.OK)
                {
                    // TODO: Reload data from database
                    HienThiDuLieu();
                }
            }
        }

        private void ButtonNhapHang_Click(object sender, EventArgs e)
        {
            using (var nhapHangForm = new FormNhaphangAdmin())
            {
                nhapHangForm.StartPosition = FormStartPosition.CenterParent;
                var result = nhapHangForm.ShowDialog(this);
                
                // Nếu lưu thành công, refresh lại danh sách
                if (result == DialogResult.OK || result == DialogResult.None)
                {
                    // TODO: Reload data from database
                    HienThiDuLieu();
                }
            }
        }

        private void ButtonXuatHuy_Click(object sender, EventArgs e)
        {
            using (var xuatHuyForm = new FormXuathuyProduct())
            {
                xuatHuyForm.StartPosition = FormStartPosition.CenterParent;
                var result = xuatHuyForm.ShowDialog(this);
                
                // Nếu lưu thành công, refresh lại danh sách
                if (result == DialogResult.OK || result == DialogResult.None)
                {
                    // TODO: Reload data from database
                    HienThiDuLieu();
                }
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower().Trim();
            
            if (string.IsNullOrEmpty(searchText))
            {
                HienThiDuLieu();
            }
            else
            {
                var filteredList = danhSachHangHoa.Where(h =>
                    h.TenSP.ToLower().Contains(searchText) ||
                    h.MaSP.ToString().Contains(searchText)
                ).ToList();
                
                HienThiDuLieu(filteredList);
            }
        }

        private void TaoDuLieuMau()
        {
            // Tạo dữ liệu mẫu cho hàng hóa
            danhSachHangHoa = new List<HangHoaMau>
            {
                new HangHoaMau
                {
                    MaSP = 1,
                    TenSP = "Coca Cola",
                    LoaiHangHoa = "Đồ uống",
                    GiaBan = 15000,
                    SoLuongTon = 50
                },
                new HangHoaMau
                {
                    MaSP = 2,
                    TenSP = "Pepsi",
                    LoaiHangHoa = "Đồ uống",
                    GiaBan = 15000,
                    SoLuongTon = 45
                },
                new HangHoaMau
                {
                    MaSP = 3,
                    TenSP = "Bánh mì thịt nướng",
                    LoaiHangHoa = "Đồ ăn",
                    GiaBan = 30000,
                    SoLuongTon = 20
                },
                new HangHoaMau
                {
                    MaSP = 4,
                    TenSP = "Phấn bida",
                    LoaiHangHoa = "Phụ kiện",
                    GiaBan = 50000,
                    SoLuongTon = 15
                },
                new HangHoaMau
                {
                    MaSP = 5,
                    TenSP = "Cơm tấm sườn",
                    LoaiHangHoa = "Đồ ăn",
                    GiaBan = 45000,
                    SoLuongTon = 30
                },
                new HangHoaMau
                {
                    MaSP = 6,
                    TenSP = "Nước suối",
                    LoaiHangHoa = "Đồ uống",
                    GiaBan = 10000,
                    SoLuongTon = 100
                },
                new HangHoaMau
                {
                    MaSP = 7,
                    TenSP = "Cơ bida",
                    LoaiHangHoa = "Phụ kiện",
                    GiaBan = 200000,
                    SoLuongTon = 8
                }
            };
        }

        private void HienThiDuLieu(List<HangHoaMau> list = null)
        {
            if (list == null)
            {
                list = danhSachHangHoa;
            }

            gridProducts.Rows.Clear();
            foreach (var hangHoa in list)
            {
                gridProducts.Rows.Add(
                    hangHoa.TenSP,
                    hangHoa.LoaiHangHoa,
                    hangHoa.GiaBan.ToString("N0") + " VNĐ",
                    hangHoa.SoLuongTon.ToString(),
                    "Xem",
                    "Xóa"
                );
            }
        }

        private void GridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Kiểm tra nếu click vào cột "Xem thông tin"
            if (gridProducts.Columns[e.ColumnIndex].Name == "colXem")
            {
                var row = gridProducts.Rows[e.RowIndex];
                string tenSP = row.Cells["colTenHangHoa"].Value?.ToString() ?? "";
                string loaiHangHoa = row.Cells["colLoaiHangHoa"].Value?.ToString() ?? "";
                string giaBanStr = row.Cells["colGiaBan"].Value?.ToString() ?? "";
                string soLuongTonStr = row.Cells["colSoLuongTon"].Value?.ToString() ?? "";

                // Lấy giá bán (bỏ phần " VNĐ")
                decimal giaBan = 0;
                if (!string.IsNullOrEmpty(giaBanStr))
                {
                    string giaBanNumber = giaBanStr.Replace(" VNĐ", "").Replace(",", "");
                    decimal.TryParse(giaBanNumber, out giaBan);
                }

                int soLuongTon = 0;
                int.TryParse(soLuongTonStr, out soLuongTon);

                // Tìm hàng hóa trong danh sách
                var hangHoa = danhSachHangHoa.FirstOrDefault(h => h.TenSP == tenSP);

                if (hangHoa != null)
                {
                    // Mở form EditProduct
                    using (var editProductForm = new FormEditProduct())
                    {
                        // Truyền dữ liệu vào form
                        editProductForm.SetProductData(tenSP, loaiHangHoa, giaBan, soLuongTon);
                        editProductForm.StartPosition = FormStartPosition.CenterParent;
                        editProductForm.ShowDialog(this);
                    }
                }
            }
            // Kiểm tra nếu click vào cột "Xóa"
            else if (gridProducts.Columns[e.ColumnIndex].Name == "colXoa")
            {
                var row = gridProducts.Rows[e.RowIndex];
                string tenSP = row.Cells["colTenHangHoa"].Value?.ToString() ?? "";

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa hàng hóa '{tenSP}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    var hangHoa = danhSachHangHoa.FirstOrDefault(h => h.TenSP == tenSP);
                    if (hangHoa != null)
                    {
                        danhSachHangHoa.Remove(hangHoa);
                        HienThiDuLieu();
                        MessageBox.Show("Đã xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
