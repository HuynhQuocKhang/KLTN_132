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
    public partial class FormTraHangNCC : Form
    {
        XuLiSuKien xlsk = new XuLiSuKien();
        DataGridViewCheckBoxColumn dgv_CheckBox = new DataGridViewCheckBoxColumn();
        DataGridViewCheckBoxColumn dgv_CheckBox1 = new DataGridViewCheckBoxColumn();
        
        public FormTraHangNCC()
        {
            InitializeComponent();
            dgv_DSSP.Columns.Add(dgv_CheckBox);
            dgv_CTTraHang.Columns.Add(dgv_CheckBox1);
            cbo_NhaCungCap.DataSource = xlsk.loadComboboxNhaCC();
            cbo_NhaCungCap.DisplayMember = "TenNCC";
            cbo_NhaCungCap.ValueMember = "MaNCC";
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            Program.frmPhieuTraHang = new FormPhieuTraHang(cbo_NhaCungCap.Text);
            Program.frmPhieuTraHang.ShowDialog();
        }
    }
}
