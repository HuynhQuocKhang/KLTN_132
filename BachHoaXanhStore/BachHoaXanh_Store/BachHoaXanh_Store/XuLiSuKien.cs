using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachHoaXanh_Store
{
    public class XuLiSuKien
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public IQueryable<SanPham> loadGridSanPham()
        {
            return db.SanPhams.Select(t => t);
        }
        public IQueryable<NhaCungCap> loadComboboxNhaCC()
        {
            return db.NhaCungCaps.Select(t => t);
        }
    }
}
