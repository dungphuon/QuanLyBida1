using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyBida.DTO;
using QuanLyBida.BLL;

namespace GUI.Admin
{
    public partial class FormQLNV : Form
    {
        private List<NhanVienDTO> danhSachNhanVien;
        private NhanVienBLL nhanVienBLL;

        public FormQLNV()
        {
            InitializeComponent();
            nhanVienBLL = new NhanVienBLL();
            KhoiTaoDataGridView();
            KhoiTaoFilter();
            TaiDuLieu();

            btnThemNV.Click += BtnThemNV_Click;

            // Thêm sự kiện tìm kiếm real-time
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cmbTrangThai.SelectedIndexChanged += Filter_Changed;
            cmbChucVu.SelectedIndexChanged += Filter_Changed;
        }

        private void BtnThemNV_Click(object sender, EventArgs e)
        {
            // Thêm mới: không truyền tham số
            using (var formNV = new FormAddNV())
            {
                if (formNV.ShowDialog() == DialogResult.OK)
                {
                    TaiDuLieu();
                }
            }
        }

        private void KhoiTaoFilter()
        {
            // Thiết lập giá trị mặc định cho các dropdown
            cmbTrangThai.SelectedIndex = 0; // "Tất cả"
            cmbChucVu.SelectedIndex = 0; // "Tất cả"
        }

        private void TaiDuLieu()
        {
            try
            {
                danhSachNhanVien = nhanVienBLL.LayDanhSachNhanVien();
                HienThiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            // Cột Ca làm việc
            gridNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCaLamViec",
                HeaderText = "Ca làm việc",
                DataPropertyName = "CaLamViec",
                Width = 100
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
                var nhanVien = row.DataBoundItem as NhanVienDTO;

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

            var nhanVien = gridNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVienDTO;
            if (nhanVien == null) return;

            if (gridNhanVien.Columns[e.ColumnIndex].Name == "colXem")
            {
                // Xem thông tin: truyền false để vào chế độ xem
                using (var formNV = new FormAddNV(nhanVien, false))
                {
                    if (formNV.ShowDialog() == DialogResult.OK)
                    {
                        TaiDuLieu();
                    }
                }
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
                    try
                    {
                        string deleteResult = nhanVienBLL.XoaNhanVien(nhanVien.MaNV);
                        if (deleteResult == "Thành công")
                        {
                            TaiDuLieu();
                            MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(deleteResult, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LocVaHienThiDuLieu();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LocVaHienThiDuLieu();
        }

        private void LocVaHienThiDuLieu()
        {
            if (danhSachNhanVien == null) return;

            var ketQua = danhSachNhanVien.AsEnumerable();

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string search = txtSearch.Text.ToLower();
                ketQua = ketQua.Where(nv =>
                    nv.HoTen.ToLower().Contains(search) ||
                    nv.MaNV.ToString().Contains(search) ||
                    (nv.SoDienThoai != null && nv.SoDienThoai.Contains(search)) ||
                    (nv.Email != null && nv.Email.ToLower().Contains(search)));
            }

            // Lọc theo trạng thái
            if (cmbTrangThai.SelectedIndex > 0)
            {
                ketQua = ketQua.Where(nv => nv.TrangThai == cmbTrangThai.SelectedItem.ToString());
            }

            // Lọc theo chức vụ
            if (cmbChucVu.SelectedIndex > 0)
            {
                ketQua = ketQua.Where(nv => nv.ChucVu == cmbChucVu.SelectedItem.ToString());
            }

            gridNhanVien.DataSource = ketQua.ToList();
        }

        private void HienThiDuLieu()
        {
            LocVaHienThiDuLieu();
        }
    }
}