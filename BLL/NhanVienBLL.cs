
using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QuanLyBida.BLL
{
    public class NhanVienBLL
    {
        public int LayMaNhanVienTheoTen(string tenNhanVien)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // 🔧 TÌM KIẾM LINH HOẠT HƠN - DÙNG LIKE
                    string sql = "SELECT MaNV FROM NhanVien WHERE HoTen LIKE @HoTen AND IsDeleted = 0";

                    using (var cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@HoTen", "%" + tenNhanVien + "%");
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int maNV = Convert.ToInt32(result);
                            Console.WriteLine($"✅ Tìm thấy MaNV: {maNV} cho tên: {tenNhanVien}");
                            return maNV;
                        }
                        else
                        {
                            Console.WriteLine($"❌ Không tìm thấy nhân viên với tên: {tenNhanVien}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy MaNV: {ex.Message}");
            }

            Console.WriteLine($"⚠️ Dùng MaNV mặc định = 1");
            return 1; // Fallback nếu không tìm thấy
        }
    }
}