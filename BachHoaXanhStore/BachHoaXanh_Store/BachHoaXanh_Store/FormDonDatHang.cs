using BO;
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
    
    public partial class FormDonDatHang : Form
    {
        public FormDonDatHang()
        {
            InitializeComponent();
            List<OrderCustomerDetailBO> lstOrderTmp = FormDatHang.lstOrderCustomerDetailBO;
            txt_NhaCungCap.Text = FormDatHang.objUser.UserFullName;
            txt_NgayDat.Text = DateTime.Now.ToString();
            txt_TongTien.Text = FormDatHang.intTotalPrice.ToString();
            dgv_Order.DataSource = lstOrderTmp;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormDatHang.lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
            FormDatHang.intTotalPrice = 0;
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {

        }
    }
}
