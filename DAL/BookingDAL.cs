using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyBida.DTO;

namespace QuanLyBida.DAL
{
    public class BookingDAL : DatabaseHelper
    {
        public List<BookingDTO> GetAllBookings()
        {
            var list = new List<BookingDTO>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT db.*, kh.HoTen 
                             FROM DatBan db 
                             INNER JOIN KhachHang kh ON db.MaKH = kh.MaKH";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BookingDTO
                            {
                                MaDatBan = Convert.ToInt32(reader["MaDatBan"]),
                                MaKH = Convert.ToInt32(reader["MaKH"]),
                                MaBan = Convert.ToInt32(reader["MaBan"]),
                                ThoiGianBatDau = Convert.ToDateTime(reader["ThoiGianBatDau"]),
                                ThoiGianKetThuc = Convert.ToDateTime(reader["ThoiGianKetThuc"]),
                                TrangThai = reader["TrangThai"].ToString(),
                                HoTen = reader["HoTen"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public int AddBooking(BookingDTO booking)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                // Tìm hoặc tạo khách hàng
                int maKH = GetOrCreateCustomer(booking.HoTen, conn);

                // Thêm đặt bàn
                string sql = @"INSERT INTO DatBan (MaKH, MaBan, ThoiGianBatDau, ThoiGianKetThuc, TrangThai) 
                             VALUES (@MaKH, @MaBan, @ThoiGianBatDau, @ThoiGianKetThuc, @TrangThai);
                             SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.Parameters.AddWithValue("@MaBan", booking.MaBan);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", booking.ThoiGianBatDau);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", booking.ThoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@TrangThai", booking.TrangThai);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        private int GetOrCreateCustomer(string hoTen, SqlConnection conn)
        {

            string findSql = "SELECT MaKH FROM KhachHang WHERE HoTen = @HoTen";
            using (var findCmd = new SqlCommand(findSql, conn))
            {
                findCmd.Parameters.AddWithValue("@HoTen", hoTen);
                var result = findCmd.ExecuteScalar();
                if (result != null) return Convert.ToInt32(result);
            }

            return 28;
        }

        public bool UpdateBookingStatus(int maDatBan, string trangThai)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "UPDATE DatBan SET TrangThai = @TrangThai WHERE MaDatBan = @MaDatBan";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@MaDatBan", maDatBan);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteBooking(int maDatBan)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM DatBan WHERE MaDatBan = @MaDatBan";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatBan", maDatBan);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CoDatKeTiep(int maBan, DateTime gioKetThucHienTai)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT COUNT(*)
            FROM DatBan
            WHERE MaBan = @MaBan
              AND ThoiGianBatDau >= @EndTime
              AND TrangThai = N'Đang đặt'";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    cmd.Parameters.AddWithValue("@EndTime", gioKetThucHienTai);

                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
        public bool GiaHanDatBan(int maDatBan, int soPhut)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
            UPDATE DatBan
            SET ThoiGianKetThuc = DATEADD(MINUTE, @p, ThoiGianKetThuc)
            WHERE MaDatBan = @id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@p", soPhut);
                    cmd.Parameters.AddWithValue("@id", maDatBan);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool HuyDatBan(int maDatBan)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE DatBan SET TrangThai = N'Đã hủy' WHERE MaDatBan = @id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", maDatBan);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}