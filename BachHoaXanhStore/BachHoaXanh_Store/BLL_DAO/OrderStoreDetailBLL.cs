using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class OrderStoreDetailBLL
    {
        BachHoaXanhDataContext data = new BachHoaXanhDataContext();
        public IQueryable<CTDonDatHang> GetListALlOrderStoreDetail(int intOrderStoreId)
        {
            return data.CTDonDatHangs.Select(t => t).Where(t => t.MaDH == intOrderStoreId);
        }
    }
}
