using BLL_DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace BachHoaXanh_Store.ReportForm
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        public Report()
        {
            InitializeComponent();
            FormLoad();
        }
        public void FormLoad()
        {
            pMaDonDat.Text = objOrderStoreBLL.GetOrderStoreIdNew().ToString();
            pMaST.Text = FormLogin.objUserBO.StoreId.ToString();
            pTongTien.Text = FormDatHang.intTotalPrice.ToString();
            pNgayDat.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            xrLabel16.Text = "TP.HCM, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
        }
    }
}
