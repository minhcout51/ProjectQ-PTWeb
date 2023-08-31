using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectQ.Models;
using ProjectQ.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectQ.Controllers
{
    public class HomeController : Controller
    {
        FarmEContext FE = new FarmEContext();
        public readonly IThongTinSanPhamRepository thongTinSanPhamRepository = null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();

        }
        public IActionResult Products()
        {
            Models.ThongTinSanPhamRepository rep = new Models.ThongTinSanPhamRepository();
            List<ThongTinSanPham> products = rep.getAllProducts();
            return View(products);
           

        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        public IActionResult ProductDetail(int Id)
        {
            ViewBag.Title = "Product Details";
            ThongTinSanPham sanpham = FE.ThongTinSanPhams.Where(x => x.Id == Id).SingleOrDefault();
            return View(sanpham);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult StoreLocation()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(KhachHang signup)
        {
            if (ModelState.IsValid)
            {
                //check email
                KhachHang c = FE.KhachHangs.Where(x => x.Email == signup.Email).SingleOrDefault();
                if (c != null)
                {
                    ModelState.AddModelError(string.Empty, "Email da ton tai! ");
                    return View(signup);
                }
                else
                {
                    FE.KhachHangs.Add(signup);
                    FE.SaveChanges();
                    return RedirectToAction("SignUp");

                }

            }
            else
            {
                return View(signup);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
