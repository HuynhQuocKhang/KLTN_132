using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CustomerBO
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }

        public string FullName
        {
            get { return string.Format(this.MaNCC.ToString() + " - " + this.TenNCC); }
        }
    }
}
