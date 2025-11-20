// SanPhamDAL.cs
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBida.DTO;

namespace QuanLyBida.DAL
{
    public class SanPhamDAL
    {


        public List<SanPhamDTO> GetAllSanPham()
        {
            var list = new List<SanPhamDTO>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT MaSP, TenSP, DonViTinh, GiaNhap, GiaBan, SoLuongTon
            FROM DichVu_SanPham 
            ORDER BY TenSP";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SanPhamDTO
                        {
                            MaSP = (int)reader["MaSP"],
                            TenSP = reader["TenSP"].ToString(),
                            DonViTinh = reader["DonViTinh"].ToString(),
                            GiaNhap = (decimal)reader["GiaNhap"],
                            GiaBan = (decimal)reader["GiaBan"],
                            SoLuongTon = (int)reader["SoLuongTon"]
                        });
                    }
                }
            }
            return list;
        }

        public bool DeleteSanPham(int maSP)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM DichVu_SanPham WHERE MaSP = @MaSP";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public bool CapNhatSoLuongTon(int maSP, int soLuongThem)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            UPDATE DichVu_SanPham 
            SET SoLuongTon = SoLuongTon + @SoLuongThem 
            WHERE MaSP = @MaSP";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuongThem", soLuongThem);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        public bool NhapHang(List<SanPhamNhapDTO> danhSachNhap)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in danhSachNhap)
                        {
                            string query = @"
                        UPDATE DichVu_SanPham 
                        SET SoLuongTon = SoLuongTon + @SoLuongThem 
                        WHERE MaSP = @MaSP";

                            using (var cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@MaSP", item.MaSP);
                                cmd.Parameters.AddWithValue("@SoLuongThem", item.SoLuongNhap);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public bool ThemSanPhamMoi(SanPhamDTO sanPham)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            INSERT INTO DichVu_SanPham (TenSP, DonViTinh, GiaNhap, GiaBan, SoLuongTon)
            VALUES (@TenSP, @DonViTinh, @GiaNhap, @GiaBan, @SoLuongTon)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
                    cmd.Parameters.AddWithValue("@DonViTinh", sanPham.DonViTinh);
                    cmd.Parameters.AddWithValue("@GiaNhap", sanPham.GiaNhap);
                    cmd.Parameters.AddWithValue("@GiaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        public bool CapNhatSanPham(SanPhamDTO sanPham)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            UPDATE DichVu_SanPham 
            SET TenSP = @TenSP, 
                GiaBan = @GiaBan, 
                SoLuongTon = @SoLuongTon
            WHERE TenSP = @TenSP";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
                    cmd.Parameters.AddWithValue("@GiaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}