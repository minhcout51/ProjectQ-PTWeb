using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectQ.Models
{
    public class ThongTinSanPhamRepository
    {
        public List<ThongTinSanPham> getAllProducts()
        {
            List<ThongTinSanPham> products = new List<ThongTinSanPham>()
            {

                new ThongTinSanPham(){ Id=1 , TenSanPham ="kiwi"},
                new ThongTinSanPham(){ Id=2 , TenSanPham ="mango"},
                
            };
            return products;
        }
    }
}
