using System;

namespace QuanLyBida.DTO
{
    public class TaiKhoanDTO
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public int MaNV { get; set; }
        public string HoTenNV { get; set; }
        public string ChucVu { get; set; }
        public string Email { get; set; }
        public string TrangThai { get; set; }
    }

    public class ResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResultDTO(bool success, string message = "", object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}