using System;
using System.Collections.Generic;
using QuanLyBida.DAL;
using QuanLyBida.DTO;

namespace QuanLyBida.BLL
{
    public class BaoTriBLL
    {
        private BaoTriDAL _dal = new BaoTriDAL();

        public List<BaoTriDTO> LayDanhSachSuCo()
        {
            return _dal.GetListSuCo();
        }

        public bool ThemSuCoMoi(string loai, string tenDoiTuong, string moTa, string trangThai)
        {
            var suCo = new BaoTriDTO
            {
                Loai = loai,
                TenDoiTuong = tenDoiTuong,
                MoTa = moTa,
                TrangThai = trangThai,
                NgayBaoCao = DateTime.Now
            };
            return _dal.ThemSuCo(suCo);
        }

        public bool ChuyenTrangThaiTiepTheo(int maSuCo, string trangThaiHienTai)
        {
            string trangThaiMoi = "";

            // Logic chuyển trạng thái: Chờ xử lý -> Đang xử lý -> Đã xử lý
            if (trangThaiHienTai == "Chờ xử lý") trangThaiMoi = "Đang xử lý";
            else if (trangThaiHienTai == "Đang xử lý") trangThaiMoi = "Đã xử lý";
            else return false; // Đã xử lý rồi thì không đổi nữa

            return _dal.CapNhatTrangThai(maSuCo, trangThaiMoi);
        }
        public string LayTrangThaiHienTai(int maSuCo)
        {
            return _dal.LayTrangThaiHienTai(maSuCo);
        }

    }
}