using BLL_DAO;
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
    public partial class FormDuyetPhieuTraHang : Form
    {
        StoreBLL objStoreBLL = new StoreBLL();
        public FormDuyetPhieuTraHang()
        {
            InitializeComponent();
            cbo_MaSieuThi.DataSource = objStoreBLL.GetAllStore();
            cbo_MaSieuThi.DisplayMember = "FullName";
            cbo_MaSieuThi.ValueMember = "MaST";
        }
    }
}
