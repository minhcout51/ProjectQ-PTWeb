using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectQ.Models
{
    public partial class ThongTinSanPham
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public int? Gia { get; set; }
        public string TrangThai { get; set; }
        public string MoTaSanPham { get; set; }
        public string HinhAnh { get; set; }
    }
}
