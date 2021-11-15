using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class OrderStoreBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public IQueryable<DonDatHang> GetListAllOrderStore()
        {
            return db.DonDatHangs.Select(t => t);
        }

        public IQueryable<DonDatHang> GetListAllOrderStoreByDay(DateTime dateFrom, DateTime dateTo)
        {
            return db.DonDatHangs.Select(t => t).Where(t => t.NgayDat >= dateFrom && t.NgayDat <= dateTo); ;
        }

        public IQueryable<DonDatHang> GetListOrderStoreByStoreId(string strStoreId, DateTime dateFrom, DateTime dateTo)
        {
            return db.DonDatHangs.Select(t => t).Where(t => t.MaST == strStoreId.Trim() && t.NgayDat >= dateFrom && t.NgayDat <= dateTo);
        }
    }
}
