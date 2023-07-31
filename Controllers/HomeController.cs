using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Models;
using quanlykhachsan.Services;
using System.Diagnostics;

namespace quanlykhachsan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChucvuService _chucvuService;

        public HomeController(ILogger<HomeController> logger, IChucvuService chucvuService)
        {
            _logger = logger;
            _chucvuService = chucvuService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chucvu()
        {
            var chucvus = _chucvuService.GetAll();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}