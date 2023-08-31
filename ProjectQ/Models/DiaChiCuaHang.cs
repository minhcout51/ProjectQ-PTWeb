﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectQ.Models
{
    public partial class DiaChiCuaHang
    {
        public int Id { get; set; }
        public int? So { get; set; }
        public string Duong { get; set; }
        public string Xa { get; set; }
        public string Huyen { get; set; }
        public string Phuong { get; set; }
        public string Quan { get; set; }
        public string ThanhPho { get; set; }

        public virtual DiaChiGiaoHang IdNavigation { get; set; }
        public virtual ThongTinDonHang ThongTinDonHang { get; set; }
    }
}
