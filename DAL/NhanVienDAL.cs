using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBida.DTO;

namespace QuanLyBida.DAL
{
    public class NhanVienDAL
    {
        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            List<NhanVienDTO> danhSach = new List<NhanVienDTO>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = @"SELECT MaNV, HoTen, GioiTinh, NgaySinh, ChucVu, 
                                SoDienThoai, Email, DiaChi, Luong, CaLamViec, LichSuLamViec, TrangThai 
                                FROM NhanVien";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVienDTO nv = new NhanVienDTO
                    {
                        MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                        HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                        GioiTinh = reader.IsDBNull(reader.GetOrdinal("GioiTinh")) ? "" : reader.GetString(reader.GetOrdinal("GioiTinh")),
                        NgaySinh = reader.IsDBNull(reader.GetOrdinal("NgaySinh")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("NgaySinh")),
                        ChucVu = reader.GetString(reader.GetOrdinal("ChucVu")),
                        SoDienThoai = reader.IsDBNull(reader.GetOrdinal("SoDienThoai")) ? "" : reader.GetString(reader.GetOrdinal("SoDienThoai")),
                        Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                        DiaChi = reader.IsDBNull(reader.GetOrdinal("DiaChi")) ? "" : reader.GetString(reader.GetOrdinal("DiaChi")),
                        Luong = reader.IsDBNull(reader.GetOrdinal("Luong")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("Luong")),
                        CaLamViec = reader.GetString(reader.GetOrdinal("CaLamViec")),
                        LichSuLamViec = reader.IsDBNull(reader.GetOrdinal("LichSuLamViec")) ? "" : reader.GetString(reader.GetOrdinal("LichSuLamViec")),
                        TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "Đang làm việc" : reader.GetString(reader.GetOrdinal("TrangThai"))
                    };
                    danhSach.Add(nv);
                }
            }
            return danhSach;
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                // Bỏ cột MaNV khỏi INSERT vì nó tự động tăng
                string query = @"INSERT INTO NhanVien (HoTen, GioiTinh, NgaySinh, ChucVu, 
                        SoDienThoai, Email, DiaChi, Luong, CaLamViec, LichSuLamViec, TrangThai) 
                        VALUES (@HoTen, @GioiTinh, @NgaySinh, @ChucVu, 
                        @SoDienThoai, @Email, @DiaChi, @Luong, @CaLamViec, @LichSuLamViec, @TrangThai)";

                SqlCommand command = new SqlCommand(query, connection);

                // Bỏ parameter @MaNV
                command.Parameters.AddWithValue("@HoTen", nv.HoTen);
                command.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                command.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", nv.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DiaChi", nv.DiaChi ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Luong", nv.Luong ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CaLamViec", nv.CaLamViec);
                command.Parameters.AddWithValue("@LichSuLamViec", nv.LichSuLamViec ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TrangThai", nv.TrangThai ?? "Đang làm việc");

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool XoaNhanVien(int maNV)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool KiemTraMaNVTonTai(int maNV)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE NhanVien SET 
                                HoTen = @HoTen,
                                GioiTinh = @GioiTinh,
                                NgaySinh = @NgaySinh,
                                ChucVu = @ChucVu,
                                SoDienThoai = @SoDienThoai,
                                Email = @Email,
                                DiaChi = @DiaChi,
                                Luong = @Luong,
                                CaLamViec = @CaLamViec,
                                LichSuLamViec = @LichSuLamViec,
                                TrangThai = @TrangThai
                                WHERE MaNV = @MaNV";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MaNV", nv.MaNV);
                command.Parameters.AddWithValue("@HoTen", nv.HoTen);
                command.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                command.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", nv.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DiaChi", nv.DiaChi ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Luong", nv.Luong ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CaLamViec", nv.CaLamViec);
                command.Parameters.AddWithValue("@LichSuLamViec", nv.LichSuLamViec ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TrangThai", nv.TrangThai ?? "Đang làm việc");

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
        // Thêm vào class NhanVienDAL
        public int LayMaNhanVienLonNhat()
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT ISNULL(MAX(MaNV), 0) FROM NhanVien";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                int maxMaNV = (int)command.ExecuteScalar();
                return maxMaNV;
            }
        }
    }
}