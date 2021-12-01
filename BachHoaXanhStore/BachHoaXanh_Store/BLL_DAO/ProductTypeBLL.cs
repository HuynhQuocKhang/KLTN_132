using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class ProductTypeBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public List<ProductTypeBO> GetALLProductType()
        {
            var model = from objProductType in db.LoaiSPs
                        where objProductType.Isdeleted == false
                        select new ProductTypeBO()
                        {
                            MaLoaiSP = objProductType.MaLoaiSP,
                            TenLoaiSP = objProductType.TenLoaiSP
                        };
            model.OrderByDescending(x => x.MaLoaiSP);
            return model.ToList();
        }
    }
}
