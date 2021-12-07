using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ReturnProductBO
    {
        public int MaPTH { get; set; }
        public string NguoiLapPhieu { get; set; }
        public int? MaST { get; set; }
        public int MaNCC { get; set; }
        public DateTime NgayTra { get; set; }
        public int TongTien { get; set; }
        public bool Isdeleted { get; set; }
        public int TinhTrang { get; set; }
    }
}
