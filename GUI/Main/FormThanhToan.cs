using QuanLyBida.BLL;
using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormThanhToan : Form
    {
        private readonly string tableName;
        private readonly string tableType;
        private readonly decimal hourlyRate;
        private readonly TimeSpan playTime;
        private readonly int _maDatBan;
        private readonly string _tenNhanVien;
        private readonly int _maNhanVien;
        private int _maHoaDon;

        // Danh sách dịch vụ (Dữ liệu gốc để tính toán)
        private List<FormDichVu.ServiceItem> _items;

        private KhachHangBLL _khachHangBLL = new KhachHangBLL();
        private KhachHangDTO _khachHangHienTai = null;
        private int _diemTichLuyThem = 0;

        // Thông tin ngân hàng để tạo QR Code
        private const string BANK_ID = "VCB";
        private const string ACCOUNT_NO = "1040678824";
        private const string TEMPLATE = "compact";

        public FormThanhToan(string tableName, string tableType, decimal hourlyRate, TimeSpan playTime,
                     List<FormDichVu.ServiceItem> items = null, int maDatBan = 0, string tenNhanVien = "", int maNhanVien = 0)
        {
            this.tableName = tableName;
            this.tableType = tableType;
            this.hourlyRate = hourlyRate;
            this.playTime = playTime;
            // Tạo bản sao danh sách để thao tác không ảnh hưởng form gốc
            _items = items != null ? new List<FormDichVu.ServiceItem>(items) : new List<FormDichVu.ServiceItem>();
            _maDatBan = maDatBan;
            _tenNhanVien = tenNhanVien;
            _maNhanVien = maNhanVien;
            _maHoaDon = 0;
            _khachHangBLL = new KhachHangBLL();

            InitializeComponent();
            Shown += FormThanhToan_Load;
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            Text = $"Thanh Toán - {tableName}";
            labelHeader.Text = "HÓA ĐƠN THANH TOÁN";
            labelSubTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

            lblTGValue.Text = playTime.ToString(@"hh\:mm\:ss");
            lblTienBanTitle.Text = $"Tiền bàn ({tableType} - {hourlyRate:N0} đ/giờ):";

            label1.Text = $"Nhân viên: {_tenNhanVien}";
            label2.Text = "Số HĐ: Chờ xác nhận";

            ResetKhachHangInfo();

            // --- CẤU HÌNH TÍNH NĂNG LISTVIEW ---
            SetupListViewFeatures();

            // Hiển thị dữ liệu
            RefreshListView();
            TinhTongTien();
        }

        // =================================================================
        // 🔥 PHẦN MỚI: XỬ LÝ LISTVIEW (THÊM, SỬA, XÓA)
        // =================================================================

        private void SetupListViewFeatures()
        {
            // 1. Bắt sự kiện Double Click để sửa số lượng
            listItems.MouseDoubleClick += ListItems_MouseDoubleClick;

            // 2. Tạo Menu chuột phải
            ContextMenuStrip menu = new ContextMenuStrip();

            // Mục: Thêm dịch vụ ngoài
            ToolStripMenuItem itemAdd = new ToolStripMenuItem("➕ Thêm dịch vụ/phụ thu khác");
            itemAdd.Click += (s, e) => ShowDialogAddCustomItem();
            menu.Items.Add(itemAdd);

            // Mục: Xóa món
            ToolStripMenuItem itemDel = new ToolStripMenuItem("❌ Xóa món này");
            itemDel.Click += (s, e) => DeleteSelectedItem();
            menu.Items.Add(itemDel);

            // Gán menu vào ListView
            listItems.ContextMenuStrip = menu;
        }

        private void RefreshListView()
        {
            listItems.Items.Clear();
            foreach (var i in _items)
            {
                var total = i.Price * i.Quantity;
                var it = new ListViewItem(new string[]
                {
                    i.Name,
                    i.Quantity.ToString(),
                    string.Format("{0:N0}", i.Price),
                    string.Format("{0:N0}", total)
                });
                it.Tag = i; // Lưu đối tượng gốc để dễ thao tác
                listItems.Items.Add(it);
            }
        }

        // Sửa số lượng khi Double Click
        private void ListItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listItems.SelectedItems.Count > 0)
            {
                var selectedItem = listItems.SelectedItems[0];
                var serviceItem = selectedItem.Tag as FormDichVu.ServiceItem;

                // Sử dụng InputBox tự chế để không cần reference VB
                string input = ShowInputDialog("Nhập số lượng mới:", "Sửa số lượng", serviceItem.Quantity.ToString());

                if (int.TryParse(input, out int newQty))
                {
                    if (newQty <= 0)
                    {
                        _items.Remove(serviceItem); // Số lượng <= 0 thì xóa luôn
                    }
                    else
                    {
                        serviceItem.Quantity = newQty;
                    }

                    RefreshListView();
                    TinhTongTien();
                }
            }
        }

        // Xóa món đang chọn
        private void DeleteSelectedItem()
        {
            if (listItems.SelectedItems.Count > 0)
            {
                var selectedItem = listItems.SelectedItems[0];
                var serviceItem = selectedItem.Tag as FormDichVu.ServiceItem;

                _items.Remove(serviceItem);
                RefreshListView();
                TinhTongTien();
            }
        }

        // Thêm món ngoài
        private void ShowDialogAddCustomItem()
        {
            Form frm = new Form();
            frm.Text = "Thêm phí khác";
            frm.Size = new Size(320, 220);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;

            Label lblName = new Label { Text = "Tên dịch vụ/lỗi:", Left = 15, Top = 20, Width = 260 };
            TextBox txtName = new TextBox { Left = 15, Top = 45, Width = 260 };

            Label lblPrice = new Label { Text = "Đơn giá (VNĐ):", Left = 15, Top = 85, Width = 260 };
            TextBox txtPrice = new TextBox { Left = 15, Top = 110, Width = 260 };

            Button btnOk = new Button { Text = "Thêm", Left = 195, Top = 145, DialogResult = DialogResult.OK, Width = 80 };

            frm.Controls.AddRange(new Control[] { lblName, txtName, lblPrice, txtPrice, btnOk });
            frm.AcceptButton = btnOk;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (decimal.TryParse(txtPrice.Text.Replace(",", ""), out decimal price) && !string.IsNullOrWhiteSpace(txtName.Text))
                {
                    _items.Add(new FormDichVu.ServiceItem
                    {
                        MaSP = -1, // 0 là mã cho dịch vụ ngoài
                        Name = txtName.Text,
                        Price = (int)price,
                        Quantity = 1,
                        DonViTinh = "Lần"
                    });

                    RefreshListView();
                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng tên và giá tiền!");
                }
            }
        }

        // Hàm tạo InputBox đơn giản
        private string ShowInputDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 250 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240, Text = defaultValue };
            Button confirmation = new Button() { Text = "OK", Left = 180, Width = 80, Top = 90, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        // =================================================================
        // CÁC HÀM TÍNH TOÁN & LOGIC CŨ (Đã cập nhật dùng _items)
        // =================================================================

        private void TinhTongTien()
        {
            try
            {
                var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
                decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
                decimal tongTam = tableCost + serviceTotal;
                decimal tienGiam = tongTam * (numGiamGia.Value / 100);
                decimal tongCuoi = tongTam - tienGiam;

                lblTienBanValue.Text = string.Format("{0:N0} đ", tableCost);
                lblTienGiamValue.Text = string.Format("- {0:N0} đ", tienGiam);
                lblTongValue.Text = string.Format("{0:N0} đ", tongCuoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính tổng tiền: {ex.Message}", "Lỗi");
            }
        }

        private decimal TinhTongTienChuaGiam()
        {
            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
            return tableCost + serviceTotal;
        }

        private void ResetKhachHangInfo()
        {
            _khachHangHienTai = null;
            _diemTichLuyThem = 0;
            lblTenKH.Text = "Chưa chọn khách hàng";
            lblTenKH.ForeColor = Color.Gray;
            btnThemKH.Visible = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (sdt == "Nhập số điện thoại..." || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _khachHangHienTai = _khachHangBLL.TimKhachHangTheoSDT(sdt);
                if (_khachHangHienTai != null)
                {
                    lblTenKH.Text = $"{_khachHangHienTai.HoTen} - {_khachHangHienTai.Hang} - Điểm: {_khachHangHienTai.DiemTichLuy}";
                    lblTenKH.ForeColor = Color.Green;
                    btnThemKH.Visible = false;
                    _diemTichLuyThem = _khachHangBLL.TinhDiemTichLuy(TinhTongTienChuaGiam());
                    MessageBox.Show($"Sẽ tích thêm {_diemTichLuyThem} điểm cho khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblTenKH.Text = "Không tìm thấy khách hàng. Bấm 'Thêm' để tạo mới.";
                    lblTenKH.ForeColor = Color.OrangeRed;
                    btnThemKH.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            var khachHangMoi = new KhachHangDTO { SDT = sdt, HoTen = "", Hang = "Thường", DiemTichLuy = 0 };

            if (ShowCustomerDialog(out khachHangMoi, khachHangMoi))
            {
                try
                {
                    if (_khachHangBLL.ThemKhachHang(khachHangMoi))
                    {
                        _khachHangHienTai = _khachHangBLL.TimKhachHangTheoSDT(sdt);
                        if (_khachHangHienTai != null)
                        {
                            lblTenKH.Text = $"{_khachHangHienTai.HoTen} - {_khachHangHienTai.Hang} - Điểm: {_khachHangHienTai.DiemTichLuy}";
                            lblTenKH.ForeColor = Color.Green;
                            btnThemKH.Visible = false;
                            _diemTichLuyThem = _khachHangBLL.TinhDiemTichLuy(TinhTongTienChuaGiam());
                            MessageBox.Show($"Đã thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi");
                }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string phuongThuc = "";
            if (radioTienMat.Checked) phuongThuc = "Tiền mặt";
            else if (radioChuyenKhoan.Checked) phuongThuc = "Chuyển khoản";
            else if (radioTheATM.Checked) phuongThuc = "Thẻ ATM";
            else if (radioViDienTu.Checked) phuongThuc = "Ví điện tử";

            if (string.IsNullOrEmpty(phuongThuc))
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận thanh toán {lblTongValue.Text}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SaveInvoiceToDatabase(phuongThuc);
                    PrintInvoice(phuongThuc);
                    MessageBox.Show("✓ Thanh toán thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi");
                }
            }
        }

        private void SaveInvoiceToDatabase(string phuongThuc)
        {
            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
            decimal tongTam = tableCost + serviceTotal;
            decimal giamGia = tongTam * (numGiamGia.Value / 100);
            decimal vat = (tongTam - giamGia) * 0.1m;
            decimal tongTien = tongTam - giamGia + vat;

            _maHoaDon = SaveHoaDon(tongTien, giamGia, vat, phuongThuc);

            try
            {
                var hoaDonBLL = new HoaDonBLL();
                bool thanhToanThanhCong = hoaDonBLL.ThanhToanHoaDon(_maHoaDon, phuongThuc, _maNhanVien);
                if (thanhToanThanhCong) Console.WriteLine($"✅ Đã tạo phiếu thu cho HĐ #{_maHoaDon}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Cảnh báo tạo phiếu thu: {ex.Message}");
            }

            if (_khachHangHienTai != null && _diemTichLuyThem > 0)
            {
                try
                {
                    _khachHangBLL.CapNhatDiemVaThangHang(_khachHangHienTai.MaKH, _khachHangHienTai.DiemTichLuy + _diemTichLuyThem);
                    MessageBox.Show($"Đã tích lũy {_diemTichLuyThem} điểm!", "Tích điểm");
                }
                catch { }
            }
            label2.Text = $"Số HĐ: HD{_maHoaDon:D6}";
        }

        private int SaveHoaDon(decimal tongTien, decimal giamGia, decimal vat, string phuongThuc)
        {
            var hoaDonDAL = new HoaDonDAL();
            var hoaDon = new HoaDonDTO
            {
                MaBan = GetMaBanFromTableName(tableName),
                MaKH = _khachHangHienTai?.MaKH,
                MaNV = _maNhanVien,
                NgayLap = DateTime.Now,
                TongTien = tongTien,
                GiamGia = giamGia,
                TrangThaiThanhToan = "Chưa thanh toán",
                PhuongThucThanhToan = phuongThuc
            };

            foreach (var item in _items)
            {
                hoaDon.ChiTiet.Add(new ChiTietHoaDonDTO
                {
                    MaSP = item.MaSP,
                    TenSP = item.Name,
                    SoLuong = item.Quantity,
                    DonGia = item.Price,
                    ThanhTien = item.Price * item.Quantity
                });
            }

            int maHD = hoaDonDAL.CreateHoaDon(hoaDon);
            foreach (var item in _items)
            {
                if (item.MaSP > 0)   // chỉ trừ kho sản phẩm thật
                    hoaDonDAL.CapNhatSoLuongTon(item.MaSP, item.Quantity);
            }
            return maHD;
        }

        private int GetMaBanFromTableName(string tableName)
        {
            if (tableName.StartsWith("Bàn"))
            {
                string numberStr = new string(tableName.Where(char.IsDigit).ToArray());
                if (int.TryParse(numberStr, out int tableNumber)) return tableNumber;
            }
            return 1;
        }

        private void PrintInvoice(string phuongThuc)
        {
            try { ShowInvoicePreview(GenerateInvoiceContent(phuongThuc), phuongThuc); }
            catch (Exception ex) { Console.WriteLine($"Lỗi in hóa đơn: {ex.Message}"); }
        }

        private string GenerateInvoiceContent(string phuongThuc)
        {
            var sb = new StringBuilder();
            sb.AppendLine("      BIDA CLUB");
            sb.AppendLine("  HÓA ĐƠN THANH TOÁN");
            sb.AppendLine("══════════════════════════════");
            sb.AppendLine($"Số HĐ: HD{_maHoaDon:D6}");
            sb.AppendLine($"Nhân viên: {_tenNhanVien}");
            sb.AppendLine($"Bàn: {tableName}");
            sb.AppendLine($"Loại: {tableType}");
            sb.AppendLine($"Giờ vào: {DateTime.Now - playTime:HH:mm}");
            sb.AppendLine($"Giờ ra: {DateTime.Now:HH:mm}");
            sb.AppendLine($"Thời gian: {playTime:hh\\:mm\\:ss}");
            sb.AppendLine("──────────────────────────────");

            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            sb.AppendLine("TIỀN BÀN:");
            sb.AppendLine($"  {playTime.TotalHours:F1} giờ × {hourlyRate:N0} = {tableCost:N0} đ");

            decimal serviceTotal = 0;
            if (_items.Count > 0)
            {
                sb.AppendLine("DỊCH VỤ:");
                foreach (var item in _items)
                {
                    var total = item.Price * item.Quantity;
                    serviceTotal += total;
                    sb.AppendLine($"  {item.Name}");
                    sb.AppendLine($"    {item.Quantity} × {item.Price:N0} = {total:N0} đ");
                }
                sb.AppendLine($"  Tổng dịch vụ: {serviceTotal:N0} đ");
            }

            sb.AppendLine("──────────────────────────────");
            decimal tongTam = tableCost + serviceTotal;
            decimal tienGiam = tongTam * (numGiamGia.Value / 100);
            decimal tongCuoi = tongTam - tienGiam;

            sb.AppendLine($"TỔNG TẠM TÍNH: {tongTam,8:N0} đ");
            sb.AppendLine($"GIẢM GIÁ: {-tienGiam,13:N0} đ");
            sb.AppendLine($"TỔNG CỘNG: {tongCuoi,13:N0} đ");
            sb.AppendLine($"Phương thức: {phuongThuc}");
            sb.AppendLine($"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}");
            sb.AppendLine("══════════════════════════════");
            sb.AppendLine("  Cảm ơn quý khách!");
            return sb.ToString();
        }

        private void ShowInvoicePreview(string invoiceContent, string phuongThuc)
        {
            // (Giữ nguyên logic QR code và hiển thị preview của bạn)
            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
            decimal tongTam = tableCost + serviceTotal;
            decimal tienGiam = tongTam * (numGiamGia.Value / 100);
            decimal tongCuoi = tongTam - tienGiam;

            var invoiceForm = new Form()
            {
                Text = "HÓA ĐƠN THANH TOÁN - BIDA CLUB",
                Size = new Size(480, 750),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White
            };

            var textPanel = new Panel() { Dock = DockStyle.Top, Height = 400, BackColor = Color.White, Padding = new Padding(10) };
            var textBoxInside = new RichTextBox()
            {
                Text = invoiceContent,
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Courier New", 10, FontStyle.Regular),
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White
            };
            textPanel.Controls.Add(textBoxInside);
            invoiceForm.Controls.Add(textPanel);

            if (phuongThuc == "Chuyển khoản" || phuongThuc == "Ví điện tử")
            {
                invoiceForm.Height += 350;
                var qrPanel = new Panel() { Dock = DockStyle.Top, Height = 350, BackColor = Color.White };
                var picQR = new PictureBox() { Size = new Size(300, 300), SizeMode = PictureBoxSizeMode.StretchImage, Location = new Point((invoiceForm.Width - 330) / 2, 10), BorderStyle = BorderStyle.FixedSingle };
                var lblHuongDan = new Label() { Text = "Quét mã để thanh toán", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Bottom, Height = 30, ForeColor = Color.Gray };

                try
                {
                    long amount = (long)tongCuoi;
                    string content = $"TT HD{_maHoaDon}";
                    string url = $"https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png?amount={amount}&addInfo={content}";
                    picQR.Load(url);
                }
                catch { picQR.BackColor = Color.WhiteSmoke; lblHuongDan.Text = "Lỗi tải QR"; }

                qrPanel.Controls.Add(picQR);
                qrPanel.Controls.Add(lblHuongDan);
                invoiceForm.Controls.Add(qrPanel);
                textPanel.BringToFront();
            }

            var actionPanel = new Panel() { Dock = DockStyle.Bottom, Height = 60, BackColor = Color.WhiteSmoke };
            var btnClose = new Button() { Text = "Hoàn tất", Size = new Size(120, 40), Location = new Point((invoiceForm.Width - 140) / 2, 10), BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnClose.Click += (s, e) => invoiceForm.Close();
            actionPanel.Controls.Add(btnClose);
            invoiceForm.Controls.Add(actionPanel);

            invoiceForm.ShowDialog();
        }

        private bool ShowCustomerDialog(out KhachHangDTO customer, KhachHangDTO seed = null)
        {
            customer = null;
            // (Giữ nguyên logic dialog nhập khách hàng)
            using (var dialog = new Form())
            {
                dialog.Text = "Thêm khách hàng";
                dialog.Size = new Size(420, 300);
                dialog.StartPosition = FormStartPosition.CenterParent;

                var lblName = new Label { Text = "Họ tên:", Left = 20, Top = 20 };
                var txtName = new TextBox { Left = 120, Top = 18, Width = 250, Text = seed?.HoTen };
                var lblSDT = new Label { Text = "SĐT:", Left = 20, Top = 60 };
                var txtSDT = new TextBox { Left = 120, Top = 58, Width = 250, Text = seed?.SDT, ReadOnly = true };
                var btnOk = new Button { Text = "Lưu", Left = 150, Top = 200, DialogResult = DialogResult.OK };

                dialog.Controls.AddRange(new Control[] { lblName, txtName, lblSDT, txtSDT, btnOk });
                dialog.AcceptButton = btnOk;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    customer = new KhachHangDTO { HoTen = txtName.Text, SDT = txtSDT.Text, Hang = "Thường", DiemTichLuy = 0 };
                    return true;
                }
            }
            return false;
        }

        // Các event handler phụ trợ
        private void numGiamGia_ValueChanged(object sender, EventArgs e) { TinhTongTien(); }
        private void btnHuy_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; Close(); }
        private void txtSDT_Enter(object sender, EventArgs e) { if (txtSDT.Text == "Nhập số điện thoại...") { txtSDT.Text = ""; txtSDT.ForeColor = Color.Black; } }
        private void txtSDT_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(txtSDT.Text)) { txtSDT.Text = "Nhập số điện thoại..."; txtSDT.ForeColor = Color.Gray; } }

        // Các method click label rỗng
        private void lblTienBanValue_Click(object sender, EventArgs e) { }
        private void lblTongValue_Click(object sender, EventArgs e) { }
        private void lblPTTTTitle_Click_1(object sender, EventArgs e) { }
        private void lblPhanTram_Click(object sender, EventArgs e) { }
        private void lblTienGiamTitle_Click(object sender, EventArgs e) { }
        private void listItems_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}