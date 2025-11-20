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
                // 1. Lấy thông tin hóa đơn để kiểm tra và lấy Mã Bàn
                var hoaDon = _hoaDonDAL.GetHoaDonByMaHD(maHD);
                if (hoaDon == null)
                    throw new Exception($"Không tìm thấy hóa đơn #{maHD}");

                // 2. Kiểm tra xem hóa đơn này đã thanh toán trước đó chưa
                if (hoaDon.TrangThaiThanhToan == "Đã thanh toán")
                    throw new Exception($"Hóa đơn #{maHD} đã được thanh toán rồi.");

                // 3. Cập nhật trạng thái hóa đơn CHÍNH thành "Đã thanh toán"
                bool capNhatThanhCong = CapNhatTrangThaiThanhToan(maHD, "Đã thanh toán", phuongThuc);

                if (!capNhatThanhCong)
                    throw new Exception("Lỗi hệ thống: Không thể cập nhật trạng thái hóa đơn.");

                // ---------------------------------------------------------
                // 4. [QUAN TRỌNG] DỌN DẸP HÓA ĐƠN CŨ
                // Gọi hàm DAL để set tất cả hóa đơn "treo" của bàn này thành "Đã thanh toán"
                // Điều này giúp bàn trở về trạng thái sạch sẽ, không còn hiển thị dịch vụ cũ.
                _hoaDonDAL.CapNhatTrangThaiHoaDonCu(hoaDon.MaBan, maHD);
                // ---------------------------------------------------------

                // 5. TỰ ĐỘNG TẠO PHIẾU THU
                // Tạo nội dung lý do thu
                string lyDo = $"Thu tiền hóa đơn #{maHD} - Bàn {hoaDon.MaBan} ({DateTime.Now:HH:mm dd/MM})";

                // Gọi BLL Phiếu Thu để tạo phiếu
                bool taoPhieuThuThanhCong = _phieuThuChiBLL.ThemPhieuThu(
                    hoaDon.TongTien,      // Số tiền
                    lyDo,                 // Lý do
                    phuongThuc,           // Tiền mặt/Chuyển khoản...
                    maNV ?? hoaDon.MaNV   // Mã nhân viên thực hiện
                );

                // Kiểm tra nếu tạo phiếu thu thất bại thì báo lỗi (hoặc rollback nếu cần)
                if (!taoPhieuThuThanhCong)
                {
                    // Tùy chọn: Nếu muốn chắc chắn, có thể rollback trạng thái hóa đơn lại
                    // CapNhatTrangThaiThanhToan(maHD, "Chưa thanh toán", "");

                    // Ở đây mình throw lỗi để thông báo cho nhân viên biết
                    throw new Exception("Thanh toán thành công nhưng KHÔNG THỂ tạo phiếu thu tự động. Vui lòng kiểm tra lại sổ quỹ.");
                }

                return true; // Tất cả thành công
            }
            catch (Exception ex)
            {
                // Ném lỗi ra ngoài để Form hiển thị MessageBox
                throw new Exception($"Lỗi xử lý thanh toán: {ex.Message}");
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