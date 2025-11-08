using System;
using System.Collections.Generic;
using QuanLyBida.DTO;
using QuanLyBida.DAL;

namespace QuanLyBida.BLL
{
    public class PhieuThuChiBLL
    {
        private PhieuThuChiDAL phieuDAL = new PhieuThuChiDAL();

        // CHỈ GIỮ LẠI 1 METHOD ThemPhieuThu
        public bool ThemPhieuThu(decimal soTien, string lyDo, string phuongThuc, int? maNV = null)
        {
            // Validation
            if (soTien <= 0)
                throw new Exception("Số tiền phải lớn hơn 0");
            if (string.IsNullOrEmpty(lyDo))
                throw new Exception("Lý do không được để trống");
            if (string.IsNullOrEmpty(phuongThuc))
                throw new Exception("Phương thức thanh toán không được để trống");

            var phieu = new PhieuThuChiDTO
            {
                LoaiPhieu = "Thu",
                NgayTao = DateTime.Now,
                SoTien = soTien,
                LyDo = lyDo,
                PhuongThuc = phuongThuc,
                MaNV = maNV,
                TrangThai = "Đã thanh toán"
            };

            return phieuDAL.ThemPhieu(phieu);
        }

        // CÁC METHOD KHÁC GIỮ NGUYÊN...
        public bool ThemPhieuChi(decimal soTien, string lyDo, string phuongThuc, int? maNV = null)
        {
            // Validation
            if (soTien <= 0)
                throw new Exception("Số tiền phải lớn hơn 0");
            if (string.IsNullOrEmpty(lyDo))
                throw new Exception("Lý do không được để trống");
            if (string.IsNullOrEmpty(phuongThuc))
                throw new Exception("Phương thức thanh toán không được để trống");

            var phieu = new PhieuThuChiDTO
            {
                LoaiPhieu = "Chi",
                NgayTao = DateTime.Now,
                SoTien = soTien,
                LyDo = lyDo,
                PhuongThuc = phuongThuc,
                MaNV = maNV,
                TrangThai = "Đã thanh toán"
            };

            return phieuDAL.ThemPhieu(phieu);
        }

        public List<PhieuThuChiDTO> LayDanhSachPhieu(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            return phieuDAL.LayDanhSachPhieu(tuNgay, denNgay);
        }

        public decimal TinhTongThu(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            var result = phieuDAL.LayTongThuChi(tuNgay, denNgay);
            return result.TongThu;
        }

        public decimal TinhTongChi(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            var result = phieuDAL.LayTongThuChi(tuNgay, denNgay);
            return result.TongChi;
        }

        public decimal TinhTonQuy(decimal quyDauKy, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            var result = phieuDAL.LayTongThuChi(tuNgay, denNgay);
            return quyDauKy + result.TongThu - result.TongChi;
        }

    }
}