using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quanlykhachsan.Models;
using quanlykhachsan.Services;
using System.Diagnostics;

namespace quanlykhachsan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaikhoanService _taikhoanService;
        private readonly IQuyenService _quyenService;
        private readonly INhanvienService _nhanvienService;
        private readonly IChucvuService _chucvuService;
        private readonly ITokenService _tokenService;
        private string? generatedToken = null;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, ITaikhoanService taikhoanService, ITokenService tokenService, IHttpContextAccessor contextAccessor, IQuyenService quyenService, INhanvienService nhanvienService, IChucvuService chucvuService)
        {
            _logger = logger;
            _taikhoanService = taikhoanService;
            _tokenService = tokenService;
            _contextAccessor = contextAccessor;
            _quyenService = quyenService;
            _nhanvienService = nhanvienService;
            _chucvuService = chucvuService;
        }

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {
                return (RedirectToAction("Login"));
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DoLogin(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                return RedirectToAction("Error");
            IActionResult response = Unauthorized();
            var taikhoan = _taikhoanService.GetByUsername(tenDangNhap);
            if (taikhoan != null && taikhoan.MatKhau == matKhau)
            {
                var quyen = _quyenService.GetById(taikhoan.MaQuyen);
                var nhanvien = _nhanvienService.GetById(taikhoan.MaNV);
                var chucvu = _chucvuService.GetById(nhanvien.MaCV);
                generatedToken = _tokenService.BuildToken(taikhoan.TenDangNhap, quyen.TenQuyen);

                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    HttpContext.Session.SetString("TaiKhoan", taikhoan.TenDangNhap);
                    HttpContext.Session.SetString("NhanVien", nhanvien.HoTen);
                    HttpContext.Session.SetInt32("MaNhanVien", nhanvien.Id);
                    HttpContext.Session.SetString("Quyen", quyen.TenQuyen);
                    HttpContext.Session.SetInt32("MaQuyen", quyen.Id);
                    HttpContext.Session.SetString("ChucVu", chucvu.TenCV);

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}