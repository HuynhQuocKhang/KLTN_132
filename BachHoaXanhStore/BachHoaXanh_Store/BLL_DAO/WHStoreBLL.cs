using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class WHStoreBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public bool UpdateStockOfProductFromStore(int intStoreId, List<ProductBO> lstProduct)
        {
            try
            {
                foreach (ProductBO item in lstProduct)
                {
                    var objProductStore = db.KhoSieuThis.Where(x => x.MaST == intStoreId && x.MaSP == item.MaSP).FirstOrDefault();
                    objProductStore.SoLuong += item.SoLuong;
                    var objProductWH = db.SanPhams.Where(x => x.MaSP == item.MaSP).FirstOrDefault();
                    objProductWH.SoLuong -= item.SoLuong;
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
