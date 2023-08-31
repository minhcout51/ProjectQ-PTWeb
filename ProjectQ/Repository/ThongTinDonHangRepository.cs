using ProjectQ.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectQ.Repository
{
    public class ThongTinDonHangRepository : IThongTinDonHangRepository
    {
        private FarmEContext _ctx;
        public ThongTinDonHangRepository(FarmEContext ctx)
        {
            _ctx = ctx;
        } 
        public List<ThongTinSanPham> getBills()
        {
            return _ctx.ThongTinSanPhams.Include(x => x.Id).ToList();
        }

        public List<ThongTinSanPham> getAllBillsById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ThongTinSanPham getBill(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<ThongTinSanPham> getAllBills()
        {
            throw new System.NotImplementedException();
        }

        public void AddBill(ThongTinDonHang bill)
        {
            throw new System.NotImplementedException();
        }
    }
}
