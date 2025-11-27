using System;
using System.Collections.Generic;
using System.Data;
using QuanLyBida.DAL;

namespace QuanLyBida.BLL
{
    public class HomeBLL
    {
        private HomeDAL _dal = new HomeDAL();

        // Lấy thống kê Card Doanh Thu (Hôm nay & % so với hôm qua)
        public (decimal TodayRevenue, double GrowthPercent) GetRevenueStats()
        {
            decimal today = _dal.GetRevenueByDate(DateTime.Now);
            decimal yesterday = _dal.GetRevenueByDate(DateTime.Now.AddDays(-1));

            double percent = 0;
            if (yesterday > 0)
                percent = (double)((today - yesterday) / yesterday) * 100;
            else if (today > 0)
                percent = 100; // Nếu hôm qua 0 đồng, hôm nay có tiền là tăng 100%

            return (today, percent);
        }

        // Lấy thống kê Card Bàn (Đang dùng / Tổng số)
        public (int Active, int Total) GetTableStats()
        {
            var statusCounts = _dal.GetTableStatusCounts();
            int active = statusCounts.ContainsKey("Đang sử dụng") ? statusCounts["Đang sử dụng"] : 0;
            int total = 0;
            foreach (var item in statusCounts) total += item.Value;

            return (active, total);
        }

        // Lấy thống kê Card Đặt Bàn
        public (int TodayCount, int YesterdayCount) GetBookingStats()
        {
            int today = _dal.GetBookingCountByDate(DateTime.Now);
            int yesterday = _dal.GetBookingCountByDate(DateTime.Now.AddDays(-1));
            return (today, yesterday);
        }

        // Lấy tổng khách hàng
        public int GetTotalCustomers()
        {
            return _dal.GetTotalCustomers();
        }

        // Dữ liệu biểu đồ Doanh thu 7 ngày
        public DataTable GetChartRevenueData()
        {
            return _dal.GetRevenueLast7Days();
        }

        // Dữ liệu biểu đồ Tròn (Tỷ lệ bàn)
        public Dictionary<string, int> GetChartTableData()
        {
            return _dal.GetTableStatusCounts();
        }

        // Dữ liệu GridView
        public DataTable GetTodayBookings()
        {
            return _dal.GetTodayBookingsList();
        }
    }
}