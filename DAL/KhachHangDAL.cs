using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBida.DTO;

namespace QuanLyBida.DAL
{
    public class KhachHangDAL
    {
        public List<KhachHangDTO> LayTatCaKhachHang()
        {
            var list = new List<KhachHangDTO>();

            if (!DatabaseHelper.TestConnection())
            {
                throw new Exception("Không thể kết nối đến database");
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    // CHỈ LẤY KHÁCH HÀNG CHƯA XÓA (IsDeleted = 0)
                    string query = "SELECT MaKH, HoTen, SoDienThoai, Email, HangThanhVien, DiemTichLuy FROM KhachHang WHERE IsDeleted = 0";

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var khachHang = new KhachHangDTO
                            {
                                MaKH = reader.GetInt32(reader.GetOrdinal("MaKH")),
                                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                SDT = reader.IsDBNull(reader.GetOrdinal("SoDienThoai")) ? "" : reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                                Hang = reader.IsDBNull(reader.GetOrdinal("HangThanhVien")) ? "Thường" : reader.GetString(reader.GetOrdinal("HangThanhVien")),
                                DiemTichLuy = reader.GetInt32(reader.GetOrdinal("DiemTichLuy"))
                            };
                            list.Add(khachHang);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi lấy dữ liệu khách hàng: {ex.Message}");
                }
            }
            return list;
        }

        public int ThemKhachHang(KhachHangDTO khachHang)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                // SỬA QUERY THEO ĐÚNG TÊN CỘT
                string query = @"INSERT INTO KhachHang (HoTen, SoDienThoai, Email, HangThanhVien, DiemTichLuy) 
                               VALUES (@HoTen, @SoDienThoai, @Email, @HangThanhVien, @DiemTichLuy);
                               SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                    command.Parameters.AddWithValue("@SoDienThoai", (object)khachHang.SDT ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)khachHang.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@HangThanhVien", (object)khachHang.Hang ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DiemTichLuy", 0); // Mặc định 0 điểm

                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public int CapNhatKhachHang(KhachHangDTO khachHang)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                // SỬA QUERY THEO ĐÚNG TÊN CỘT
                string query = @"UPDATE KhachHang 
                               SET HoTen = @HoTen, 
                                   SoDienThoai = @SoDienThoai, 
                                   Email = @Email, 
                                   HangThanhVien = @HangThanhVien 
                               WHERE MaKH = @MaKH";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                    command.Parameters.AddWithValue("@HoTen", khachHang.HoTen);
                    command.Parameters.AddWithValue("@SoDienThoai", (object)khachHang.SDT ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)khachHang.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@HangThanhVien", (object)khachHang.Hang ?? DBNull.Value);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int XoaKhachHang(int maKH)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                // XÓA MỀM: Đánh dấu IsDeleted = 1 thay vì xóa thật
                string query = "UPDATE KhachHang SET IsDeleted = 1 WHERE MaKH = @MaKH";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", maKH);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public KhachHangDTO TimKhachHangTheoSDT(string soDienThoai)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                // CHỈ TÌM KHÁCH HÀNG CHƯA XÓA
                string query = "SELECT MaKH, HoTen, SoDienThoai, Email, HangThanhVien, DiemTichLuy FROM KhachHang WHERE SoDienThoai = @SoDienThoai AND IsDeleted = 0";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhachHangDTO
                            {
                                MaKH = reader.GetInt32(reader.GetOrdinal("MaKH")),
                                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                SDT = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                                Hang = reader.IsDBNull(reader.GetOrdinal("HangThanhVien")) ? "Thường" : reader.GetString(reader.GetOrdinal("HangThanhVien")),
                                DiemTichLuy = reader.GetInt32(reader.GetOrdinal("DiemTichLuy"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int CapNhatDiemTichLuy(int maKH, int diemMoi)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE KhachHang SET DiemTichLuy = @DiemTichLuy WHERE MaKH = @MaKH";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", maKH);
                    command.Parameters.AddWithValue("@DiemTichLuy", diemMoi);
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Tìm khách hàng theo mã KH
        public KhachHangDTO TimKhachHangTheoMaKH(int maKH)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT MaKH, HoTen, SoDienThoai, Email, HangThanhVien, DiemTichLuy FROM KhachHang WHERE MaKH = @MaKH AND IsDeleted = 0";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", maKH);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhachHangDTO
                            {
                                MaKH = reader.GetInt32(reader.GetOrdinal("MaKH")),
                                HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                SDT = reader.GetString(reader.GetOrdinal("SoDienThoai")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                                Hang = reader.IsDBNull(reader.GetOrdinal("HangThanhVien")) ? "Thường" : reader.GetString(reader.GetOrdinal("HangThanhVien")),
                                DiemTichLuy = reader.GetInt32(reader.GetOrdinal("DiemTichLuy"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Cập nhật cả điểm và hạng
        // Trong KhachHangDAL.cs - Sửa method CapNhatDiemVaHang
        public bool CapNhatDiemVaHang(int maKH, int diemMoi, string hangMoi)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE KhachHang 
                       SET DiemTichLuy = @DiemTichLuy, 
                           HangThanhVien = @HangThanhVien 
                       WHERE MaKH = @MaKH";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", maKH);
                    command.Parameters.AddWithValue("@DiemTichLuy", diemMoi);
                    command.Parameters.AddWithValue("@HangThanhVien", hangMoi);

                    // SỬA: Trả về bool
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


    }
}