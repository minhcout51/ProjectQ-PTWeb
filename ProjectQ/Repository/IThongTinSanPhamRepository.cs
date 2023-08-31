using ProjectQ.Models;
using System.Collections.Generic;

namespace ProjectQ.Repository
{
    public interface IThongTinSanPhamRepository
    {
        
        List<ThongTinSanPham> getAllProducts();
        List<ThongTinSanPham> getAllProductsById(int Id);
        ThongTinSanPham getProduct(int Id);
        

    }
}
