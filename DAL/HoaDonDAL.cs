using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyBida.DTO;

namespace QuanLyBida.DAL
{
    public class HoaDonDAL : DatabaseHelper
    {
        public int CreateHoaDon(HoaDonDTO hoaDon)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO HoaDon (MaBan, MaKH, MaNV, NgayLap, TongTien, GiamGia, TrangThaiThanhToan, PhuongThucThanhToan)
         VALUES (@MaBan, @MaKH, @MaNV, @NgayLap, @TongTien, @GiamGia, @TrangThaiThanhToan, @PhuongThucThanhToan);
         SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", hoaDon.MaBan);
                    cmd.Parameters.AddWithValue("@MaKH", (object)hoaDon.MaKH ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNV", (object)hoaDon.MaNV ?? DBNull.Value); // THÊM DÒNG NÀY
                    cmd.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                    cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                    cmd.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);
                    cmd.Parameters.AddWithValue("@TrangThaiThanhToan", hoaDon.TrangThaiThanhToan);
                    cmd.Parameters.AddWithValue("@PhuongThucThanhToan", hoaDon.PhuongThucThanhToan ?? (object)DBNull.Value);

                    int maHD = Convert.ToInt32(cmd.ExecuteScalar());

                    // Lưu chi tiết hóa đơn
                    SaveChiTietHoaDon(conn, maHD, hoaDon.ChiTiet);

