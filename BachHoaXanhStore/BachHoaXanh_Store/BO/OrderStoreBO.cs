using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderStoreBO
    {
        public int MaHD { get; set; }
        public int? MaST { get; set; }
        public string NguoiLapPhieu { get; set; }
        public DateTime? NgayDat { get; set; }
        public int? TinhTrang { get; set; }
        public int? TongTien { get; set; }
        public bool Isdeleted { get; set; }
    }
}
