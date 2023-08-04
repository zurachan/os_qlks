using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Master;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    public class NhanvienController : Controller
    {
        private readonly INhanvienService _nhanvienService;
        private readonly ITaikhoanService _taikhoanService;
        public NhanvienController(INhanvienService nhanvienService, ITaikhoanService taikhoanService)
        {
            _nhanvienService = nhanvienService;
            _taikhoanService = taikhoanService;
        }

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login", "Home"));
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetAll(bool? hasAccount = true)
        {
            if (hasAccount.Value)
            {
                var res = _nhanvienService.GetAll();
                return Json(new { Success = true, data = res });
            }
            else
            {
                var allAccount = _taikhoanService.GetAll().Select(x => x.MaNV).ToList();
                var res = _nhanvienService.GetAll().Where(x => !allAccount.Contains(x.Id)).ToList();
                return Json(new { Success = true, data = res });
            }

        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var res = _nhanvienService.GetById(id);
            return Json(new { Success = true, data = res });
        }

        [HttpPost]
        public JsonResult LuuNhanVien(Nhanvien model)
        {
            try
            {
                _nhanvienService.Create(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }

        [HttpPut]
        public JsonResult SuaNhanVien(Nhanvien model)
        {
            try
            {
                _nhanvienService.Update(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }

        [HttpDelete]
        public bool XoaNhanVien(int id)
        {
            try
            {
                _nhanvienService.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
