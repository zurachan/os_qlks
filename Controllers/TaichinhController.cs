using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Models;
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

        [HttpGet]
        public JsonResult DoanhThu(int nam, int thang)
        {

            var dates = GetDates(nam, thang);
            var hoadonthang = _hoadonService.GetAllHoaDonThang(nam, thang);

            var group = hoadonthang.GroupBy(x => x.NgayThanhToan)
                .Select(x => new
                {
                    Ngay = x.Key,
                    TongTien = x.Sum(i => i.SoTienThanhToan)
                }).OrderBy(x => x.Ngay).ToList();

            var result = new List<DoanhthuViewModel>();
            foreach (var item in dates)
            {
                var model = new DoanhthuViewModel
                {
                    Ngay = item
                };

                if (group.Any(x => x.Ngay == item))
                {
                    model.TongTien = group.FirstOrDefault(i => i.Ngay == item).TongTien;
                }
                else
                {
                    model.TongTien = 0;
                }

                result.Add(model);
            }

            return Json(new { data = result });
        }

        private List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
    }
}
