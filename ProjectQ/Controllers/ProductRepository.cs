using Microsoft.AspNetCore.Mvc;
using ProjectQ.Repository;
using ProjectQ.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectQ.Controllers
{
    public class ProductRepository : Controller
    {
        private IThongTinSanPhamRepository _sp;
        private FarmEContext FE;
        public ProductRepository(IThongTinSanPhamRepository sp)
        {
            _sp = sp;
        }
        public IActionResult Index()
        {
            List<ThongTinSanPham> lst = _sp.getAllProducts();
            ViewBag.items = lst;
            return View();
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ThongTinSanPham sanpham = new ThongTinSanPham();
            // categories ==> dropdownlist
            ViewBag.ThongTinSanPhams = FE.ThongTinSanPhams.ToList();
            return View(sanpham);
            return RedirectToAction("GetAllProducts");
        }
    }
}
