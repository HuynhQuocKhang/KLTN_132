using BO;
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
        public List<CustomerBO> GetListALlCustomer()
        {
            var model = from objCustomer in data.NhaCungCaps
                        select new CustomerBO()
                        {
                            MaNCC = objCustomer.MaNCC,
                            TenNCC = objCustomer.TenNCC,
                            DiaChi = objCustomer.DiaChi
                        };
            model.OrderByDescending(x => x.MaNCC);
            return model.ToList();
        }
    }
}
