using BLL_DAO;
using BO;
using DevExpress.XtraBars;
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
        public static ExportProductBLL objExportProductBLL = new ExportProductBLL();
        public static ProductBLL objProductBLL = new ProductBLL();
        public static OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        public static StoreBLL objStoreBLL = new StoreBLL();
        public static List<ProductBO> lstProduct = objProductBLL.GetListAllProduct();
        public FormMain()
        {
            InitializeComponent();
            lbl_MaST.Text = objStoreBLL.getStoreNameByUser(FormLogin.objUserBO.StoreId);
            lbl_MaNV.Text = FormLogin.objUserBO.UserName + " - " + FormLogin.objUserBO.UserFullName;
        }
        private string reportType;
        public string ReportType { get => reportType; set => reportType = value; }

        public bool IsFormActive(Form pForm)
        {
            bool Isopend = false;
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (pForm.Name == item.Name)
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
            if (!IsFormActive(pForm))
            {
                pForm.MdiParent = this;
                pForm.Show();
            }
        }

        private void btn_XuatHang_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = true;
            reportType = "PhanPhoiHang";
            label1.Text = "Số đơn đã xuất";
            label3.Text = "Tổng giá trị xuất";
            Program.frmPhanPhoiHang = new FormPhanPhoiHang();
            ViewChildForm(Program.frmPhanPhoiHang);
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = false;
            label1.Text = "Số sản phẩm còn";
            label3.Text = "Số sản phẩm đã hết";
            Program.frmDanhSachSP = new FormDanhSachSP();
            ViewChildForm(Program.frmDanhSachSP);
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = false;
            label1.Text = "Số đơn chưa xử lí";
            label3.Text = "Số đơn đã xử lí";
            Program.frmXemDonDatHang = new FormXemDonDatHang();
            ViewChildForm(Program.frmXemDonDatHang);
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = true;
            reportType = "DatHang";
            label1.Text = "Số đơn đã đặt";
            label3.Text = "Tổng giá trị đặt";
            Program.frmDatHang = new FormDatHang();
            ViewChildForm(Program.frmDatHang);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = false;
            label1.Text = "Số sản phẩm còn";
            label3.Text = "Số sản phẩm đã hết";
            Program.frmDanhSachSP = new FormDanhSachSP();
            ViewChildForm(Program.frmDanhSachSP);
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = false;
            label1.Text = "Số đơn chưa xử lí";
            label3.Text = "Số đơn đã xử lí";
            Program.frmXemDonDatHang = new FormXemDonDatHang();
            ViewChildForm(Program.frmXemDonDatHang);
        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (xtraTabbedMdiManager1.SelectedPage != null)
            {
                if (xtraTabbedMdiManager1.SelectedPage.Text == "FormDatHang")
                {
                    bunifuButton1.Visible = true;
                    reportType = "DatHang";
                    label1.Text = "Số đơn đã đặt";
                    label3.Text = "Tổng giá trị đặt";
                    label2.Text=objOrderStoreBLL.countOrderFromStore().ToString();
                    label4.Text = objOrderStoreBLL.sumValueOrderFormStore().ToString();
                }
                else if (xtraTabbedMdiManager1.SelectedPage.Text == "FormPhanPhoiHang")
                {
                    bunifuButton1.Visible = true;
                    reportType = "PhanPhoiHang";
                    label1.Text = "Số đơn đã xuất";
                    label3.Text = "Tổng giá trị xuất";
                    label2.Text = objOrderStoreBLL.countOrderFromStore().ToString();
                    label4.Text = objOrderStoreBLL.sumValueOrderFormStore().ToString();
                }
                else if (xtraTabbedMdiManager1.SelectedPage.Text == "FormTraHangNCC")
                {
                    bunifuButton1.Visible = true;
                    reportType = "TraHang";
                    label1.Text = "Số sản phẩm trả về";
                    label3.Text = "Tổng giá trị trả về";
                    label2.Text = objExportProductBLL.countExportProduct().ToString();
                    label4.Text = objExportProductBLL.sumValueExportProduct().ToString();
                }
                else if (xtraTabbedMdiManager1.SelectedPage.Text == "FormDanhSachSP")
                {
                    bunifuButton1.Visible = false;
                    label1.Text = "Số sản phẩm còn";
                    label3.Text = "Số sản phẩm đã hết";
                    int intProductStock = 0;
                    int intProductOOT = 0;
                    intProductStock = lstProduct.Count(x => x.SoLuong > 0);
                    intProductOOT = lstProduct.Count(x => x.SoLuong == 0);
                    label2.Text = intProductStock.ToString();
                    label4.Text = intProductOOT.ToString();
                }
                else if (xtraTabbedMdiManager1.SelectedPage.Text == "FormXemDonDatHang")
                {
                    bunifuButton1.Visible = false;
                    label1.Text = "Số đơn chưa xử lí";
                    label3.Text = "Số đơn đã xử lí"; 
                    label2.Text = objOrderStoreBLL.countOrderFromStore().ToString();
                    label4.Text = objOrderStoreBLL.countTransferFromStore().ToString();
                }
                else if (xtraTabbedMdiManager1.SelectedPage.Text == "FormNhapHang")
                {
                    bunifuButton1.Visible = false;
                    label1.Text = "Số đơn chưa xử lí";
                    label3.Text = "Số đơn đã xử lí";
                    label4.Text = objOrderStoreBLL.countOrderFromStore().ToString();
                    label2.Text = objOrderStoreBLL.countTransferFromStore().ToString();
                }
                else if (xtraTabbedMdiManager1.SelectedPage.Text == "FormDuyetTraHang")
                {
                    bunifuButton1.Visible = false;
                    label1.Text = "Số đơn chưa duyệt";
                    label3.Text = "Số đơn đã duyệt";
                    label2.Text = objOrderStoreBLL.countReturnProductOrder().ToString();
                    label4.Text = objOrderStoreBLL.sumValueReturnProductOrder().ToString();
                }
            }

        }


        private void bunifuButton1_Click(object sender, EventArgs e)
        {
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (MdiChildren.Count() == 0)
            {
                panel9.Visible = false;
            }
        }

        private void accordionControlElement6_Click_1(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = true;
            reportType = "DatHang";
            label1.Text = "Số đơn đã đặt";
            label3.Text = "Tổng giá trị đặt";
            Program.frmDatHang = new FormDatHang();
            ViewChildForm(Program.frmDatHang);
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = true;
            reportType = "DatHang";
            label1.Text = "Số đơn đã đặt";
            label3.Text = "Tổng giá trị đặt";
            FormNhapHang frmNhapHang = new FormNhapHang();
            ViewChildForm(frmNhapHang);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmLogin.Show();
            this.Hide();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedItem.ToString() == "Đăng xuất")
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất", "Đăng xuất?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Program.frmLogin.Show();
                    this.Hide();
                }
            }
        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = true;
            reportType = "TraHang";
            label1.Text = "Số sản phẩm trả về";
            label3.Text = "Tổng giá trị trả về";
            Program.frmTraHangNCC = new FormTraHangNCC();
            ViewChildForm(Program.frmTraHangNCC);
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            panel9.Visible = true;
            bunifuButton1.Visible = true;
            reportType = "DuyetTraHang";
            label1.Text = "Số đơn đã duyệt";
            label3.Text = "Số đơn chưa duyệt";
            Program.frmDuyetPhieuTraHang = new FormDuyetPhieuTraHang();
            ViewChildForm(Program.frmDuyetPhieuTraHang);
        }
    }
}