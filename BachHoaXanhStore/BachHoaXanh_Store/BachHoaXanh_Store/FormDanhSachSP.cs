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
    public partial class FormDanhSachSP : Form
    {
        #region Biến dùng chung
        ProductBLL objProductBLL = new ProductBLL();
        CustomerBLL objcustomerBLL = new CustomerBLL();
        ProductTypeBLL objProductTypeBLL = new ProductTypeBLL();
        public static ProductBO objProductBO = new ProductBO();
        public static int indexCustomerId = 0;
        public static int indexProductTypeId = 0;
        public static bool isEdit = false;
        #endregion

        public FormDanhSachSP()
        {
            InitializeComponent();
            //Load dữ liệu ban đầu
            dgv_DSSP.DataSource = objProductBLL.GetListAllProduct();
            cbo_NhaCungCap.DataSource = objcustomerBLL.GetListALlCustomer();
            cbo_NhaCungCap.DisplayMember = "FullName";
            cbo_NhaCungCap.ValueMember = "MaNCC";
        }

        private void dgv_DSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString());

        }
        //Tìm kiếm sản phẩm theo key and customerid
        private void Search(string strProductName, string strCustomerId)
        {
            if (int.Parse(strCustomerId) == 1)
            {
                dgv_DSSP.DataSource = objProductBLL.GetProductByKeys(strProductName.Trim(), 0, 0);
            }
            else
            {
                dgv_DSSP.DataSource = objProductBLL.GetProductByKeys(strProductName.Trim(), 0, int.Parse(strCustomerId));
            }
        }
        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_DSSP.CurrentCell.RowIndex;

            //Sửa Sản phẩm
            if (dgv_DSSP["col_Sua", index].Selected)
            {
                //Xét trạng form
                isEdit = true;

                #region Truyền dữ liệu cho object chung
                objProductBO.MaSP = dgv_DSSP["col_MaSP", index].Value.ToString();
                objProductBO.TenSP = dgv_DSSP["col_TenSP", index].Value.ToString();
                objProductBO.MaLoaiSP = int.Parse(dgv_DSSP["col_MaLoaiSP", index].Value.ToString());
                objProductBO.MaNCC = int.Parse(dgv_DSSP["col_MaNCC", index].Value.ToString());
                objProductBO.SoLuong = int.Parse(dgv_DSSP["col_SoLuong", index].Value.ToString());
                objProductBO.GiaBan = int.Parse(dgv_DSSP["col_GiaBan", index].Value.ToString());
                objProductBO.GiaVon = int.Parse(dgv_DSSP["col_GiaVon", index].Value.ToString());
                #endregion

                List<CustomerBO> lstCustomer = objcustomerBLL.GetListALlCustomer();
                indexCustomerId = lstCustomer.FindIndex(x => x.MaNCC == int.Parse(dgv_DSSP["col_MaNCC", index].Value.ToString()));

                List<ProductTypeBO> lstProductType = objProductTypeBLL.GetALLProductType();
                indexProductTypeId = lstProductType.FindIndex(x => x.MaLoaiSP == int.Parse(dgv_DSSP["col_MaLoaiSP", index].Value.ToString()));
                if (dgv_DSSP["col_DonViTinh", index].Value == null)
                {
                    objProductBO.DVT = "Lon";
                }
                else
                {
                    objProductBO.DVT = dgv_DSSP["col_DonViTinh", index].Value.ToString();
                }
                Program.frmChinhSuaSP = new FormChinhSuaSP();
                Program.frmChinhSuaSP.ShowDialog();
                
            }
            //Xóa Sản Phẩm
            if (dgv_DSSP["col_Xoa", index].Selected)
            {
                ProductBO objProductDel = new ProductBO();
                objProductDel.MaSP = dgv_DSSP["col_MaSP", index].Value.ToString();
                List<ProductBO> lstProduct = new List<ProductBO>();
                lstProduct.Add(objProductDel);
                objProductBLL.DeleteMultiProduct(lstProduct);
                if (objProductBLL.DeleteMultiProduct(lstProduct))
                {
                    MessageBox.Show("Xóa Sản Phẩm Thành Công");
                    Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString());
                    FormMain.lstProduct = objProductBLL.GetListAllProduct();
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá tình Xóa Sản Phẩm");
                }
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            isEdit = false;
            Program.frmChinhSuaSP = new FormChinhSuaSP();
            Program.frmChinhSuaSP.ShowDialog();
        }
    }
}
