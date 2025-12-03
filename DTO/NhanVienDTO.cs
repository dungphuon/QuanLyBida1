using System;

namespace QuanLyBida.DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public decimal? Luong { get; set; }
        public string CaLamViec { get; set; }
        public string TrangThai { get; set; }
    }
}