using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class OrderCustomerBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public List<OrderCustomerBO> GetListOrderCustomer(int intOrderId, int intCustomerId)
        {
            if (intOrderId == 0)
            {
                var model = from objOrderCustomer in db.HoaDonDatNCCs
                            where objOrderCustomer.Isdeleted == false && objOrderCustomer.MaNCC == intCustomerId
                            select new OrderCustomerBO()
                            {
                                MaHDDat = objOrderCustomer.MaHDDat,
                                MaNCC = objOrderCustomer.MaNCC,
                                TongTien = objOrderCustomer.TongTien,
                                NgayDat = objOrderCustomer.NgayDat,
                                TinhTrang = objOrderCustomer.TinhTrang,
                                Isdeleted = objOrderCustomer.Isdeleted
                            };
                model.OrderByDescending(x => x.MaHDDat);
                return model.ToList();

            }
            else
            {
                var model = from objOrderCustomer in db.HoaDonDatNCCs
                            where objOrderCustomer.Isdeleted == false && objOrderCustomer.MaHDDat == intOrderId && objOrderCustomer.MaNCC == intCustomerId
                            select new OrderCustomerBO()
                            {
                                MaHDDat = objOrderCustomer.MaHDDat,
                                MaNCC = objOrderCustomer.MaNCC,
                                TongTien = objOrderCustomer.TongTien,
                                NgayDat = objOrderCustomer.NgayDat,
                                TinhTrang = objOrderCustomer.TinhTrang,
                                Isdeleted = objOrderCustomer.Isdeleted
                            };
                model.OrderByDescending(x => x.MaHDDat);
                return model.ToList();
            }
        }

        public bool InsertOrderCustomer(OrderCustomerBO model)
        {
            try
            {
                HoaDonDatNCC objHoaDonDatNCC = new HoaDonDatNCC();
                objHoaDonDatNCC.MaNCC = model.MaNCC;
                objHoaDonDatNCC.TongTien = model.TongTien;
                objHoaDonDatNCC.NgayDat = model.NgayDat;
                objHoaDonDatNCC.TinhTrang = model.TinhTrang;
                objHoaDonDatNCC.Isdeleted = false;
                db.HoaDonDatNCCs.InsertOnSubmit(objHoaDonDatNCC);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteOrderCustomer(OrderCustomerBO model)
        {
            try
            {
                var objOrderCustomerBO = db.HoaDonDatNCCs.SingleOrDefault(t => t.MaHDDat == model.MaHDDat);
                objOrderCustomerBO.Isdeleted = true;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
