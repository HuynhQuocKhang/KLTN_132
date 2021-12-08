using BLL_DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace BachHoaXanh_Store.ReportForm
{
    public partial class rptPhieuTraHang : DevExpress.XtraReports.UI.XtraReport
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public rptPhieuTraHang()
        {
            InitializeComponent();
            pMaPhieuTra.Text = (db.PhieuTraHangs.Select(t => t).Count() + 1).ToString();
            pNgayTra.Text = DateTime.Now.Day.ToString()+"/"+ DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            if (FormLogin.objUserBO.Permission == 1)
            {
                lbl_MaSieuThi.Text = "Mã nhà cung cấp";
                pMaSieuThi.Text = FormTraHangNCC.intCustomerId.ToString();
            }
            else
            {
                lbl_MaSieuThi.Text = "Mã siêu thị";
                pMaSieuThi.Text = FormLogin.objUserBO.StoreId.ToString();
            }
        }

    }
}
