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
    public partial class FormNhapHang : Form
    {
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        CustomerBLL objCustomerBLL = new CustomerBLL();
        WHStoreBLL objWHStoreBLL = new WHStoreBLL();
        public FormNhapHang()
        {
            InitializeComponent();
            toolTip1.SetToolTip(cbo_NhaCungCap, "Tìm kiếm đơn hàng từ nhà cung cấp"); 
            toolTip1.SetToolTip(txtKeyWord, "Tìm kiếm");
            if (FormLogin.objUserBO.Permission != 1)
            {
                cbo_NhaCungCap.Text = "1 - Bách Hóa Xanh";
            }
            else
            {
                cbo_NhaCungCap.DataSource = objCustomerBLL.GetListALlCustomer();
                cbo_NhaCungCap.DisplayMember = "FullName";
                cbo_NhaCungCap.ValueMember = "MaNCC";

                dgv_DSDH.Columns["col_MaDH"].DataPropertyName = "MaHDDat";
                dgv_DSDH.Columns["col_MaST"].DataPropertyName = "MaNCC";
                dgv_DSDH.Columns["col_MaST"].HeaderText = "Mã nhà cung cáp";
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (FormLogin.objUserBO.Permission != 1)
            {
                string key = string.Empty;
                if (txtKeyWord.Text.Trim() == null || txtKeyWord.Text.Trim() == string.Empty)
                {
                    key = txtKeyWord.Text.Trim();
                }
                else
                {
                    if (int.TryParse(txtKeyWord.Text.Trim(), out int intMaHD))
                    {
                        key = intMaHD.ToString();
                    }
                    else
                    {
                        key = txtKeyWord.Text.Trim();
                    }
                }
                dgv_DSDH.DataSource = objOrderStoreBLL.GetListOrderFromStoreBO((int)FormLogin.objUserBO.StoreId, 1, key);
            }
            else
            {
                int intOrderStoreId = 0;
                if (txtKeyWord.Text.Trim() != "")
                {
                    if (!int.TryParse(txtKeyWord.Text.Trim(), out intOrderStoreId))
                    {
                        MessageBox.Show("Mã đơn hàng phải là số nguyên dương và lớn hơn 0 hoặc không cần nhập. Xin vui lòng thử lại");
                    }
                }
                if (intOrderStoreId < 0)
                {
                    MessageBox.Show("Mã đơn hàng phải là số nguyên dương và lớn hơn 0. Xin vui lòng thử lại");
                }
                else
                {
                    dgv_DSDH.DataSource = objOrderCustomerBLL.GetListOrderCustomer(intOrderStoreId, int.Parse(cbo_NhaCungCap.SelectedValue.ToString().Trim()), 0);
                }
            }
        }

        private void dgv_DSDH_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_DSDH.CurrentCell.RowIndex;
            if (FormLogin.objUserBO.Permission != 1)
            {
                if (dgv_DSDH.DataSource != null && index != -1)
                {
                    dgv_DSCTDH.Rows.Clear();
                    List<GetListOrderStoreByOrderIdBO> lstOrder = objOrderStoreDetailBLL.GetListOrderStoreByOrderId(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
                    foreach (GetListOrderStoreByOrderIdBO item in lstOrder)
                    {
                        dgv_DSCTDH.Rows.Add(item.MaSP, item.TenSP, item.SoLuong, item.SoLuong);
                    }
                }
                
            }
            else
            {
                dgv_DSCTDH.Rows.Clear();
                List<GetListOrderStoreByOrderIdBO> lstOrder = objOrderCustomerBLL.GetListOrderCustomerDetail(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
                foreach (GetListOrderStoreByOrderIdBO item in lstOrder)
                {
                    dgv_DSCTDH.Rows.Add(item.MaSP, item.TenSP, item.SoLuong, item.SoLuong);
                }
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (dgv_DSCTDH.Rows.Count > 0)
            {
                List<ProductBO> lstProductBO = new List<ProductBO>();
                int index = dgv_DSDH.CurrentCell.RowIndex;
                for (int i = 0; i < dgv_DSCTDH.Rows.Count; i++)
                {
                    int intStock;
                    if (dgv_DSCTDH["col_SoLuongNhap", i].Value != null)
                    {
                        if (!int.TryParse(dgv_DSCTDH["col_SoLuongNhap", i].Value.ToString().Trim(), out intStock))
                        {
                            MessageBox.Show("Sản phẩm [ " + dgv_DSCTDH["col_MaSP", i].Value.ToString() + " - " + dgv_DSCTDH["col_TenSP", i].Value.ToString() + " ] có số lượng nhập phải là số nguyên dương lớn hơn 0" + Environment.NewLine + "Và có sô lượng nhập phải bé hơn hoặc bằng số lượng đặt của Phiếu đặt hàng");
                            return;
                        }
                        if (intStock > int.Parse(dgv_DSCTDH["col_SoLuong", i].Value.ToString().Trim()) || intStock < 0)
                        {
                            MessageBox.Show("Sản phẩm [ " + dgv_DSCTDH["col_MaSP", i].Value.ToString() + " - " + dgv_DSCTDH["col_TenSP", i].Value.ToString() + " ] có số lượng nhập phải nhỏ hơn hoặc bằng số lượng đặt của siêu thị");
                            return;
                        }
                        else
                        {
                            ProductBO objProductBO = new ProductBO();
                            objProductBO.MaSP = dgv_DSCTDH["col_MaSP", i].Value.ToString().Trim();
                            objProductBO.TenSP = dgv_DSCTDH["col_TenSP", i].Value.ToString().Trim();
                            objProductBO.SoLuong = intStock;
                            lstProductBO.Add(objProductBO);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_DSCTDH["col_MaSP", i].Value.ToString() + " - " + dgv_DSCTDH["col_TenSP", i].Value.ToString() + " ] có số lượng nhập phải là số nguyên dương và lớn hơn 0");
                        return;
                    }
                }
                if (lstProductBO.Count == dgv_DSCTDH.Rows.Count)
                {
                    
                    if (FormLogin.objUserBO.Permission != 1)
                    {
                        int intMaHD = int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim());
                        ExportProductBLL objExportProductBLL = new ExportProductBLL();
                        var lstExportProductDetail = objExportProductBLL.GetExportProductDetailByOrderStoreId(intMaHD, (int)FormLogin.objUserBO.StoreId);
                        bool isSuccess = true;
                        foreach (var item in lstProductBO)
                        {
                            var objDetail = lstExportProductDetail.Where(x => x.MaSP.Trim() == item.MaSP.Trim()).FirstOrDefault();
                            if (objDetail.SoLuong < item.SoLuong)
                            {
                                MessageBox.Show("Sản phẩm [ " + item.MaSP + " - " + item.TenSP + " ] có số lượng nhập là [ " + item.SoLuong + " ] lớn hơn số lượng xuất của kho là [ " + objDetail.SoLuong + " ]");
                                isSuccess = false;
                                return;
                            }
                        }
                        if (isSuccess)
                        {
                            if (objWHStoreBLL.UpdateStockOfProductFromStore((int)FormLogin.objUserBO.StoreId, lstProductBO))
                            {
                                objOrderStoreBLL.UpdateOrderStoreStatus(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
                            }
                        }
                    }

                    else
                    {
                        objOrderCustomerBLL.UpdateCustomerOrder(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()), lstProductBO);
                    }
                    MessageBox.Show("Nhập hàng thành công!");
                    lstProductBO = new List<ProductBO>();
                    dgv_DSCTDH.Rows.Clear();
                    Search();
                }
            }
        }
    }
}
