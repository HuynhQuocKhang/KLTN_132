using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class StoreBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public List<StoreBO> GetAllStore()
        {
            var model = from objStore in db.SieuThis
                        orderby objStore.MaST ascending
                        select new StoreBO()
                        {
                            MaST = objStore.MaST,
                            TenST = objStore.TenST,
                            DiaChi = objStore.DiaChi,
                            SDT = objStore.SDT
                        };
            return model.Select(x => x).ToList();
        }
        public string getStoreNameByUser(int? pStoreId)
        {
            var model = (from objStore in db.SieuThis
                         where objStore.MaST == pStoreId
                         select new StoreBO()
                         {
                             MaST = objStore.MaST,
                             TenST = objStore.TenST,
                             DiaChi = objStore.DiaChi,
                             SDT = objStore.SDT
                         });
            return model.Select(t => t.TenST).SingleOrDefault();
        }

        public int GetSaleOfStore(DateTime datCurrentDay, int intStoreId, int intUserId)
        {
            int totoalSale = 0;
            List<HoaDonBanHang> lstInvoice = db.HoaDonBanHangs.Where(x => x.NgayTao == datCurrentDay && x.MaST == intStoreId && x.MaNV == intUserId).ToList();
            foreach (HoaDonBanHang item in lstInvoice)
            {
                totoalSale += (int)item.ThanhTien;
            }
            return totoalSale;
        }
    }
}
