using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyBida.DTO;
using QuanLyBida.BLL;
using OfficeOpenXml;
using System.IO;


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
            btnXuatExcel.Click += btnXuatExcel_Click;
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
                    $"Bạn có chắc muốn cho nhân viên '{nhanVien.HoTen}' THÔI VIỆC?\n(Tài khoản đăng nhập sẽ bị khóa)", 
                    "Xác nhận thôi việc",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Gọi hàm BLL -> DAL (DAL giờ đã chạy lệnh UPDATE)
                        string deleteResult = nhanVienBLL.XoaNhanVien(nhanVien.MaNV);

                     
                        if (deleteResult == "Thành công" || deleteResult == "true" || deleteResult == "True")
                        {
                            TaiDuLieu(); 
                            MessageBox.Show("Đã cập nhật trạng thái nhân viên thành 'Đã nghỉ'!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Nếu BLL trả về chuỗi lỗi
                            MessageBox.Show(deleteResult, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xử lý: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Lưu file Excel";
                    saveFileDialog.FileName = "DanhSachNhanVien_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        XuatExcel(saveFileDialog.FileName);
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel sau khi xuất (tuỳ chọn)
                        // System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XuatExcel(string filePath)
        {
            // Set license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Tạo worksheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Nhân viên");

                // Tiêu đề chính
                worksheet.Cells[1, 1].Value = "DANH SÁCH NHÂN VIÊN";
                worksheet.Cells[1, 1, 1, 10].Merge = true;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                // Ngày xuất
                worksheet.Cells[2, 1].Value = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                worksheet.Cells[2, 1, 2, 10].Merge = true;
                worksheet.Cells[2, 1].Style.Font.Italic = true;
                worksheet.Cells[2, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                // Header các cột
                int row = 4;
                int col = 1;

                string[] headers = { "Mã NV", "Họ và tên", "Giới tính", "Ngày sinh", "Chức vụ",
                           "Số điện thoại", "Email", "Lương", "Ca làm việc", "Trạng thái" };

                // Tạo header
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[row, col].Value = headers[i];
                    worksheet.Cells[row, col].Style.Font.Bold = true;
                    worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    col++;
                }

                // Dữ liệu
                row++;
                var data = gridNhanVien.DataSource as List<NhanVienDTO>;

                if (data != null)
                {
                    foreach (var nv in data)
                    {
                        col = 1;

                        worksheet.Cells[row, col].Value = nv.MaNV;
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.HoTen;
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.GioiTinh ?? "";
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.NgaySinh?.ToString("dd/MM/yyyy") ?? "";
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.ChucVu;
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.SoDienThoai ?? "";
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.Email ?? "";
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.Luong;
                        worksheet.Cells[row, col].Style.Numberformat.Format = "#,##0";
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.CaLamViec;
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        worksheet.Cells[row, col].Value = nv.TrangThai ?? "";
                        worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        worksheet.Cells[row, col].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        worksheet.Cells[row, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        col++;

                        row++;
                    }
                }

                // Đường viền đậm cho toàn bộ bảng (viền ngoài)
                if (data != null && data.Count > 0)
                {
                    var tableRange = worksheet.Cells[4, 1, row - 1, headers.Length];
                    tableRange.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);
                }

                // Tự động điều chỉnh độ rộng cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Lưu file
                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);
            }
        }
    }
}