using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderCustomerBO
    {
        public int MaHDDat { get; set; }
        public int? MaNCC { get; set; }
        public int? TongTien { get; set; }
        public string NguoiLapPhieu { get; set; }
        public DateTime? NgayDat { get; set; }
        public int? TinhTrang { get; set; }
    }

    public class OrderCustomerGetOrder
    {
        public int MaHD { get; set; }
        public int? MaST { get; set; }
        public int? TongTien { get; set; }
        public string NguoiLapPhieu { get; set; }
        public DateTime? NgayDat { get; set; }
        public int? TinhTrang { get; set; }
    }
}
