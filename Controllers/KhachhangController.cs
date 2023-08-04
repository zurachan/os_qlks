using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{

    public class KhachhangController : Controller
    {
        private readonly IKhachhangService _khachhangService;
        public KhachhangController(IKhachhangService khachhangService)
        {
            _khachhangService = khachhangService;
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
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpPut]
        public JsonResult SuaKhachhang(Khachhang model)
        {
            try
            {
                _khachhangService.Update(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpDelete]
        public bool XoaKhachhang(int id)
        {
            try
            {
                _khachhangService.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
