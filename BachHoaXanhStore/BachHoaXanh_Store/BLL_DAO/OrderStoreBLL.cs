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
        public List<OrderStoreBO> GetListOrderStoreByKey(int intStoreId/*, DateTime dateFrom, DateTime dateTo*/, int intStatus)
        {
            var model = from objOrderStore in db.DonDatHangs
                        where objOrderStore.TinhTrang == intStatus && objOrderStore.MaST == intStoreId
                        select new OrderStoreBO()
                        {
                            MaHD = objOrderStore.MaDH,
                            MaST = objOrderStore.MaST,
                            NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                            NgayDat = objOrderStore.NgayDat,
                            TinhTrang = objOrderStore.TinhTrang,
                            TongTien = objOrderStore.TongTien
                        };
            return model.OrderByDescending(x => x.MaHD).ToList();
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

        //Xóa đơn đặt hàng ST
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

        //Lấy mã đơn hàng mới nhất
        public int GetOrderStoreIdNew()
        {
            return db.DonDatHangs.OrderByDescending(t => t.MaDH).Select(t => t.MaDH).FirstOrDefault();
        }

        //Lấy danh sách sản phẩm từ kho ST
        public List<ProductOrderCustomerBO> GetProductFromStore(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0, int intStock = 0, int intPageSize = 50, int intStoreId = 1)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
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
                            where objProduct.Isdeleted == false && objProduct.MaLoaiSP == intProductTypeId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objStore.MaST == intStoreId)
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
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objStore.MaST == intStoreId)
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
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objProduct.MaLoaiSP == intProductTypeId && objStore.MaST == intStoreId)
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

        //Lấy danh sách sản phẩm từ kho ST
        public List<ProductBO> GetProductBOFromStore(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0, int intStock = 0, int intPageSize = 50, int intStoreId = 1)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                var model = from objProduct in db.SanPhams
                            join objStore in db.KhoSieuThis
                            on objProduct.MaSP equals objStore.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && (objProduct.TenSP.Contains(strkeywords.Trim()) || objStore.MaSP.Contains(strkeywords.Trim())) && objStore.MaST == intStoreId
                            select new ProductBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intCustomerId == 0 && intProductTypeId != 0)
            {
                var model = from objProduct in db.SanPhams
                            join objStore in db.KhoSieuThis
                            on objProduct.MaSP equals objStore.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaLoaiSP == intProductTypeId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim())) && objStore.SoLuong <= intStock && objStore.MaST == intStoreId
                            select new ProductBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intProductTypeId == 0 && intCustomerId != 0)
            {
                var model = from objProduct in db.SanPhams
                            join objStore in db.KhoSieuThis
                            on objProduct.MaSP equals objStore.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim())) && objStore.SoLuong <= intStock && objStore.MaST == intStoreId
                            select new ProductBO()
                            {
                                MaSP = objProduct.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };

                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            else
            {
                var model = from objProduct in db.SanPhams
                            join objStore in db.KhoSieuThis
                            on objProduct.MaSP equals objStore.MaSP
                            join objProductType in db.LoaiSPs
                            on objProduct.MaLoaiSP equals objProductType.MaLoaiSP
                            join objCustomer in db.NhaCungCaps
                            on objProduct.MaNCC equals objCustomer.MaNCC
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim())) && objStore.SoLuong <= intStock && objProduct.MaLoaiSP == intProductTypeId && objStore.MaST == intStoreId
                            select new ProductBO()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                TenLoaiSP = objProductType.TenLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                TenNCC = objCustomer.TenNCC,
                                DVT = objProduct.DVT,
                                GiaVon = objProduct.GiaVon,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
        }

        //Get danh sách ddonwd dặt hàng
        public List<GetOrderFromStoreBO> GetOrderFromStoreBO(int intStoreId, DateTime dateFrom, DateTime dateTo)
        {
            if (intStoreId == 0)
            {
                var model = from objOrderStore in db.DonDatHangs
                            where objOrderStore.TinhTrang == 0
                            select new GetOrderFromStoreBO()
                            {
                                MaHD = objOrderStore.MaDH,
                                MaST = objOrderStore.MaST,
                                NgayDat = objOrderStore.NgayDat,
                                TongTien = objOrderStore.TongTien,
                            };
                return model.OrderByDescending(x => x.MaHD).Where(x => x.NgayDat <= dateTo && x.NgayDat >= dateFrom).ToList();
            }
            else
            {
                var model = from objOrderStore in db.DonDatHangs
                            where objOrderStore.TinhTrang == 0
                            select new GetOrderFromStoreBO()
                            {
                                MaHD = objOrderStore.MaDH,
                                MaST = objOrderStore.MaST,
                                NgayDat = objOrderStore.NgayDat,
                                TongTien = objOrderStore.TongTien,
                            };
                return model.OrderByDescending(x => x.MaHD).Where(x => x.NgayDat <= dateTo && x.NgayDat >= dateFrom && x.MaST == intStoreId).ToList();
            }
        }
        public int countAllOrderFromStore()
        {
            var entities = from objOrderStore in db.DonDatHangs
                           select new OrderStoreBO()
                           {
                               MaHD = objOrderStore.MaDH,
                               MaST = objOrderStore.MaST,
                               NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                               NgayDat = objOrderStore.NgayDat,
                               TongTien = objOrderStore.TongTien,
                               TinhTrang = objOrderStore.TinhTrang
                           };
            return entities.Count();
        }
        public int countOrderFromStore()
        {
            var entities = db.DonDatHangs.Where(x => x.TinhTrang == 0).ToList();
            return entities.Count();
        }
        public int countTransferFromStore()
        {
            var entities = from objOrderStore in db.DonDatHangs
                           where objOrderStore.TinhTrang == 1
                           select new OrderStoreBO()
                           {
                               MaHD = objOrderStore.MaDH,
                               MaST = objOrderStore.MaST,
                               NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                               NgayDat = objOrderStore.NgayDat,
                               TongTien = objOrderStore.TongTien,
                               TinhTrang = objOrderStore.TinhTrang
                           };
            return entities.Count();
        }
        public int sumAllValueOrderFormStore()
        {
            var entities = from objOrderStore in db.DonDatHangs
                           select new OrderStoreBO()
                           {
                               MaHD = objOrderStore.MaDH,
                               MaST = objOrderStore.MaST,
                               NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                               NgayDat = objOrderStore.NgayDat,
                               TongTien = objOrderStore.TongTien,
                               TinhTrang = objOrderStore.TinhTrang
                           };
            return int.Parse(entities.Sum(x => x.TongTien).ToString());
        }
        public int sumValueOrderFormStore()
        {
            var entities = db.DonDatHangs.Where(x => x.TinhTrang == 0).ToList();
            if (entities.Count > 0)
            {
                return int.Parse(entities.Sum(x => x.TongTien).ToString());
            }
            else
            {
                return 0;
            }
        }

        public List<OrderStoreBO> GetOrderFromStoreBO(int intStoreId, int pTinhTrang, string strkeywords = "")
        {
            if (pTinhTrang == 3)
            {
                if (intStoreId == 0)
                {
                    var model = from objOrderStore in db.DonDatHangs
                                where objOrderStore.NguoiLapPhieu.ToLower().Contains(strkeywords.ToLower().Trim()) || objOrderStore.MaDH.ToString().Contains(strkeywords.Trim())
                                select new OrderStoreBO()
                                {
                                    MaHD = objOrderStore.MaDH,
                                    MaST = objOrderStore.MaST,
                                    NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                                    NgayDat = objOrderStore.NgayDat,
                                    TongTien = objOrderStore.TongTien,
                                    TinhTrang = objOrderStore.TinhTrang
                                };
                    return model.OrderByDescending(x => x.MaHD).ToList();
                }
                else
                {
                    var model = from objOrderStore in db.DonDatHangs
                                where objOrderStore.NguoiLapPhieu.ToLower().Contains(strkeywords.ToLower().Trim()) || objOrderStore.MaDH.ToString().Contains(strkeywords.Trim())
                                select new OrderStoreBO()
                                {
                                    MaHD = objOrderStore.MaDH,
                                    MaST = objOrderStore.MaST,
                                    NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                                    NgayDat = objOrderStore.NgayDat,
                                    TongTien = objOrderStore.TongTien,
                                    TinhTrang = objOrderStore.TinhTrang
                                };
                    return model.OrderByDescending(x => x.MaHD).Where(x => x.MaST == intStoreId).ToList();
                }
            }
            else
            {
                if (intStoreId == 0)
                {
                    var model = from objOrderStore in db.DonDatHangs
                                select new OrderStoreBO()
                                {
                                    MaHD = objOrderStore.MaDH,
                                    MaST = objOrderStore.MaST,
                                    NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                                    NgayDat = objOrderStore.NgayDat,
                                    TongTien = objOrderStore.TongTien,
                                    TinhTrang = objOrderStore.TinhTrang
                                };
                    return model.OrderByDescending(x => x.MaHD).Where(x => x.TinhTrang == pTinhTrang).ToList();
                }
                else
                {
                    var model = from objOrderStore in db.DonDatHangs
                                select new OrderStoreBO()
                                {
                                    MaHD = objOrderStore.MaDH,
                                    MaST = objOrderStore.MaST,
                                    NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                                    NgayDat = objOrderStore.NgayDat,
                                    TongTien = objOrderStore.TongTien,
                                    TinhTrang = objOrderStore.TinhTrang
                                };
                    return model.OrderByDescending(x => x.MaHD).Where(x => x.TinhTrang == pTinhTrang && x.MaST == intStoreId).ToList();
                }
            }
        }

        public bool UpdateOrderStoreStatus(int intOrderStoreId)
        {
            try
            {
                var objDonDatHang = db.DonDatHangs.Where(x => x.MaDH == intOrderStoreId).FirstOrDefault();
                objDonDatHang.TinhTrang += 1;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReturnProductStoreStatus(int intOrderStoreId, List<ProductBO> lstProduct, int intStoreId)
        {
            try
            {
                var objPhieuTraHang = db.PhieuTraHangs.Where(x => x.MaPTH == intOrderStoreId).FirstOrDefault();
                objPhieuTraHang.TinhTrang = 1;
                foreach (ProductBO item in lstProduct)
                {
                    var objProduct = db.SanPhams.Where(x => x.MaSP == item.MaSP).FirstOrDefault();
                    objProduct.SoLuong += item.SoLuong;

                    var objProductStore = db.KhoSieuThis.Where(x => x.MaST == intStoreId && x.MaSP == item.MaSP).FirstOrDefault();
                    objProductStore.SoLuong -= item.SoLuong;
                    db.SubmitChanges();
                }

                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int countReturnProductOrder()
        {
            var model = from objOrderStore in db.PhieuTraHangs
                        where objOrderStore.TinhTrang == 0
                        select new GetReturnProductsBO()
                        {
                            MaPTH = objOrderStore.MaPTH,
                            MaST = objOrderStore.MaST,
                            MaNCC = objOrderStore.MaNCC,
                            NgayTra = objOrderStore.NgayTra,
                            NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                            TongTien = objOrderStore.TongTien
                        };
            return model.Count();
        }
        public int sumValueReturnProductOrder()
        {
            var model = from objOrderStore in db.PhieuTraHangs
                        where objOrderStore.TinhTrang == 0
                        select new GetReturnProductsBO()
                        {
                            MaPTH = objOrderStore.MaPTH,
                            MaST = objOrderStore.MaST,
                            MaNCC = objOrderStore.MaNCC,
                            NgayTra = objOrderStore.NgayTra,
                            NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                            TongTien = objOrderStore.TongTien
                        };
            int total = 0;
            foreach (var item in model)
            {
                total += (int)item.TongTien;
            }
            return total;
        }
        public List<GetReturnProductsBO> GetReturnProductOrder(string pKeyWord, string strStoreId, DateTime dateFrom, DateTime dateTo)
        {
            if (pKeyWord != "")
            {
                var model = from objOrderStore in db.PhieuTraHangs
                            where (objOrderStore.MaPTH.ToString().Contains(pKeyWord.Trim()) ||
                                   objOrderStore.NguoiLapPhieu.ToString().Contains(pKeyWord.Trim())) &&
                                   objOrderStore.MaST == int.Parse(strStoreId.ToLower().Trim()) &&
                                   objOrderStore.TinhTrang == 0
                            select new GetReturnProductsBO()
                            {
                                MaPTH = objOrderStore.MaPTH,
                                MaST = objOrderStore.MaST,
                                MaNCC = objOrderStore.MaNCC,
                                NgayTra = objOrderStore.NgayTra,
                                NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                                TongTien = objOrderStore.TongTien
                            };
                return model.OrderBy(x => x.MaPTH).Where(x => x.NgayTra <= dateTo && x.NgayTra >= dateFrom).ToList();
            }
            else
            {
                var model = from objOrderStore in db.PhieuTraHangs
                            where objOrderStore.MaST == (int.Parse(strStoreId.ToLower().Trim())) && objOrderStore.TinhTrang == 0
                            select new GetReturnProductsBO()
                            {
                                MaPTH = objOrderStore.MaPTH,
                                MaST = objOrderStore.MaST,
                                MaNCC = objOrderStore.MaNCC,
                                NgayTra = objOrderStore.NgayTra,
                                NguoiLapPhieu = objOrderStore.NguoiLapPhieu,
                                TongTien = objOrderStore.TongTien
                            };
                return model.OrderBy(x => x.MaPTH).Where(x => x.NgayTra <= dateTo && x.NgayTra >= dateFrom).ToList();
            }

        }

        //Lấy Danh sách Sản phẩm Kho KM
        public List<ProductPromotionBO> GetProductPromotionFromStore(string strProductId, int intStoreId)
        {
            try
            {
                var model = from objProductPromo in db.KhoHangKMs
                            join objProduct in db.SanPhams
                            on objProductPromo.MaSP equals objProduct.MaSP
                            where objProductPromo.MaSP == strProductId && objProductPromo.MaST == intStoreId
                            select new ProductPromotionBO()
                            {
                                MaSP = objProductPromo.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                DVT = objProduct.DVT,
                                GiaBan = objProduct.GiaBan,
                                GiaKM = objProductPromo.GiaKM,
                                SoLuong = objProductPromo.SoLuong,
                                NgayKM = objProductPromo.NgayKM,
                                NgayHetHan = objProductPromo.NgayHetHan
                            };
                return model.ToList();
            }
            catch
            {
                return new List<ProductPromotionBO>();
            }
        }

        public bool UpdateListProductPromotion(List<ProductBO> lstProduct, int intStoreId)
        {
            try
            {
                foreach (ProductBO item in lstProduct)
                {
                    var objPromo = db.KhoHangKMs.Where(x => x.MaSP == item.MaSP && x.MaST == intStoreId).FirstOrDefault();
                    objPromo.SoLuong -= item.SoLuong;
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertOrUpdateProductPromotion(ProductPromotionBO objProductPromotionBO, int intStoreId, bool isUpdate)
        {
            var objProductStore = db.KhoSieuThis.Where(x => x.MaSP == objProductPromotionBO.MaSP && x.MaST == intStoreId).FirstOrDefault();
            try
            {
                if (isUpdate)
                {
                    var objProductPromo = db.KhoHangKMs.Where(x => x.MaSP == objProductPromotionBO.MaSP && x.MaST == intStoreId).FirstOrDefault();

                    if (objProductPromo.SoLuong > objProductPromotionBO.SoLuong)
                    {
                        int? intStockUpdate = objProductPromo.SoLuong - objProductPromotionBO.SoLuong;
                        objProductPromo.SoLuong = objProductPromotionBO.SoLuong;
                        objProductStore.SoLuong += intStockUpdate;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        int? intStockUpdate = objProductPromotionBO.SoLuong - objProductPromo.SoLuong;
                        objProductPromo.SoLuong = objProductPromotionBO.SoLuong;
                        objProductStore.SoLuong -= intStockUpdate;
                        db.SubmitChanges();
                        return true;
                    }
                }
                else
                {
                    KhoHangKM objKhoHangKM = new KhoHangKM();
                    objKhoHangKM.MaSP = objProductPromotionBO.MaSP;
                    objKhoHangKM.MaST = intStoreId;
                    objKhoHangKM.NgayKM = objProductPromotionBO.NgayKM;
                    objKhoHangKM.NgayHetHan = objProductPromotionBO.NgayHetHan;
                    objKhoHangKM.SoLuong = objProductPromotionBO.SoLuong;
                    db.KhoHangKMs.InsertOnSubmit(objKhoHangKM);
                    objProductStore.SoLuong -= objProductPromotionBO.SoLuong;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProductPromoTion(ProductPromotionBO objProductPromotionBO, int intStoreId)
        {
            try
            {
                var objProductStore = db.KhoSieuThis.Where(x => x.MaSP == objProductPromotionBO.MaSP && x.MaST == intStoreId).FirstOrDefault();
                objProductStore.SoLuong += objProductPromotionBO.SoLuong;
                var objProductPromo = db.KhoHangKMs.Where(x => x.MaSP == objProductPromotionBO.MaSP && x.MaST == intStoreId).FirstOrDefault();
                db.KhoHangKMs.DeleteOnSubmit(objProductPromo);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateMultiProductFromStore(List<ProductBO> lstProduct, int intMaST)
        {
            try
            {
                for (int i = 0; i < lstProduct.Count; i++)
                {
                    var objProduct = db.KhoSieuThis.Where(x => x.MaST == intMaST && x.MaSP == lstProduct[i].MaSP).FirstOrDefault();
                    objProduct.SoLuong -= lstProduct[i].SoLuong;
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Hàm dùng riêng cho form Tìm kiếm - Mục đích bán hàng
        public List<ProductFromStoreFromSearch> GetProductFromStoreFromSearchUsing(string strkeywords = "", int intProductTypeId = 0, int intCustomerId = 0, int intStock = 0, int intPageSize = 50, int intStoreId = 1)
        {
            if (intCustomerId == 0 && intProductTypeId == 0)
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            where objProduct.Isdeleted == false && (objProduct.TenSP.Contains(strkeywords.Trim()) || objStore.MaSP.Contains(strkeywords.Trim()) && objStore.MaST == intStoreId)
                            select new ProductFromStoreFromSearch()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intCustomerId == 0 && intProductTypeId != 0)
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            where objProduct.Isdeleted == false && objProduct.MaLoaiSP == intProductTypeId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objStore.MaST == intStoreId)
                            select new ProductFromStoreFromSearch()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            if (intProductTypeId == 0 && intCustomerId != 0)
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objStore.MaST == intStoreId)
                            select new ProductFromStoreFromSearch()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };

                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
            else
            {
                var model = from objStore in db.KhoSieuThis
                            join objProduct in db.SanPhams
                            on objStore.MaSP equals objProduct.MaSP
                            where objProduct.Isdeleted == false && objProduct.MaNCC == intCustomerId && (objProduct.TenSP.Contains(strkeywords.Trim()) || objProduct.MaSP.Contains(strkeywords.Trim()) && objProduct.MaLoaiSP == intProductTypeId && objStore.MaST == intStoreId)
                            select new ProductFromStoreFromSearch()
                            {
                                MaSP = objStore.MaSP,
                                TenSP = objProduct.TenSP,
                                GiaBan = objProduct.GiaBan,
                                SoLuong = objStore.SoLuong
                            };
                return model.OrderByDescending(x => x.MaSP).Where(x => x.SoLuong <= intStock).Take(intPageSize).ToList();
            }
        }

        public List<ProductPromotionBO> GetProductPromotionFromStoreByKey(string strProductId, int intStoreId, int pagesize)
        {
            try
            {
                var model = from objProductPromo in db.KhoHangKMs
                            join objProduct in db.SanPhams
                            on objProductPromo.MaSP equals objProduct.MaSP
                            where (objProductPromo.MaSP.Contains(strProductId) || objProduct.TenSP.Contains(strProductId)) && objProductPromo.MaST == intStoreId
                            select new ProductPromotionBO()
                            {
                                MaSP = objProductPromo.MaSP,
                                TenSP = objProduct.TenSP,
                                MaLoaiSP = objProduct.MaLoaiSP,
                                MaNCC = objProduct.MaNCC,
                                DVT = objProduct.DVT,
                                GiaBan = objProduct.GiaBan,
                                GiaKM = objProductPromo.GiaKM,
                                SoLuong = objProductPromo.SoLuong,
                                NgayKM = objProductPromo.NgayKM,
                                NgayHetHan = objProductPromo.NgayHetHan
                            };
                return model.OrderByDescending(x => x.MaSP).Take(pagesize).ToList();
            }
            catch
            {
                return new List<ProductPromotionBO>();
            }
        }
    }
}
