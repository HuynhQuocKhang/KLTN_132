using BLL_DAO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachHoaXanh_Store
{
    public partial class FormThongKeKho : DevExpress.XtraEditors.XtraForm
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public FormThongKeKho()
        {
            InitializeComponent();
            loadChart(DateTime.Now.Month.ToString());
            chr_SoLuong.Titles.Add("Biểu đồ số lượng");
            chr_GiaTri.Titles.Add("Biểu đồ giá trị");
        }
        public void loadChart(string cbo)
        {
            DateTime aDateTime = GetFistDayInMonth(DateTime.Now.Year, int.Parse(cbo));
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(cbo)); i++)
            {
                chr_SoLuong.Series["Đơn đặt hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.HoaDonDatNCCs.Select(t => t).Where(t => t.NgayDat == aDateTime).Count());
                chr_SoLuong.Series["Phiếu trả hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.PhieuTraHangs.Select(t => t).Where(t => t.MaST == (-1) && t.NgayTra == aDateTime).Count().ToString());
                chr_SoLuong.Series["Phiếu xuất kho"].Points.AddXY(aDateTime.ToShortDateString(), db.PhieuXuatKhos.Select(t => t).Where(t=>t.NgayXuat == aDateTime).Count().ToString());

                chr_GiaTri.Series["Đơn đặt hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.DonDatHangs.Where(t => t.TinhTrang == 2 && t.NgayDat == aDateTime).Sum(t => t.TongTien).ToString());
                chr_GiaTri.Series["Phiếu trả hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.PhieuTraHangs.Where(t => t.MaST == (-1) && t.TinhTrang == 1 && t.NgayTra == aDateTime).Sum(t => t.TongTien).ToString());
                chr_GiaTri.Series["Phiếu xuất kho"].Points.AddXY(aDateTime.ToShortDateString(), db.PhieuXuatKhos.Where(t => t.NgayXuat == aDateTime).Sum(t => t.TongTien).ToString());
                aDateTime = aDateTime.AddDays(1);
            }
            
        }
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }

        private void cbo_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            chr_SoLuong.Series["Đơn đặt hàng"].Points.Clear();
            chr_SoLuong.Series["Phiếu trả hàng"].Points.Clear();
            chr_SoLuong.Series["Phiếu xuất kho"].Points.Clear();
            chr_GiaTri.Series["Đơn đặt hàng"].Points.Clear();
            chr_GiaTri.Series["Phiếu trả hàng"].Points.Clear();
            chr_GiaTri.Series["Phiếu xuất kho"].Points.Clear();
            loadChart(cbo_Month.Text);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Program.frmReport= new FormReport("ThongKeKho");
            Program.frmReport.ShowDialog();
        }
    }
}