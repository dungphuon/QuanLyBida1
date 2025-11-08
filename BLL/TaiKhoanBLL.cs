using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;

namespace QuanLyBida.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL _taiKhoanDAL;

        public TaiKhoanBLL()
        {
            _taiKhoanDAL = new TaiKhoanDAL();
        }

        public ResultDTO Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return new ResultDTO(false, "Vui lòng nhập đầy đủ thông tin");

                var taiKhoan = _taiKhoanDAL.GetTaiKhoanByUsername(username);

                if (taiKhoan == null)
                    return new ResultDTO(false, "Tài khoản không tồn tại");

                if (taiKhoan.MatKhau != password)
                    return new ResultDTO(false, "Mật khẩu không chính xác");

                return new ResultDTO(true, "Đăng nhập thành công", taiKhoan);
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, $"Lỗi hệ thống: {ex.Message}");
            }
        }

        public ResultDTO Register(TaiKhoanDTO taiKhoan)
        {
            try
            {
                if (string.IsNullOrEmpty(taiKhoan.TenDangNhap) || string.IsNullOrEmpty(taiKhoan.MatKhau))
                    return new ResultDTO(false, "Vui lòng nhập tên đăng nhập và mật khẩu");

                if (taiKhoan.MatKhau.Length < 6)
                    return new ResultDTO(false, "Mật khẩu phải có ít nhất 6 ký tự");

                if (_taiKhoanDAL.CheckUsernameExists(taiKhoan.TenDangNhap))
                    return new ResultDTO(false, "Tên đăng nhập đã tồn tại");

                bool result = _taiKhoanDAL.CreateTaiKhoan(taiKhoan);

                return result ?
                    new ResultDTO(true, "Đăng ký thành công") :
                    new ResultDTO(false, "Đăng ký thất bại");
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, $"Lỗi hệ thống: {ex.Message}");
            }
        }

        // THÊM CÁC METHOD BỊ THIẾU
        public ResultDTO CheckEmailExists(string email)
        {
            try
            {
                bool exists = _taiKhoanDAL.CheckEmailExists(email);
                return exists ?
                    new ResultDTO(true, "Email tồn tại") :
                    new ResultDTO(false, "Email không tồn tại");
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, $"Lỗi hệ thống: {ex.Message}");
            }
        }

        public ResultDTO ChangePassword(string email, string newPassword)
        {
            try
            {
                

                if (string.IsNullOrEmpty(newPassword))
                    return new ResultDTO(false, "Mật khẩu không được để trống");

                if (newPassword.Length < 6)
                    return new ResultDTO(false, "Mật khẩu phải có ít nhất 6 ký tự");

                // Kiểm tra email có tồn tại không
                bool emailExists = _taiKhoanDAL.CheckEmailExists(email);
                

                if (!emailExists)
                    return new ResultDTO(false, "Email không tồn tại trong hệ thống");

                // Cập nhật mật khẩu
                bool result = _taiKhoanDAL.UpdatePassword(email, newPassword);
                

                return result ?
                    new ResultDTO(true, "Đổi mật khẩu thành công") :
                    new ResultDTO(false, "Đổi mật khẩu thất bại");
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, $"Lỗi ChangePassword: {ex.Message}");
            }
        }

        // THÊM METHOD CHO QUÊN MẬT KHẨU (nếu cần)
        public ResultDTO ForgotPassword(string email)
        {
            try
            {
                bool emailExists = _taiKhoanDAL.CheckEmailExists(email);

                if (!emailExists)
                    return new ResultDTO(false, "Email không tồn tại trong hệ thống");

                // TODO: Gửi email reset mật khẩu hoặc tạo mã OTP
                return new ResultDTO(true, "Vui lòng kiểm tra email để reset mật khẩu");
            }
            catch (Exception ex)
            {
                return new ResultDTO(false, $"Lỗi hệ thống: {ex.Message}");
            }
        }
    }
}