using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class CustomerBLL
    {
        BachHoaXanhDataContext data = new BachHoaXanhDataContext();
        public IQueryable<NhaCungCap> GetListALlCustomer()
        {
            return data.NhaCungCaps.Select(t => t);
        }
    }
}
