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
    public partial class FormPhieuTraHang : Form
    {
        XuLiGiaoDien xlgd = new XuLiGiaoDien();
        private string pNhaCungCap;
        public string PNhaCungCap { get => pNhaCungCap; set => pNhaCungCap = value; }


        public FormPhieuTraHang(string s)
        {
            InitializeComponent();
            txt_NhaCungCap.Text = s;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
