using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class ReturnProductBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public bool InsertReturnOrder(ReturnProductBO model)
        {
            try
            {
                PhieuTraHang objPhieuTraHang = new PhieuTraHang();
                objPhieuTraHang.MaST = model.MaST;
                objPhieuTraHang.MaNCC = model.MaNCC;
                objPhieuTraHang.NguoiLapPhieu = model.NguoiLapPhieu;
                objPhieuTraHang.NgayTra = model.NgayTra;
                objPhieuTraHang.TongTien = model.TongTien;
                objPhieuTraHang.Isdeleted = false;
                objPhieuTraHang.TinhTrang = 0;
                db.PhieuTraHangs.InsertOnSubmit(objPhieuTraHang);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertReturnOrderDetail(OrderDetailBO model)
        {
            try
            {
                CTPhieuTraHang objCTPhieuTraHang = new CTPhieuTraHang();
                objCTPhieuTraHang.MaPTH = model.MaHD;
                objCTPhieuTraHang.MaSP = model.MaSP;
                objCTPhieuTraHang.SoLuong = model.SoLuong;
                objCTPhieuTraHang.NgayHetHan = DateTime.Parse(model.Ngay);
                db.CTPhieuTraHangs.InsertOnSubmit(objCTPhieuTraHang);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetIdNew()
        {
            return db.PhieuTraHangs.OrderByDescending(t => t.MaPTH).Select(t => t.MaPTH).FirstOrDefault();
        }
    }
}
