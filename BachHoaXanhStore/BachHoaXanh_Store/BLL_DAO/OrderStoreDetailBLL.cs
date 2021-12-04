using BO;
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

        public bool InserOrderStoreDetail(List<OrderCustomerDetailBO> lstProduct, int intOrderStoreId)
        {
            try
            {
                foreach (var item in lstProduct)
                {
                    CTDonDatHang objCTDonDatHang = new CTDonDatHang();
                    objCTDonDatHang.MaDH = intOrderStoreId;
                    objCTDonDatHang.MaSP = item.MaSP;
                    objCTDonDatHang.SoLuong = item.SoLuong;
                    objCTDonDatHang.ThanhTien = item.ThanhTien;
                    data.CTDonDatHangs.InsertOnSubmit(objCTDonDatHang);
                    data.SubmitChanges();
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
