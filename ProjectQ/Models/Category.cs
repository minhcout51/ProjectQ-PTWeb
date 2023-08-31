using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectQ.Models
{
    public partial class Category
    {
        public Category()
        {
            ThongTinDonHangs = new HashSet<ThongTinDonHang>();
        }

        public int? Id { get; set; }
        public string Ten { get; set; }

        public virtual ICollection<ThongTinDonHang> ThongTinDonHangs { get; set; }
    }
}
