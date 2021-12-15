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
        public List<OrderCustomerBO> GetListOrderCustomer(int intOrderId, int intCustomerId, int intStatus)
        {
            if (intOrderId == 0)
            {
                var model = from objOrderCustomer in db.HoaDonDatNCCs
                            where objOrderCustomer.Isdeleted == false && objOrderCustomer.MaNCC == intCustomerId && objOrderCustomer.TinhTrang == intStatus
                            select new OrderCustomerBO()
                            {
                                MaHDDat = objOrderCustomer.MaHDDat,
                                MaNCC = objOrderCustomer.MaNCC,
                                NguoiLapPhieu = objOrderCustomer.NguoiLapPhieu,
                                TongTien = objOrderCustomer.TongTien,
                                NgayDat = objOrderCustomer.NgayDat
                                //TinhTrang = objOrderCustomer.TinhTrang,
                                //Isdeleted = objOrderCustomer.Isdeleted
                            };
                model.OrderByDescending(x => x.MaHDDat);
                return model.ToList();

            }
            else
            {
                var model = from objOrderCustomer in db.HoaDonDatNCCs
                            where objOrderCustomer.Isdeleted == false && objOrderCustomer.MaHDDat == intOrderId && objOrderCustomer.MaNCC == intCustomerId && objOrderCustomer.TinhTrang == intStatus
                            select new OrderCustomerBO()
                            {
                                MaHDDat = objOrderCustomer.MaHDDat,
                                MaNCC = objOrderCustomer.MaNCC,
                                NguoiLapPhieu = objOrderCustomer.NguoiLapPhieu,
                                TongTien = objOrderCustomer.TongTien,
                                NgayDat = objOrderCustomer.NgayDat
                                //TinhTrang = objOrderCustomer.TinhTrang,
                                //Isdeleted = objOrderCustomer.Isdeleted
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
                objHoaDonDatNCC.NguoiLapPhieu = model.NguoiLapPhieu;
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

        public int GetOrderCustomerIdNew()
        {
            return db.HoaDonDatNCCs.OrderByDescending(t => t.MaHDDat).Select(t => t.MaHDDat).FirstOrDefault();
        }

        public bool InsertOrderCustomerDetail(int intOrderId, string strProductId, int intStock, int TotalPrice)
        {
            try
            {
                CTHoaDonDatNCC model = new CTHoaDonDatNCC();
                model.MaHDDat = intOrderId;
                model.MaSP = strProductId;
                model.SoLuong = intStock;
                model.ThanhTien = TotalPrice;
                db.CTHoaDonDatNCCs.InsertOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<GetListOrderStoreByOrderIdBO> GetListOrderCustomerDetail(int intOrderId)
        {
            if (intOrderId == 0)
            {
                var model = from objCTHoaDonDatNCC in db.CTHoaDonDatNCCs
                            join objProduct in db.SanPhams
                            on objCTHoaDonDatNCC.MaSP equals objProduct.MaSP
                            select new GetListOrderStoreByOrderIdBO()
                            {
                                MaSP = objCTHoaDonDatNCC.MaSP,
                                TenSP = objProduct.TenSP,
                                SoLuong = objCTHoaDonDatNCC.SoLuong
                            };
                return model.ToList();
            }
            else
            {
                var model = from objCTHoaDonDatNCC in db.CTHoaDonDatNCCs
                            join objProduct in db.SanPhams
                            on objCTHoaDonDatNCC.MaSP equals objProduct.MaSP
                            where objCTHoaDonDatNCC.MaHDDat == intOrderId
                            select new GetListOrderStoreByOrderIdBO()
                            {
                                MaSP = objCTHoaDonDatNCC.MaSP,
                                TenSP = objProduct.TenSP,
                                SoLuong = objCTHoaDonDatNCC.SoLuong
                            };
                return model.ToList();
            }
        }

        public bool UpdateCustomerOrder(int intOrderId, List<ProductBO> lstProduct)
        {
            try
            {
                foreach (ProductBO item in lstProduct)
                {
                    var objProduct = db.SanPhams.Where(x => x.MaSP == item.MaSP).FirstOrDefault();
                    objProduct.SoLuong += item.SoLuong;
                    db.SubmitChanges();
                }
                var objOrderCustomer = db.HoaDonDatNCCs.Where(x => x.MaHDDat == intOrderId).FirstOrDefault();
                objOrderCustomer.TinhTrang = 1;
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
