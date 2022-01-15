using BLL_DAO;
using BO;
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
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        public FormXemDonDatHang()
        {
            InitializeComponent();
            if (FormLogin.objUserBO.Permission == 1)
            {
                cbo_SieuThi.DataSource = objStoreBLL.GetAllStore();
                cbo_SieuThi.DisplayMember = "FullName";
                cbo_SieuThi.ValueMember = "MaST";
            }
            else
            {
                cbo_SieuThi.Text = objStoreBLL.getStoreNameByUser(FormLogin.objUserBO.StoreId);
                cbo_SieuThi.Enabled = false;
                chk_AllStore.Visible = false;
                bunifuCustomLabel1.Visible = false;
            }

            cbo_TinhTrang.SelectedIndex = 3;
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (chk_AllStore.Visible == true)
            {
                if (chk_AllStore.Checked == true)
                {
                    dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(-1,int.Parse(cbo_TinhTrang.SelectedIndex.ToString()), txtKeyword.Text);
                }
                else
                {
                    if (int.Parse(cbo_SieuThi.SelectedValue.ToString()) == 0)
                    {
                        string strKey = "0";
                        if (txtKeyword.Text.Trim() != null && txtKeyword.Text.Trim() != string.Empty)
                        {
                            strKey = txtKeyword.Text.Trim();
                        }
                        dgv_DSDH.DataSource = objOrderCustomerBLL.GetListOrderCustomerView(int.Parse(strKey), int.Parse(cbo_TinhTrang.SelectedIndex.ToString()));
                    }
                    else
                    {
                        dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(int.Parse(cbo_SieuThi.SelectedValue.ToString()), int.Parse(cbo_TinhTrang.SelectedIndex.ToString()), txtKeyword.Text);
                    }
                    
                }
            }
            else
            {
                dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO((int)FormLogin.objUserBO.StoreId, int.Parse(cbo_TinhTrang.SelectedIndex.ToString()), txtKeyword.Text);
            }
            if (dgv_DSDH.Rows.Count == 0)
            {
                dgv_DHDT.Rows.Clear();
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
            dgv_DHDT.Rows.Clear();
            if (dgv_DSDH.DataSource != null && index != -1)
            {
                if (FormLogin.objUserBO.Permission == 1)
                {
                    if (int.Parse(cbo_SieuThi.SelectedValue.ToString()) != 0)
                    {
                        List<GetDetailsOrderStoreByOrderIdBO> lstOrder = objOrderStoreDetailBLL.GetDetailsOrderStoreByOrderId(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
                        foreach (GetDetailsOrderStoreByOrderIdBO item in lstOrder)
                        {
                            dgv_DHDT.Rows.Add(item.MaSP, item.TenSP, item.GiaBan, item.SoLuong, item.ThanhTien);
                        }
                    }
                    else
                    {
                        List<GetDetailsOrderStoreByOrderIdBO> lstOrder = new List<GetDetailsOrderStoreByOrderIdBO>();
                        lstOrder = objOrderCustomerBLL.GetListOrderCustomerDetailView(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
                        foreach (GetDetailsOrderStoreByOrderIdBO item in lstOrder)
                        {
                            dgv_DHDT.Rows.Add(item.MaSP, item.TenSP, item.GiaBan, item.SoLuong, item.ThanhTien);
                        }
                    }
                }
                else
                {
                    List<GetDetailsOrderStoreByOrderIdBO> lstOrder = objOrderStoreDetailBLL.GetDetailsOrderStoreByOrderId(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
                    foreach (GetDetailsOrderStoreByOrderIdBO item in lstOrder)
                    {
                        dgv_DHDT.Rows.Add(item.MaSP, item.TenSP, item.GiaBan, item.SoLuong, item.ThanhTien);
                    }
                }
            }
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
