using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class ExportProductBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public bool InsertExportProduct(ExportProductBO model)
        {
            try
            {
                PhieuXuatKho objPhieuXuatKho = new PhieuXuatKho();
                objPhieuXuatKho.MaDH = model.MaDH;
                objPhieuXuatKho.MaST = model.MaST;
                objPhieuXuatKho.NguoiLapPhieu = model.NguoiLapPhieu;
                objPhieuXuatKho.TongTien = model.TongTien;
                objPhieuXuatKho.NgayXuat = DateTime.Now;
                objPhieuXuatKho.Isdeleted = false;
                db.PhieuXuatKhos.InsertOnSubmit(objPhieuXuatKho);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetExportProductIdNew()
        {
            return db.PhieuXuatKhos.OrderByDescending(t => t.MaPXK).Select(t => t.MaPXK).FirstOrDefault();
        }

        public bool InsertExportProductDetail(List<ExportProductDetailBO> lstExportProductDetailBO, int intMaPXK)
        {
            try
            {
                foreach (ExportProductDetailBO item in lstExportProductDetailBO)
                {
                    CTPhieuXuatKho objCTPhieuXuatKho = new CTPhieuXuatKho();
                    objCTPhieuXuatKho.MaPXK = intMaPXK;
                    objCTPhieuXuatKho.MaSP = item.MaSP;
                    objCTPhieuXuatKho.SoLuong = item.SoLuong;
                    objCTPhieuXuatKho.ThanhTien = item.ThanhTien;
                    db.CTPhieuXuatKhos.InsertOnSubmit(objCTPhieuXuatKho);
                    db.SubmitChanges();
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
