using System;
using System.Collections.Generic;

namespace QuanLyBida.DTO
{
    public class InvoiceDTO
    {
        public int MaHoaDon { get; set; }
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public TimeSpan ThoiGianChoi { get; set; }
        public decimal TienBan { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public DateTime NgayTao { get; set; }
        public List<InvoiceDetailDTO> ChiTietDichVu { get; set; } = new List<InvoiceDetailDTO>();
    }

    public class InvoiceDetailDTO
    {
        public string TenDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}