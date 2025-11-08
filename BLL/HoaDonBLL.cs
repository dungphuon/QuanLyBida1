using QuanLyBida.DTO;
using QuanLyBida.DAL;
using System;
using System.Collections.Generic;

namespace QuanLyBida.BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL _hoaDonDAL = new HoaDonDAL();
        private PhieuThuChiBLL _phieuThuChiBLL = new PhieuThuChiBLL();
        // Lấy tất cả hóa đơn
        public List<HoaDonDTO> GetAllHoaDon()
        {
            return _hoaDonDAL.GetAllHoaDon();
        }

        // Lấy hóa đơn theo khoảng thời gian
        public List<HoaDonDTO> GetHoaDonByTimeRange(DateTime fromDate, DateTime toDate)
        {
            return _hoaDonDAL.GetHoaDonByTimeRange(fromDate, toDate);
        }

        // Lấy hóa đơn theo mã
        public HoaDonDTO GetHoaDonByMaHD(int maHD)
        {
            return _hoaDonDAL.GetHoaDonByMaHD(maHD);
        }

        // Lấy chi tiết hóa đơn
        public List<ChiTietHoaDonDTO> GetInvoiceDetails(int maHD)
        {
            return _hoaDonDAL.GetInvoiceDetails(maHD);
        }

        // Tìm kiếm hóa đơn
        public List<HoaDonDTO> SearchHoaDon(string keyword)
        {
            return _hoaDonDAL.SearchHoaDon(keyword);
        }

        // Xóa hóa đơn
        public bool DeleteHoaDon(int maHD)
        {
            return _hoaDonDAL.DeleteHoaDon(maHD);
        }
        public bool ThanhToanHoaDon(int maHD, string phuongThuc, int? maNV = null)
        {
            try
            {
                // 1. Lấy thông tin hóa đơn
                var hoaDon = _hoaDonDAL.GetHoaDonByMaHD(maHD);
                if (hoaDon == null)
                    throw new Exception($"Không tìm thấy hóa đơn #{maHD}");

                // 2. Kiểm tra xem đã thanh toán chưa
                if (hoaDon.TrangThaiThanhToan == "Đã thanh toán")
                    throw new Exception($"Hóa đơn #{maHD} đã được thanh toán");

                // 3. Cập nhật trạng thái hóa đơn
                bool capNhatThanhCong = CapNhatTrangThaiThanhToan(maHD, "Đã thanh toán", phuongThuc);
                if (!capNhatThanhCong)
                    throw new Exception("Không thể cập nhật trạng thái hóa đơn");

                // 4. TỰ ĐỘNG TẠO PHIẾU THU
                string lyDo = $"Thu tiền hóa đơn #{maHD} - Bàn {hoaDon.MaBan}";

                // Tạo phiếu thu
                bool taoPhieuThuThanhCong = _phieuThuChiBLL.ThemPhieuThu(
                    hoaDon.TongTien,
                    lyDo,
                    phuongThuc,  // "Tiền mặt", "Chuyển khoản", "Ví điện tử", "Thẻ ATM"
                    maNV ?? hoaDon.MaNV
                );

                if (!taoPhieuThuThanhCong)
                {
                    // Rollback nếu tạo phiếu thu thất bại
                    CapNhatTrangThaiThanhToan(maHD, "Chưa thanh toán", "");
                    throw new Exception("Không thể tạo phiếu thu");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thanh toán hóa đơn: {ex.Message}");
            }
        }

        // PHƯƠNG THỨC CẬP NHẬT TRẠNG THÁI
        public bool CapNhatTrangThaiThanhToan(int maHD, string trangThai, string phuongThuc)
        {
            // Gọi phương thức từ DAL
            return _hoaDonDAL.CapNhatTrangThaiThanhToan(maHD, trangThai, phuongThuc);
        }
    }
}