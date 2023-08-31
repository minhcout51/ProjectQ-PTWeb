using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectQ.Models;
using ProjectQ.Repository;

namespace ProjectQ.Controllers
{
    public class AdminController : Controller
    {
        FarmEContext FE = new FarmEContext();
         IThongTinSanPhamRepository _sp;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllProducts()
        {
            //Select from where
            List<ThongTinSanPham> lst = FE.ThongTinSanPhams.ToList();
            return View(lst);
            //List<ThongTinSanPham> lst = _sp.getAllProducts();
            //ViewBag.items = lst;
            //return View();
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
        
            public ActionResult EditProduct(int id)
        {
            // Tim doi tuong bang id 
            ThongTinSanPham TTSP = FE.ThongTinSanPhams.Where(c => c.Id == id).SingleOrDefault();
            return View(TTSP);
        }

        //insert
        [HttpPost]
        public IActionResult SaveProduct(ThongTinSanPham TTSP)
        {
            //insert db

            FE.ThongTinSanPhams.Add(TTSP);
            FE.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

        [HttpPost]
        public IActionResult UpdateProduct(ThongTinSanPham TTSP)
        {
            ThongTinSanPham sp = FE.ThongTinSanPhams.Where(x => x.Id == TTSP.Id).SingleOrDefault();
            if (sp != null)
            {
                // tìm đối tượng có trong db tương ứng                
                sp.Id = TTSP.Id;
                sp.TenSanPham = TTSP.TenSanPham;
                sp.LoaiSanPham = TTSP.LoaiSanPham;
                sp.Gia = TTSP.Gia;
                sp.TrangThai = TTSP.TrangThai;
                sp.LoaiSanPham = TTSP.LoaiSanPham;
                sp.MoTaSanPham = TTSP.MoTaSanPham;
            }
            // Cập nhật thông tin   
            FE.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult DeleteProduct(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            ThongTinSanPham sp = FE.ThongTinSanPhams.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            FE.ThongTinSanPhams.Remove(sp);
            FE.SaveChanges();

            return RedirectToAction("GetAllProducts");
        }

        public IActionResult GetAllBills()
        {
            //Select from where
            List<ThongTinDonHang> lst = FE.ThongTinDonHangs.ToList();
            return View(lst);
        }
        public IActionResult AddBill()
        {
            
            return View();
            return RedirectToAction("GetAllBills");
        }

        public ActionResult EditBill(int id)
        {
            // Tim doi tuong bang id 
            ThongTinDonHang TTDH = FE.ThongTinDonHangs.Where(c => c.Id == id).SingleOrDefault();
            return View(TTDH);
        }

        [HttpPost]
        public IActionResult UpdateBill(ThongTinDonHang TTDH)
        {
            // tìm đối tượng có trong db tương ứng 
            ThongTinDonHang dh = FE.ThongTinDonHangs.Where(x => x.Id == TTDH.Id).SingleOrDefault();
            if (dh != null)
            {
                dh.Id = TTDH.Id;
                dh.TenSanPham = TTDH.TenSanPham;
                dh.LoaiSanPham = TTDH.LoaiSanPham;
                dh.Gia = TTDH.Gia;
                dh.TenKhachHang = TTDH.TenKhachHang;
                dh.DiaChi = TTDH.DiaChi;
                dh.DiaChiCuaHang = TTDH.DiaChiCuaHang;
                dh.SoDienThoaiKhachHang = TTDH.SoDienThoaiKhachHang;
            }
            // Cập nhật thông tin   
            FE.SaveChanges();
            return RedirectToAction("GetAllBills");
        }
        [HttpPost]
        public IActionResult SaveBill(ThongTinDonHang TTDH)
        {
            //insert db
            FE.ThongTinDonHangs.Add(TTDH);
            FE.SaveChanges();
            return RedirectToAction("GetAllBills");
        }

        public IActionResult DeleteBill(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            ThongTinDonHang dh = FE.ThongTinDonHangs.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            FE.ThongTinDonHangs.Remove(dh);
            FE.SaveChanges();

            return RedirectToAction("GetAllBills");
        }

        public IActionResult GetAllStoreAddresses()
        {
            //Select from where
            List<DiaChiCuaHang> lst = FE.DiaChiCuaHangs.ToList();
            return View(lst);
        }
        
        public IActionResult AddStoreAddress()
        {
            return View();
            return RedirectToAction("GetAllStoreAddresses");
        }

        public ActionResult EditStoreAddress(int id)
        {
            // Tim doi tuong bang id 
            DiaChiCuaHang DCCH = FE.DiaChiCuaHangs.Where(c => c.Id == id).SingleOrDefault();
            return View(DCCH);
        }

        [HttpPost]
        public IActionResult UpdateStoreAddress(DiaChiCuaHang DCCH)
        {
            // tìm đối tượng có trong db tương ứng 
            DiaChiCuaHang dcch = FE.DiaChiCuaHangs.Where(x => x.Id == DCCH.Id).SingleOrDefault();
            if (dcch != null)
            {
                dcch.Id = DCCH.Id;
                dcch.So = DCCH.So;
                dcch.Duong = DCCH.Duong;
                dcch.Xa = DCCH.Xa;
                dcch.Huyen = DCCH.Huyen;
                dcch.Phuong = DCCH.Phuong;
                dcch.Quan = DCCH.Quan;
                dcch.ThanhPho = DCCH.ThanhPho;
            }
            // Cập nhật thông tin   
            FE.SaveChanges();
            return RedirectToAction("GetAllStoreAddresses");
        }
        [HttpPost]
        public IActionResult SaveStoreAddress(DiaChiCuaHang DCCH)
        {
            //insert db
            FE.DiaChiCuaHangs.Add(DCCH);
            FE.SaveChanges();
            return RedirectToAction("GetAllStoreAddresses");
        }

        public IActionResult DeleteStoreAddress(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            DiaChiCuaHang dcch = FE.DiaChiCuaHangs.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            FE.DiaChiCuaHangs.Remove(dcch);
            FE.SaveChanges();

            return RedirectToAction("GetAllStoreAddresses");
        }
        public IActionResult GetAllCustomers()
        {
            //Select from where
            List<KhachHang> lst = FE.KhachHangs.ToList();
            return View(lst);
        }
        public IActionResult AddCustomer()
        {
            return View();
            return RedirectToAction("GetAllCustomers");
        }

        public ActionResult EditCustomer(int id)
        {
            // Tim doi tuong bang id 
            KhachHang KH = FE.KhachHangs.Where(c => c.Id == id).SingleOrDefault();
            return View(KH);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(KhachHang KH)
        {
            // tìm đối tượng có trong db tương ứng 
            KhachHang kh = FE.KhachHangs.Where(x => x.Id == KH.Id).SingleOrDefault();
            if (kh != null)
            {
                kh.Id = KH.Id;
                kh.HoVaTen = KH.HoVaTen;
                kh.SoDienThoai = KH.SoDienThoai;
                kh.Email = KH.Email;
                kh.MatKhau = KH.MatKhau;
                kh.DiaChi = KH.DiaChi;
            }
            // Cập nhật thông tin   
            FE.SaveChanges();
            return RedirectToAction("GetAllCustomers");
        }
        [HttpPost]
        public IActionResult SaveCustomer(KhachHang KH)
        {
            //insert db
            FE.KhachHangs.Add(KH);
            FE.SaveChanges();
            return RedirectToAction("GetAllCustomers");
        }

        public IActionResult DeleteCustomer(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            KhachHang kh = FE.KhachHangs.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            FE.KhachHangs.Remove(kh);
            FE.SaveChanges();

            return RedirectToAction("GetAllCustomers");
        }

        public IActionResult GetAllEmployees()
        {
            //Select from where
            List<NhanVien> lst = FE.NhanViens.ToList();
            return View(lst);
        }

        public IActionResult AddEmployee()
        { 
            return View();
            return RedirectToAction("GetAllEmployees");
        }
       

        public ActionResult EditEmployee(int id)
        {
            // Tim doi tuong bang id 
            NhanVien NV = FE.NhanViens.Where(c => c.Id == id).SingleOrDefault();
            return View(NV);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(NhanVien NV)
        {
            // tìm đối tượng có trong db tương ứng 
            NhanVien nv = FE.NhanViens.Where(x => x.Id == NV.Id).SingleOrDefault();
            if (nv != null)
            {
                nv.Id = NV.Id;
                nv.HoVaTen = NV.HoVaTen;
                nv.GioiTinh = NV.GioiTinh;
                nv.NgaySinh = NV.NgaySinh;
                nv.SoDienThoai = NV.SoDienThoai;
                nv.DiaChi = NV.DiaChi;
                nv.Email = NV.Email;
                nv.CongViec = NV.CongViec;
            }
            // Cập nhật thông tin   
            FE.SaveChanges();
            return RedirectToAction("GetAllEmployees");
        }
        [HttpPost]
        public IActionResult SaveEmployee(NhanVien NV)
        {
            //insert db
            FE.NhanViens.Add(NV);
            FE.SaveChanges();
            return RedirectToAction("GetAllEmployees");
        }

        public IActionResult DeleteEmployee(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            NhanVien nv = FE.NhanViens.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            FE.NhanViens.Remove(nv);
            FE.SaveChanges();

            return RedirectToAction("GetAllEmployees");
        }

        public IActionResult GetAllDeliveryAddresses()
        {
            //Select from where
            List<DiaChiGiaoHang> lst = FE.DiaChiGiaoHangs.ToList();
            return View(lst);
        }
        
        public IActionResult AddDeliveryAddress()
        {
            return View();
            return RedirectToAction("GetAllDeliveryAddresses");
        }

        public ActionResult EditDeliveryAddress(int id)
        {
            // Tim doi tuong bang id 
            DiaChiGiaoHang DCGH = FE.DiaChiGiaoHangs.Where(c => c.Id == id).SingleOrDefault();
            return View(DCGH);
        }
        
        [HttpPost]
        public IActionResult UpdateDeliveryAddress(DiaChiGiaoHang DCGH)
        {
            // tìm đối tượng có trong db tương ứng 
            DiaChiGiaoHang dcgh = FE.DiaChiGiaoHangs.Where(x => x.Id == DCGH.Id).SingleOrDefault();
            if (dcgh != null)
            {
                dcgh.Id = DCGH.Id;
                dcgh.So = DCGH.So;
                dcgh.Duong = DCGH.Duong;
                dcgh.Xa = DCGH.Xa;
                dcgh.Huyen = DCGH.Huyen;
                dcgh.Phuong = DCGH.Phuong;
                dcgh.Quan = DCGH.Quan;
                dcgh.ThanhPho = DCGH.ThanhPho;
            }
            // Cập nhật thông tin   
            FE.SaveChanges();
            return RedirectToAction("GetAllDeliveryAddresses");
        }
        [HttpPost]
        public IActionResult SaveDeliveryAddress(DiaChiGiaoHang DCGH)
        {
            //insert db
            FE.DiaChiGiaoHangs.Add(DCGH);
            FE.SaveChanges();
            return RedirectToAction("GetAllDeliveryAddresses");
        }

        public IActionResult DeleteDeliveryAddress(int id)
        {
            // tim doi tuong có id
            //select * from categories where CCategoryId = id 
            DiaChiGiaoHang dcgh = FE.DiaChiGiaoHangs.Where(x => x.Id == id).SingleOrDefault();

            //xoa du lieu

            FE.DiaChiGiaoHangs.Remove(dcgh);
            FE.SaveChanges();

            return RedirectToAction("GetAllDeliveryAddresses");
        }

    }
}
