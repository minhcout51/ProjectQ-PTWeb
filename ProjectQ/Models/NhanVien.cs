using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectQ.Models
{
    public partial class NhanVien
    {
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string CongViec { get; set; }
        public string TrangThai { get; set; }
    }
}
