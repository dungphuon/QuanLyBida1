// SanPhamDAL.cs
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            SELECT MaSP, TenSP, DonViTinh, GiaNhap, GiaBan, SoLuongTon, LoaiHangHoa
            FROM DichVu_SanPham 
            WHERE IsDeleted = 0
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
                            GiaNhap = reader["GiaNhap"] == DBNull.Value ? 0 : (decimal)reader["GiaNhap"],
                            GiaBan = (decimal)reader["GiaBan"],
                            SoLuongTon = reader["SoLuongTon"] == DBNull.Value ? 0 : (int)reader["SoLuongTon"],
                            LoaiHangHoa = reader["LoaiHangHoa"]?.ToString()
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
                string query = @"
                    UPDATE DichVu_SanPham
                    SET IsDeleted = 1
                    WHERE MaSP = @MaSP";
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
            INSERT INTO DichVu_SanPham (TenSP, DonViTinh, GiaNhap, GiaBan, SoLuongTon, LoaiHangHoa)
            VALUES (@TenSP, @DonViTinh, @GiaNhap, @GiaBan, @SoLuongTon, @LoaiHangHoa)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
                    cmd.Parameters.AddWithValue("@DonViTinh", sanPham.DonViTinh);
                    cmd.Parameters.AddWithValue("@GiaNhap", sanPham.GiaNhap);
                    cmd.Parameters.AddWithValue("@GiaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);
                    cmd.Parameters.AddWithValue("@LoaiHangHoa", sanPham.LoaiHangHoa ?? (object)System.DBNull.Value); // Thêm trường mới

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
                SoLuongTon = @SoLuongTon,
                LoaiHangHoa = @LoaiHangHoa
            WHERE TenSP = @TenSP";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSP", sanPham.TenSP);
                    cmd.Parameters.AddWithValue("@GiaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", sanPham.SoLuongTon);
                    cmd.Parameters.AddWithValue("@LoaiHangHoa", sanPham.LoaiHangHoa ?? (object)System.DBNull.Value);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}