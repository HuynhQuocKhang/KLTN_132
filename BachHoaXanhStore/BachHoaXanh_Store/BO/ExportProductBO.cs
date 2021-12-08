using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ExportProductBO
    {
        public int? MaPXK { get; set; }
        public int? MaDH { get; set; }
        public int? MaST { get; set; }
        public string NguoiLapPhieu { get; set; }
        public int? TongTien { get; set; }
        public DateTime NgayXuat { get; set; }
        public bool Isdeleted { get; set; }
    }

    public class ExportProductDetailBO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int? SoLuong { get; set; }
        public int? ThanhTien { get; set; }
    }
}
