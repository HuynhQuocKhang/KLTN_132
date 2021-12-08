using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class StoreBO
    {
        public int? MaST { get; set; }
        public string TenST { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string FullName { get { return string.Format(this.MaST.ToString() + " - " + this.TenST); } }
    }
}
