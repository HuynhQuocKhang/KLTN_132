using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class InvoiceBO
    {
        public string MaHD { get; set; }
        public int? MaST { get; set; }
        public int? MaNV { get; set; }
        public DateTime? NgayTao { get; set; }
        public bool Isdeleted { get; set; }
        public int? TongSP { get; set; }
        public int? ThanhTien { get; set; }
    }

    public class InvoiceDetailBO
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int? SoLuong { get; set; }
        public int? ThanhTien { get; set; }
    }
}
