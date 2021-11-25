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
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
           
        }

        private void btn_DatHangNCC_Click(object sender, EventArgs e)
        {
            Program.frmDatHang = new FormDatHang();
            ViewChildForm(Program.frmDatHang);
        }

        public bool IsFormActive(Form pForm)
        {
            bool Isopend = false;
            if(MdiChildren.Count()>0)
            {
                foreach(var item in MdiChildren)
                {
                    if(pForm.Name==item.Name)
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

        private void btn_XuatHang_Click(object sender, EventArgs e)
        {
            Program.frmPhanPhoiHang = new FormPhanPhoiHang();
            ViewChildForm(Program.frmPhanPhoiHang);
        }

        private void btn_TraHangNCC_Click(object sender, EventArgs e)
        {
            Program.frmTraHangNCC = new  FormTraHangNCC();
            ViewChildForm(Program.frmTraHangNCC);
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            Program.frmDanhSachSP = new FormDanhSachSP();
            ViewChildForm(Program.frmDanhSachSP);
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            Program.frmXemDonDatHang = new  FormXemDonDatHang();
            ViewChildForm(Program.frmXemDonDatHang);
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            Program.frmDatHang = new FormDatHang();
            ViewChildForm(Program.frmDatHang);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            Program.frmTraHangNCC = new  FormTraHangNCC();
            ViewChildForm(Program.frmTraHangNCC);
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            Program.frmDanhSachSP = new  FormDanhSachSP();
            ViewChildForm(Program.frmDanhSachSP);
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            Program.frmXemDonDatHang = new  FormXemDonDatHang();
            ViewChildForm(Program.frmXemDonDatHang);
        }
    }
}