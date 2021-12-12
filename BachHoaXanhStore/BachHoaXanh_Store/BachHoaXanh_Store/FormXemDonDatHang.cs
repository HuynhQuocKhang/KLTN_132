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
    public partial class FormXemDonDatHang : Form
    {
        StoreBLL objStoreBLL = new StoreBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        public FormXemDonDatHang()
        {
            InitializeComponent();
            cbo_SieuThi.DataSource = objStoreBLL.GetAllStore();
            cbo_SieuThi.DisplayMember = "FullName";
            cbo_SieuThi.ValueMember = "MaST";
            cbo_TinhTrang.SelectedIndex = 3;
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (chk_AllStore.Checked == true)
            {
                dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(0,int.Parse(cbo_TinhTrang.SelectedIndex.ToString()), txtKeyword.Text);
            }
            else
            {
                dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(int.Parse(cbo_SieuThi.SelectedValue.ToString()), int.Parse(cbo_TinhTrang.SelectedIndex.ToString()), txtKeyword.Text);
            }
        }

        private void chk_AllStore_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chk_AllStore.Checked == true)
            {
                cbo_SieuThi.Enabled = false;
            }
            else
            {
                cbo_SieuThi.Enabled = true;

            }
        }

        private void dgv_DSDH_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_DSDH.CurrentCell.RowIndex;
            if (dgv_DSDH.DataSource != null && index != -1)
            {
                dgv_DHDT.DataSource = objOrderStoreDetailBLL.GetDetailsOrderStoreByOrderId(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
            }
        }
    }
}
