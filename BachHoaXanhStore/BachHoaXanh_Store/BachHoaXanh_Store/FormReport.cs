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
       
        public FormReport()
        {
            InitializeComponent();
        }
        
        private void FormReport_Load(object sender, EventArgs e)
        {
                rptDonDatHang rptDDH = new rptDonDatHang();
                documentViewer1.PrintingSystem = rptDDH.PrintingSystem;
                rptDDH.CreateDocument();
        }
    }
}
