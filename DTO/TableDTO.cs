using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBida.DTO
{
    public class TableDTO
    {
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string LoaiBan { get; set; }
        public string TrangThai { get; set; }
        public decimal GiaGio { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }  // Thời gian bắt đầu thực tế
        public DateTime? ThoiGianKetThuc { get; set; } // Thời gian kết thúc thực tế
    }
}
