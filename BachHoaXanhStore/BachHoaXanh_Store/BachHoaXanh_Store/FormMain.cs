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
        private string reportType;
        public string ReportType { get => reportType; set => reportType = value; }

        private void btn_DatHangNCC_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
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
            panel4.Visible = true;
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

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            if(xtraTabbedMdiManager1.SelectedPage.MdiChild.Name == "FormDatHang")
            {
                bunifuButton1.Visible = true;
                reportType = "DatHang";
                label1.Text = "Số đơn đã đặt";
                label3.Text = "Tổng giá trị đặt";
            }    
            else if (xtraTabbedMdiManager1.SelectedPage.MdiChild.Name == "FormPhanPhoiHang")
            {
                bunifuButton1.Visible = true;
                reportType = "PhanPhoiHang";
                label1.Text = "Số đơn đã xuất";
                label3.Text = "Tổng giá trị xuất";
            }
            else if (xtraTabbedMdiManager1.SelectedPage.MdiChild.Name == "FormTraHangNCC")
            {
                bunifuButton1.Visible = true;
                reportType = "TraHang";
                label1.Text = "Số sản phẩm trả về";
                label3.Text = "Tổng giá trị trả về";
            }
            else if (xtraTabbedMdiManager1.SelectedPage.MdiChild.Name == "FormDanhSachSP")
            {
                bunifuButton1.Visible = false;
                label1.Text = "Số sản phẩm còn";
                label3.Text = "Số sản phẩm đã hết";
            }
            else if (xtraTabbedMdiManager1.SelectedPage.MdiChild.Name == "FormXemDonDatHang")
            {
                bunifuButton1.Visible = false;
                label1.Text = "Số đơn chưa xử lí";
                label3.Text = "Số đơn đã xử lí";
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Program.frmReport = new FormReport();
            Program.frmReport.Show();
        }
    }
}