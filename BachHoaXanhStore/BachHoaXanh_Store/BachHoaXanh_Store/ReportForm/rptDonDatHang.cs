using BLL_DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using BarcodeLib;
namespace BachHoaXanh_Store.ReportForm
{
    public partial class rptDonDatHang : DevExpress.XtraReports.UI.XtraReport
    {
        Barcode barcode;
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public rptDonDatHang()
        {
            InitializeComponent();
            FormLoad();
        }

       
        public void FormLoad()
        {
            pMaDonDat.Text = GenerateCode();
            pMaNhaCungCap.Text = FormDatHang.strCustomerName;
            pTongTien.Text = FormDatHang.intTotalPrice.ToString();
            pNgayTra.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            xrLabel16.Text = "TP.HCM, ngày "+ DateTime.Now.Day.ToString() + " tháng "+ DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            string strBarcode = pMaDonDat.Text;
            barcode = new Barcode();
            Image barCodeImage = barcode.Encode(TYPE.CODE128, strBarcode);
            img_barcode.Image = barCodeImage;
        }
        public string GenerateCode()
        {
            var model = db.HoaDonDatNCCs.Select(t => t).Count();
            return model.ToString();
        }
    }
}
