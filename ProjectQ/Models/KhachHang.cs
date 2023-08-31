using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectQ.Models
{
    public partial class KhachHang
    {
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public int? SoDienThoai { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string DiaChi { get; set; }
    }
}
