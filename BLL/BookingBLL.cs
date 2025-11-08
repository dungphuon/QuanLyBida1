using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBida.BLL
{
    public class BookingBLL
    {
        private BookingDAL bookingDAL = new BookingDAL();
        private TableDAL tableDAL = new TableDAL();

        public List<BookingDTO> GetAllBookings()
        {
            return bookingDAL.GetAllBookings();
        }

        public int AddBooking(BookingDTO booking)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(booking.HoTen))
                throw new Exception("Tên khách hàng không được để trống");

            if (booking.ThoiGianKetThuc <= booking.ThoiGianBatDau)
                throw new Exception("Giờ kết thúc phải sau giờ bắt đầu");

            // Thêm booking
            return bookingDAL.AddBooking(booking);
        }

        public bool StartUsingTable(int maDatBan)
        {
            return bookingDAL.UpdateBookingStatus(maDatBan, "Đang sử dụng");
        }

        public bool CancelBooking(int maDatBan)
        {
            return bookingDAL.DeleteBooking(maDatBan);
        }

        public bool CompleteBooking(int maDatBan)
        {
            return bookingDAL.UpdateBookingStatus(maDatBan, "Đã kết thúc");
        }

        public BookingDTO GetActiveBookingByTable(int maBan)
        {
            var bookings = bookingDAL.GetAllBookings();
            return bookings
                .Where(b => b.MaBan == maBan && b.TrangThai == "Đang sử dụng")
                .FirstOrDefault();
        }

        public bool UpdateBookingStatus(int maDatBan, string trangThai)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(trangThai))
                    throw new Exception("Trạng thái không được để trống");

                // Cập nhật trạng thái booking
                bool result = bookingDAL.UpdateBookingStatus(maDatBan, trangThai);

                // Nếu là trạng thái "Đã kết thúc", cập nhật trạng thái bàn về "Trống"
                if (result && trangThai == "Đã kết thúc")
                {
                    // Lấy thông tin booking để biết MaBan
                    var booking = GetAllBookings().Find(b => b.MaDatBan == maDatBan);
                    if (booking != null)
                    {
                        tableDAL.UpdateTableStatus(booking.MaBan, "Trống");
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái booking: {ex.Message}");
            }
        }
    }
}