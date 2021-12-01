using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductTypeBO
    {
        public int MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public string FullName { get { return string.Format(this.MaLoaiSP.ToString() + "-" + this.TenLoaiSP); } }
    }
}
