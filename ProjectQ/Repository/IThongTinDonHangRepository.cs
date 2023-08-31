using ProjectQ.Models;
using System.Collections.Generic;

namespace ProjectQ.Repository

{
    public interface IThongTinDonHangRepository
    {
        List<ThongTinSanPham> getAllBills();
        List<ThongTinSanPham> getAllBillsById(int Id);
        ThongTinSanPham getBill(int Id);
        void AddBill(ThongTinDonHang bill);
    }
}
