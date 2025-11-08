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
    public partial class FormQLHD : Form
    {
        private HoaDonBLL _hoaDonBLL = new HoaDonBLL();
        private List<HoaDonDTO> _currentHoaDonList = new List<HoaDonDTO>();

        public FormQLHD()
        {
            InitializeComponent();
        }

        private void FormQLHD_Load(object sender, EventArgs e)
        {
            // ================== THIẾT LẬP COMBOBOX LỌC ==================
            guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Items.Add("Tất cả");
            guna2ComboBox1.Items.Add("Hôm nay");
            guna2ComboBox1.Items.Add("Tuần này");
            guna2ComboBox1.Items.Add("Tháng này");
            guna2ComboBox1.SelectedIndex = 0;

            // ================== TẠO CÁC CỘT ==================
            CreateColumns();

            // ================== LOAD DỮ LIỆU TỪ DATABASE ==================
            LoadDataFromDatabase();

            // ================== THIẾT LẬP SỰ KIỆN ==================
            buttonSearch.Click += ButtonSearch_Click;
            guna2ComboBox1.SelectedIndexChanged += Guna2ComboBox1_SelectedIndexChanged;
        }

        private void CreateColumns()
        {
            // Xóa tất cả cột cũ trước khi tạo mới
            guna2DataGridHoadon.Columns.Clear();

            // ================== CÁC CỘT CHÍNH ==================
            guna2DataGridHoadon.Columns.Add("MaHD", "Mã hóa đơn");
            guna2DataGridHoadon.Columns.Add("NgayLap", "Ngày lập");
            guna2DataGridHoadon.Columns.Add("TongTien", "Tổng tiền");
            guna2DataGridHoadon.Columns.Add("PhuongThuc", "Phương thức");
            guna2DataGridHoadon.Columns.Add("TrangThai", "Trạng thái");

            // ================== CỘT XEM ==================
            DataGridViewLinkColumn colView = new DataGridViewLinkColumn();
            colView.ActiveLinkColor = Color.FromArgb(0, 123, 255);
            colView.HeaderText = "Xem";
            colView.LinkColor = Color.FromArgb(0, 123, 255);
            colView.MinimumWidth = 60;
            colView.Name = "View";
            colView.ReadOnly = true;
            colView.Text = "Xem";
            colView.UseColumnTextForLinkValue = true;
            colView.VisitedLinkColor = Color.FromArgb(0, 123, 255);
            guna2DataGridHoadon.Columns.Add(colView);

            // ================== CỘT XÓA ==================
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
            guna2DataGridHoadon.Columns.Add(colDelete);
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                _currentHoaDonList = _hoaDonBLL.GetAllHoaDon();
                BindDataToGrid(_currentHoaDonList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid(List<HoaDonDTO> hoaDonList)
        {

            guna2DataGridHoadon.Rows.Clear();

            foreach (var hd in hoaDonList)
            {
                guna2DataGridHoadon.Rows.Add(
                    $"HD{hd.MaHD:D6}",
                    hd.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                    string.Format("{0:N0} đ", hd.TongTien),
                    hd.PhuongThucThanhToan ?? "Tiền mặt",
                    hd.TrangThaiThanhToan ?? "Đã thanh toán",
                    "Xem",
                    "Xóa"
                );
            }

            // Hiển thị tổng số hóa đơn
            labelTitle.Text = $"Quản Lý Hóa Đơn ({hoaDonList.Count} hóa đơn)";
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Nhập mã HD, tên bàn, phương thức...")
            {
                LoadDataFromDatabase();
                return;
            }

            try
            {
                var searchResults = _hoaDonBLL.SearchHoaDon(keyword);
                BindDataToGrid(searchResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate, toDate;
                var now = DateTime.Now;

                switch (guna2ComboBox1.SelectedItem.ToString())
                {
                    case "Hôm nay":
                        fromDate = now.Date;
                        toDate = now.Date.AddDays(1).AddSeconds(-1);
                        break;
                    case "Tuần này":
                        var startOfWeek = now.AddDays(-(int)now.DayOfWeek);
                        fromDate = startOfWeek.Date;
                        toDate = startOfWeek.AddDays(7).AddSeconds(-1);
                        break;
                    case "Tháng này":
                        fromDate = new DateTime(now.Year, now.Month, 1);
                        toDate = new DateTime(now.Year, now.Month, 1).AddMonths(1).AddSeconds(-1);
                        break;
                    default: // Tất cả
                        LoadDataFromDatabase();
                        return;
                }

                var filteredData = _hoaDonBLL.GetHoaDonByTimeRange(fromDate, toDate);
                BindDataToGrid(filteredData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2DataGridHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maHDText = guna2DataGridHoadon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
            int maHD = int.Parse(maHDText.Replace("HD", ""));

            if (guna2DataGridHoadon.Columns[e.ColumnIndex].Name == "View")
            {
                ShowInvoiceDetails(maHD);
            }
            else if (guna2DataGridHoadon.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteInvoice(maHD, maHDText, e.RowIndex);
            }
        }

        private void ShowInvoiceDetails(int maHD)
        {
            try
            {
                var hoaDon = _hoaDonBLL.GetHoaDonByMaHD(maHD);
                if (hoaDon == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var chiTietHoaDon = _hoaDonBLL.GetInvoiceDetails(maHD);
                ShowInvoiceDetailsForm(hoaDon, chiTietHoaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load chi tiết hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInvoiceDetailsForm(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTiet)
        {
            Form invoiceDetailsForm = new Form();
            invoiceDetailsForm.Text = "Chi Tiết Hóa Đơn";
            invoiceDetailsForm.Size = new Size(600, 580);
            invoiceDetailsForm.StartPosition = FormStartPosition.CenterParent;
            invoiceDetailsForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            invoiceDetailsForm.MaximizeBox = false;
            invoiceDetailsForm.MinimizeBox = false;
            
            // Tạo DataGridView để hiển thị chi tiết dịch vụ
            DataGridView dgvDetails = new DataGridView();
            dgvDetails.Location = new Point(20, 20);
            dgvDetails.Size = new Size(540, 250);
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.BorderStyle = BorderStyle.FixedSingle;

            // Thiết lập header style
            dgvDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgvDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDetails.EnableHeadersVisualStyles = false;

            // Thêm các cột
            dgvDetails.Columns.Add("TenSP", "Tên dịch vụ");
            dgvDetails.Columns.Add("SoLuong", "Số lượng");
            dgvDetails.Columns.Add("DonGia", "Đơn giá");
            dgvDetails.Columns.Add("ThanhTien", "Thành tiền");

            decimal tienBan = hoaDon.TongTien - chiTiet.Sum(x => x.ThanhTien) + hoaDon.GiamGia;
            dgvDetails.Rows.Add("Tiền bàn", "1", string.Format("{0:N0} đ", tienBan), string.Format("{0:N0} đ", tienBan));
            // Thêm dữ liệu thực
            foreach (var item in chiTiet)
            {
                dgvDetails.Rows.Add(
                    item.TenSP,
                    item.SoLuong,
                    string.Format("{0:N0} đ", item.DonGia),
                    string.Format("{0:N0} đ", item.ThanhTien)
                );
            }

            // Tạo panel thông tin tổng kết
            Panel summaryPanel = new Panel();
            summaryPanel.Location = new Point(20, 290);
            summaryPanel.Size = new Size(540, 170);
            summaryPanel.BackColor = Color.White;
            summaryPanel.BorderStyle = BorderStyle.FixedSingle;
            
            // Thêm các label thông tin
            Label lblMaHD = new Label();
            lblMaHD.Text = $"Mã hóa đơn: HD{hoaDon.MaHD:D6}";
            lblMaHD.Location = new Point(10, 10);
            lblMaHD.Size = new Size(300, 20);
            lblMaHD.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            Label lblTotal = new Label();
            lblTotal.Text = $"Tổng cộng: {hoaDon.TongTien:N0} đ";
            lblTotal.Location = new Point(10, 35);
            lblTotal.Size = new Size(300, 20);
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            Label lblDiscount = new Label();
            lblDiscount.Text = $"Giảm giá: {hoaDon.GiamGia:N0} đ";
            lblDiscount.Location = new Point(10, 60);
            lblDiscount.Size = new Size(300, 20);
            lblDiscount.Font = new Font("Segoe UI", 10F);

            Label lblPayment = new Label();
            lblPayment.Text = $"Phương thức thanh toán: {hoaDon.PhuongThucThanhToan}";
            lblPayment.Location = new Point(10, 85);
            lblPayment.Size = new Size(400, 20);
            lblPayment.Font = new Font("Segoe UI", 10F);

            Label lblNguoiLap = new Label();
            lblNguoiLap.Text = $"Người lập: {hoaDon.TenNhanVien}";
            lblNguoiLap.Location = new Point(10, 110);
            lblNguoiLap.Size = new Size(400, 20);
            lblNguoiLap.Font = new Font("Segoe UI", 10F);
            
            

            Label lblDateTime = new Label();
            lblDateTime.Text = $"Ngày giờ: {hoaDon.NgayLap:HH:mm:ss dd/MM/yyyy}";
            lblDateTime.Location = new Point(10, 135);
            lblDateTime.Size = new Size(400, 20);
            lblDateTime.Font = new Font("Segoe UI", 10F);

            // Tạo nút In hóa đơn
            Button btnPrint = new Button();
            btnPrint.Text = "In hóa đơn";
            btnPrint.Location = new Point(20, 490);
            btnPrint.Size = new Size(100, 35);
            btnPrint.BackColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderColor = Color.FromArgb(0, 123, 255);
            btnPrint.FlatAppearance.BorderSize = 1;
            btnPrint.Font = new Font("Segoe UI", 10F);
            btnPrint.ForeColor = Color.FromArgb(0, 123, 255);
            btnPrint.Click += (s, e) => ShowPrintInvoice(hoaDon, chiTiet);

            // Tạo nút Đóng
            Button btnClose = new Button();
            btnClose.Text = "Đóng";
            btnClose.Location = new Point(130, 490);
            btnClose.Size = new Size(100, 35);
            btnPrint.BackColor = Color.FromArgb(0, 123, 255);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnClose.Click += (s, e) => invoiceDetailsForm.Close();

            // Thêm controls vào form
            summaryPanel.Controls.Add(lblMaHD);
            summaryPanel.Controls.Add(lblTotal);
            summaryPanel.Controls.Add(lblDiscount);
            summaryPanel.Controls.Add(lblPayment);
            summaryPanel.Controls.Add(lblNguoiLap);
            summaryPanel.Controls.Add(lblDateTime);
            

            invoiceDetailsForm.Controls.Add(dgvDetails);
            invoiceDetailsForm.Controls.Add(summaryPanel);
            invoiceDetailsForm.Controls.Add(btnPrint);
            invoiceDetailsForm.Controls.Add(btnClose);

            // Hiển thị form
            invoiceDetailsForm.ShowDialog();
        }

        private void DeleteInvoice(int maHD, string maHDText, int rowIndex)
        {
            DialogResult result = MessageBox.Show($"Bạn có muốn xóa hóa đơn {maHDText}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _hoaDonBLL.DeleteHoaDon(maHD);
                    if (success)
                    {
                        guna2DataGridHoadon.Rows.RemoveAt(rowIndex);
                        MessageBox.Show($"Đã xóa hóa đơn {maHDText} thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại tổng số hóa đơn
                        labelTitle.Text = $"Quản Lý Hóa Đơn ({guna2DataGridHoadon.Rows.Count} hóa đơn)";
                    }
                    else
                    {
                        MessageBox.Show($"Không thể xóa hóa đơn {maHDText}!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowPrintInvoice(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTiet)
        {
            // Tạo form in hóa đơn với dữ liệu thực
            Form printForm = new Form();
            printForm.Text = "HÓA ĐƠN THANH TOÁN - BIDA CLUB";
            printForm.Size = new Size(400, 650);
            printForm.StartPosition = FormStartPosition.CenterParent;
            printForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            printForm.MaximizeBox = false;
            printForm.MinimizeBox = false;
            printForm.BackColor = Color.White;

            // Tạo Panel chứa nội dung hóa đơn
            Panel invoicePanel = new Panel();
            invoicePanel.Location = new Point(20, 20);
            invoicePanel.Size = new Size(350, 500);
            invoicePanel.BackColor = Color.White;
            invoicePanel.BorderStyle = BorderStyle.FixedSingle;

            // Tạo RichTextBox để hiển thị nội dung hóa đơn
            RichTextBox rtbInvoice = new RichTextBox();
            rtbInvoice.Location = new Point(10, 10);
            rtbInvoice.Size = new Size(330, 480);
            rtbInvoice.BorderStyle = BorderStyle.None;
            rtbInvoice.BackColor = Color.White;
            rtbInvoice.Font = new Font("Courier New", 10F);
            rtbInvoice.ReadOnly = true;

            // Tạo nội dung hóa đơn
            string invoiceContent = GenerateInvoiceContent(hoaDon, chiTiet);
            rtbInvoice.Text = invoiceContent;

            // Nút In
            Button btnPrint = new Button();
            btnPrint.Text = "In";
            btnPrint.Location = new Point(100, 540);
            btnPrint.Size = new Size(80, 35);
            btnPrint.BackColor = Color.FromArgb(0, 123, 255);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Click += (s, e) => {
                MessageBox.Show("Đã in hóa đơn thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Nút Đóng
            Button btnClose = new Button();
            btnClose.Text = "Đóng";
            btnClose.Location = new Point(190, 540);
            btnClose.Size = new Size(80, 35);
            btnClose.BackColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(0, 123, 255);
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.FromArgb(0, 123, 255);
            btnClose.Click += (s, e) => printForm.Close();

            invoicePanel.Controls.Add(rtbInvoice);
            printForm.Controls.Add(invoicePanel);
            printForm.Controls.Add(btnPrint);
            printForm.Controls.Add(btnClose);

            printForm.ShowDialog();
        }

        private string GenerateInvoiceContent(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTiet)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("      BIDA CLUB");
            sb.AppendLine("  HÓA ĐƠN THANH TOÁN");
            sb.AppendLine("══════════════════════════════");
            sb.AppendLine($"Số HĐ: HD{hoaDon.MaHD:D6}");
            sb.AppendLine($"Ngày: {hoaDon.NgayLap:dd/MM/yyyy HH:mm}");
            sb.AppendLine("──────────────────────────────");

            // Chi tiết dịch vụ
            if (chiTiet.Count > 0)
            {
                sb.AppendLine("DỊCH VỤ:");
                foreach (var item in chiTiet)
                {
                    sb.AppendLine($"  {item.TenSP}");
                    sb.AppendLine($"    {item.SoLuong} × {item.DonGia:N0} = {item.ThanhTien:N0} đ");
                }
                sb.AppendLine("──────────────────────────────");
            }

            // Tổng kết
            decimal tongTam = chiTiet.Sum(x => x.ThanhTien);
            sb.AppendLine($"TỔNG TẠM TÍNH: {tongTam,13:N0} đ");
            sb.AppendLine($"GIẢM GIÁ: {-hoaDon.GiamGia,13:N0} đ");
            sb.AppendLine($"TỔNG CỘNG: {hoaDon.TongTien,13:N0} đ");
            sb.AppendLine($"Phương thức: {hoaDon.PhuongThucThanhToan}");
            sb.AppendLine("══════════════════════════════");
            sb.AppendLine("  Cảm ơn quý khách!");
            sb.AppendLine("    Hẹn gặp lại!");
            sb.AppendLine();
            sb.AppendLine("  Hotline: 0900 123 456");

            return sb.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Không cần xử lý
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Không cần xử lý
        }
    }
}