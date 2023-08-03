﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Domains.Entities.Product;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    [Authorize]
    public class DichvuController : Controller
    {
        private readonly IDichvuService _dichvuService;
        public DichvuController(IDichvuService dichvuService)
        {
            _dichvuService = dichvuService;
        }
        public IActionResult Index()
        {
            return View();
        }
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
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpPut]
        public JsonResult SuaDichvu(Dichvu model)
        {
            try
            {
                _dichvuService.UpdateDichvu(model);
                return Json(new { Success = true });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }
        [HttpDelete]
        public bool XoaDichvu(int id)
        {
            try
            {
                _dichvuService.DeleteDichvu(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
