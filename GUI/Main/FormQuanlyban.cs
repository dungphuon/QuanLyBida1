using Guna.UI2.WinForms;
using QuanLyBida.BLL;
using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormQuanlyban : Form
    {
        private class TableState
        {
            public int TableNumber { get; set; }
            public bool IsPlaying { get; set; }
            public bool IsReserved { get; set; }
            public string TableType { get; set; }
            public decimal HourlyRate { get; set; }
            public DateTime? StartTime { get; set; }
            public List<FormDichVu.ServiceItem> Items { get; set; } = new List<FormDichVu.ServiceItem>();
            public List<BookingDTO> Reservations { get; set; } = new List<BookingDTO>();

        }

        private readonly List<TableState> tables = new List<TableState>();
        private BookingBLL bookingBLL = new BookingBLL();
        private TableBLL tableBLL = new TableBLL();
        private Timer statusTimer;
        public TaiKhoanDTO CurrentTaiKhoan { get; set; }
        public string CurrentUserName { get; set; } = "Nhân viên";
        public FormQuanlyban(TaiKhoanDTO taiKhoan = null)
        {
            InitializeComponent();
            CurrentTaiKhoan = taiKhoan;
            if (taiKhoan != null)
            {
                CurrentUserName = taiKhoan.TenDangNhap ?? "Nhân viên";
            }
            Load += FormQuanlyban_Load;
            statusTimer = new Timer();
            statusTimer.Interval = 30000;
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();
        }
        public FormQuanlyban()
        {
            InitializeComponent();
            Load += FormQuanlyban_Load;

            statusTimer = new Timer();
            statusTimer.Interval = 30000;
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            foreach (var table in tables)
            {
                if (!table.IsPlaying)
                {
                    var currentReservation = GetCurrentActiveReservation(table);
                    table.IsReserved = (currentReservation != null);
                }
            }
            RenderTables();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            statusTimer?.Stop();
            statusTimer?.Dispose();
            base.OnFormClosed(e);
        }

        private void lblStatus1_Click(object sender, EventArgs e)
        {
        }

        private void FormQuanlyban_Load(object sender, EventArgs e)
        {
            LoadTablesFromDatabase();
            LoadBookingsFromDatabase();
            RenderTables();
        }

        private void LoadTablesFromDatabase()
        {
            try
            {
                var tableDTOs = tableBLL.GetAllTables();
                tables.Clear();

                foreach (var tableDTO in tableDTOs)
                {
                    var tableState = new TableState
                    {
                        TableNumber = tableDTO.MaBan,
                        TableType = tableDTO.LoaiBan,
                        HourlyRate = tableDTO.GiaGio,
                        IsPlaying = tableDTO.TrangThai == "Đang sử dụng",
                        IsReserved = tableDTO.TrangThai == "Đã đặt trước",
                        StartTime = tableDTO.ThoiGianBatDau
                    };

                    // THÊM: Load dịch vụ từ database nếu bàn đang chơi
                    if (tableState.IsPlaying)
                    {
                        tableState.Items = LoadServicesFromDatabase(tableDTO.MaBan);
                    }

                    tables.Add(tableState);
                }
            }
            catch (Exception)
            {
                CreateDemoTables();
            }
        }

        private void LoadBookingsFromDatabase()
        {
            try
            {
                var bookings = bookingBLL.GetAllBookings();
                foreach (var booking in bookings)
                {
                    var table = tables.Find(t => t.TableNumber == booking.MaBan);
                    if (table != null)
                    {
                        table.Reservations.Add(booking);
                        if (booking.TrangThai == "Đang sử dụng")
                        {
                            table.IsPlaying = true;
                            table.StartTime = booking.ThoiGianBatDau;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Bỏ qua lỗi
            }
        }

        private void CreateDemoTables()
        {
            for (int i = 1; i <= 8; i++)
            {
                tables.Add(new TableState
                {
                    TableNumber = i,
                    IsPlaying = false,
                    IsReserved = false,
                    TableType = (i % 2 == 0) ? "Lỗ" : "3 bi",
                    HourlyRate = (i % 2 == 0) ? 35000 : 40000
                });
            }
        }

        private void RenderTables()
        {
            flowTables.Controls.Clear();
            foreach (var t in tables)
            {
                var panel = BuildTablePanel(t);
                flowTables.Controls.Add(panel);
            }
        }

        private void ArrangeTwoButtons(Panel container, Control leftBtn, Control rightBtn, int top = 90)
        {
            int margin = 15;
            int spacing = 12;
            int height = 40;
            int width = (container.Width - (margin * 2) - spacing);
            width = Math.Max(60, width / 2);

            leftBtn.Height = rightBtn.Height = height;
            leftBtn.Width = rightBtn.Width = width;
            leftBtn.Top = rightBtn.Top = top;
            leftBtn.Left = margin;
            rightBtn.Left = margin + width + spacing;
        }

        private Control BuildTablePanel(TableState state)
        {
            var panel = new Panel
            {
                Width = 230,
                Height = 170,
                Margin = new Padding(10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var lbl = new Label
            {
                Text = $"Bàn {state.TableNumber}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            panel.Controls.Add(lbl);

            var lblType = new Label
            {
                Text = $"Loại: {state.TableType}",
                AutoSize = true,
                Location = new Point(10, 40)
            };
            panel.Controls.Add(lblType);

            var lblStatus = new Label
            {
                Text = GetStatusText(state),
                AutoSize = true,
                ForeColor = Color.DimGray,
                Location = new Point(10, 60)
            };
            panel.Controls.Add(lblStatus);

            var currentActiveReservation = GetCurrentActiveReservation(state);

            if (state.IsPlaying)
            {
                ReplaceWithPlayingActions(panel, state);
            }
            else if (currentActiveReservation != null)
            {
                ShowActiveReservationInfo(panel, state, currentActiveReservation);
            }
            else
            {
                ShowAvailableTable(panel, state);
            }

            return panel;
        }

        private BookingDTO GetCurrentActiveReservation(TableState state)
        {
            var now = DateTime.Now;
            return state.Reservations
                .Where(r => r.TrangThai == "Đang đặt" &&
                           now >= r.ThoiGianBatDau &&
                           now <= r.ThoiGianKetThuc)
                .FirstOrDefault();
        }

        private List<BookingDTO> GetUpcomingReservations(TableState state)
        {
            var now = DateTime.Now;
            return state.Reservations
                .Where(r => r.TrangThai == "Đang đặt" && r.ThoiGianBatDau > now)
                .OrderBy(r => r.ThoiGianBatDau)
                .ToList();
        }

        private void ShowActiveReservationInfo(Panel panel, TableState state, BookingDTO reservation)
        {
            var lblReservation = new Label
            {
                Text = $"Đã đặt từ:\n{reservation.ThoiGianBatDau:HH:mm} - {reservation.ThoiGianKetThuc:HH:mm}",
                AutoSize = false,
                Width = panel.Width - 20,
                Height = 30,
                ForeColor = Color.OrangeRed,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(10, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(lblReservation);

            var lblCustomer = new Label
            {
                Text = $"Khách: {reservation.HoTen}",
                AutoSize = false,
                Width = panel.Width - 20,
                Height = 20,
                ForeColor = Color.DarkBlue,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(10, 110),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(lblCustomer);

            panel.BackColor = Color.FromArgb(255, 248, 225);

            var btnStart = new Guna2Button
            {
                Text = "Bắt đầu",
                Width = 65,
                Height = 30,
                FillColor = Color.FromArgb(92, 124, 250),
                ForeColor = Color.White,
                BorderRadius = 8,
                Location = new Point(10, 135)
            };
            btnStart.Cursor = Cursors.Hand;
            btnStart.Click += (s, e) => StartFromReservation(state, reservation);

            var btnCancel = new Guna2Button
            {
                Text = "Hủy đặt",
                Width = 65,
                Height = 30,
                FillColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                BorderRadius = 8,
                Location = new Point(80, 135)
            };
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => CancelReservation(state, reservation);

            var btnDetail = new Guna2Button
            {
                Text = "Chi tiết",
                Width = 65,
                Height = 30,
                FillColor = Color.FromArgb(144, 164, 174),
                ForeColor = Color.White,
                BorderRadius = 8,
                Location = new Point(150, 135)
            };
            btnDetail.Cursor = Cursors.Hand;
            btnDetail.Click += (s, e) =>
            {
                MessageBox.Show(
                    $"Thông tin đặt bàn:\n\n" +
                    $"Bàn: {state.TableNumber}\n" +
                    $"Khách: {reservation.HoTen}\n" +
                    $"Thời gian: {reservation.ThoiGianBatDau:HH:mm dd/MM} - {reservation.ThoiGianKetThuc:HH:mm dd/MM}\n" +
                    $"Trạng thái: {reservation.TrangThai}",
                    "Chi tiết đặt bàn"
                );
            };

            panel.Controls.Add(btnStart);
            panel.Controls.Add(btnCancel);
            panel.Controls.Add(btnDetail);
        }

        private void StartFromReservation(TableState state, BookingDTO reservation)
        {
            var bookingBLL = new BookingBLL();
            var tableBLL = new TableBLL();

            bookingBLL.UpdateBookingStatus(reservation.MaDatBan, "Đang sử dụng");
            tableBLL.UpdateTableStatus(state.TableNumber, "Đang sử dụng");

            state.IsPlaying = true;
            state.StartTime = DateTime.Now; // ĐẢM BẢO LUÔN SET THỜI GIAN
            state.IsReserved = false;

            RenderTables();
            MessageBox.Show($"Đã bắt đầu sử dụng bàn {state.TableNumber}!");
        }

        private void CancelReservation(TableState state, BookingDTO reservation)
        {
            var result = MessageBox.Show(
                $"Bạn có chắc muốn hủy đặt bàn này?\n\n" +
                $"Bàn: {state.TableNumber}\n" +
                $"Khách: {reservation.HoTen}\n" +
                $"Thời gian: {reservation.ThoiGianBatDau:HH:mm} - {reservation.ThoiGianKetThuc:HH:mm}",
                "Xác nhận hủy đặt bàn",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                var bookingBLL = new BookingBLL();
                var tableBLL = new TableBLL();

                bookingBLL.CancelBooking(reservation.MaDatBan);
                tableBLL.UpdateTableStatus(state.TableNumber, "Trống");

                state.Reservations.Remove(reservation);
                state.IsReserved = false;

                RenderTables();
                MessageBox.Show("Đã hủy đặt bàn thành công!");
            }
        }

        private void ShowAvailableTable(Panel panel, TableState state)
        {
            var upcomingReservations = GetUpcomingReservations(state);
            if (upcomingReservations.Any())
            {
                var nextReservation = upcomingReservations.First();
                var lblUpcoming = new Label
                {
                    Text = $"Sắp đặt:\n{nextReservation.ThoiGianBatDau:HH:mm} - {nextReservation.ThoiGianKetThuc:HH:mm}",
                    AutoSize = false,
                    Width = panel.Width - 20,
                    Height = 30,
                    ForeColor = Color.Green,
                    Font = new Font("Segoe UI", 8, FontStyle.Italic),
                    Location = new Point(10, 80),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                panel.Controls.Add(lblUpcoming);

                var lblUpcomingCustomer = new Label
                {
                    Text = $"Khách: {nextReservation.HoTen}",
                    AutoSize = false,
                    Width = panel.Width - 20,
                    Height = 20,
                    ForeColor = Color.DarkGreen,
                    Font = new Font("Segoe UI", 8, FontStyle.Italic),
                    Location = new Point(10, 105),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                panel.Controls.Add(lblUpcomingCustomer);
            }

            var btnStart = new Guna2Button
            {
                Text = "Bắt đầu chơi",
                Width = 120,
                Height = 38,
                FillColor = Color.FromArgb(92, 124, 250),
                ForeColor = Color.White,
                BorderRadius = 15
            };
            btnStart.Click += (s, e) =>
            {
                var tableBLL = new TableBLL();
                tableBLL.UpdateTableStatus(state.TableNumber, "Đang sử dụng");
                tableBLL.UpdateStartTime(state.TableNumber, DateTime.Now);

                state.IsPlaying = true;
                state.StartTime = DateTime.Now;
                state.Items = new List<FormDichVu.ServiceItem>();
                ReplaceWithPlayingActions(panel, state);
            };

            var btnReserve = new Guna2Button
            {
                Text = "Đặt bàn",
                Width = 90,
                Height = 38,
                FillColor = Color.FromArgb(144, 164, 174),
                ForeColor = Color.White,
                BorderRadius = 15
            };
            btnReserve.Click += (s, e) => ReserveTable(state);

            panel.Controls.Add(btnStart);
            panel.Controls.Add(btnReserve);

            int buttonTop = upcomingReservations.Any() ? 130 : 90;
            ArrangeTwoButtons(panel, btnStart, btnReserve, buttonTop);
            panel.Resize += (s, e2) => ArrangeTwoButtons(panel, btnStart, btnReserve, buttonTop);
        }

        private void ReserveTable(TableState state)
        {
            using (var frm = new FormDatBan())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    var bookingDTO = new BookingDTO
                    {
                        MaBan = state.TableNumber,
                        HoTen = frm.CustomerName,
                        ThoiGianBatDau = frm.StartAt,
                        ThoiGianKetThuc = frm.EndAt,
                        TrangThai = "Đang đặt"
                    };

                    int bookingId = bookingBLL.AddBooking(bookingDTO);
                    bookingDTO.MaDatBan = bookingId;
                    state.Reservations.Add(bookingDTO);

                    RenderTables();
                    MessageBox.Show("Đặt bàn thành công!");
                }
            }
        }

        private void ReplaceWithPlayingActions(Panel panel, TableState state)
        {
            panel.Controls.Clear();
            var lbl = new Label
            {
                Text = $"Bàn {state.TableNumber}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            panel.Controls.Add(lbl);

            var lblType = new Label
            {
                Text = $"Loại: {state.TableType}",
                AutoSize = true,
                Location = new Point(10, 40)
            };
            panel.Controls.Add(lblType);

            var lblStatus = new Label
            {
                Text = GetStatusText(state),
                AutoSize = true,
                ForeColor = Color.DimGray,
                Location = new Point(10, 60)
            };
            panel.Controls.Add(lblStatus);

            if (state.StartTime.HasValue)
            {
                var playTime = DateTime.Now - state.StartTime.Value;
                var lblTime = new Label
                {
                    Text = $"Thời gian: {playTime.ToString(@"hh\:mm\:ss")}",
                    AutoSize = true,
                    ForeColor = Color.Green,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    Location = new Point(10, 80)
                };
                panel.Controls.Add(lblTime);
            }

            var btnPay = new Guna2Button
            {
                Text = "Thanh toán",
                Width = 90,
                Height = 40,
                FillColor = Color.FromArgb(67, 160, 71),
                ForeColor = Color.White,
                BorderRadius = 15
            };
            btnPay.Cursor = Cursors.Hand;
            btnPay.Click += (s, e) => ProcessPayment(state);

            var btnService = new Guna2Button
            {
                Text = "DV thêm",
                Width = 90,
                Height = 40,
                FillColor = Color.FromArgb(63, 97, 181),
                ForeColor = Color.White,
                BorderRadius = 15
            };
            btnService.Cursor = Cursors.Hand;
            btnService.Click += (s, e) =>
            {
                using (var dlg = new FormDichVu($"Bàn {state.TableNumber}", state.TableNumber))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        if (state.Items == null)
                            state.Items = new List<FormDichVu.ServiceItem>();

                        state.Items.AddRange(dlg.SelectedItems);

                        // Lưu dịch vụ vào database - method này giờ đã public
                        if (state.Items.Count > 0)
                        {
                            dlg.LuuHoaDonDichVu(dlg.SelectedItems);
                            MessageBox.Show($"Đã thêm {state.Items.Count} dịch vụ!", "Thành công");
                        }
                    }
                }
            };

            panel.Controls.Add(btnPay);
            panel.Controls.Add(btnService);
            ArrangeTwoButtons(panel, btnPay, btnService);
            panel.Resize += (s, e2) => ArrangeTwoButtons(panel, btnPay, btnService);
        }

        private string GetStatusText(TableState state)
        {
            if (state.IsPlaying) return "Trạng thái: Đang chơi";

            var activeReservation = GetCurrentActiveReservation(state);
            if (activeReservation != null) return "Trạng thái: Đang được đặt";

            var upcomingReservations = GetUpcomingReservations(state);
            if (upcomingReservations.Any()) return "Trạng thái: Trống (có đặt trước)";

            return "Trạng thái: Trống";
        }

        private void ProcessPayment(TableState state)
        {
            if (!state.StartTime.HasValue)
            {
                MessageBox.Show("Không thể tính tiền!");
                return;
            }

            var played = DateTime.Now - state.StartTime.Value;

            int maDatBan = 0;
            var activeBooking = state.Reservations
                .Where(b => b.TrangThai == "Đang sử dụng")
                .FirstOrDefault();

            if (activeBooking != null)
            {
                maDatBan = activeBooking.MaDatBan;
            }

            // 🔧 LẤY MA NHÂN VIÊN THỰC TẾ THEO TÊN
            int maNV = CurrentTaiKhoan?.MaNV ?? 1;
            string tenNhanVien = CurrentTaiKhoan?.TenDangNhap ?? CurrentUserName;

            // DEBUG
            Console.WriteLine($"✅ FormQuanlyban - Thanh toán với MaNV = {maNV}");

            using (var dlg = new FormThanhToan(
                tableName: $"Bàn {state.TableNumber}",
                tableType: state.TableType,
                hourlyRate: state.HourlyRate,
                playTime: played,
                items: state.Items,
                maDatBan: maDatBan,
                tenNhanVien: tenNhanVien,
                maNhanVien: maNV)) // 🔧 TRUYỀN MA NHÂN VIÊN THỰC TẾ
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateDatabaseAfterPayment(state, activeBooking);

                    state.IsPlaying = false;
                    state.StartTime = null;
                    state.Items.Clear();
                    Console.WriteLine($"✅ Đã xóa {state.Items.Count} dịch vụ khỏi bàn {state.TableNumber}");
                    RenderTables();
                    
                }
            }
        }

        // 🔧 THÊM PHƯƠNG THỨC LẤY MA NHÂN VIÊN THỰC TẾ
        private int LayMaNhanVienThucTe(string tenNhanVien)
        {
            try
            {
                var nhanVienBLL = new NhanVienBLL();
                return nhanVienBLL.LayMaNhanVienTheoTen(tenNhanVien);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy MaNV thực tế: {ex.Message}");
                return 1; // Fallback
            }
        }

        private void UpdateDatabaseAfterPayment(TableState state, BookingDTO activeBooking)
        {
            var tableBLL = new TableBLL();
            var bookingBLL = new BookingBLL();

            tableBLL.UpdateTableStatus(state.TableNumber, "Trống");

            if (activeBooking != null)
            {
                bookingBLL.UpdateBookingStatus(activeBooking.MaDatBan, "Đã kết thúc");
                state.Reservations.Remove(activeBooking);
            }

            state.IsReserved = false;
        }

        
        private List<FormDichVu.ServiceItem> LoadServicesFromDatabase(int maBan)
        {
            try
            {
                var hoaDonDAL = new HoaDonDAL();
                var services = new List<FormDichVu.ServiceItem>();

                // Sử dụng method mới - lấy trực tiếp dịch vụ chưa thanh toán
                var pendingServices = hoaDonDAL.GetPendingServicesByTable(maBan);
                Console.WriteLine($"🔍 LoadServicesFromDatabase - Bàn {maBan}: {pendingServices.Count} dịch vụ chưa thanh toán");
                foreach (var service in pendingServices)
                {
                    services.Add(new FormDichVu.ServiceItem
                    {
                        MaSP = service.MaSP,
                        Name = service.TenSP,
                        Price = (int)service.DonGia,
                        Quantity = service.SoLuong,
                        DonViTinh = "Cái" // Có thể lấy từ bảng DichVu_SanPham nếu cần
                    });
                }

                return services;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi load dịch vụ: {ex.Message}");
                return new List<FormDichVu.ServiceItem>();
            }
        }
    }
}