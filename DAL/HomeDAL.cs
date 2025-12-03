using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBida.DAL
{
    public class HomeDAL
    {
        // 1. Lấy doanh thu theo ngày cụ thể (để tính hôm nay và hôm qua)
        public decimal GetRevenueByDate(DateTime date)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT ISNULL(SUM(SoTien), 0) 
                               FROM PHIEUTHUCHI 
                               WHERE (LoaiPhieu = 'Thu' OR LoaiPhieu = 'THU') 
                               AND CAST(NgayTao AS DATE) = @Date";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Date", date.Date);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        // 2. Đếm số lượng theo trạng thái bàn (cho biểu đồ tròn và Card)
        public Dictionary<string, int> GetTableStatusCounts()
        {
            var data = new Dictionary<string, int>();
            // Khởi tạo mặc định
            data["Trống"] = 0;
            data["Đang sử dụng"] = 0;
            data["Bảo trì"] = 0;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT TrangThai, COUNT(*) FROM BanBida GROUP BY TrangThai";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader.GetString(0);
                            int count = reader.GetInt32(1);
                            if (data.ContainsKey(status))
                                data[status] = count;
                            else
                                data[status] = count; // Trường hợp tên khác
                        }
                    }
                }
            }
            return data;
        }

        // 3. Đếm số lượt đặt bàn trong ngày
        public int GetBookingCountByDate(DateTime date)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM DatBan WHERE CAST(ThoiGianBatDau AS DATE) = @Date";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Date", date.Date);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // 4. Đếm tổng khách hàng
        public int GetTotalCustomers()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM KhachHang";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // 5. Lấy doanh thu 7 ngày gần nhất (Cho biểu đồ miền)
        public DataTable GetRevenueLast7Days()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT CAST(NgayTao AS DATE) as Ngay, ISNULL(SUM(SoTien), 0) as DoanhThu
                    FROM PHIEUTHUCHI
                    WHERE (LoaiPhieu = 'Thu' OR LoaiPhieu = 'THU') 
                    AND NgayTao >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
                    GROUP BY CAST(NgayTao AS DATE)
                    ORDER BY CAST(NgayTao AS DATE)";

                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // 6. Lấy danh sách đặt bàn chi tiết cho hôm nay (Cho GridView)
        public DataTable GetTodayBookingsList()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        db.MaDatBan,
                        CASE 
                        WHEN db.TenKhachDat IS NOT NULL AND db.TenKhachDat <> '' THEN db.TenKhachDat 
                        ELSE kh.HoTen 
                    END AS KhachHang,
                        b.TenBan AS SoBan,
                        db.ThoiGianBatDau,
                        db.ThoiGianKetThuc,
                        db.TrangThai
                    FROM DatBan db
                    LEFT JOIN KhachHang kh ON db.MaKH = kh.MaKH
                    LEFT JOIN BanBida b ON db.MaBan = b.MaBan
                    WHERE CAST(db.ThoiGianBatDau AS DATE) = CAST(GETDATE() AS DATE)
                    ORDER BY db.ThoiGianBatDau ASC";

                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}