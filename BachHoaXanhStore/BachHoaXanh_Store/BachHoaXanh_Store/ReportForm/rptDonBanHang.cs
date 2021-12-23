using BarcodeLib;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BachHoaXanh_Store.ReportForm
{
    public partial class rptDonBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        Barcode barcode;
        public rptDonBanHang()
        {
            InitializeComponent();
            lbl_MaHD.Text = FormBanHang.objInvoiceBO.MaHD;
            lbl_MaST.Text = FormBanHang.objInvoiceBO.MaST.ToString();
            lbl_MaNhanVien.Text = FormBanHang.objInvoiceBO.MaNV.ToString();
            lbl_NgayTao.Text = FormBanHang.objInvoiceBO.NgayTao.ToString();
            lbl_TongTien.Text = FormBanHang.objInvoiceBO.ThanhTien.ToString();

            string strBarcode = lbl_MaHD.Text;
            barcode = new Barcode();
            Image barCodeImage = barcode.Encode(TYPE.CODE128, strBarcode);
            img_barcode.Image = barCodeImage;
        }

    }
}
