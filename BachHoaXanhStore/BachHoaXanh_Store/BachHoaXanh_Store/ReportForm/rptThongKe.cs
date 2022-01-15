using BLL_DAO;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace BachHoaXanh_Store.ReportForm
{
    public partial class rptThongKe : DevExpress.XtraReports.UI.XtraReport
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public string SLDDH, SLPTH, SLPXK;
        public rptThongKe(string type)
        {
            InitializeComponent();
            loadChart(type);
        }
        public void loadChart(string type)
        {
            if (type == "ThongKeKho")
            {
                DateTime aDateTime = GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
                for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
                {
                    chr_SoLuong.Series["Đơn đặt hàng"].Points.AddPoint(aDateTime.ToShortDateString(), db.HoaDonDatNCCs.Select(t => t).Where(t => t.NgayDat == aDateTime).Count());
                    chr_SoLuong.Series["Phiếu trả hàng"].Points.AddPoint(aDateTime.ToShortDateString(), db.PhieuTraHangs.Select(t => t).Where(t => t.MaST == (-1) && t.NgayTra == aDateTime).Count());
                    chr_SoLuong.Series["Phiếu xuất kho"].Points.AddPoint(aDateTime.ToShortDateString(), db.PhieuXuatKhos.Select(t => t).Where(t => t.NgayXuat == aDateTime).Count());

                    SLDDH = db.DonDatHangs.Where(t => t.TinhTrang == 2 && t.NgayDat == aDateTime).Sum(t => t.TongTien).ToString();
                    SLPTH = db.PhieuTraHangs.Where(t => t.MaST == (-1) && t.TinhTrang == 1 && t.NgayTra == aDateTime).Sum(t => t.TongTien).ToString();
                    SLPXK = db.PhieuXuatKhos.Where(t => t.NgayXuat == aDateTime).Sum(t => t.TongTien).ToString();
                    if (string.IsNullOrEmpty(SLDDH))
                    {
                        SLDDH = "0";
                    }
                    if (string.IsNullOrEmpty(SLPTH))
                    {
                        SLPTH = "0";
                    }
                    if (string.IsNullOrEmpty(SLPXK))
                    {
                        SLPXK = "0";
                    }
                    chr_GiaTri.Series["Đơn đặt hàng"].Points.AddPoint(aDateTime.ToShortDateString(), double.Parse(SLDDH));
                    chr_GiaTri.Series["Phiếu trả hàng"].Points.AddPoint(aDateTime.ToShortDateString(), double.Parse(SLPTH));
                    chr_GiaTri.Series["Phiếu xuất kho"].Points.AddPoint(aDateTime.ToShortDateString(), double.Parse(SLPXK));
                    aDateTime = aDateTime.AddDays(1);
                }
            }
            else
            {
                chr_SoLuong.Series.Remove(chr_SoLuong.Series["Phiếu xuất kho"]);
                chr_GiaTri.Series.Remove(chr_GiaTri.Series["Phiếu xuất kho"]);
                DateTime aDateTime = GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
                for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
                {
                    chr_SoLuong.Series["Đơn đặt hàng"].Points.AddPoint(aDateTime.ToShortDateString(), db.DonDatHangs.Select(t => t).Where(t => t.NgayDat == aDateTime).Count());
                    chr_SoLuong.Series["Phiếu trả hàng"].Points.AddPoint(aDateTime.ToShortDateString(), db.PhieuTraHangs.Select(t => t).Where(t => t.MaST == FormLogin.objUserBO.StoreId && t.NgayTra == aDateTime).Count());
                    SLDDH = db.DonDatHangs.Where(t => t.TinhTrang == 2 && t.NgayDat == aDateTime).Sum(t => t.TongTien).ToString();
                    SLPTH = db.PhieuTraHangs.Where(t => t.MaST == (-1) && t.TinhTrang == 1 && t.NgayTra == aDateTime).Sum(t => t.TongTien).ToString();
                    if (string.IsNullOrEmpty(SLDDH))
                    {
                        SLDDH = "0";
                    }
                    if (string.IsNullOrEmpty(SLPTH))
                    {
                        SLPTH = "0";
                    }
                    chr_GiaTri.Series["Đơn đặt hàng"].Points.AddPoint(aDateTime.ToShortDateString(), double.Parse(SLDDH));
                    chr_GiaTri.Series["Phiếu trả hàng"].Points.AddPoint(aDateTime.ToShortDateString(), double.Parse(SLPTH));
                    aDateTime = aDateTime.AddDays(1);
                }

            }
        }
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
    }
}
