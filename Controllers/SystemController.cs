using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Master;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    public class SystemController : Controller
    {
        private readonly IChucvuService _chucvuService;
        public SystemController(IChucvuService chucvuService)
        {
            _chucvuService = chucvuService;
        }

        public IActionResult Phanquyen()
        {
            return View();
        }

        //Chuc vu
        public IActionResult Chucvu()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
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
            return View();
        }
    }
}
