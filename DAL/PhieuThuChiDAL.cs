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
                string query = @"
                    SELECT MaPhieu, LoaiPhieu, NgayTao, SoTien, LyDo, PhuongThuc, MaNV, TrangThai
                    FROM PHIEUTHUCHI 
                    WHERE 1=1";

                if (tuNgay.HasValue)
                    query += " AND NgayTao >= @TuNgay";
                if (denNgay.HasValue)
                    query += " AND NgayTao <= @DenNgay";

                query += " ORDER BY NgayTao DESC";

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
                                MaPhieu = reader.GetInt32(reader.GetOrdinal("MaPhieu")),
                                LoaiPhieu = reader.GetString(reader.GetOrdinal("LoaiPhieu")),
                                NgayTao = reader.GetDateTime(reader.GetOrdinal("NgayTao")),
                                SoTien = reader.GetDecimal(reader.GetOrdinal("SoTien")),
                                LyDo = reader.GetString(reader.GetOrdinal("LyDo")),
                                PhuongThuc = reader.GetString(reader.GetOrdinal("PhuongThuc")),
                                TrangThai = reader.GetString(reader.GetOrdinal("TrangThai"))
                            };

                            int maNVOrdinal = reader.GetOrdinal("MaNV");
                            if (!reader.IsDBNull(maNVOrdinal))
                                phieu.MaNV = reader.GetInt32(maNVOrdinal);

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