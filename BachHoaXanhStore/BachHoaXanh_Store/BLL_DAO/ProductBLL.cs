using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class ProductBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public ProductBLL()
        {

        }
        public IQueryable<SanPham> GetListAllProdyct()
        {
            return db.SanPhams.Select(t => t);
        }

        public IQueryable<SanPham> GetProductByKeys(string strkeywords, int intCustomerId)
        {
            return db.SanPhams.Select(t => t).Where(t => t.MaSP.Contains(strkeywords.Trim()) || t.TenSP.Contains(strkeywords.Trim()) && t.MaNCC == intCustomerId);
        }


    }
}
