using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuanLyBida.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL;

        public NhanVienBLL()
        {
            nhanVienDAL = new NhanVienDAL();
        }

        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return nhanVienDAL.LayDanhSachNhanVien();
        }

        public string ThemNhanVien(NhanVienDTO nv)
        {
            // Kiểm tra business rules
            string validationResult = KiemTraNhanVien(nv);
            if (!string.IsNullOrEmpty(validationResult))
                return validationResult;

            // Bỏ kiểm tra mã NV trùng vì database tự sinh

            // Thêm vào database
            bool result = nhanVienDAL.ThemNhanVien(nv);
            return result ? "Thành công" : "Thêm nhân viên thất bại!";
        }

        public string XoaNhanVien(int maNV)
        {
            bool result = nhanVienDAL.XoaNhanVien(maNV);
            return result ? "Thành công" : "Xóa nhân viên thất bại!";
        }

        public string CapNhatNhanVien(NhanVienDTO nv)
        {
            // Kiểm tra business rules
            string validationResult = KiemTraNhanVien(nv);
            if (!string.IsNullOrEmpty(validationResult))
                return validationResult;

            // Cập nhật database
            bool result = nhanVienDAL.CapNhatNhanVien(nv);
            return result ? "Thành công" : "Cập nhật nhân viên thất bại!";
        }

        private string KiemTraNhanVien(NhanVienDTO nv)
        {


            if (string.IsNullOrWhiteSpace(nv.HoTen))
                return "Họ tên không được để trống!";

            if (string.IsNullOrWhiteSpace(nv.ChucVu) || nv.ChucVu == "Chọn chức vụ")
                return "Vui lòng chọn chức vụ!";

            if (string.IsNullOrWhiteSpace(nv.CaLamViec) || nv.CaLamViec == "Chọn ca làm việc")
                return "Vui lòng chọn ca làm việc!";

            if (!string.IsNullOrWhiteSpace(nv.SoDienThoai) && !IsValidPhoneNumber(nv.SoDienThoai))
                return "Số điện thoại không hợp lệ!";

            if (!string.IsNullOrWhiteSpace(nv.Email) && !IsValidEmail(nv.Email))
                return "Email không hợp lệ!";

            if (nv.Luong < 0)
                return "Lương không được âm!";

            return string.Empty;
        }

        private bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^(0[3|5|7|8|9])+([0-9]{8,9})\b$");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // Thêm vào class NhanVienBLL
        public int LayMaNhanVienTiepTheo()
        {
            try
            {
                int maxMaNV = nhanVienDAL.LayMaNhanVienLonNhat();
                return maxMaNV + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}