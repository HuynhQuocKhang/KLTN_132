using DevExpress.XtraBars;
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
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.frmDatHang = new FormDatHang();
            ViewChildForm(Program.frmDatHang);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.frmPhanPhoiHang = new FormPhanPhoiHang();
            ViewChildForm(Program.frmPhanPhoiHang);
        }

        public bool IsFormActive(Form pForm)
        {
            bool Isopend = false;
            if(MdiChildren.Count()>0)
            {
                foreach(var item in MdiChildren)
                {
                    if(pForm.Name == item.Name)
                    {
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        Isopend = true;
                    }    
                }    
            }
            return Isopend;
        }

        public void ViewChildForm(Form pForm)
        {
            if(!IsFormActive(pForm))
            {
                pForm.MdiParent = this;
                pForm.Show();
            }    
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.frmDanhSachSP = new  FormDanhSachSP();
            ViewChildForm(Program.frmDanhSachSP);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.frmTraHangNCC = new  FormTraHangNCC();
            ViewChildForm(Program.frmTraHangNCC);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.frmXemDonDatHang = new  FormXemDonDatHang();
            ViewChildForm(Program.frmXemDonDatHang);
        }
    }
}