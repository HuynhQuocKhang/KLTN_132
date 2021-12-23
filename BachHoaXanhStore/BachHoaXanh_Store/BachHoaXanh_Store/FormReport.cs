using BachHoaXanh_Store.ReportForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachHoaXanh_Store
{
    public partial class FormReport : Form
    {
        private static string reportType;
        public FormReport(string pReportType)
        {
            InitializeComponent();
              reportType=pReportType;
        }

        public static string ReportType { get => reportType; set => reportType = value; }

        private void FormReport_Load(object sender, EventArgs e)
        {
            if (reportType == "DatHang")
            {
                rptDonDatHang rptDDH = new rptDonDatHang();
                documentViewer1.PrintingSystem = rptDDH.PrintingSystem;
                rptDDH.CreateDocument();
            }
            else if (reportType == "STDatHang")
            {
                Report rptDDHST = new Report();
                documentViewer1.PrintingSystem = rptDDHST.PrintingSystem;
                rptDDHST.CreateDocument();
            }
            else if (reportType == "XuatKho")
            {
                rptPhieuXuatKho rptPXK = new rptPhieuXuatKho();
                documentViewer1.PrintingSystem = rptPXK.PrintingSystem;
                rptPXK.CreateDocument();
            }
            else if (reportType == "TraHang")
            {
                rptPhieuTraHang rptPTH = new rptPhieuTraHang();
                documentViewer1.PrintingSystem = rptPTH.PrintingSystem;
                rptPTH.CreateDocument();
            }
            else if(reportType=="Bill")
            {
                rptDonBanHang rptBill = new rptDonBanHang();
                documentViewer1.PrintingSystem = rptBill.PrintingSystem;
                rptBill.CreateDocument();
            }    
        }
    }
}
