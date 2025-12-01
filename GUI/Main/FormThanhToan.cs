using QuanLyBida.BLL;
using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;
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
        private readonly List<FormDichVu.ServiceItem> _items;
        private KhachHangBLL _khachHangBLL = new KhachHangBLL();
        private KhachHangDTO _khachHangHienTai = null;
        private int _diemTichLuyThem = 0;
        // Khai báo ngay dưới dòng "public partial class FormThanhToan : Form"
        private const string BANK_ID = "VCB";       // Tên ngân hàng (MB, VCB, ACB,...)
        private const string ACCOUNT_NO = "1040678824"; // Số tài khoản nhận tiền
        private const string TEMPLATE = "compact"; // Kiểu QR
        public FormThanhToan(string tableName, string tableType, decimal hourlyRate, TimeSpan playTime,
                     List<FormDichVu.ServiceItem> items = null, int maDatBan = 0, string tenNhanVien = "", int maNhanVien = 0)
        {
            this.tableName = tableName;
            this.tableType = tableType;
            this.hourlyRate = hourlyRate;
            this.playTime = playTime;
            _items = items ?? new List<FormDichVu.ServiceItem>();
            _maDatBan = maDatBan;
            _tenNhanVien = tenNhanVien;
            _maNhanVien = maNhanVien;
            _maHoaDon = 0;
            _khachHangBLL = new KhachHangBLL();

            InitializeComponent();
            Shown += FormThanhToan_Shown;
        }

        private void FormThanhToan_Shown(object sender, EventArgs e)
        {
            Text = $"Thanh Toán - {tableName}";
            labelHeader.Text = "HÓA ĐƠN THANH TOÁN";
            labelSubTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

            lblTGValue.Text = playTime.ToString(@"hh\:mm\:ss");
            lblTienBanTitle.Text = $"Tiền bàn ({tableType} - {hourlyRate:N0} đ/giờ):";

            // XÓA DEBUG - HIỂN THỊ THÔNG TIN NHÂN VIÊN BÌNH THƯỜNG
            label1.Text = $"Nhân viên: {_tenNhanVien}";
            label2.Text = "Số HĐ: Chờ xác nhận";
            ResetKhachHangInfo();
            TinhTongTien();
            BuildItemsList();
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
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                // Tìm khách hàng theo SĐT
                _khachHangHienTai = _khachHangBLL.TimKhachHangTheoSDT(sdt);

                if (_khachHangHienTai != null)
                {
                    // Hiển thị thông tin khách hàng
                    lblTenKH.Text = $"{_khachHangHienTai.HoTen} - {_khachHangHienTai.Hang} - Điểm: {_khachHangHienTai.DiemTichLuy}";
                    lblTenKH.ForeColor = Color.Green;
                    btnThemKH.Visible = false;

                    // Tính điểm tích lũy sẽ thêm (1,000đ = 1 điểm)
                    _diemTichLuyThem = _khachHangBLL.TinhDiemTichLuy(TinhTongTienChuaGiam());
                    MessageBox.Show($"Sẽ tích thêm {_diemTichLuyThem} điểm cho khách hàng!\n(Tỷ lệ: 1,000đ = 1 điểm)", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();

            if (sdt == "Nhập số điện thoại..." || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo form thêm khách hàng mới (sử dụng form có sẵn từ FormQLKH)
            var khachHangMoi = new KhachHangDTO
            {
                SDT = sdt,
                HoTen = "", // Sẽ nhập trong form
                Hang = "Thường",
                DiemTichLuy = 0
            };

            bool result = ShowCustomerDialog(out khachHangMoi, khachHangMoi);

            if (result && khachHangMoi != null)
            {
                try
                {
                    // Thêm khách hàng mới
                    bool success = _khachHangBLL.ThemKhachHang(khachHangMoi);
                    if (success)
                    {
                        // Tìm lại để lấy đầy đủ thông tin (bao gồm MaKH)
                        _khachHangHienTai = _khachHangBLL.TimKhachHangTheoSDT(sdt);

                        if (_khachHangHienTai != null)
                        {
                            lblTenKH.Text = $"{_khachHangHienTai.HoTen} - {_khachHangHienTai.Hang} - Điểm: {_khachHangHienTai.DiemTichLuy}";
                            lblTenKH.ForeColor = Color.Green;
                            btnThemKH.Visible = false;

                            // Tính điểm tích lũy sẽ thêm (1,000đ = 1 điểm)
                            _diemTichLuyThem = _khachHangBLL.TinhDiemTichLuy(TinhTongTienChuaGiam());
                            MessageBox.Show($"Đã thêm khách hàng thành công! Sẽ tích thêm {_diemTichLuyThem} điểm.\n(Tỷ lệ: 1,000đ = 1 điểm)",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void TinhTongTien()
        {
            try
            {
                // Tính tiền bàn
                var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
                
                // Tính tiền dịch vụ
                decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
                
                // Tổng tạm tính
                decimal tongTam = tableCost + serviceTotal;
                
                // Tính tiền giảm
                decimal tienGiam = tongTam * (numGiamGia.Value / 100);
                
                // Tổng cuối cùng
                decimal tongCuoi = tongTam - tienGiam;

                // Cập nhật UI
                lblTienBanValue.Text = string.Format("{0:N0} đ", tableCost);
                lblTienGiamValue.Text = string.Format("- {0:N0} đ", tienGiam);
                lblTongValue.Text = string.Format("{0:N0} đ", tongCuoi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính tổng tiền: {ex.Message}", "Lỗi");
            }
        }

        // Thêm method tính tổng tiền chưa giảm (để tính điểm)
        private decimal TinhTongTienChuaGiam()
        {
            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
            return tableCost + serviceTotal;
        }

        private void BuildItemsList()
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
                listItems.Items.Add(it);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra phương thức thanh toán được chọn
            string phuongThuc = "";
            if (radioTienMat.Checked) phuongThuc = "Tiền mặt";
            else if (radioChuyenKhoan.Checked) phuongThuc = "Chuyển khoản";
            else if (radioTheATM.Checked) phuongThuc = "Thẻ ATM";
            else if (radioViDienTu.Checked) phuongThuc = "Ví điện tử";

            if (string.IsNullOrEmpty(phuongThuc))
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thanh toán
            var result = MessageBox.Show(
                $"Xác nhận thanh toán {lblTongValue.Text} bằng {phuongThuc}?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Lưu hóa đơn vào database
                    SaveInvoiceToDatabase(phuongThuc);

                    // In hóa đơn
                    PrintInvoice(phuongThuc);


                    MessageBox.Show("✓ Thanh toán thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveInvoiceToDatabase(string phuongThuc)
        {
            // Tính toán các thành phần
            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
            decimal tongTam = tableCost + serviceTotal;

            // Tính giảm giá và VAT
            decimal giamGia = tongTam * (numGiamGia.Value / 100);
            decimal vat = (tongTam - giamGia) * 0.1m;
            decimal tongTien = tongTam - giamGia + vat;


            // Lưu vào database và lấy mã hóa đơn
            _maHoaDon = SaveHoaDon(tongTien, giamGia, vat, phuongThuc);
            // 🔥 THÊM: TỰ ĐỘNG TẠO PHIẾU THU KHI THANH TOÁN
            try
            {
                var hoaDonBLL = new HoaDonBLL();
                bool thanhToanThanhCong = hoaDonBLL.ThanhToanHoaDon(_maHoaDon, phuongThuc, _maNhanVien);

                if (thanhToanThanhCong)
                {
                    Console.WriteLine($"✅ Đã tự động tạo phiếu thu cho hóa đơn #{_maHoaDon}");
                }
                else
                {
                    Console.WriteLine($"⚠️ Cảnh báo: Không thể tạo phiếu thu cho hóa đơn #{_maHoaDon}");
                }
            }
            catch (Exception ex)
            {
                // Không throw error, chỉ cảnh báo để không ảnh hưởng đến trải nghiệm người dùng
                Console.WriteLine($"⚠️ Cảnh báo tạo phiếu thu: {ex.Message}");
                MessageBox.Show($"Thanh toán thành công nhưng có cảnh báo: {ex.Message}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Cập nhật điểm tích lũy nếu có khách hàng
            if (_khachHangHienTai != null && _diemTichLuyThem > 0)
            {
                try
                {
                    int diemMoi = _khachHangHienTai.DiemTichLuy + _diemTichLuyThem;

                    // SỬA: Dùng method mới để tự động thăng hạng
                    bool success = _khachHangBLL.CapNhatDiemVaThangHang(_khachHangHienTai.MaKH, diemMoi);

                    if (success)
                    {
                        // Lấy lại thông tin mới nhất để kiểm tra thăng hạng
                        var khachHangMoi = _khachHangBLL.TimKhachHangTheoMaKH(_khachHangHienTai.MaKH);

                        string thongBao = $"Đã tích lũy {_diemTichLuyThem} điểm cho {_khachHangHienTai.HoTen}!\nTổng điểm: {diemMoi}";

                        // Kiểm tra nếu có thăng hạng
                        if (khachHangMoi != null && khachHangMoi.Hang != _khachHangHienTai.Hang)
                        {
                        }

                        MessageBox.Show(thongBao, "Tích điểm thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật điểm: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Cập nhật số hóa đơn trên giao diện
            label2.Text = $"Số HĐ: HD{_maHoaDon:D6}";
        }

        private int SaveHoaDon(decimal tongTien, decimal giamGia, decimal vat, string phuongThuc)
        {
            var hoaDonDAL = new HoaDonDAL();

            // Tạo hóa đơn mới - ĐỂ TrangThaiThanhToan = "Chưa thanh toán"
            var hoaDon = new HoaDonDTO
            {
                MaBan = GetMaBanFromTableName(tableName),
                MaKH = _khachHangHienTai?.MaKH,
                MaNV = _maNhanVien,
                NgayLap = DateTime.Now,
                TongTien = tongTien,
                GiamGia = giamGia,
                TrangThaiThanhToan = "Chưa thanh toán", // 🔧 SỬA THÀNH "Chưa thanh toán"
                PhuongThucThanhToan = phuongThuc
            };

            // Thêm chi tiết hóa đơn cho dịch vụ
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

            // Lưu hóa đơn vào database và lấy mã hóa đơn
            int maHD = hoaDonDAL.CreateHoaDon(hoaDon);

            // Cập nhật số lượng tồn
            foreach (var item in _items)
            {
                hoaDonDAL.CapNhatSoLuongTon(item.MaSP, item.Quantity);
            }

            return maHD;
        }

        private int GetMaBanFromTableName(string tableName)
        {
            if (tableName.StartsWith("Bàn"))
            {
                string numberStr = new string(tableName.Where(char.IsDigit).ToArray());
                if (int.TryParse(numberStr, out int tableNumber))
                {
                    return tableNumber;
                }
            }
            return 1;
        }

        private void PrintInvoice(string phuongThuc)
        {
            try
            {
                // Tạo nội dung bill
                var invoiceContent = GenerateInvoiceContent(phuongThuc);

                // Hiển thị bill preview
                ShowInvoicePreview(invoiceContent, phuongThuc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi in hóa đơn: {ex.Message}");
            }
        }

        private void ShowInvoicePreview(string invoiceContent, string phuongThuc)
        {
            // 1. Tính toán lại tổng tiền cuối cùng để tạo QR chính xác
            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            decimal serviceTotal = _items.Sum(item => item.Price * item.Quantity);
            decimal tongTam = tableCost + serviceTotal;
            decimal tienGiam = tongTam * (numGiamGia.Value / 100);
            decimal tongCuoi = tongTam - tienGiam; // Số tiền cần thanh toán

            // 2. Cấu hình Form Preview
            var invoiceForm = new Form()
            {
                Text = "HÓA ĐƠN THANH TOÁN - BIDA CLUB",
                Size = new Size(480, 750),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                BackColor = Color.White
            };

            // 3. Panel chứa nội dung Text hóa đơn
            var lineCount = invoiceContent.Split('\n').Length;
            var textHeight = Math.Min(lineCount * 20, 400); // Giới hạn chiều cao vùng chữ

            var textPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = textHeight + 20,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var textBoxInside = new RichTextBox()
            {
                Text = invoiceContent,
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Courier New", 10, FontStyle.Regular), // Font monospaced để thẳng hàng
                ScrollBars = RichTextBoxScrollBars.None,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ForeColor = Color.Black
            };
            textPanel.Controls.Add(textBoxInside);
            invoiceForm.Controls.Add(textPanel);

            // 4. 🔥 XỬ LÝ QR CODE (CHUYỂN KHOẢN HOẶC VÍ ĐIỆN TỬ)
            if (phuongThuc == "Chuyển khoản" || phuongThuc == "Ví điện tử")
            {
                // Tăng chiều cao form để chứa QR
                invoiceForm.Height += 350;

                var qrPanel = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = 350,
                    BackColor = Color.White
                };

                var picQR = new PictureBox()
                {
                    Size = new Size(300, 300),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point((invoiceForm.Width - 330) / 2, 10), // Căn giữa
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Tùy chỉnh câu hướng dẫn dựa trên phương thức
                string huongDanText = (phuongThuc == "Ví điện tử")
                    ? "Mở Momo/ZaloPay quét mã để thanh toán"
                    : "Mở App Ngân hàng quét mã để thanh toán";

                var lblHuongDan = new Label()
                {
                    Text = huongDanText,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    Height = 30,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.DimGray
                };

                try
                {
                    // Tạo Link VietQR
                    // Link này sẽ tự động điền số tiền và nội dung chuyển khoản
                    long amount = (long)tongCuoi;
                    string content = $"TT HD{_maHoaDon}"; // Nội dung: TT HD000123

                    // BANK_ID và ACCOUNT_NO lấy từ biến hằng số bạn đã khai báo ở đầu class
                    string url = $"https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png?amount={amount}&addInfo={content}";

                    picQR.Load(url);
                }
                catch
                {
                    // Xử lý nếu không có mạng
                    picQR.Image = null;
                    picQR.BackColor = Color.WhiteSmoke;
                    lblHuongDan.Text = "Không thể tải mã QR (Kiểm tra Internet)";
                    lblHuongDan.ForeColor = Color.Red;
                }

                qrPanel.Controls.Add(picQR);
                qrPanel.Controls.Add(lblHuongDan);
                invoiceForm.Controls.Add(qrPanel);

                // Đưa panel text lên trên cùng lại
                textPanel.BringToFront();
            }

            // 5. Nút Đóng
            var actionPanel = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.WhiteSmoke
            };

            var btnClose = new Button()
            {
                Text = "Hoàn tất",
                Size = new Size(120, 40),
                Location = new Point((invoiceForm.Width - 140) / 2, 10),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => invoiceForm.Close();

            actionPanel.Controls.Add(btnClose);
            invoiceForm.Controls.Add(actionPanel);

            invoiceForm.ShowDialog();
        }

        private bool ShowCustomerDialog(out KhachHangDTO customer, KhachHangDTO seed = null)
        {
            customer = null;

            using (var dialog = new Form())
            {
                dialog.Text = seed == null ? "Thêm khách hàng" : "Sửa khách hàng";
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.MinimizeBox = false;
                dialog.MaximizeBox = false;
                dialog.ClientSize = new Size(420, 300);

                var labelHoTen = new Label { Text = "Họ tên *", Left = 20, Top = 20, AutoSize = true };
                var inputHoTen = new TextBox { Left = 160, Top = 16, Width = 230 };

                var labelSoDienThoai = new Label { Text = "Số điện thoại *", Left = 20, Top = 60, AutoSize = true };
                var inputSoDienThoai = new TextBox { Left = 160, Top = 56, Width = 230, ReadOnly = seed?.SDT != null };

                var labelEmail = new Label { Text = "Email", Left = 20, Top = 100, AutoSize = true };
                var inputEmail = new TextBox { Left = 160, Top = 96, Width = 230 };

                var labelHangThanhVien = new Label { Text = "Hạng thành viên", Left = 20, Top = 140, AutoSize = true };
                var inputHangThanhVien = new ComboBox { Left = 160, Top = 136, Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
                inputHangThanhVien.Items.AddRange(new object[] { "Thường", "Bạc", "Vàng", "Kim Cương" });

                var btnOk = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Left = 220, Width = 80, Top = 190 };
                var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Left = 310, Width = 80, Top = 190 };

                if (seed != null)
                {
                    inputHoTen.Text = seed.HoTen;
                    inputSoDienThoai.Text = seed.SDT;
                    inputEmail.Text = seed.Email;
                    inputHangThanhVien.SelectedItem = seed.Hang;
                }
                else
                {
                    inputHangThanhVien.SelectedIndex = 0;
                }

                dialog.Controls.AddRange(new System.Windows.Forms.Control[]
                 {
                    labelHoTen, inputHoTen,
                    labelSoDienThoai, inputSoDienThoai,
                    labelEmail, inputEmail,
                    labelHangThanhVien, inputHangThanhVien,
                    btnOk, btnCancel
                 });

                dialog.AcceptButton = btnOk;
                dialog.CancelButton = btnCancel;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(inputHoTen.Text))
                    {
                        MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    customer = new KhachHangDTO
                    {
                        HoTen = inputHoTen.Text.Trim(),
                        SDT = inputSoDienThoai.Text.Trim(),
                        Email = inputEmail.Text.Trim(),
                        Hang = inputHangThanhVien.SelectedItem?.ToString() ?? "Thường"
                    };

                    return true;
                }
            }

            return false;
        }
        private string GenerateInvoiceContent(string phuongThuc)
        {
            var sb = new StringBuilder();

            // Header với thông tin nhân viên và số HĐ
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

            // Tiền bàn
            var tableCost = Math.Round((decimal)playTime.TotalHours * hourlyRate, 0);
            sb.AppendLine("TIỀN BÀN:");
            sb.AppendLine($"  {playTime.TotalHours:F1} giờ × {hourlyRate:N0} = {tableCost:N0} đ");

            // Dịch vụ thêm
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

            // Tổng tiền
            decimal tongTam = tableCost + serviceTotal;
            decimal tienGiam = tongTam * (numGiamGia.Value / 100);
            decimal tongCuoi = tongTam - tienGiam;

            sb.AppendLine($"TỔNG TẠM TÍNH: {tongTam,8:N0} đ");
            sb.AppendLine($"GIẢM GIÁ: {-tienGiam,13:N0} đ");
            sb.AppendLine($"TỔNG CỘNG: {tongCuoi,13:N0} đ");

            // Phương thức thanh toán
            sb.AppendLine($"Phương thức: {phuongThuc}");
            sb.AppendLine($"Thời gian: {DateTime.Now:HH:mm dd/MM/yyyy}");

            // Footer
            sb.AppendLine("══════════════════════════════");
            sb.AppendLine("  Cảm ơn quý khách!");
            sb.AppendLine("    Hẹn gặp lại!");
            sb.AppendLine();
            sb.AppendLine("  Hotline: 0900 123 456");

            return sb.ToString();
        }

        // Các method xử lý sự kiện
        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Các method rỗng cho sự kiện click của label
        private void lblTienBanValue_Click(object sender, EventArgs e) { }
        private void lblTongValue_Click(object sender, EventArgs e) { }
        private void lblPTTTTitle_Click_1(object sender, EventArgs e) { }
        private void lblPhanTram_Click(object sender, EventArgs e) { }
        private void lblTienGiamTitle_Click(object sender, EventArgs e) { }

        private void FormThanhToan_Load(object sender, EventArgs e) { }

        private void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}