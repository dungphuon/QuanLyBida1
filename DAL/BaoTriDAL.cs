using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBida.DTO;

namespace QuanLyBida.DAL
{
    public class BaoTriDAL
    {
        // Lấy danh sách sự cố
        public List<BaoTriDTO> GetListSuCo()
        {
            var list = new List<BaoTriDTO>();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Giả sử bảng tên là SUCO (Bạn cần tạo bảng này trong SQL nếu chưa có)
                string sql = "SELECT * FROM SuCo ORDER BY case when TrangThai = N'Chờ xử lý' then 1 when TrangThai = N'Đang xử lý' then 2 else 3 end, NgayBaoCao DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BaoTriDTO
                            {
                                MaSuCo = Convert.ToInt32(reader["MaSuCo"]),
                                Loai = reader["Loai"].ToString(),
                                TenDoiTuong = reader["TenDoiTuong"].ToString(),
                                MoTa = reader["MoTa"].ToString(),
                                TrangThai = reader["TrangThai"].ToString(),
                                NgayBaoCao = Convert.ToDateTime(reader["NgayBaoCao"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Thêm sự cố mới
        public bool ThemSuCo(BaoTriDTO suCo)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO SuCo (Loai, TenDoiTuong, MoTa, TrangThai, NgayBaoCao) 
                               VALUES (@Loai, @TenDoiTuong, @MoTa, @TrangThai, @NgayBaoCao)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Loai", suCo.Loai);
                    cmd.Parameters.AddWithValue("@TenDoiTuong", suCo.TenDoiTuong);
                    cmd.Parameters.AddWithValue("@MoTa", suCo.MoTa);
                    cmd.Parameters.AddWithValue("@TrangThai", suCo.TrangThai);
                    cmd.Parameters.AddWithValue("@NgayBaoCao", suCo.NgayBaoCao);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Cập nhật trạng thái sự cố
        public bool CapNhatTrangThai(int maSuCo, string trangThaiMoi)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE SuCo SET TrangThai = @TrangThai WHERE MaSuCo = @MaSuCo";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@MaSuCo", maSuCo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}