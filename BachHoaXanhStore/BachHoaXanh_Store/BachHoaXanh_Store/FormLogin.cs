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
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (cbo_LoaiTK.Text!= "Nhân viên bán hàng")
            {
                Program.frmMain = new FormMain();
                Program.frmMain.Show();
                this.Hide();
            }
            else
            {
                Program.frmBanHang = new FormBanHang();
                Program.frmBanHang.Show();
                this.Hide();
            }
            
        }
    }
}