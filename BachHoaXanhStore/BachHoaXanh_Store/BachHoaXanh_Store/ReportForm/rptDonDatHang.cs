using BLL_DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace BachHoaXanh_Store.ReportForm
{
    public partial class rptDonDatHang : DevExpress.XtraReports.UI.XtraReport
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public rptDonDatHang()
        {
            InitializeComponent();
            FormLoad();
        }

       
        public void FormLoad()
        {
            pMaDonDat.Text = GenerateCode();
            pMaNhaCungCap.Text = FormDatHang.strCustomerName; ;
            pTongTien.Text = FormDatHang.intTotalPrice.ToString();
            pNgayTra.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            xrLabel16.Text = "TP.HCM, ngày "+ DateTime.Now.Day.ToString() + " tháng "+ DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }
        public string GenerateCode()
        {
            var model = db.HoaDonDatNCCs.Select(t => t).Count() + 1;
            return model.ToString();
        }
    }
}
