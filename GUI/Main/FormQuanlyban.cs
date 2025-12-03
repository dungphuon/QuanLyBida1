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
            public string TableName { get; set; }
            public bool IsPlaying { get; set; }
            public bool IsReserved { get; set; }
            public string TableType { get; set; }
            public decimal HourlyRate { get; set; }
            public string TrangThai { get; set; }
            public DateTime? StartTime { get; set; }
            public List<FormDichVu.ServiceItem> Items { get; set; } = new List<FormDichVu.ServiceItem>();
            public List<BookingDTO> Reservations { get; set; } = new List<BookingDTO>();

        }

        private readonly List<TableState> tables = new List<TableState>();
        private BookingBLL bookingBLL = new BookingBLL();
        private TableBLL tableBLL = new TableBLL();
        private Timer statusTimer;
        private List<int> _daThongBaoHetGio = new List<int>();
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
            var bookingBLL = new BookingBLL();
            var now = DateTime.Now;

            foreach (var table in tables)
            {
                if (table.IsPlaying) continue;

                // ======= 1) LẤY CÁC ĐẶT BÀN HẾT GIỜ (ĐÃ LỌC NHỮNG CÁI ĐÃ BÁO) =======
                var expiredReservations = table.Reservations
                    .Where(r => r.TrangThai == "Đang đặt"
                             && now >= r.ThoiGianKetThuc
                             && !_daThongBaoHetGio.Contains(r.MaDatBan)) // <--- THÊM ĐIỀU KIỆN NÀY
                    .ToList();

                foreach (var r in expiredReservations)
                {
                    // Đánh dấu là đã báo rồi -> Timer lần sau sẽ bỏ qua
                    _daThongBaoHetGio.Add(r.MaDatBan);

                    // Không cần đổi r.TrangThai = "Đang xử lý" nữa để giao diện vẫn hiện màu vàng

                    var result = MessageBox.Show(
                        $"Bàn {table.TableNumber} đã hết thời gian đặt ({r.ThoiGianKetThuc:HH:mm}).\n\n" +
                        "Bạn muốn làm gì?\n" +
                        "- YES = Gia hạn thêm giờ\n" +
                        "- NO = Kết thúc và Thanh toán ngay",
                        "Hết giờ đặt bàn",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)  // GIA HẠN
                    {
                        string input = ShowInputBox("Nhập số phút muốn gia hạn:", "Gia hạn đặt bàn", "30");

                        if (int.TryParse(input, out int minutes) && minutes > 0)
                        {
                            bool hasNext = bookingBLL.CoDatKeTiep(table.TableNumber, r.ThoiGianKetThuc);
                            if (hasNext)
                            {
                                MessageBox.Show("Không thể gia hạn vì có khách đặt tiếp theo!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                bookingBLL.GiaHanDatBan(r.MaDatBan, minutes);
                                r.ThoiGianKetThuc = r.ThoiGianKetThuc.AddMinutes(minutes);

                                // QUAN TRỌNG: Xóa khỏi danh sách đã báo để lần sau hết giờ mới thì báo tiếp
                                _daThongBaoHetGio.Remove(r.MaDatBan);

                                MessageBox.Show($"Đã gia hạn thêm {minutes} phút.");
                            }
                        }
                    }
                    else if (result == DialogResult.No) // THANH TOÁN LUÔN
                    {
                        // Lấy giờ đặt đắp vào giờ bắt đầu để tính tiền
                        table.StartTime = r.ThoiGianBatDau;
                        table.IsPlaying = true;
                        r.TrangThai = "Đang sử dụng";

                        // Gọi thanh toán
                        ProcessPayment(table);

                        // Render lại
                        RenderTables();
                    }
                }

                // ======= 2) LOGIC CŨ GIỮ NGUYÊN =======
                if (!table.IsPlaying)
                {
                    var currentReservation = GetCurrentActiveReservation(table);
                    table.IsReserved = (currentReservation != null);
                }
            }
            // Render lại bàn nếu cần thiết (thường timer tick không cần render nếu không có thay đổi lớn)
            // Nhưng để chắc chắn trạng thái IsReserved cập nhật đúng màu sắc
            RenderTables();
        }



        private string ShowInputBox(string prompt, string title, string defaultValue = "")
        {
            Form form = new Form();
            form.Width = 350;
            form.Height = 160;
            form.Text = title;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            Label lbl = new Label() { Left = 10, Top = 10, Text = prompt, Width = 300 };
            TextBox txt = new TextBox() { Left = 10, Top = 40, Width = 300, Text = defaultValue };

            Button btnOk = new Button() { Text = "OK", Left = 70, Width = 80, Top = 80 };
            Button btnCancel = new Button() { Text = "Hủy", Left = 170, Width = 80, Top = 80 };

            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            form.Controls.Add(lbl);
            form.Controls.Add(txt);
            form.Controls.Add(btnOk);
            form.Controls.Add(btnCancel);

            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            return form.ShowDialog() == DialogResult.OK ? txt.Text : "";
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
                        TableName = tableDTO.TenBan,
                        TableType = tableDTO.LoaiBan,
                        HourlyRate = tableDTO.GiaGio,
                        IsPlaying = tableDTO.TrangThai == "Đang sử dụng",
                        IsReserved = tableDTO.TrangThai == "Đã đặt trước",
                        StartTime = tableDTO.ThoiGianBatDau,
                        TrangThai = tableDTO.TrangThai
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
                    TableType = (i % 2 == 0) ? "Lỗ" : "Carom",
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
                Margin = new Padding(20),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // KIỂM TRA TRẠNG THÁI NGƯNG HOẠT ĐỘNG (XÓA MỀM)
            
            if (state.TrangThai == "Ngưng hoạt động" || state.TrangThai == "Hỏng")
            {
                panel.BackColor = Color.FromArgb(240, 240, 240); // Màu xám nhạt
                                                                 

                // Tên bàn (Gạch ngang để thể hiện đã hủy)
                var lblNameDeleted = new Label
                {
                    Text = state.TableName,
                    Font = new Font("Segoe UI", 12, FontStyle.Strikeout | FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 10),
                    ForeColor = Color.DimGray
                };
                panel.Controls.Add(lblNameDeleted);

                // Loại bàn
                var lblTypeDeleted = new Label
                {
                    Text = $"Loại: {state.TableType}",
                    AutoSize = true,
                    Location = new Point(10, 40),
                    ForeColor = Color.DimGray
                };
                panel.Controls.Add(lblTypeDeleted);

                // Thông báo lớn ở giữa
                var lblReason = new Label
                {
                    Text = "NGƯNG HOẠT ĐỘNG",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = false,
                    Width = panel.Width - 20,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.IndianRed,
                    Location = new Point(10, 80)
                };
                panel.Controls.Add(lblReason);

                return panel; 
            }
            // KIỂM TRA TRẠNG THÁI BẢO TRÌ
            if (state.TrangThai == "Bảo trì")
            {
                panel.BackColor = Color.FromArgb(255, 245, 204); 

                // Tên bàn
                var lblNameBT = new Label
                {
                    Text = state.TableName,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 10),
                    ForeColor = Color.OrangeRed
                };
                panel.Controls.Add(lblNameBT);

                // Loại bàn
                var lblTypeBT = new Label
                {
                    Text = $"Loại: {state.TableType}",
                    AutoSize = true,
                    Location = new Point(10, 40),
                    ForeColor = Color.DarkOrange
                };
                panel.Controls.Add(lblTypeBT);

                // Label cảnh báo
                var lblWarningBT = new Label
                {
                    Text = "ĐANG BẢO TRÌ",
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = false,
                    Width = panel.Width - 20,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.OrangeRed,
                    Location = new Point(10, 80)
                };
                panel.Controls.Add(lblWarningBT);

                return panel;
            }


            //TẠO MENU CHUỘT PHẢI
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Mục 1: Xem lịch đặt
            var itemView = contextMenu.Items.Add($"📅 Xem lịch đặt bàn ({state.Reservations.Count})");
            itemView.Click += (s, e) => ShowReservationList(state); // Gọi hàm hiện danh sách

            // Mục 2: Đặt bàn nhanh (Optional)
            var itemAdd = contextMenu.Items.Add("➕ Đặt bàn mới");
            itemAdd.Click += (s, e) => ReserveTable(state);

            // Gắn menu vào Panel
            panel.ContextMenuStrip = contextMenu;


            var lbl = new Label
            {
                Text = state.TableName,
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
            var lblReservationInfo = new Label
            {
                Text = $"Đặt: {reservation.ThoiGianBatDau:HH:mm}-{reservation.ThoiGianKetThuc:HH:mm} • Khách: {reservation.HoTen}",
                AutoSize = false,
                Width = panel.Width - 20,
                Height = 30,
                ForeColor = Color.OrangeRed, 
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(10, 80),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true 
            };
            panel.Controls.Add(lblReservationInfo);

            // Đổi màu nền nhẹ
            panel.BackColor = Color.FromArgb(255, 248, 225);

            // 2. NÚT BẮT ĐẦU
            var btnStart = new Guna2Button
            {
                Text = "Bắt đầu",
                // Width và Location sẽ được hàm ArrangeTwoButtons tự tính toán cho đẹp
                Height = 35,
                FillColor = Color.FromArgb(92, 124, 250),
                ForeColor = Color.White,
                BorderRadius = 15
            };
            btnStart.Cursor = Cursors.Hand;
            btnStart.Click += (s, e) => StartFromReservation(state, reservation);

            // 3. NÚT HỦY ĐẶT
            var btnCancel = new Guna2Button
            {
                Text = "Hủy đặt",
                // Width và Location sẽ được hàm ArrangeTwoButtons tự tính toán
                Height = 35,
                FillColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                BorderRadius = 15
            };
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => CancelReservation(state, reservation);

            panel.Controls.Add(btnStart);
            panel.Controls.Add(btnCancel);

            // 4. CĂN CHỈNH VỊ TRÍ 2 NÚT
            // Dùng hàm có sẵn để 2 nút cân đối, đặt ở độ cao 115 (ngay dưới dòng chữ)
            ArrangeTwoButtons(panel, btnStart, btnCancel, 115);

            // Đảm bảo khi resize panel thì nút vẫn cân
            panel.Resize += (s, e2) => ArrangeTwoButtons(panel, btnStart, btnCancel, 115);
        }

        private void StartFromReservation(TableState state, BookingDTO reservation)
        {
            var bookingBLL = new BookingBLL();
            var tableBLL = new TableBLL();

            // Cập nhật trạng thái sang Đang sử dụng
            bookingBLL.UpdateBookingStatus(reservation.MaDatBan, "Đang sử dụng");
            tableBLL.UpdateTableStatus(state.TableNumber, "Đang sử dụng");


            tableBLL.UpdateStartTime(state.TableNumber, DateTime.Now);

            state.IsPlaying = true;
            state.StartTime = DateTime.Now; 
            state.IsReserved = false;

            RenderTables();
            MessageBox.Show($"Đã bắt đầu tính giờ cho bàn {state.TableNumber}!");
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
                var lblUpcomingInfo = new Label
                {
                    Text = $"Sắp đặt: {nextReservation.ThoiGianBatDau:HH:mm}-{nextReservation.ThoiGianKetThuc:HH:mm} • Khách: {nextReservation.HoTen}",
                    AutoSize = false,
                    Width = panel.Width - 20,
                    Height = 30,
                    ForeColor = Color.DarkGreen, 
                    Font = new Font("Segoe UI", 8, FontStyle.Italic), 
                    Location = new Point(10, 80), 
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true 
                };
                panel.Controls.Add(lblUpcomingInfo);


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

            int buttonTop = 115;
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

                    try
                    {
                        int bookingId = bookingBLL.AddBooking(bookingDTO);

                        bookingDTO.MaDatBan = bookingId;
                        state.Reservations.Add(bookingDTO);

                        RenderTables();
                        MessageBox.Show("Đặt bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi đặt bàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        private void ReplaceWithPlayingActions(Panel panel, TableState state)
        {
            panel.Controls.Clear();
            var lbl = new Label
            {
                Text = state.TableName,
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

            ArrangeTwoButtons(panel, btnPay, btnService, 115);

            panel.Resize += (s, e2) => ArrangeTwoButtons(panel, btnPay, btnService, 115);
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

            int maNV = CurrentTaiKhoan?.MaNV ?? 1;
            string tenNhanVien = CurrentTaiKhoan?.TenDangNhap ?? CurrentUserName;

            

            using (var dlg = new FormThanhToan(
                tableName: $"Bàn {state.TableNumber}",
                tableType: state.TableType,
                hourlyRate: state.HourlyRate,
                playTime: played,
                items: state.Items,
                maDatBan: maDatBan,
                tenNhanVien: tenNhanVien,
                maNhanVien: maNV)) 
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateDatabaseAfterPayment(state, activeBooking);

                    state.IsPlaying = false;
                    state.StartTime = null;
                    state.Items.Clear();
                    RenderTables();
                    
                }
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

        private void ShowReservationList(TableState state)
        {
            // Tạo Form tạm để chứa lưới
            Form listForm = new Form();
            listForm.Text = $"Lịch đặt - Bàn số {state.TableNumber}";
            listForm.Size = new Size(600, 400);
            listForm.StartPosition = FormStartPosition.CenterParent;
            listForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            listForm.MaximizeBox = false;

            // Tạo lưới hiển thị
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.RowHeadersVisible = false;

            // Đổ dữ liệu vào (chỉ lấy cột cần thiết)
            // Sắp xếp theo giờ tăng dần để dễ nhìn
            var dataShow = state.Reservations
                .OrderBy(r => r.ThoiGianBatDau)
                .Select(r => new
                {
                    KhachHang = r.HoTen,
                    BatDau = r.ThoiGianBatDau.ToString("HH:mm dd/MM"),
                    KetThuc = r.ThoiGianKetThuc.ToString("HH:mm dd/MM"),
                    TrangThai = r.TrangThai
                }).ToList();

            grid.DataSource = dataShow;

            listForm.Controls.Add(grid);
            listForm.ShowDialog();
        }
    }
}