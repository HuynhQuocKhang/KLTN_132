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
                        where objNhanVien.UserName == strUsertName && objNhanVien.Pass == strPassWord
                        select new UserBO()
                        {
                            UserId = objNhanVien.UserId,
                            UserName = objNhanVien.UserName,
                            PassWord = objNhanVien.Pass,
                            Permission = objNhanVien.Permisson,
                            StoreId = objNhanVien.StoreId,
                            UserFullName = objNhanVien.FullName
                        };
            return model.FirstOrDefault();
        }
    }
}
