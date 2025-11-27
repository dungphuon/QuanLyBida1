using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBida.DTO;

namespace QuanLyBida.DAL
{
    public class PhieuThuChiDAL
    {
        public List<PhieuThuChiDTO> LayDanhSachPhieu(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            var list = new List<PhieuThuChiDTO>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();

                // 🔥 SỬA QUERY: JOIN với bảng NhanVien để lấy HoTen
                string query = @"
            SELECT p.MaPhieu, p.LoaiPhieu, p.NgayTao, p.SoTien, p.LyDo, p.PhuongThuc, p.MaNV, p.TrangThai, nv.HoTen
            FROM PHIEUTHUCHI p
            LEFT JOIN NhanVien nv ON p.MaNV = nv.MaNV
            WHERE 1=1";

                if (tuNgay.HasValue)
                    query += " AND p.NgayTao >= @TuNgay";
                if (denNgay.HasValue)
                    query += " AND p.NgayTao <= @DenNgay";

                query += " ORDER BY p.NgayTao DESC";

                using (var cmd = new SqlCommand(query, connection))
                {
                    if (tuNgay.HasValue)
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Value);
                    if (denNgay.HasValue)
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var phieu = new PhieuThuChiDTO
                            {
                                MaPhieu = Convert.ToInt32(reader["MaPhieu"]),
                                LoaiPhieu = reader["LoaiPhieu"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"]),
                                SoTien = Convert.ToDecimal(reader["SoTien"]),
                                LyDo = reader["LyDo"].ToString(),
                                PhuongThuc = reader["PhuongThuc"].ToString(),
                                TrangThai = reader["TrangThai"].ToString(),
                                MaNV = reader["MaNV"] != DBNull.Value ? (int?)reader["MaNV"] : null,

                                // 🔥 LẤY TÊN: Nếu null (không có NV) thì để là "Admin" hoặc "Hệ thống"
                                TenNhanVien = reader["HoTen"] != DBNull.Value ? reader["HoTen"].ToString() : "Admin"
                            };

                            list.Add(phieu);
                        }
                    }
                }
            }
            return list;
        }

        public bool ThemPhieu(PhieuThuChiDTO phieu)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO PHIEUTHUCHI 
                                (LoaiPhieu, NgayTao, SoTien, LyDo, PhuongThuc, MaNV, TrangThai)
                                VALUES (@LoaiPhieu, @NgayTao, @SoTien, @LyDo, @PhuongThuc, @MaNV, @TrangThai)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LoaiPhieu", phieu.LoaiPhieu);
                    cmd.Parameters.AddWithValue("@NgayTao", phieu.NgayTao);
                    cmd.Parameters.AddWithValue("@SoTien", phieu.SoTien);
                    cmd.Parameters.AddWithValue("@LyDo", phieu.LyDo);
                    cmd.Parameters.AddWithValue("@PhuongThuc", phieu.PhuongThuc);

                    if (phieu.MaNV.HasValue)
                        cmd.Parameters.AddWithValue("@MaNV", phieu.MaNV.Value);
                    else
                        cmd.Parameters.AddWithValue("@MaNV", DBNull.Value);

                    cmd.Parameters.AddWithValue("@TrangThai", phieu.TrangThai);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public (decimal TongThu, decimal TongChi) LayTongThuChi(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            decimal tongThu = 0;
            decimal tongChi = 0;

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT 
                        ISNULL(SUM(CASE WHEN LoaiPhieu = 'THU' THEN SoTien ELSE 0 END), 0) as TongThu,
                        ISNULL(SUM(CASE WHEN LoaiPhieu = 'CHI' THEN SoTien ELSE 0 END), 0) as TongChi
                    FROM PHIEUTHUCHI 
                    WHERE 1=1";

                if (tuNgay.HasValue)
                    query += " AND NgayTao >= @TuNgay";
                if (denNgay.HasValue)
                    query += " AND NgayTao <= @DenNgay";

                using (var cmd = new SqlCommand(query, connection))
                {
                    if (tuNgay.HasValue)
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay.Value);
                    if (denNgay.HasValue)
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay.Value);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tongThu = reader.GetDecimal(reader.GetOrdinal("TongThu"));
                            tongChi = reader.GetDecimal(reader.GetOrdinal("TongChi"));
                        }
                    }
                }
            }
            return (tongThu, tongChi);
        }
    }
}