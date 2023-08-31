using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectQ.Models
{
    public partial class ThongTinDonHang
    {
        public int Id { get; set; }
        public int? IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public int? Gia { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string DiaChiCuaHang { get; set; }
        public int? SoDienThoaiKhachHang { get; set; }

        public virtual DiaChiCuaHang IdNavigation { get; set; }
        public virtual Category LoaiSanPhamNavigation { get; set; }
    }
}
