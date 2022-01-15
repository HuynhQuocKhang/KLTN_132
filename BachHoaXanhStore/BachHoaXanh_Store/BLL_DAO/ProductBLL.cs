using BO;
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
        public List<ProductBO> GetListAllProduct()
        {
            var model = from objProduct in db.SanPhams
                        join objProductType in db.LoaiSPs
                        on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                        join objCustomer in db.NhaCungCaps
                        on objProduct.MaNCC equals objCustomer.MaNCC
                        where objProduct.Isdeleted == false
                        select new ProductBO()
                        {
                            MaSP = objProduct.MaSP,
                            TenSP = objProduct.TenSP,
                            MaLoaiSP = objProduct.MaLoaiSP,
                            TenLoaiSP = objProductType.TenLoaiSP,
                            MaNCC = objProduct.MaNCC,
                            TenNCC = objCustomer.TenNCC,
                            DVT = objProduct.DVT,
                            GiaBan = objProduct.GiaBan,
                            GiaVon = objProduct.GiaVon,
                            SoLuong = objProduct.SoLuong
                        };
            model.OrderByDescending(x => x.MaSP);

            return model.ToList();
        }


        public int CountProductStore()
        {
            var model = from objProductStore in db.KhoSieuThis
                        select new ProductBO()
                        {
                            MaSP = objProductStore.MaSP,
                        };
            return model.ToList().Count();
        }

        //Lấy danh sách sản phẩm theo keyword và mã nhà cung cấp
        public List<ProductBO> GetProductByKeys(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0, int intPageSize = 50)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()))
                            orderby objProduct.MaSP descending
                            select new ProductBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaBan = objProduct.GiaBan,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };


                return model.OrderByDescending(x => x.MaSP).Take(intPageSize).ToList();
            }
            if (intCustomerId == 0 && intProductTypeId != 0)
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaLoaiSP == intProductTypeId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()))
                            select new ProductBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaBan = objProduct.GiaBan,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Take(intPageSize).ToList();
            }
            if (intCustomerId != 0 && intProductTypeId == 0)
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()))
                            select new ProductBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaBan = objProduct.GiaBan,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Take(intPageSize).ToList();
            }
            else
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objProduct.MaLoaiSP == intProductTypeId)
                            select new ProductBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaBan = objProduct.GiaBan,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Take(intPageSize).ToList();
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
        public bool DeleteMultiProduct(List<ProductBO> lstProduct)
        {
            try
            {
                foreach (ProductBO item in lstProduct)
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

        public bool InsertOrUpdate(ProductBO model)
        {
            try
            {
                //Kiểm tra tồn tại
                var objCheckDuplicate = db.SanPhams.Where(x => x.MaSP == model.MaSP).FirstOrDefault();
                if (objCheckDuplicate == null)
                {
                    SanPham objSanPham = new SanPham();
                    objSanPham.MaSP = model.MaSP;
                    objSanPham.TenSP = model.TenSP;
                    objSanPham.MaLoaiSP = model.MaLoaiSP;
                    objSanPham.MaNCC = model.MaNCC;
                    objSanPham.DVT = model.DVT;
                    objSanPham.GiaBan = model.GiaBan;
                    objSanPham.GiaVon = model.GiaVon;
                    objSanPham.Isdeleted = false;
                    db.SanPhams.InsertOnSubmit(objSanPham);
                    db.SubmitChanges();
                }
                else
                {
                    objCheckDuplicate.TenSP = model.TenSP;
                    objCheckDuplicate.MaLoaiSP = model.MaLoaiSP;
                    objCheckDuplicate.MaNCC = model.MaNCC;
                    objCheckDuplicate.DVT = model.DVT;
                    objCheckDuplicate.GiaBan = model.GiaBan;
                    objCheckDuplicate.GiaVon = model.GiaVon;
                    objCheckDuplicate.SoLuong = model.SoLuong;
                    db.SubmitChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public SanPham GetProductByid(string strProductId)
        {
            var model = db.SanPhams.Where(x => x.MaSP == strProductId);
            return model.ToList().FirstOrDefault();
        }


        public List<ProductOrderCustomerBO> GetProductByKeysForOrderCustomer(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0, int intStock = 0, int intPageSize = 50)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()))
                            orderby objProduct.MaSP ascending

                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };

                return model.Where(t=>t.SoLuong<=intStock).Take(intPageSize).ToList();
            }
            if (intCustomerId == 0 && intProductTypeId != 0)
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaLoaiSP == intProductTypeId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()))
                            orderby objProduct.MaSP ascending

                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };
                return model.Where(t => t.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intProductTypeId == 0 && intCustomerId != 0)
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()))
                            orderby objProduct.MaSP ascending
                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };

                return model.Where(t => t.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            else
            {
                var model = from objProduct in db.SanPhams
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objProduct.MaLoaiSP == intProductTypeId)
                            orderby objProduct.MaSP ascending

                            select new ProductOrderCustomerBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                SoLuong = objProduct.SoLuong
                            };
                return model.Where(t => t.SoLuong <= intStock).Take(intPageSize).ToList();
            }
        }


        public List<ProductPromotionBO> GetProductPromotionFromStore(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0, int intStock = 0, int intPageSize = 50, int intStoreId = 1)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                var model = from objProduct in db.SanPhams
                            join objStorePromotion in db.KhoHangKMs
                            on objProduct.MaSP equals objStorePromotion.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && (objProduct.TenSP.Contains(strkeywords.Trim()) || objStorePromotion.MaSP.Contains(strkeywords.Trim())) && objStorePromotion.MaST == intStoreId
                            select new ProductPromotionBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                SoLuong = objStorePromotion.SoLuong,
                                GiaBan = objProduct.GiaBan,
                                GiaKM = objStorePromotion.GiaKM,
                                NgayKM = objStorePromotion.NgayKM,
                                NgayHetHan = objStorePromotion.NgayHetHan
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intCustomerId == 0 && intProductTypeId != 0)
            {
                var model = from objProduct in db.SanPhams
                            join objStorePromotion in db.KhoHangKMs
                            on objProduct.MaSP equals objStorePromotion.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaLoaiSP == intProductTypeId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim())) && objStorePromotion.SoLuong <= intStock && objStorePromotion.MaST == intStoreId
                            select new ProductPromotionBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                SoLuong = objStorePromotion.SoLuong,
                                GiaBan = objProduct.GiaBan,
                                GiaKM = objStorePromotion.GiaKM,
                                NgayKM = objStorePromotion.NgayKM,
                                NgayHetHan = objStorePromotion.NgayHetHan
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intProductTypeId == 0 && intCustomerId != 0)
            {
                var model = from objProduct in db.SanPhams
                            join objStorePromotion in db.KhoHangKMs
                            on objProduct.MaSP equals objStorePromotion.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim())) && objStorePromotion.SoLuong <= intStock && objStorePromotion.MaST == intStoreId
                            select new ProductPromotionBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                SoLuong = objStorePromotion.SoLuong,
                                GiaBan = objProduct.GiaBan,
                                GiaKM = objStorePromotion.GiaKM,
                                NgayKM = objStorePromotion.NgayKM,
                                NgayHetHan = objStorePromotion.NgayHetHan
                            };

                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            else
            {
                var model = from objProduct in db.SanPhams
                            join objStorePromotion in db.KhoHangKMs
                            on objProduct.MaSP equals objStorePromotion.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim())) && objStorePromotion.SoLuong <= intStock && objProduct.MaLoaiSP == intProductTypeId && objStorePromotion.MaST == intStoreId
                            select new ProductPromotionBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                SoLuong = objStorePromotion.SoLuong,
                                GiaBan = objProduct.GiaBan,
                                GiaKM = objStorePromotion.GiaKM,
                                NgayKM = objStorePromotion.NgayKM,
                                NgayHetHan = objStorePromotion.NgayHetHan
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
        }
    }
}
