using System;

namespace QuanLyBida.DTO
{
    public class BookingDTO
    {
        public int MaDatBan { get; set; }
        public int MaKH { get; set; }
        public int MaBan { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string TrangThai { get; set; }
        public int ThoiGianGiaHan { get; set; }
        public string TrangThaiGiaHan { get; set; }
        public string HoTen { get; set; }
    }
}