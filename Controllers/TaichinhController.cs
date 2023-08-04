using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Services;

namespace quanlykhachsan.Controllers
{
    public class TaichinhController : Controller
    {
        private readonly IHoadonService _hoadonService;
        public TaichinhController(IHoadonService hoadonService)
        {
            _hoadonService = hoadonService;
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
        public JsonResult GetAllHoadon()
        {
            var res = _hoadonService.GetAll();
            return Json(new { Success = true, data = res });
        }
    }
}
