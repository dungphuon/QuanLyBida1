using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBida.BLL
{
    public class SanPhamBLL
    {
        private SanPhamDAL _sanPhamDAL = new SanPhamDAL();

        public List<SanPhamDTO> GetDanhSachSanPham()
        {
            return _sanPhamDAL.GetAllSanPham();
        }

        public List<SanPhamDTO> TimKiemSanPham(string keyword)
        {
            var allProducts = _sanPhamDAL.GetAllSanPham();

            if (string.IsNullOrEmpty(keyword))
                return allProducts;

            keyword = keyword.ToLower();
            return allProducts.FindAll(p =>
                p.TenSP.ToLower().Contains(keyword) ||
                p.DonViTinh.ToLower().Contains(keyword) ||
                p.GiaBan.ToString().Contains(keyword)
            );
        }

        public bool XoaSanPham(int maSP)
        {
            try
            {
                return _sanPhamDAL.DeleteSanPham(maSP);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa sản phẩm: {ex.Message}");
            }
        }
        public bool CapNhatSoLuongTon(int maSP, int soLuongThem)
        {
            return _sanPhamDAL.CapNhatSoLuongTon(maSP, soLuongThem);
        }

        public bool NhapHang(List<SanPhamNhapDTO> danhSachNhap)
        {
            return _sanPhamDAL.NhapHang(danhSachNhap);
        }

        public SanPhamDTO GetSanPhamByID(int maSP)
        {
            var allProducts = _sanPhamDAL.GetAllSanPham();
            return allProducts.FirstOrDefault(sp => sp.MaSP == maSP);
        }
        public bool ThemSanPhamMoi(SanPhamDTO sanPham)
        {
            try
            {
                return _sanPhamDAL.ThemSanPhamMoi(sanPham);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm sản phẩm: {ex.Message}");
            }
        }
        public bool CapNhatSanPham(SanPhamDTO sanPham)
        {
            try
            {
                return _sanPhamDAL.CapNhatSanPham(sanPham);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật sản phẩm: {ex.Message}");
            }
        }

        public SanPhamDTO GetSanPhamByTen(string tenSP)
        {
            var allProducts = _sanPhamDAL.GetAllSanPham();
            return allProducts.FirstOrDefault(sp => sp.TenSP == tenSP);
        }
    }
}