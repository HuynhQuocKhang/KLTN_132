using BarcodeLib;
using BLL_DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace BachHoaXanh_Store.ReportForm
{
    public partial class rptPhieuXuatKho : DevExpress.XtraReports.UI.XtraReport
    {
        Barcode barcode;
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public rptPhieuXuatKho()
        {
            InitializeComponent();
            pMaPhieuXuat.Text = (db.PhieuXuatKhos.Select(t => t).Count()).ToString();
            pMaSieuThi.Text = FormPhanPhoiHang.objExportProductBO.MaST.ToString();
            pDonDatHang.Text = FormPhanPhoiHang.objExportProductBO.MaDH.ToString();
            pTongTien.Text = FormPhanPhoiHang.objExportProductBO.TongTien.ToString();
            pNgayXuat.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            xrLabel16.Text = "TP.HCM, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            string strBarcode = pMaPhieuXuat.Text + pMaSieuThi.Text + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + pMaPhieuXuat.Text;
            barcode = new Barcode();
            Image barCodeImage = barcode.Encode(TYPE.CODE128, strBarcode);
            img_barcode.Image = barCodeImage;
        }

    }
}
