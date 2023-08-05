using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{

    public class DichvuController : Controller
    {
        private readonly IDichvuService _dichvuService;
        public DichvuController(IDichvuService dichvuService)
        {
            _dichvuService = dichvuService;
        }

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login", "Home"));
            }

            ViewBag.CanAddDichVu = false;
            ViewBag.CanAddLich = false;
            var ChucVu = HttpContext.Session.GetString("ChucVu");
            switch (ChucVu)
            {
                case "Admin":
                    ViewBag.CanAddDichVu = true;
                    ViewBag.CanAddLich = true;
                    break;
                case "Nhân sự":
                    ViewBag.CanAddLich = true;
                    break;
                default:
                    break;
            }
            return View();
        }
        //Dich vu
        [HttpGet]
        public JsonResult GetAllDichvu()
        {
            var res = _dichvuService.GetAllDichvu();
            return Json(new { Success = true, data = res });
        }
        [HttpGet]
        public JsonResult GetByIdDichvu(int id)
        {
            var res = _dichvuService.GetByIdDichvu(id);
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuDichvu(Dichvu model)
        {
            try
            {
                _dichvuService.CreateDichvu(model);
                return Json(new { Success = true, Message = "Thêm dịch vụ thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Thêm dịch vụ không thành công" });
            }
        }
        [HttpPut]
        public JsonResult SuaDichvu(Dichvu model)
        {
            try
            {
                _dichvuService.UpdateDichvu(model);
                return Json(new { Success = true, Message = "Cập nhật dịch vụ thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật dịch vụ không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaDichvu(int id)
        {
            try
            {
                var lich = _dichvuService.GetAllLichdichvu().Any(x => x.MaDV == id);
                if (!lich)
                {
                    _dichvuService.DeleteDichvu(id);
                    return Json(new { Success = true, Message = "Xóa dịch vụ thành công" });
                }
                return Json(new { Success = false, Message = "Không thể dịch vụ đã được lên lịch" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa dịch vụ thất bại" });
            }
        }

        //Lich dich vu
        [HttpGet]
        public JsonResult GetAllLichdichvu()
        {
            var res = _dichvuService.GetAllLichdichvu();
            return Json(new { Success = true, data = res });
        }
        [HttpGet]
        public JsonResult GetByIdLichdichvu(int id)
        {
            var res = _dichvuService.GetByIdLichdichvu(id);
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuLichdichvu(Lichdichvu model)
        {
            try
            {
                _dichvuService.CreateLichdichvu(model);
                return Json(new { Success = true, Message = "Thêm lịch dịch vụ thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Thêm lịch dịch vụ không thành công" });
            }
        }
        [HttpPut]
        public JsonResult SuaLichdichvu(Lichdichvu model)
        {
            try
            {
                _dichvuService.UpdateLichdichvu(model);
                return Json(new { Success = true, Message = "Cập nhật lịch dịch vụ thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật lịch dịch vụ không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaLichdichvu(int id)
        {
            try
            {
                _dichvuService.DeleteLichdichvu(id);
                return Json(new { Success = true, Message = "Xóa lịch dịch vụ thành công" });
            }
            catch
            {
                return Json(new { Success = true, Message = "Xóa lịch dịch vụ không thành công" });
            }
        }

        //Dat dich vu
        [HttpGet]
        public JsonResult GetAllDatdichvu()
        {
            var res = _dichvuService.GetAllDatdichvu();
            return Json(new { Success = true, data = res });
        }
        [HttpGet]
        public JsonResult GetByIdDatdichvu(int id)
        {
            var res = _dichvuService.GetByIdDatdichvu(id);
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuDatdichvu(Datdichvu model)
        {
            try
            {
                _dichvuService.CreateDatdichvu(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpPut]
        public JsonResult SuaDatdichvu(Datdichvu model)
        {
            try
            {
                _dichvuService.UpdateDatdichvu(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpDelete]
        public bool XoaDatdichvu(int id)
        {
            try
            {
                _dichvuService.DeleteDatdichvu(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
