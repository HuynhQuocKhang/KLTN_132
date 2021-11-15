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
    public partial class FormDatHang : Form
    {
        public FormDatHang()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Program.frmDonDatHang = new FormDonDatHang();
            Program.frmDonDatHang.ShowDialog();
        }
    }
}
