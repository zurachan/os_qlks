using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    [Authorize]
    public class PhieudatphongController : Controller
    {
        private readonly IPhieudatphongService _phieudatphongService;
        private readonly IHoadonService _hoadonService;
        public PhieudatphongController(IPhieudatphongService phieudatphongService, IHoadonService hoadonService)
        {
            _phieudatphongService = phieudatphongService;
            _hoadonService = hoadonService;
        }

        [HttpGet]
        public JsonResult GetAllPhieudatphong()
        {
            var res = _phieudatphongService.GetAll();
            return Json(new { Success = true, data = res });
        }

        [HttpGet]
        public JsonResult GetByIdPhieudatphong(int id)
        {
            var res = _phieudatphongService.GetById(id);
            return Json(new { Success = true, data = res });
        }

        [HttpPost]
        public JsonResult LuuPhieudatphong(Phieudatphong model)
        {
            try
            {
                var nhanvienId = HttpContext.Session.GetInt32("MaNhanVien");

                var pdp = _phieudatphongService.Create(model);
                var hoaDon = new Hoadon
                {
                    MaPDP = pdp.Id,
                    MaNV = nhanvienId.Value,
                    NgayThanhToan = pdp.NgayNhanPhong,
                    SoTienThanhToan = pdp.TongTien,
                };
                _hoadonService.Create(hoaDon);

                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }

        [HttpPut]
        public JsonResult SuaPhieudatphong(Phieudatphong model)
        {
            try
            {
                var pdp = _phieudatphongService.Update(model);
                var hoadon = _hoadonService.GetAll().FirstOrDefault(x => x.MaPDP == pdp.Id);
                hoadon.NgayThanhToan = pdp.NgayNhanPhong;
                hoadon.SoTienThanhToan = pdp.TongTien;
                _hoadonService.Update(hoadon);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }

        [HttpDelete]
        public bool XoaPhieudatphong(int id)
        {
            try
            {
                _phieudatphongService.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
