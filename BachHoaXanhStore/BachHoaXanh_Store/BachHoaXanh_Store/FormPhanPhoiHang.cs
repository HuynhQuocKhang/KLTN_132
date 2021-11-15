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
    public partial class FormPhanPhoiHang : Form
    {
        public FormPhanPhoiHang()
        {
            InitializeComponent();
            if(chk_AllStore.Checked==true)
            {
                cbo_SieuThi.Enabled = false;
            }    
            else
            {
                cbo_SieuThi.Enabled = true;

            }    
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Program.frmPhieuXuatKho = new FormPhieuXuatKho();
            Program.frmPhieuXuatKho.ShowDialog();
        }

        private void chk_AllStore_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chk_AllStore.Checked == true)
                cbo_SieuThi.Enabled = false;
            else
                cbo_SieuThi.Enabled = true;
        }
    }
}
