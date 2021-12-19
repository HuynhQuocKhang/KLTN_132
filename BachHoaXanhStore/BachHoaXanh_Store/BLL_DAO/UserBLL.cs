using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAO
{
    public class UserBLL
    {
        BachHoaXanhDataContext data = new BachHoaXanhDataContext();
        public UserBO GetUserByKey(string strUsertName, string strPassWord)
        {
            var model = from objNhanVien in data.NhanViens
                        where objNhanVien.TenDN == strUsertName && objNhanVien.MatKhau == strPassWord
                        select new UserBO()
                        {
                            UserId = objNhanVien.MaNV,
                            UserName = objNhanVien.TenDN,
                            PassWord = objNhanVien.MatKhau,
                            Permission = objNhanVien.Quyen,
                            StoreId = objNhanVien.MaST,
                            UserFullName = objNhanVien.HoTen
                        };
            return model.FirstOrDefault();
        }
    }
}
