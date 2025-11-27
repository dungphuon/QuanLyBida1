using System;
using System.Data;
using QuanLyBida.DAL;

namespace QuanLyBida.BLL
{
    public class DashboardBLL
    {
        private DashboardDAL _dal = new DashboardDAL();

        public decimal LayTongDoanhThu()
        {
            return _dal.GetTotalRevenue();
        }

        public int LaySoBanDangDung()
        {
            return _dal.GetActiveTableCount();
        }

        public int LayTongNhanVien()
        {
            return _dal.GetEmployeeCount();
        }

        public int LayTongSanPham()
        {
            return _dal.GetProductCount();
        }

        public DataTable LayHoatDongGanDay()
        {
            return _dal.GetRecentActivities();
        }
    }
}