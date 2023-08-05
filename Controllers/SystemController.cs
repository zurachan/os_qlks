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
        private readonly INhanvienService _nhanvienService;
        public SystemController(IChucvuService chucvuService, IQuyenService quyenService, ITaikhoanService taikhoanService, INhanvienService nhanvienService)
        {
            _chucvuService = chucvuService;
            _quyenService = quyenService;
            _taikhoanService = taikhoanService;
            _nhanvienService = nhanvienService;
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
                return Json(new { Success = true, Message = "Thêm quyền thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Thêm quyền không thành công" });
            }
        }
        [HttpPut]
        public JsonResult SuaQuyen(Quyen model)
        {
            try
            {
                _quyenService.Update(model);
                return Json(new { Success = true, Message = "Cập nhật quyền thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật quyền không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaQuyen(int id)
        {
            try
            {
                var quyen = _taikhoanService.GetAll().Any(x => x.MaQuyen == id);
                if (!quyen)
                {
                    _quyenService.Delete(id);
                    return Json(new { Success = true, Message = "Xóa quyền thành công" });
                }
                return Json(new { Success = false, Message = "Không thể xóa quyền đã tồn tại tài khoản" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa quyền thất bại" });
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
                return Json(new { Success = true, Message = "Thêm chức vụ thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Thêm chức vụ không thành công" });
            }
        }
        [HttpPut]
        public JsonResult SuaChucVu(Chucvu model)
        {
            try
            {
                _chucvuService.Update(model);
                return Json(new { Success = true, Message = "Cập nhật chức vụ thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật chức vụ không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaChucVu(int id)
        {
            try
            {
                var nv = _nhanvienService.GetAll().Any(x => x.MaCV == id);
                if (!nv)
                {
                    _chucvuService.Delete(id);

                    return Json(new { Success = true, Message = "Xóa chức vụ thành công" });
                }
                return Json(new { Success = false, Message = "Không thể xóa chức vụ đã tồn tại nhân viên" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa chức vụ thất bại" });
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
                var duplicate = _taikhoanService.GetAll().Any(x => x.TenDangNhap == model.TenDangNhap);
                if (duplicate)
                {
                    return Json(new { Success = false, Message = "Tên đăng nhập bị trùng" });
                }

                _taikhoanService.Create(model);
                return Json(new { Success = true, Message = "Thêm tài khoản thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Thêm tài khoản không thành công" });
            }
        }
        [HttpPut]
        public JsonResult SuaTaiKhoan(Taikhoan model)
        {
            try
            {
                var duplicate = _taikhoanService.GetAll().Any(x => x.TenDangNhap == model.TenDangNhap && x.Id != model.Id);
                if (duplicate)
                {
                    return Json(new { Success = false, Message = "Tên đăng nhập bị trùng" });
                }
                _taikhoanService.Update(model);
                return Json(new { Success = true, Message = "Cập nhật tài khoản thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Cập nhật tài khoản không thành công" });
            }
        }
        [HttpDelete]
        public JsonResult XoaTaiKhoan(int id)
        {
            try
            {
                _taikhoanService.Delete(id);
                return Json(new { Success = true, Message = "Xóa tài khoản thành công" });
            }
            catch
            {
                return Json(new { Success = false, Message = "Xóa tài khoản không thành công" });
            }
        }
    }
}
