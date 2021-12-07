using BO;
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
        //Lấy danh sách tất cả các đơn đặt hàng 
        public IQueryable<DonDatHang> GetListAllOrderStore()
        {
            return db.DonDatHangs.Select(t => t);
        }

        //Lấy danh sách đơn đặt hàng theo điều kiện
        public IQueryable<DonDatHang> GetListOrderStoreByKey(int intStoreId, DateTime dateFrom, DateTime dateTo)
        {
            if (intStoreId == 0)
            {
                return db.DonDatHangs.Select(t => t).Where(t => t.NgayDat >= dateFrom && t.NgayDat <= dateTo);
            }
            else
            {
                return db.DonDatHangs.Select(t => t).Where(t => t.MaST == intStoreId && t.NgayDat >= dateFrom && t.NgayDat <= dateTo);
            }
        }

        //Tạo đơn đặt hàng
        public bool InsertOrderStore(OrderStoreBO model)
        {
            try
            {
                DonDatHang objDonDatHang = new DonDatHang();
                objDonDatHang.MaST = model.MaST;
                objDonDatHang.NgayDat = DateTime.Now;
                objDonDatHang.NguoiLapPhieu = model.NguoiLapPhieu;
                objDonDatHang.TinhTrang = 0;
                objDonDatHang.TongTien = model.TongTien;
                objDonDatHang.Isdeleted = false;
                db.DonDatHangs.InsertOnSubmit(objDonDatHang);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrderStore(DonDatHang model)
        {
            try
            {
                var objDonDatHang = db.DonDatHangs.Where(t => t.MaDH == model.MaDH).FirstOrDefault();
                objDonDatHang.Isdeleted = true;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetOrderStoreIdNew()
        {
            return db.DonDatHangs.OrderByDescending(t => t.MaDH).Select(t => t.MaDH).FirstOrDefault();
        }

        public List<ProductOrderCustomerBO> GetProductFromStore(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0, int intStock = 0, int intPageSize = 50, int intStoreId = 1)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && (objProduct.TenSP.Contains(strkeywords.Trim()) || objStore.MaSP.Contains(strkeywords.Trim()) && objStore.MaST == intStoreId)
                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intCustomerId == 0 && intProductTypeId != 0)
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaLoaiSP == intProductTypeId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objStore.SoLuong <= intStock)
                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intProductTypeId == 0 && intCustomerId != 0)
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objStore.SoLuong <= intStock)
                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objStore.SoLuong
                            };

                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            else
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objStore.SoLuong <= intStock && objProduct.MaLoaiSP == intProductTypeId)
                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
        }

    }
}
