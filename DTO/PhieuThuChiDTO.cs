using System;

namespace QuanLyBida.DTO
{
    public class PhieuThuChiDTO
    {
        public int MaPhieu { get; set; }
        public string LoaiPhieu { get; set; } // "THU" hoặc "CHI"
        public DateTime NgayTao { get; set; }
        public decimal SoTien { get; set; }
        public string LyDo { get; set; }
        public string PhuongThuc { get; set; }
        public int? MaNV { get; set; }
        public string TenNhanVien { get; set; }
        public string TrangThai { get; set; }

        // Property để hiển thị loại giao dịch
        public string LoaiGiaoDichDisplay
        {
            get
            {
                // Kiểm tra giá trị thực tế trong database
                if (LoaiPhieu == "THU" || LoaiPhieu == "Thu")
                    return "Phiếu Thu";
                else if (LoaiPhieu == "CHI" || LoaiPhieu == "Chi")
                    return "Phiếu Chi";
                else
                    return "Không xác định";
            }
        }
    }
}