using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyBida.BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL khachHangDAL = new KhachHangDAL();

        public List<KhachHangDTO> LayTatCaKhachHang()
        {
            return khachHangDAL.LayTatCaKhachHang();
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            return khachHangDAL.ThemKhachHang(khachHang) > 0;
        }

        public bool CapNhatKhachHang(KhachHangDTO khachHang)
        {
            return khachHangDAL.CapNhatKhachHang(khachHang) > 0;
        }

        public bool XoaKhachHang(int maKH)
        {
            return khachHangDAL.XoaKhachHang(maKH) > 0;
        }

        public KhachHangDTO TimKhachHangTheoSDT(string soDienThoai)
        {
            if (string.IsNullOrWhiteSpace(soDienThoai))
                return null;

            return khachHangDAL.TimKhachHangTheoSDT(soDienThoai.Trim());
        }

        public bool CapNhatDiemTichLuy(int maKH, int diemMoi)
        {
            return khachHangDAL.CapNhatDiemTichLuy(maKH, diemMoi) > 0;
        }
        public int TinhDiemTichLuy(decimal tongTien)
        {
            // QUY TẮC MỚI: 1,000đ = 1 điểm
            return (int)(tongTien / 1000);
        }
        // Method tự động thăng hạng dựa trên điểm
        public string TuDongThangHang(int diemHienTai, string hangHienTai)
        {
            // Nếu chưa có hạng, mặc định là Thường
            if (string.IsNullOrEmpty(hangHienTai))
                hangHienTai = "Thường";

            // Logic thăng hạng
            if (hangHienTai == "Thường" && diemHienTai >= 6000)
                return "Kim Cương";
            else if (hangHienTai == "Thường" && diemHienTai >= 4000)
                return "Vàng";
            else if (hangHienTai == "Thường" && diemHienTai >= 2000)
                return "Bạc";
            else if (hangHienTai == "Bạc" && diemHienTai >= 6000)
                return "Kim Cương";
            else if (hangHienTai == "Bạc" && diemHienTai >= 4000)
                return "Vàng";
            else if (hangHienTai == "Vàng" && diemHienTai >= 6000)
                return "Kim Cương";
            else
                return hangHienTai; // Giữ nguyên hạng nếu chưa đạt
        }

        // Method cập nhật điểm và tự động thăng hạng
        public bool CapNhatDiemVaThangHang(int maKH, int diemMoi)
        {
            try
            {
                // Lấy thông tin khách hàng hiện tại
                var khachHang = khachHangDAL.TimKhachHangTheoMaKH(maKH);
                if (khachHang == null) return false;

                // Tự động thăng hạng dựa trên điểm mới
                string hangMoi = TuDongThangHang(diemMoi, khachHang.Hang);

                // Cập nhật cả điểm và hạng - SỬA: Gọi trực tiếp
                return khachHangDAL.CapNhatDiemVaHang(maKH, diemMoi, hangMoi);
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Thêm vào KhachHangBLL.cs
        public KhachHangDTO TimKhachHangTheoMaKH(int maKH)
        {
            return khachHangDAL.TimKhachHangTheoMaKH(maKH);
        }
    }
}