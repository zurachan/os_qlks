using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Master;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    public class PhongController : Controller
    {
        private readonly IPhongService _phongService;
        public PhongController(IPhongService phongService)
        {
            _phongService = phongService;

        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.CanAdd = true;
            var ChucVu = HttpContext.Session.GetString("ChucVu");
            if (ChucVu == "Lễ tân")
                ViewBag.CanAdd = false;
            return View();
        }

        //Loại phòng
        public JsonResult GetAllLoaiphong()
        {
            var res = _phongService.GetAllLoaiphong();
            return Json(new { Success = true, data = res });
        }
        [HttpGet]
        public JsonResult GetByIdLoaiphong(int id)
        {
            var res = _phongService.GetByIdLoaiphong(id);
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuLoaiphong(Loaiphong model)
        {
            try
            {
                _phongService.CreateLoaiphong(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpPut]
        public JsonResult SuaLoaiphong(Loaiphong model)
        {
            try
            {
                _phongService.UpdateLoaiphong(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpDelete]
        public bool XoaLoaiphong(int id)
        {
            try
            {
                _phongService.DeleteLoaiphong(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Phòng
        [HttpGet]
        public JsonResult GetAllPhong()
        {
            var res = _phongService.GetAllPhong();
            return Json(new { Success = true, data = res });
        }

        [HttpGet]
        public JsonResult GetByIdPhong(int id)
        {
            var res = _phongService.GetByIdPhong(id);
            return Json(new { Success = true, data = res });
        }

        [HttpPost]
        public JsonResult LuuPhong(Phong model)
        {
            try
            {
                _phongService.CreatePhong(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }

        [HttpPut]
        public JsonResult SuaPhong(Phong model)
        {
            try
            {
                _phongService.UpdatePhong(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }

        [HttpDelete]
        public bool XoaPhong(int id)
        {
            try
            {
                _phongService.DeletePhong(id);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
