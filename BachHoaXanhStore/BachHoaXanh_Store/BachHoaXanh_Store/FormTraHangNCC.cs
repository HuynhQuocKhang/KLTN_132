using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAO;

namespace BachHoaXanh_Store
{
    public partial class FormTraHangNCC : Form
    {
        XuLiSuKien xlsk = new XuLiSuKien();
        DataGridViewCheckBoxColumn dgv_CheckBox = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn dgv_CheckBox1 = new DataGridViewCheckBoxColumn();
        
        public FormTraHangNCC()
        {
            InitializeComponent();
            CustomerBLL objCustomerBLL = new CustomerBLL();
            dgv_DSSP.Columns.Add(dgv_CheckBox);
            dgv_CTTraHang.Columns.Add(dgv_CheckBox1);
            cbo_NhaCungCap.DataSource = objCustomerBLL.GetListALlCustomer();
            cbo_NhaCungCap.DisplayMember = "TenNCC";
            cbo_NhaCungCap.ValueMember = "MaNCC";
        }

        private void btn_LapPhieu_Click(object sender, EventArgs e)
        {
            Program.frmPhieuTraHang = new FormPhieuTraHang(cbo_NhaCungCap.Text);
            Program.frmPhieuTraHang.ShowDialog();
        }
    }
}
