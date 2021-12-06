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
    public partial class FormNhapHang : Form
    {
        public FormNhapHang()
        {
            InitializeComponent();
            toolTip1.SetToolTip(cbo_NhaCungCap, "Tìm kiếm đơn hàng từ nhà cung cấp nào");
            toolTip1.SetToolTip(cbo_TinhTrang, "Tìm kiếm theo tình trạng đơn hàng");
        }
    }
}
