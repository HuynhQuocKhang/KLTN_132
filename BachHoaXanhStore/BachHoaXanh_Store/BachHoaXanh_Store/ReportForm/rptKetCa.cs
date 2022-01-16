using BLL_DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BachHoaXanh_Store.ReportForm
{
    public partial class rptKetCa : DevExpress.XtraReports.UI.XtraReport
    {
        StoreBLL objStoreBLL = new StoreBLL();
        public rptKetCa()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            lbl_Start.Text = DateTime.Now.AddHours(-8).ToString() ;
            lbl_End.Text = DateTime.Now.ToString();
            xrLabel10.Text = objStoreBLL.getStoreAddressByUser(FormLogin.objUserBO.StoreId);
            lbl_MaNhanVien.Text = FormLogin.objUserBO.UserFullName;
            lbl_TongTien.Text= FormKetCa.pTotal.ToString();
            xrLabel13.Text = FormKetCa.p500.ToString();
            xrLabel16.Text = FormKetCa.p200.ToString();
            xrLabel19.Text = FormKetCa.p100.ToString();
            xrLabel22.Text = FormKetCa.p50.ToString();
            xrLabel25.Text = FormKetCa.p20.ToString();
            xrLabel28.Text = FormKetCa.p10.ToString();
            xrLabel34.Text = FormKetCa.p5.ToString();
            xrLabel31.Text = FormKetCa.p2.ToString();
            xrLabel40.Text = FormKetCa.p1.ToString();
            xrLabel37.Text = FormKetCa.p12.ToString();

            xrLabel14.Text = (500000*FormKetCa.p500).ToString();
            xrLabel17.Text = (200000*FormKetCa.p200).ToString();
            xrLabel18.Text = (100000*FormKetCa.p100).ToString();
            xrLabel21.Text = (50000*FormKetCa.p50).ToString();
            xrLabel24.Text = (20000*FormKetCa.p20).ToString();
            xrLabel26.Text = (10000*FormKetCa.p10).ToString();
            xrLabel35.Text = (5000*FormKetCa.p5).ToString();
            xrLabel32.Text = (2000*FormKetCa.p2).ToString();
            xrLabel41.Text = (1000*FormKetCa.p1).ToString();
            xrLabel38.Text = (500*FormKetCa.p12).ToString();
            xrLabel45.Text = ((500000 * FormKetCa.p500) + (200000 * FormKetCa.p200) + (100000 * FormKetCa.p100) + (50000 * FormKetCa.p50) + (20000 * FormKetCa.p20) + (10000 * FormKetCa.p10) + (5000 * FormKetCa.p5) + (2000 * FormKetCa.p2) + (1000 * FormKetCa.p1) + (500 * FormKetCa.p12)).ToString();
            xrLabel43.Text = FormKetCa.pTotalReality.ToString();
            lbl_MaST.Text = objStoreBLL.getStoreNameByUser(FormLogin.objUserBO.StoreId);
        }    
        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {



        }
    }
}
