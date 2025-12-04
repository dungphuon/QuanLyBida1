using QuanLyBida.BLL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormQLQuy : Form
    {
        private PhieuThuChiBLL phieuBLL = new PhieuThuChiBLL();
        private TaiKhoanDTO _taiKhoan;
        public FormQLQuy(TaiKhoanDTO taiKhoan = null)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
            InitializeFilterOptions();
            LoadData();
            CalculateTotals();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            try
            {
                guna2DataGridThuChi.AutoGenerateColumns = false;
                guna2DataGridThuChi.Columns.Clear();

                // 1. Cột Mã giao dịch
                var colMa = new DataGridViewTextBoxColumn
                {
                    Name = "MaPhieu",
                    DataPropertyName = "MaPhieu",
                    HeaderText = "Mã GD",
                    Width = 80
                };
                guna2DataGridThuChi.Columns.Add(colMa);

                // 2. Cột Thời gian
                var colNgay = new DataGridViewTextBoxColumn
                {
                    Name = "NgayTao",
                    DataPropertyName = "NgayTao",
                    HeaderText = "Thời gian",
                    Width = 140,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
                };
                guna2DataGridThuChi.Columns.Add(colNgay);

                // 3. Cột Loại giao dịch
                var colLoai = new DataGridViewTextBoxColumn
                {
                    Name = "LoaiGiaoDichDisplay",
                    DataPropertyName = "LoaiGiaoDichDisplay",
                    HeaderText = "Loại",
                    Width = 100
                };
                guna2DataGridThuChi.Columns.Add(colLoai);

                // 4. Cột Lý do 
                var colLyDo = new DataGridViewTextBoxColumn
                {
                    Name = "LyDo",
                    DataPropertyName = "LyDo", // Tên thuộc tính trong DTO
                    HeaderText = "Lý do / Diễn giải",
                    Width = 250 // Cho rộng ra chút để đọc nội dung
                };
                guna2DataGridThuChi.Columns.Add(colLyDo);

                // 5. Cột Số tiền
                var colTien = new DataGridViewTextBoxColumn
                {
                    Name = "SoTien",
                    DataPropertyName = "SoTien",
                    HeaderText = "Số tiền",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "N0",
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        ForeColor = System.Drawing.Color.DarkBlue,
                        Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)
                    }
                };
                guna2DataGridThuChi.Columns.Add(colTien);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thiết lập DataGridView: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeFilterOptions()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new object[]
            {
                "Hôm nay",
                "Hôm qua",
                "Tuần này",
                "Tháng này",
                "Tất cả",
                "Tùy chọn"  // Thêm option này để dùng DateTimePicker
            });

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 4;
            }

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // THÊM SỰ KIỆN CHO DATETIMEPICKER
            dateTimePicker1.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker_ValueChanged;

            // Ẩn datetimepicker mặc định, chỉ hiện khi chọn "Tùy chọn"
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }
        private decimal LayQuyDauKy(string filterType, DateTime? startDate = null)
        {
            switch (filterType)
            {
                case "Hôm nay":
                    // Quỹ đầu kỳ = Tồn quỹ cuối ngày HÔM QUA
                    DateTime homQua = DateTime.Today.AddDays(-1);
                    return TinhTonQuyDenNgay(homQua);

                case "Hôm qua":
                    // Quỹ đầu kỳ = Tồn quỹ cuối ngày HAI NGÀY TRƯỚC
                    DateTime haiNgayTruoc = DateTime.Today.AddDays(-2);
                    return TinhTonQuyDenNgay(haiNgayTruoc);

                case "Tuần này":
                    // Quỹ đầu kỳ = Tồn quỹ cuối TUẦN TRƯỚC
                    DateTime cuoiTuanTruoc = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    return TinhTonQuyDenNgay(cuoiTuanTruoc);

                case "Tháng này":
                    // Quỹ đầu kỳ = Tồn quỹ cuối THÁNG TRƯỚC
                    DateTime cuoiThangTruoc = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                    return TinhTonQuyDenNgay(cuoiThangTruoc);

                case "Tùy chọn" when startDate.HasValue:
                    // Quỹ đầu kỳ = Tồn quỹ cuối ngày TRƯỚC ngày bắt đầu
                    DateTime ngayTruoc = startDate.Value.AddDays(-1);
                    return TinhTonQuyDenNgay(ngayTruoc);

                case "Tất cả":
                default:
                    return 0;
            }
        }
 

        private decimal TinhTonQuyDenNgay(DateTime denNgay)
        {
            // Quỹ ban đầu (ngày đầu tiên hệ thống hoạt động)
            decimal quyBanDau = 0;

            // Tính tồn quỹ đến ngày được chỉ định
            return phieuBLL.TinhTonQuy(quyBanDau, null, denNgay);
        }

        private void LoadData()
        {
            try
            {
                var filter = comboBox1.SelectedItem?.ToString();
                DateTime? startDate = null;
                DateTime? endDate = null;

                if (filter == "Tùy chọn")
                {
                    // DÙNG DATETIMEPICKER KHI CHỌN "TÙY CHỌN"
                    startDate = dateTimePicker1.Value.Date;
                    endDate = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    // DÙNG COMBOBOX FILTER
                    switch (filter)
                    {
                        case "Hôm nay":
                            startDate = DateTime.Today;
                            endDate = DateTime.Today.AddDays(1).AddSeconds(-1);
                            break;
                        case "Hôm qua":
                            startDate = DateTime.Today.AddDays(-1);
                            endDate = DateTime.Today.AddSeconds(-1);
                            break;
                        case "Tuần này":
                            startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
                            endDate = startDate.Value.AddDays(7).AddSeconds(-1);
                            break;
                        case "Tháng này":
                            startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                            endDate = startDate.Value.AddMonths(1).AddSeconds(-1);
                            break;
                        case "Tất cả":
                            // KHÔNG set startDate và endDate
                            break;
                    }
                }

                var dsPhieu = phieuBLL.LayDanhSachPhieu(startDate, endDate);
                guna2DataGridThuChi.DataSource = dsPhieu;

                CalculateTotals(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var filter = comboBox1.SelectedItem?.ToString();

                // TÍNH QUỸ ĐẦU KỲ THEO LOẠI LỌC
                decimal quyDauKy = LayQuyDauKy(filter, startDate);

                // TÍNH TỔNG THU, TỔNG CHI TRONG KHOẢNG THỜI GIAN
                decimal tongThu = phieuBLL.TinhTongThu(startDate, endDate);
                decimal tongChi = phieuBLL.TinhTongChi(startDate, endDate);
                decimal tonQuy = quyDauKy + tongThu - tongChi;

                // HIỂN THỊ
                label7.Text = quyDauKy.ToString("N0") + " đ";
                label6.Text = tongThu.ToString("N0") + " đ";
                label8.Text = tongChi.ToString("N0") + " đ";
                label9.Text = tonQuy.ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính toán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filter = comboBox1.SelectedItem?.ToString();

            // Hiện/ẩn datetimepicker khi chọn "Tùy chọn"
            if (filter == "Tùy chọn")
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
            }

            LoadData(); // Load data khi đổi filter
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int maNV = _taiKhoan?.MaNV ?? 1;
                string tenNV = _taiKhoan?.TenDangNhap ?? "Nhân viên";

                using (var frm = new FormPhieuThu(maNV, tenNV))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form phiếu thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int maNV = _taiKhoan?.MaNV ?? 1;
                string tenNV = _taiKhoan?.TenDangNhap ?? "Nhân viên";

                using (var frm = new FormPhieuChi(maNV, tenNV))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form phiếu thu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Chỉ load data khi đang chọn filter "Tùy chọn"
            if (comboBox1.SelectedItem?.ToString() == "Tùy chọn")
            {
                // Kiểm tra ngày hợp lệ
                if (dateTimePicker1.Value <= dateTimePicker2.Value)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label9_Click_1(object sender, EventArgs e) { }
    }
}