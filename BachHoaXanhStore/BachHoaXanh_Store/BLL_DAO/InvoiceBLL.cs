using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class InvoiceBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public bool InsertInvoice(InvoiceBO model)
        {
            try
            {
                HoaDonBanHang objHoaDonBanHang = new HoaDonBanHang();
                objHoaDonBanHang.MaHD = model.MaHD;
                objHoaDonBanHang.MaST = model.MaST;
                objHoaDonBanHang.MaNV = model.MaNV;
                objHoaDonBanHang.NgayTao = model.NgayTao;
                objHoaDonBanHang.Isdeleted = false;
                objHoaDonBanHang.TongSP = model.TongSP;
                objHoaDonBanHang.ThanhTien = model.ThanhTien;
                db.HoaDonBanHangs.InsertOnSubmit(objHoaDonBanHang);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertInvoiceDetail(List<InvoiceDetailBO> lstInvoiceDetail)
        {
            try
            {
                foreach(InvoiceDetailBO item in lstInvoiceDetail)
                {
                    CTHoaDonBanHang objCTHoaDonBanHang = new CTHoaDonBanHang();
                    objCTHoaDonBanHang.MaHD = item.MaHD;
                    objCTHoaDonBanHang.MaSP = item.MaSP;
                    objCTHoaDonBanHang.KhuyenMai = item.KhuyenMai;
                    objCTHoaDonBanHang.SoLuong = item.SoLuong;
                    objCTHoaDonBanHang.ThanhTien = item.ThanhTien;
                    db.CTHoaDonBanHangs.InsertOnSubmit(objCTHoaDonBanHang);
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int CountInvoicebyCreateDate(DateTime dateCreatedDay)
        {
            return db.HoaDonBanHangs.Count(x => x.NgayTao == dateCreatedDay);
        }
    }
}
