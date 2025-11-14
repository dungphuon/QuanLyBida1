using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Admin
{
    public partial class FormQLNV : Form
    {
        // Class để lưu dữ liệu mẫu nhân viên
        private class NhanVienMau
        {
            public int MaNV { get; set; }
            public string HoTen { get; set; }
            public string GioiTinh { get; set; }
            public DateTime? NgaySinh { get; set; }
            public string ChucVu { get; set; }
            public string SoDienThoai { get; set; }
            public string Email { get; set; }
            public decimal? Luong { get; set; }
            public string TrangThai { get; set; }
        }

        private List<NhanVienMau> danhSachNhanVien;

        public FormQLNV()
        {
            InitializeComponent();
            TaoDuLieuMau();
            KhoiTaoDataGridView();
            KhoiTaoFilter();
            HienThiDuLieu();
            
            // Gắn sự kiện click cho button Thêm nhân viên
            btnThemNV.Click += BtnThemNV_Click;
        }

        private void BtnThemNV_Click(object sender, EventArgs e)
        {
            // Mở form thêm nhân viên dưới dạng dialog
            using (var formAddNV = new FormAddNV())
            {
                if (formAddNV.ShowDialog() == DialogResult.OK)
                {
                    // Nếu người dùng nhấn Lưu thành công, có thể reload dữ liệu
                    // TODO: Thêm logic reload dữ liệu từ database
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Reload dữ liệu (tạm thời giữ nguyên dữ liệu mẫu)
                    // HienThiDuLieu();
                }
            }
        }

        private void KhoiTaoFilter()
        {
            // Thiết lập giá trị mặc định cho các dropdown
            cmbTrangThai.SelectedIndex = 0; // "Tất cả"
            cmbChucVu.SelectedIndex = 0; // "Tất cả"
        }

        private void TaoDuLieuMau()
        {
            danhSachNhanVien = new List<NhanVienMau>
            {
                new NhanVienMau
                {
                    MaNV = 1,
                    HoTen = "Nguyễn Văn An",
                    GioiTinh = "Nam",
                    NgaySinh = new DateTime(1990, 5, 15),
                    ChucVu = "Quản lý",
                    SoDienThoai = "0912345678",
                    Email = "nguyenvanan@email.com",
                    Luong = 15000000,
                    TrangThai = "Đang làm việc"
                },
                new NhanVienMau
                {
                    MaNV = 2,
                    HoTen = "Trần Thị Bình",
                    GioiTinh = "Nữ",
                    NgaySinh = new DateTime(1995, 8, 20),
                    ChucVu = "Nhân viên",
                    SoDienThoai = "0923456789",
                    Email = "tranthibinh@email.com",
                    Luong = 8000000,
                    TrangThai = "Đang làm việc"
                },
                new NhanVienMau
                {
                    MaNV = 3,
                    HoTen = "Lê Văn Cường",
                    GioiTinh = "Nam",
                    NgaySinh = new DateTime(1992, 3, 10),
                    ChucVu = "Nhân viên",
                    SoDienThoai = "0934567890",
                    Email = "levancuong@email.com",
                    Luong = 7500000,
                    TrangThai = "Đã nghỉ"
                },
                new NhanVienMau
                {
                    MaNV = 4,
                    HoTen = "Phạm Thị Dung",
                    GioiTinh = "Nữ",
                    NgaySinh = new DateTime(1998, 11, 25),
                    ChucVu = "Bảo vệ",
                    SoDienThoai = "0945678901",
                    Email = "phamthidung@email.com",
                    Luong = 6000000,
                    TrangThai = "Đang làm việc"
                }
            };
        }

        private void KhoiTaoDataGridView()
        {
            gridNhanVien.AutoGenerateColumns = false;
            gridNhanVien.Columns.Clear();

            // Cột Mã NV
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaNV",
                HeaderText = "Mã NV",
                DataPropertyName = "MaNV",
                Width = 80
            });

            // Cột Họ và tên
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHoTen",
                HeaderText = "Họ và tên",
                DataPropertyName = "HoTen",
                Width = 150
            });

            // Cột Giới tính
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGioiTinh",
                HeaderText = "Giới tính",
                DataPropertyName = "GioiTinh",
                Width = 80
            });

            // Cột Ngày sinh
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgaySinh",
                HeaderText = "Ngày sinh",
                DataPropertyName = "NgaySinh",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            // Cột Chức vụ
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colChucVu",
                HeaderText = "Chức vụ",
                DataPropertyName = "ChucVu",
                Width = 100
            });

            // Cột Số điện thoại
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoDienThoai",
                HeaderText = "Số điện thoại",
                DataPropertyName = "SoDienThoai",
                Width = 120
            });

            // Cột Email
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });

            // Cột Lương
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLuong",
                HeaderText = "Lương",
                DataPropertyName = "Luong",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            // Cột Trạng thái (với màu sắc)
            var colTrangThai = new DataGridViewTextBoxColumn
            {
                Name = "colTrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                Width = 120
            };
            gridNhanVien.Columns.Add(colTrangThai);

            // Cột Thao tác - Nút Xem
            var colXem = new DataGridViewButtonColumn
            {
                Name = "colXem",
                HeaderText = "Thao tác",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            gridNhanVien.Columns.Add(colXem);

            // Cột Thao tác - Nút Xóa
            var colXoa = new DataGridViewButtonColumn
            {
                Name = "colXoa",
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            gridNhanVien.Columns.Add(colXoa);

            // Xử lý sự kiện CellFormatting để tô màu cột Trạng thái
            gridNhanVien.CellFormatting += GridNhanVien_CellFormatting;
            gridNhanVien.CellContentClick += GridNhanVien_CellContentClick;
        }

        private void GridNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridNhanVien.Columns[e.ColumnIndex].Name == "colTrangThai" && e.RowIndex >= 0)
            {
                var row = gridNhanVien.Rows[e.RowIndex];
                var nhanVien = row.DataBoundItem as NhanVienMau;
                
                if (nhanVien != null)
                {
                    if (nhanVien.TrangThai == "Đang làm việc")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(46, 213, 115); // Màu xanh
                        e.CellStyle.Font = new Font(gridNhanVien.Font, FontStyle.Bold);
                    }
                    else if (nhanVien.TrangThai == "Đã nghỉ")
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60); // Màu đỏ
                        e.CellStyle.Font = new Font(gridNhanVien.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void GridNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var nhanVien = gridNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVienMau;
            if (nhanVien == null) return;

            if (gridNhanVien.Columns[e.ColumnIndex].Name == "colXem")
            {
                MessageBox.Show(
                    $"Mã NV: {nhanVien.MaNV}\n" +
                    $"Họ tên: {nhanVien.HoTen}\n" +
                    $"Giới tính: {nhanVien.GioiTinh}\n" +
                    $"Ngày sinh: {nhanVien.NgaySinh?.ToString("dd/MM/yyyy")}\n" +
                    $"Chức vụ: {nhanVien.ChucVu}\n" +
                    $"Số điện thoại: {nhanVien.SoDienThoai}\n" +
                    $"Email: {nhanVien.Email}\n" +
                    $"Lương: {nhanVien.Luong?.ToString("N0")} VNĐ\n" +
                    $"Trạng thái: {nhanVien.TrangThai}",
                    "Thông tin nhân viên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if (gridNhanVien.Columns[e.ColumnIndex].Name == "colXoa")
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa nhân viên '{nhanVien.HoTen}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    danhSachNhanVien.Remove(nhanVien);
                    HienThiDuLieu();
                    MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void HienThiDuLieu()
        {
            gridNhanVien.DataSource = null;
            gridNhanVien.DataSource = danhSachNhanVien;
        }
    }
}
