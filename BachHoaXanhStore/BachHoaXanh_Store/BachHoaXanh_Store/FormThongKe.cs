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
    public partial class FormThongKe : DevExpress.XtraEditors.XtraForm
    {
        BachHoaXanhDataContext db = new BachHoaXanhDataContext();
        public static string pMonth;
        public FormThongKe()
        {
            InitializeComponent();
            loadChart(DateTime.Now.Month.ToString());
            chr_SoLuong.Titles.Add("Biểu đồ số lượng");
            chr_GiaTri.Titles.Add("Biểu đồ giá trị");
            cbo_Month.Text = DateTime.Now.Month.ToString();
        }
        public void loadChart(string cbo)
        {
            DateTime aDateTime = new DateTime(DateTime.Now.Year, int.Parse(cbo),1);
            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, int.Parse(cbo)); i++)
            {
                chr_SoLuong.Series["Đơn đặt hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.DonDatHangs.Select(t => t).Where(t => t.NgayDat == aDateTime).Count());
                chr_SoLuong.Series["Phiếu trả hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.PhieuTraHangs.Select(t => t).Where(t => t.MaST == FormLogin.objUserBO.StoreId && t.NgayTra == aDateTime).Count().ToString());
                chr_GiaTri.Series["Đơn đặt hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.DonDatHangs.Where(t => t.TinhTrang == 2 && t.NgayDat == aDateTime).Sum(t => t.TongTien).ToString());
                chr_GiaTri.Series["Phiếu trả hàng"].Points.AddXY(aDateTime.ToShortDateString(), db.PhieuTraHangs.Where(t => t.MaST == FormLogin.objUserBO.StoreId && t.TinhTrang == 1 && t.NgayTra == aDateTime).Sum(t => t.TongTien).ToString());
                aDateTime = aDateTime.AddDays(1);
            }
        }
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pMonth = cbo_Month.Text;
            if (int.TryParse(cbo_Month.Text.Trim(), out int month))
            {
                pMonth = month.ToString();
                if (month > 0 && month < 13)
                {
                    FormReport rpt = new FormReport("ThongKe");
                    rpt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tháng nhập vào phải từ 1 đến 12");
                }
            }
            else
            {
                MessageBox.Show("Tháng nhập vào phải số nguyên có giá trị từ 1 đến 12");
            }

        }

        private void cbo_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            chr_SoLuong.Series["Đơn đặt hàng"].Points.Clear();
            chr_SoLuong.Series["Phiếu trả hàng"].Points.Clear();
            chr_GiaTri.Series["Đơn đặt hàng"].Points.Clear();
            chr_GiaTri.Series["Phiếu trả hàng"].Points.Clear();
            if(int.TryParse(cbo_Month.Text.Trim(),out int month))
            {
                if(month > 0 && month < 13)
                {
                    loadChart(month.ToString());
                }
            }
        }
    }
}