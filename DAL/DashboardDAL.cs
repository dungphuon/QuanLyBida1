using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBida.DAL
{
    public class DashboardDAL
    {
        // 1. Lấy Tổng Doanh Thu (Tổng phiếu thu)
        public decimal GetTotalRevenue()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Chỉ tính phiếu Thu
                string sql = "SELECT ISNULL(SUM(SoTien), 0) FROM PHIEUTHUCHI WHERE LoaiPhieu = 'Thu' OR LoaiPhieu = 'THU'";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        // 2. Đếm số bàn đang sử dụng
        public int GetActiveTableCount()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM BanBida WHERE TrangThai = N'Đang sử dụng'";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // 3. Đếm tổng nhân viên đang làm việc
        public int GetEmployeeCount()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Giả sử bảng NhanVien có cột TrangThai, nếu không có thì bỏ điều kiện WHERE
                string sql = "SELECT COUNT(*) FROM NhanVien WHERE TrangThai = N'Đang làm việc' OR TrangThai IS NULL";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // 4. Đếm tổng sản phẩm/dịch vụ
        public int GetProductCount()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM DichVu_SanPham";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // 5. Lấy danh sách hoạt động gần đây (Lấy từ bảng PhieuThuChi và SuCo để làm giả lập hoạt động)
        public DataTable GetRecentActivities(int limit = 10)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                // Query này kết hợp phiếu thu chi và sự cố để tạo danh sách hoạt động
                string sql = $@"
                    SELECT TOP {limit} * FROM 
                    (
                        SELECT NgayTao, 
                               CASE WHEN LoaiPhieu = 'Thu' THEN N'Thu tiền: ' + LyDo 
                                    ELSE N'Chi tiền: ' + LyDo END as HoatDong,
                               nv.HoTen as NguoiThucHien
                        FROM PHIEUTHUCHI p
                        LEFT JOIN NhanVien nv ON p.MaNV = nv.MaNV

                        UNION ALL

                        SELECT NgayBaoCao as NgayTao,
                               N'Báo cáo sự cố: ' + TenDoiTuong + ' - ' + MoTa as HoatDong,
                               N'Admin' as NguoiThucHien
                        FROM SuCo
                    ) AS Combined
                    ORDER BY NgayTao DESC";

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