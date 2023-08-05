using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Models;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    [Authorize]
    public class PhieudatphongController : Controller
    {
        private readonly IPhieudatphongService _phieudatphongService;
        private readonly IHoadonService _hoadonService;
        private readonly IDichvuService _dichvuService;
        private readonly IPhongService _phongService;
        public PhieudatphongController(IPhieudatphongService phieudatphongService, IHoadonService hoadonService, IDichvuService dichvuService, IPhongService phongService)
        {
            _phieudatphongService = phieudatphongService;
            _hoadonService = hoadonService;
            _dichvuService = dichvuService;
            _phongService = phongService;
        }

        [HttpGet]
        public JsonResult GetAllPhieudatphong()
        {
            var phieu = _phieudatphongService.GetAll();
            return Json(new { Success = true, data = phieu });
        }

        [HttpGet]
        public JsonResult GetByIdPhieudatphong(int id)
        {
            var phieu = _phieudatphongService.GetById(id);
            var datdichvu = _dichvuService.GetAllDatdichvu().FirstOrDefault(x => x.MaPDP == phieu.Id);

            var phieuViewModel = new PhieudatphongViewModel
            {
                Id = phieu.Id,
                MaKH = phieu.MaKH,
                MaPhong = phieu.MaPhong,
                NgayNhanPhong = phieu.NgayNhanPhong,
                NgayTraPhong = phieu.NgayTraPhong,
                TongTien = phieu.TongTien,
                IdDatDichVu = datdichvu.Id,
                MaDV = datdichvu.MaDV,
                SoLuong = datdichvu.SoLuongDV,
            };

            return Json(new { Success = true, data = phieuViewModel });
        }

        [HttpPost]
        public JsonResult LuuPhieudatphong(PhieudatphongViewModel model)
        {
            try
            {
                var nhanvienId = HttpContext.Session.GetInt32("MaNhanVien");

                var entity = new Phieudatphong
                {
                    MaKH = model.MaKH,
                    MaPhong = model.MaPhong,
                    NgayNhanPhong = model.NgayNhanPhong,
                    NgayTraPhong = model.NgayTraPhong,
                    TongTien = 0
                };

                var giaPhong = _phongService.GetByIdPhong(model.MaPhong).GiaPhong;
                var soNgay = model.NgayTraPhong - model.NgayNhanPhong;
                var dichVu = _dichvuService.GetByIdDichvu(model.MaDV);
                if (dichVu != null)
                    entity.TongTien = (soNgay.Days * giaPhong) + (model.SoLuong * dichVu.GiaDV);
                var phieuDatPhong = _phieudatphongService.Create(entity);

                var datdichvu = new Datdichvu
                {
                    MaPDP = phieuDatPhong.Id,
                    MaDV = model.MaDV,
                    SoLuongDV = model.SoLuong,
                };
                _dichvuService.CreateDatdichvu(datdichvu);

                var hoaDon = new Hoadon
                {
                    MaPDP = phieuDatPhong.Id,
                    MaNV = nhanvienId.Value,
                    NgayThanhToan = phieuDatPhong.NgayNhanPhong,
                    SoTienThanhToan = phieuDatPhong.TongTien,
                };
                _hoadonService.Create(hoaDon);

                return Json(new { Success = true, Message = "Đặt phòng thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Đặt phòng không thành công" });
            }
        }

        [HttpPut]
        public JsonResult SuaPhieudatphong(PhieudatphongViewModel model)
        {
            try
            {
                var Datdichvu = _dichvuService.GetByIdDatdichvu(model.IdDatDichVu);
                Datdichvu.MaDV = model.MaDV;
                Datdichvu.SoLuongDV = model.SoLuong;
                _dichvuService.UpdateDatdichvu(Datdichvu);

                var phieuDatPhong = _phieudatphongService.GetById(model.Id);
                phieuDatPhong.MaKH = model.MaKH;
                phieuDatPhong.MaPhong = model.MaPhong;
                phieuDatPhong.NgayNhanPhong = model.NgayNhanPhong;
                phieuDatPhong.NgayTraPhong = model.NgayTraPhong;

                var giaPhong = _phongService.GetByIdPhong(model.MaPhong).GiaPhong;
                var soNgay = model.NgayTraPhong - model.NgayNhanPhong;
                var dichVu = _dichvuService.GetByIdDichvu(model.MaDV);
                if (dichVu != null)
                    phieuDatPhong.TongTien = (soNgay.Days * giaPhong) + (model.SoLuong * dichVu.GiaDV);


                var result = _phieudatphongService.Update(phieuDatPhong);

                var hoadon = _hoadonService.GetAll().FirstOrDefault(x => x.MaPDP == result.Id);
                hoadon.NgayThanhToan = result.NgayNhanPhong;
                hoadon.SoTienThanhToan = result.TongTien;
                _hoadonService.Update(hoadon);

                return Json(new { Success = true, Message = "Cập nhật thông tin đặt phòng thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật thông tin đặt phòng không thành công" });
            }
        }

        [HttpDelete]
        public JsonResult XoaPhieudatphong(int id)
        {
            try
            {
                var datdichvu = _dichvuService.GetAllDatdichvu().FirstOrDefault(x => x.MaPDP == id);
                if (datdichvu != null)
                {
                    _dichvuService.DeleteDatdichvu(datdichvu.Id);
                }

                _phieudatphongService.Delete(id);
                return Json(new { Success = true, Message = "Xóa phiếu đặt phòng thành công" });

            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa phiếu đặt phòng thất bại" });
            }
        }
    }
}
