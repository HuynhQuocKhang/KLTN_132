﻿using BLL_DAO;
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
        }

        private void dgv_DSPTH_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_DSPTH.CurrentCell.RowIndex;
            if (dgv_DSPTH.DataSource != null && index != -1)
            {
                dgv_DSCT.Rows.Clear();
                List<GetDetailsReturnProductStoreByOrderIdBO> lstReturnProduct = objOrderStoreDetailBLL.GetDetailsReturnProductStoreByOrderId(int.Parse(dgv_DSPTH["col_MaDH", index].Value.ToString().Trim()));
                foreach (GetDetailsReturnProductStoreByOrderIdBO item in lstReturnProduct)
                {
                    dgv_DSCT.Rows.Add(item.MaSP, item.TenSP, item.SoLuong, ((DateTime)item.NgayHetHan).ToString("d"));
                }
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
                    List<GetDetailsReturnProductStoreByOrderIdBO> lstReturnProduct = objOrderStoreDetailBLL.GetDetailsReturnProductStoreByOrderId(int.Parse(dgv_DSPTH["col_MaDH", i].Value.ToString().Trim()));
                    List<ProductBO> lstProduct = new List<ProductBO>();
                    foreach (GetDetailsReturnProductStoreByOrderIdBO item in lstReturnProduct)
                    {
                        ProductBO objProduct = new ProductBO();
                        objProduct.MaSP = item.MaSP.Trim();
                        objProduct.SoLuong = item.SoLuong;
                        lstProduct.Add(objProduct);
                    }
                    if (objOrderStoreBLL.UpdateReturnProductStoreStatus(int.Parse(dgv_DSPTH["col_MaDH", i].Value.ToString().Trim()), lstProduct, int.Parse(dgv_DSPTH["col_MaST", i].Value.ToString().Trim())))
                    {
                        MessageBox.Show("Duyệt đơn trả hàng thành công");
                        dgv_DSCT.Rows.Clear();
                        Search(txtKeyWord.Text.Trim(), cbo_MaSieuThi.SelectedValue.ToString(), (DateTime)dtp_NgayBatDau.Value, (DateTime)dtp_NgayKetThuc.Value);
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
