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
    }
}
