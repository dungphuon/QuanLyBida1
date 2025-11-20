using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyBida.DTO
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaNhap { get; set; }
        public string DonViTinh { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string LoaiHangHoa { get; set; }
    }

    public class SanPhamNhapDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien => GiaNhap * SoLuongNhap;
    }
}
