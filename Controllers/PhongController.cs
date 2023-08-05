using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Models;
using quanlykhachsan.Services;
using System.Net;

namespace quanlykhachsan.Controllers
{
    public class PhongController : Controller
    {
        private readonly IPhongService _phongService;
        private readonly IPhieudatphongService _phieudatphongService;
        public PhongController(IPhongService phongService, IPhieudatphongService phieudatphongService)
        {
            _phongService = phongService;
            _phieudatphongService = phieudatphongService;
        }


        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login", "Home"));
            }

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
                return Json(new { Success = true, Message = "Thêm mới loại phòng thành công" });
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
                return Json(new { Success = true, Message = "Cập nhật loại phòng thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật loại phòng không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaLoaiphong(int id)
        {
            try
            {
                var phong = _phongService.GetAllPhong().Any(x => x.MaLP == id);
                if (!phong)
                {
                    _phongService.DeleteLoaiphong(id);
                    return Json(new { Success = true, Message = "Xóa loại phòng thành công" });
                }

                return Json(new { Success = false, Message = "Không thể xóa loại phòng đã tồn tại phòng" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa loại phòng lỗi" });
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
                return Json(new { Success = true, Message = "Thêm phòng thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Thêm phòng không thành công" });
            }
        }
        [HttpPut]
        public JsonResult SuaPhong(Phong model)
        {
            try
            {
                _phongService.UpdatePhong(model);
                return Json(new { Success = true, Message = "Cập nhật phòng thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật phòng không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaPhong(int id)
        {
            try
            {
                var pdp = _phieudatphongService.GetAll().Any(x => x.MaPhong == id);
                if (!pdp)
                {
                    _phongService.DeletePhong(id);
                    return Json(new { Success = true, Message = "Xóa phòng thành công" });
                }
                return Json(new { Success = false, Message = "Không thể xóa phòng đã tồn tại phiếu đặt phòng" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa phòng lỗi" });
            }
        }

        [HttpGet]
        public JsonResult SearchPhong(CustomerSearchPhong model)
        {
            var res = _phongService.GetAllPhong();

            if (model.SucChua != null)
                res = res.Where(x => x.SucChua == model.SucChua).ToList();
            if (model.Tang != null)
                res = res.Where(x => x.Tang == model.Tang).ToList();

            return Json(new { Success = true, data = res });
        }
    }
}