                    return maHD;
                }
            }
        }

        private void SaveChiTietHoaDon(SqlConnection conn, int maHD, List<ChiTietHoaDonDTO> chiTiet)
        {
            foreach (var item in chiTiet)
            {
                string sql = @"INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia, ThanhTien)
                             VALUES (@MaHD, @MaSP, @SoLuong, @DonGia, @ThanhTien)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@MaSP", item.MaSP);
                    cmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", item.DonGia);
                    cmd.Parameters.AddWithValue("@ThanhTien", item.ThanhTien);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Thêm method này vào HoaDonDAL nếu chưa có
        public void CapNhatSoLuongTon(int maSP, int soLuongDaBan)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE DichVu_SanPham 
                     SET SoLuongTon = SoLuongTon - @SoLuongDaBan 
                     WHERE MaSP = @MaSP AND SoLuongTon >= @SoLuongDaBan";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuongDaBan", soLuongDaBan);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // METHOD 1: Lấy các hóa đơn chưa thanh toán theo mã bàn
        public List<HoaDonDTO> GetPendingInvoicesByTable(int maBan)
        {
            var list = new List<HoaDonDTO>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT MaHD, MaBan, NgayLap, TongTien, GiamGia, TrangThaiThanhToan 
                     FROM HoaDon 
                     WHERE MaBan = @MaBan AND TrangThaiThanhToan = N'Chưa thanh toán' 
                     ORDER BY NgayLap DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new HoaDonDTO
                            {
                                MaHD = Convert.ToInt32(reader["MaHD"]),
                                MaBan = Convert.ToInt32(reader["MaBan"]),
                                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                TrangThaiThanhToan = reader["TrangThaiThanhToan"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        // METHOD 2: Lấy chi tiết hóa đơn theo mã hóa đơn
        public List<ChiTietHoaDonDTO> GetInvoiceDetails(int maHD)
        {
            var list = new List<ChiTietHoaDonDTO>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT c.MaCTHD, c.MaSP, c.SoLuong, c.DonGia, c.ThanhTien, s.TenSP
                     FROM ChiTietHoaDon c
                     INNER JOIN DichVu_SanPham s ON c.MaSP = s.MaSP
                     WHERE c.MaHD = @MaHD";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChiTietHoaDonDTO
                            {
                                MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                                MaSP = Convert.ToInt32(reader["MaSP"]),
                                TenSP = reader["TenSP"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                DonGia = Convert.ToDecimal(reader["DonGia"]),
                                ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        // METHOD 3: Cập nhật trạng thái hóa đơn khi thanh toán
        public void UpdateInvoiceStatusByTable(int maBan, string trangThai)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE HoaDon 
                             SET TrangThaiThanhToan = @TrangThai
                             WHERE MaBan = @MaBan AND TrangThaiThanhToan = N'Chưa thanh toán'";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // METHOD 4: Lấy tất cả dịch vụ chưa thanh toán của bàn
        public List<ChiTietHoaDonDTO> GetPendingServicesByTable(int maBan)
        {
            var list = new List<ChiTietHoaDonDTO>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT c.MaCTHD, c.MaSP, c.SoLuong, c.DonGia, c.ThanhTien, s.TenSP
                     FROM ChiTietHoaDon c
                     INNER JOIN HoaDon h ON c.MaHD = h.MaHD
                     INNER JOIN DichVu_SanPham s ON c.MaSP = s.MaSP
                     WHERE h.MaBan = @MaBan AND h.TrangThaiThanhToan = N'Chưa thanh toán'";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChiTietHoaDonDTO
                            {
                                MaCTHD = Convert.ToInt32(reader["MaCTHD"]),
                                MaSP = Convert.ToInt32(reader["MaSP"]),
                                TenSP = reader["TenSP"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                DonGia = Convert.ToDecimal(reader["DonGia"]),
                                ThanhTien = Convert.ToDecimal(reader["ThanhTien"])
                            });
                        }
                    }
                }
            }
            return list;
        }
        // Lấy tất cả hóa đơn
        public List<HoaDonDTO> GetAllHoaDon()
        {
            var list = new List<HoaDonDTO>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT hd.MaHD, hd.MaBan, hd.NgayLap, hd.TongTien, hd.GiamGia, 
                              hd.TrangThaiThanhToan, hd.PhuongThucThanhToan, hd.MaKH, hd.MaNV,
                              b.TenBan, kh.HoTen AS TenKH, nv.HoTen AS TenNhanVien
                       FROM HoaDon hd
                       LEFT JOIN BanBida b ON hd.MaBan = b.MaBan
                       LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                       LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                       ORDER BY hd.NgayLap DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var hoaDon = new HoaDonDTO
                            {
                                MaHD = Convert.ToInt32(reader["MaHD"]),
                                MaBan = Convert.ToInt32(reader["MaBan"]),
                                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                TrangThaiThanhToan = reader["TrangThaiThanhToan"].ToString(),
                                PhuongThucThanhToan = reader["PhuongThucThanhToan"]?.ToString(),
                                MaKH = reader["MaKH"] != DBNull.Value ? Convert.ToInt32(reader["MaKH"]) : (int?)null,
                                MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null,
                                TenNhanVien = reader["TenNhanVien"]?.ToString() ?? "Không xác định"
                            };

                            list.Add(hoaDon);
                        }
                    }
                }
            }
            return list;
        }

        // Lấy hóa đơn theo khoảng thời gian
        public List<HoaDonDTO> GetHoaDonByTimeRange(DateTime fromDate, DateTime toDate)
        {
            var list = new List<HoaDonDTO>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT hd.MaHD, hd.MaBan, hd.NgayLap, hd.TongTien, hd.GiamGia, 
                              hd.TrangThaiThanhToan, hd.PhuongThucThanhToan,
                              b.TenBan, kh.HoTen AS TenKH
                       FROM HoaDon hd
                       LEFT JOIN BanBida b ON hd.MaBan = b.MaBan
                       LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                       WHERE hd.NgayLap BETWEEN @FromDate AND @ToDate
                       ORDER BY hd.NgayLap DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.Date.AddDays(1).AddSeconds(-1));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new HoaDonDTO
                            {
                                MaHD = Convert.ToInt32(reader["MaHD"]),
                                MaBan = Convert.ToInt32(reader["MaBan"]),
                                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                TrangThaiThanhToan = reader["TrangThaiThanhToan"].ToString(),
                                PhuongThucThanhToan = reader["PhuongThucThanhToan"]?.ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Tìm kiếm hóa đơn
        public List<HoaDonDTO> SearchHoaDon(string keyword)
        {
            var list = new List<HoaDonDTO>();

            using (var conn = GetConnection())
            {
                conn.Open();

                // Xử lý keyword để tìm theo mã hóa đơn
                string searchPattern = $"%{keyword}%";

                // Nếu người dùng nhập "HD000001" thì tìm theo mã số 1
                if (keyword.ToUpper().StartsWith("HD"))
                {
                    string numberPart = keyword.Substring(2).Trim();
                    if (int.TryParse(numberPart, out int maHD))
                    {
                        // Tìm chính xác theo mã hóa đơn
                        string sql = @"SELECT hd.MaHD, hd.MaBan, hd.NgayLap, hd.TongTien, hd.GiamGia, 
                                      hd.TrangThaiThanhToan, hd.PhuongThucThanhToan, hd.MaKH,
                                      b.TenBan, kh.HoTen AS TenKH
                               FROM HoaDon hd
                               LEFT JOIN BanBida b ON hd.MaBan = b.MaBan
                               LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                               WHERE hd.MaHD = @MaHD
                               ORDER BY hd.NgayLap DESC";

                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maHD);

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    list.Add(new HoaDonDTO
                                    {
                                        MaHD = Convert.ToInt32(reader["MaHD"]),
                                        MaBan = Convert.ToInt32(reader["MaBan"]),
                                        NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                        TongTien = Convert.ToDecimal(reader["TongTien"]),
                                        GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                        TrangThaiThanhToan = reader["TrangThaiThanhToan"].ToString(),
                                        PhuongThucThanhToan = reader["PhuongThucThanhToan"]?.ToString()
                                    });
                                }
                            }
                        }
                        return list;
                    }
                }

                // Tìm kiếm thông thường
                string sqlNormal = @"SELECT hd.MaHD, hd.MaBan, hd.NgayLap, hd.TongTien, hd.GiamGia, 
                                    hd.TrangThaiThanhToan, hd.PhuongThucThanhToan, hd.MaKH,
                                    b.TenBan, kh.HoTen AS TenKH
                             FROM HoaDon hd
                             LEFT JOIN BanBida b ON hd.MaBan = b.MaBan
                             LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                             WHERE b.TenBan LIKE @Keyword 
                                OR kh.HoTen LIKE @Keyword 
                                OR hd.PhuongThucThanhToan LIKE @Keyword
                                OR CAST(hd.MaHD AS NVARCHAR(20)) LIKE @Keyword
                             ORDER BY hd.NgayLap DESC";

                using (var cmd = new SqlCommand(sqlNormal, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", searchPattern);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new HoaDonDTO
                            {
                                MaHD = Convert.ToInt32(reader["MaHD"]),
                                MaBan = Convert.ToInt32(reader["MaBan"]),
                                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                TrangThaiThanhToan = reader["TrangThaiThanhToan"].ToString(),
                                PhuongThucThanhToan = reader["PhuongThucThanhToan"]?.ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Xóa hóa đơn
        public bool DeleteHoaDon(int maHD)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                // Xóa chi tiết hóa đơn trước
                string sqlDeleteDetails = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD";
                using (var cmdDetails = new SqlCommand(sqlDeleteDetails, conn))
                {
                    cmdDetails.Parameters.AddWithValue("@MaHD", maHD);
                    cmdDetails.ExecuteNonQuery();
                }

                // Xóa hóa đơn
                string sqlDelete = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
                using (var cmd = new SqlCommand(sqlDelete, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // Lấy hóa đơn theo mã
        public HoaDonDTO GetHoaDonByMaHD(int maHD)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT hd.MaHD, hd.MaBan, hd.NgayLap, hd.TongTien, hd.GiamGia, 
                      hd.TrangThaiThanhToan, hd.PhuongThucThanhToan, hd.MaKH, hd.MaNV,
                      b.TenBan, kh.HoTen AS TenKH, nv.HoTen AS TenNhanVien
               FROM HoaDon hd
               LEFT JOIN BanBida b ON hd.MaBan = b.MaBan
               LEFT JOIN KhachHang kh ON hd.MaKH = kh.MaKH
               LEFT JOIN NhanVien nv ON hd.MaNV = nv.MaNV
               WHERE hd.MaHD = @MaHD";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var hoaDon = new HoaDonDTO
                            {
                                MaHD = Convert.ToInt32(reader["MaHD"]),
                                MaBan = Convert.ToInt32(reader["MaBan"]),
                                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                                TongTien = Convert.ToDecimal(reader["TongTien"]),
                                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                                TrangThaiThanhToan = reader["TrangThaiThanhToan"].ToString(),
                                PhuongThucThanhToan = reader["PhuongThucThanhToan"]?.ToString(),
                                MaKH = reader["MaKH"] != DBNull.Value ? Convert.ToInt32(reader["MaKH"]) : (int?)null,
                                MaNV = reader["MaNV"] != DBNull.Value ? Convert.ToInt32(reader["MaNV"]) : (int?)null,
                                TenNhanVien = reader["TenNhanVien"]?.ToString() ?? "Không xác định"
                            };

                            return hoaDon;
                        }
                    }
                }
            }
            return null;
        }

        public bool CapNhatTrangThaiThanhToan(int maHD, string trangThai, string phuongThuc)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE HoaDon 
                     SET TrangThaiThanhToan = @TrangThai,
                         PhuongThucThanhToan = @PhuongThuc
                     WHERE MaHD = @MaHD";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@PhuongThuc", phuongThuc ?? (object)DBNull.Value);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        // Thêm vào file HoaDonDAL.cs

        public void CapNhatTrangThaiHoaDonCu(int maBan, int maHDMoi)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                // Logic: Tìm tất cả hóa đơn của bàn này đang "Chưa thanh toán" (TRỪ cái hóa đơn mới vừa tạo)
                // và set chúng thành "Đã thanh toán" để ẩn đi.
                string sql = @"UPDATE HoaDon 
                       SET TrangThaiThanhToan = N'Đã thanh toán'
                       WHERE MaBan = @MaBan 
                       AND TrangThaiThanhToan = N'Chưa thanh toán' 
                       AND MaHD != @MaHDMoi";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);
                    cmd.Parameters.AddWithValue("@MaHDMoi", maHDMoi);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}