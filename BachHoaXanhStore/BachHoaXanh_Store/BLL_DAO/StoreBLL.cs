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
                        select new StoreBO()
                        {
                            MaST = objStore.MaST,
                            TenST = objStore.TenST,
                            DiaChi = objStore.DiaChi,
                            SDT = objStore.SDT
                        };
            return model.OrderByDescending(x => x.MaST).ToList();
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
            return model.Select(t=>t.TenST).SingleOrDefault();
        }
    }
}
