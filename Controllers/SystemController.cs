using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Master;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    public class SystemController : Controller
    {
        private readonly IChucvuService _chucvuService;
        private readonly IQuyenService _quyenService;
        private readonly ITaikhoanService _taikhoanService;
        public SystemController(IChucvuService chucvuService, IQuyenService quyenService, ITaikhoanService taikhoanService)
        {
            _chucvuService = chucvuService;
            _quyenService = quyenService;
            _taikhoanService = taikhoanService;
        }

        //Quyen
        public IActionResult Quyen()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login", "Home"));
            }
            var chucVu = HttpContext.Session.GetString("ChucVu");
            if (!string.IsNullOrEmpty(chucVu) && chucVu != "Admin")
                return RedirectToAction("Error", "Home");
            return View();
        }
        [HttpGet]
        public JsonResult GetAllQuyen()
        {
            var res = _quyenService.GetAll();
            return Json(new { Success = true, data = res });
        }
        [HttpGet]
        public JsonResult GetByIdQuyen(int id)
        {
            var res = _quyenService.GetById(id);
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuQuyen(Quyen model)
        {
            try
            {
                _quyenService.Create(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpPut]
        public JsonResult SuaQuyen(Quyen model)
        {
            try
            {
                _quyenService.Update(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpDelete]
        public bool XoaQuyen(int id)
        {
            try
            {
                _quyenService.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Chuc vu
        public IActionResult Chucvu()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login", "Home"));
            }
            var chucVu = HttpContext.Session.GetString("ChucVu");
            if (!string.IsNullOrEmpty(chucVu) && chucVu != "Admin")
                return RedirectToAction("Error", "Home");
            return View();
        }
        [HttpGet]
        public JsonResult GetAllChucVu()
        {
            var res = _chucvuService.GetAll();
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuChucVu(Chucvu model)
        {
            try
            {
                _chucvuService.Create(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpPut]
        public JsonResult SuaChucVu(Chucvu model)
        {
            try
            {
                _chucvuService.Update(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpDelete]
        public bool XoaChucVu(int id)
        {
            try
            {
                _chucvuService.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Tai khoan
        public IActionResult Taikhoan()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login", "Home"));
            }
            var chucVu = HttpContext.Session.GetString("ChucVu");
            if (!string.IsNullOrEmpty(chucVu) && chucVu != "Admin")
                return RedirectToAction("Error", "Home");
            return View();
        }
        public JsonResult GetAllTaiKhoan()
        {
            var res = _taikhoanService.GetAll();
            return Json(new { Success = true, data = res });
        }
        [HttpGet]
        public JsonResult GetByIdTaiKhoan(int id)
        {
            var res = _taikhoanService.GetById(id);
            return Json(new { Success = true, data = res });
        }
        [HttpPost]
        public JsonResult LuuTaiKhoan(Taikhoan model)
        {
            try
            {
                _taikhoanService.Create(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpPut]
        public JsonResult SuaTaiKhoan(Taikhoan model)
        {
            try
            {
                var duplicate = _taikhoanService.GetAll().Any(x => x.TenDangNhap == model.TenDangNhap);
                if (duplicate)
                {
                    return Json(new { Success = false, Message = "Tên đăng nhập bị trùng" });
                }
                _taikhoanService.Update(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpDelete]
        public bool XoaTaiKhoan(int id)
        {
            try
            {
                _taikhoanService.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
