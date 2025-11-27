using System;

namespace QuanLyBida.DTO
{
    public class BaoTriDTO
    {
        public int MaSuCo { get; set; }
        public string Loai { get; set; } // "Bàn" hoặc "Thiết bị"
        public string TenDoiTuong { get; set; } // Tên bàn hoặc tên thiết bị
        public string MoTa { get; set; }
        public string TrangThai { get; set; } // "Chờ xử lý", "Đang xử lý", "Đã xử lý"
        public DateTime NgayBaoCao { get; set; }
    }
}