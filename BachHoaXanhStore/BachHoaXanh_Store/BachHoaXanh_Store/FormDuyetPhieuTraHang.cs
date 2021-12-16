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
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        List<String> listMaPTH = new List<string>();
        public FormDuyetPhieuTraHang()
        {
            InitializeComponent();
            cbo_MaSieuThi.DataSource = objStoreBLL.GetAllStore();
            cbo_MaSieuThi.DisplayMember = "FullName";
            cbo_MaSieuThi.ValueMember = "MaST";
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            Search(txtKeyWord.Text.Trim(), cbo_MaSieuThi.SelectedValue.ToString(), (DateTime)dtp_NgayBatDau.Value, (DateTime)dtp_NgayKetThuc.Value);
        }
        private void Search(string pKeyWord, string strStoreId, DateTime dateFrom, DateTime dateTo)
        {
            dgv_DSPTH.DataSource = objOrderStoreBLL.GetReturnProductOrder(pKeyWord.Trim(), strStoreId, dateFrom, dateTo);
        }

        private void chk_SelectAll_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chk_SelectAll.Checked == true)
            {
                for (int i = 0; i < dgv_DSPTH.Rows.Count; i++)
                {
                    dgv_DSPTH["col_check", i].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dgv_DSPTH.Rows.Count; i++)
                {
                    dgv_DSPTH["col_check", i].Value = false;
                }
            }
        }

        private void dgv_DSPTH_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_DSPTH.CurrentCell.RowIndex;
            if (dgv_DSPTH.DataSource != null && index != -1)
            {
                dgv_DSCT.DataSource = objOrderStoreDetailBLL.GetDetailsReturnProductStoreByOrderId(int.Parse(dgv_DSPTH["col_MaDH", index].Value.ToString().Trim()));
            }
        }

        private void btn_DuyetDonTraHang_Click(object sender, EventArgs e)
        {
            bool cellCheck;
            for (int i = 0; i < dgv_DSPTH.Rows.Count; i++)
            {
                var cbxCell = (DataGridViewCheckBoxCell)dgv_DSPTH.Rows[i].Cells["col_check"];
                if ((string)cbxCell.Value == "T")
                {
                    if (objOrderStoreBLL.UpdateReturnProductStoreStatus(int.Parse(dgv_DSPTH.Rows[i].Cells[2].Value.ToString())))
                    {
                        MessageBox.Show("Duyệt đơn trả hàng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Duyệt đơn trả hàng thất bại");
                    }
                }
            }

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Search(txtKeyWord.Text.Trim(), cbo_MaSieuThi.SelectedValue.ToString(), (DateTime)dtp_NgayBatDau.Value, (DateTime)dtp_NgayKetThuc.Value);
        }


    }
}
