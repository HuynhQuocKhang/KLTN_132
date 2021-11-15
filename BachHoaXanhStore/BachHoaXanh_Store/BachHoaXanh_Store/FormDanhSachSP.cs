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
    public partial class FormDanhSachSP : Form
    {
        public FormDanhSachSP()
        {
            InitializeComponent();
        }

        private void dgv_DSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string command = dgv_DSSP.Columns[e.ColumnIndex].Name;
                if (command == "col_Sua")
                {
                    Program.frmChinhSuaSP = new FormChinhSuaSP();
                    Program.frmChinhSuaSP.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Xoá sản phẩm");
                }    
            }
        }
    }
}
