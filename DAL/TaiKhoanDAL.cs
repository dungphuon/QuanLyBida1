using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace QuanLyBida.DAL
{
    public class TaiKhoanDAL
    {
        // Trong file DAL/TaiKhoanDAL.cs

        public TaiKhoanDTO GetTaiKhoanByUsername(string username)
        {
            TaiKhoanDTO taiKhoan = null;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                // 🔥 SỬA QUERY: Kết nối bảng TaiKhoan (tk) với NhanVien (nv)
                // Để lấy được cột nv.TrangThai
                string query = @"
            SELECT tk.*, nv.TrangThai 
            FROM TaiKhoan tk
            LEFT JOIN NhanVien nv ON tk.MaNV = nv.MaNV
            WHERE tk.TenDangNhap = @Username";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taiKhoan = new TaiKhoanDTO
                            {
                                MaTK = Convert.ToInt32(reader["MaTK"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                // Xử lý MaNV có thể null (ví dụ tài khoản admin gốc)
                                MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : 0,
                                HoTenNV = "User",
                                ChucVu = reader["VaiTro"].ToString(),
                                Email = reader["Email"]?.ToString(),

                                // 🔥 HỨNG DỮ LIỆU TRẠNG THÁI TỪ BẢNG NHÂN VIÊN
                                // Nếu không có liên kết nhân viên (null) thì mặc định là "Đang làm việc"
                                TrangThai = reader["TrangThai"] != DBNull.Value ? reader["TrangThai"].ToString() : "Đang làm việc"
                            };
                        }
                    }
                }
            }

            return taiKhoan;
        }

        public bool CheckUsernameExists(string username)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @Username";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool CheckEmailExists(string email)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE Email = @Email";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool CreateTaiKhoan(TaiKhoanDTO taiKhoan)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, Email, MaNV) 
                           VALUES (@TenDangNhap, @MatKhau, @VaiTro, @Email, NULL)";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                        cmd.Parameters.AddWithValue("@VaiTro", "Nhân viên");
                        cmd.Parameters.AddWithValue("@Email", taiKhoan.Email ?? "");

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo tài khoản: {ex.Message}");
            }
        }

        public bool UpdatePassword(string email, string newPassword)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE Email = @Email";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MatKhau", newPassword);
                        cmd.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật mật khẩu: {ex.Message}");
            }
        }
    }
}
    
