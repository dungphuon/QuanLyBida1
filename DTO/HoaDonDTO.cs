using System;
using System.Collections.Generic;

namespace QuanLyBida.DTO
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public int MaBan { get; set; }
        public DateTime NgayLap { get; set; }
        public int? MaKH { get; set; }
        public int? MaNV { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public string TrangThaiThanhToan { get; set; } 
        public string PhuongThucThanhToan { get; set; }
        public string TenNhanVien { get; set; }
        public List<ChiTietHoaDonDTO> ChiTiet { get; set; } = new List<ChiTietHoaDonDTO>();
    }

    public class ChiTietHoaDonDTO
    {
        public int MaCTHD { get; set; }
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}