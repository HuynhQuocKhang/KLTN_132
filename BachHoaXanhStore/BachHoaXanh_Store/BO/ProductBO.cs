using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductBO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int? MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public int? MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DVT { get; set; }
        public int? GiaBan { get; set; }
        public int? GiaVon { get; set; }
        public int? SoLuong { get; set; }
    }

    public class ProductOrderCustomerBO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string DVT { get; set; }
        public int? GiaVon { get; set; }
        public int? SoLuong { get; set; }
    }

    public class ProductPromotionBO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int? MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public int? MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DVT { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? NgayKM { get; set; }
        public DateTime? NgayHetHan { get; set; }
    }
}
