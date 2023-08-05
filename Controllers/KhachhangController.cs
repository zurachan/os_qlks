using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{

    public class KhachhangController : Controller
    {
        private readonly IKhachhangService _khachhangService;
        private readonly IPhieudatphongService _phieudatphongService;
        public KhachhangController(IKhachhangService khachhangService, IPhieudatphongService phieudatphongService)
        {
            _khachhangService = khachhangService;
            _phieudatphongService = phieudatphongService;
        }


        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login", "Home"));
            }
            var chucVu = HttpContext.Session.GetString("ChucVu");
            if (chucVu != "Lễ tân" && chucVu != "Admin")
                return RedirectToAction("Error", "Home");
            return View();
        }

        public JsonResult GetAllKhachhang()
        {
            var res = _khachhangService.GetAll();
            return Json(new { Success = true, data = res });
        }
        [HttpGet]
        public JsonResult GetByIdKhachhang(int id)
        {
            var res = _khachhangService.GetById(id);
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuKhachhang(Khachhang model)
        {
            try
            {
                _khachhangService.Create(model);
                return Json(new { Success = true, Message = "Thêm khách hàng thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Thêm khách hàng không thành công" });
            }
        }
        [HttpPut]
        public JsonResult SuaKhachhang(Khachhang model)
        {
            try
            {
                _khachhangService.Update(model);
                return Json(new { Success = true, Message = "Cập nhật khách hàng thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật khách hàng không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaKhachhang(int id)
        {
            try
            {
                var pdp = _phieudatphongService.GetAll().Any(x => x.MaKH == id);
                if (!pdp)
                {
                    _khachhangService.Delete(id);
                    return Json(new { Success = true, Message = "Xóa khách hàng thành công" });
                }
                return Json(new { Success = false, Message = "Không thể xóa khách hàng đã đặt phòng" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa khách hàng thất bại" });
            }
        }
    }
}
