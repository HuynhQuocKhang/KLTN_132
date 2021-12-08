using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderCustomerDetailBO
    {
        public int MaHDDat { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int GiaVon { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
        public string Ngay { get; set; }
    }

    public class OrderDetailBO
    {
        public int MaHD { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public string Ngay { get; set; }
    }

    public class GetListOrderStoreByOrderIdBO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int? SoLuong { get; set; }
    }
}
