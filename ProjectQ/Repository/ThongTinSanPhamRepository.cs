using ProjectQ.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectQ.Repository
{
    public class ThongTinSanPhamRepository : IThongTinSanPhamRepository
    {
        private FarmEContext _ctx;

        public ThongTinSanPhamRepository()
        {
        }

        public ThongTinSanPhamRepository(FarmEContext ctx)
        {
            _ctx = ctx;
        }


        public List<ThongTinSanPham> getAllProducts()
        {
            return _ctx.ThongTinSanPhams.Include(x => x.Id).ToList();
        }

        public List<ThongTinSanPham> getAllProductsById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ThongTinSanPham getProduct(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
