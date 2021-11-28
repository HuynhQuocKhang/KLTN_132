using BachHoaXanh_Store.ReportForm;
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
    public partial class FormReport : Form
    {
       
        public FormReport()
        {
            InitializeComponent();
        }
        
        private void FormReport_Load(object sender, EventArgs e)
        {
            if (Program.frmMain.ReportType == "DatHang")
            {
                rptDonDatHang rptDDH = new rptDonDatHang();
                documentViewer1.PrintingSystem = rptDDH.PrintingSystem;
                rptDDH.CreateDocument();
            }
            else if (Program.frmMain.ReportType == "TraHang")
            {
                rptPhieuTraHang rptTH = new rptPhieuTraHang();
                documentViewer1.PrintingSystem = rptTH.PrintingSystem;
                rptTH.CreateDocument();
            }
            else if (Program.frmMain.ReportType == "PhanPhoiHang")
            {
                rptPhieuXuatKho rptPPH = new rptPhieuXuatKho();
                documentViewer1.PrintingSystem = rptPPH.PrintingSystem;
                rptPPH.CreateDocument();
            }
        }
    }
}
