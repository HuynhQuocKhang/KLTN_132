using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class ProductBLL
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public ProductBLL()
        {

        }
        //Lấy danh sách tất cả sản phẩm
        public IQueryable<SanPham> GetListAllProdyct()
        {
            return db.SanPhams.Select(t => t);
        }

        //Lấy danh sách sản phẩm theo keyword và mã nhà cung cấp
        public IQueryable<SanPham> GetProductByKeys(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                return db.SanPhams.Select(t => t).Where(t => t.MaSP.Contains(strkeywords.Trim()) || t.TenSP.Contains(strkeywords.Trim()));
            }
            if (intCustomerId == 0)
            {
                return db.SanPhams.Select(t => t).Where(t => t.MaSP.Contains(strkeywords.Trim()) || t.TenSP.Contains(strkeywords.Trim()) && t.MaLoaiSP == intProductTypeId);
            }
            else
            {
                return db.SanPhams.Select(t => t).Where(t => t.MaSP.Contains(strkeywords.Trim()) || t.TenSP.Contains(strkeywords.Trim()) && t.MaNCC == intCustomerId);
            }
        }

        //Thêm danh sách Sản phẩm
        public bool InsertMultyProduct(List<SanPham> lstProduct)
        {
            try
            {
                foreach (SanPham item in lstProduct)
                {
                    SanPham objSanPham = new SanPham();
                    objSanPham.TenSP = item.TenSP;
                    objSanPham.MaLoaiSP = item.MaLoaiSP;
                    objSanPham.MaNCC = item.MaNCC;
                    objSanPham.DVT = item.DVT;
                    objSanPham.GiaBan = item.GiaBan;
                    objSanPham.GiaVon = item.GiaVon;
                    objSanPham.Isdeleted = false;
                    db.SanPhams.InsertOnSubmit(objSanPham);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xóa danh sách Sản phẩm
        public bool DeleteMultiProduct(List<SanPham> lstProduct)
        {
            try
            {
                foreach (SanPham item in lstProduct)
                {
                    var objProduct = db.SanPhams.SingleOrDefault(t => t.MaSP == item.MaSP);
                    objProduct.Isdeleted = true;
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
