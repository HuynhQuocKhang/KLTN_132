using BarcodeLib;
using BLL_DAO;
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
        StoreBLL objStoreBLL = new StoreBLL();
        public rptDonBanHang()
        {
            InitializeComponent();
            lbl_MaHD.Text = FormBanHang.objInvoiceBO.MaHD;
            lbl_MaST.Text = objStoreBLL.getStoreNameByUser(FormLogin.objUserBO.StoreId);
            lbl_NgayTao.Text = FormBanHang.objInvoiceBO.NgayTao.ToString();
            lbl_TongTien.Text = FormBanHang.objInvoiceBO.ThanhTien.ToString();
            xrLabel10.Text = objStoreBLL.getStoreAddressByUser(FormLogin.objUserBO.StoreId);
            lbl_MaNhanVien.Text = FormLogin.objUserBO.UserFullName;
            string strBarcode = lbl_MaHD.Text;
            barcode = new Barcode();
            Image barCodeImage = barcode.Encode(TYPE.CODE128, strBarcode);
            img_barcode.Image = barCodeImage;
        }

    }
}
