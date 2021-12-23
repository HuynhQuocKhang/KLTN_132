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
    public partial class FormDanhSachSP : Form
    {
        #region Biến dùng chung
        ProductBLL objProductBLL = new ProductBLL();
        CustomerBLL objcustomerBLL = new CustomerBLL();
        ProductTypeBLL objProductTypeBLL = new ProductTypeBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        #endregion

        #region Biến public sử dụng chung cho các form
        public static ProductBO objProductBO = new ProductBO();
        public static int indexCustomerId = 0;
        public static int indexProductTypeId = 0;
        public static bool isEdit = false;
        public static ProductPromotionBO objPromotion = new ProductPromotionBO();
        #endregion
        public FormDanhSachSP()
        {
            InitializeComponent();
            cbo_NhaCungCap.DataSource = objcustomerBLL.GetListALlCustomer();
            cbo_NhaCungCap.DisplayMember = "FullName";
            cbo_NhaCungCap.ValueMember = "MaNCC";
            if (FormLogin.objUserBO.Permission != 1)
            {
                bunifuButton3.Visible = false;
                cbo_NhaCungCap.SelectedIndex = 0;
                cbo_NhaCungCap.Enabled = false;
                dgv_DSSP.Columns["col_Sua"].Visible = false;
                dgv_DSSP.Columns["col_Xoa"].Visible = false;
                chk_AllStore.Visible = true;
                chk_AllStore.Checked = false;
                bunifuCustomLabel1.Visible = true;
                bunifuButton1.Text = "Cập Nhật Sản Phẩm Khuyến Mãi";
            }

            toolTip1.SetToolTip(cbo_LoaiSP, "Chọn tìm kiếm theo loại sản phẩm");
            toolTip1.SetToolTip(cbo_NhaCungCap, "Chọn tìm kiếm theo nhà cung cấp");
            toolTip1.SetToolTip(txtKeyWord, "Tìm kiếm dữ liệu sản phẩm");

            cbo_LoaiSP.DataSource = objProductTypeBLL.GetALLProductType();
            cbo_LoaiSP.DisplayMember = "FullName";
            cbo_LoaiSP.ValueMember = "MaLoaiSP";
            cbo_PageSize.SelectedIndex = 0;
        }

        private void dgv_DSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);

        }
        //Tìm kiếm sản phẩm theo key and customerid
        private void Search(string strProductName, string strCustomerId, string strProductTypeId, string strPageSize)
        {
            if (FormLogin.objUserBO.Permission != 1)
            {
                if (chk_AllStore.Checked == true)
                {
                    if (int.Parse(strProductTypeId) == 1)
                    {
                        dgv_DSSP.DataSource = objProductBLL.GetProductPromotionFromStore(strProductName.Trim(), 0, 0, int.MaxValue, int.Parse(strPageSize.Trim()), (int)FormLogin.objUserBO.StoreId);
                    }
                    else
                    {
                        dgv_DSSP.DataSource = objProductBLL.GetProductPromotionFromStore(strProductName.Trim(), int.Parse(strProductTypeId), 0, int.MaxValue, int.Parse(strPageSize.Trim()), (int)FormLogin.objUserBO.StoreId);
                    }
                    bunifuButton1.Visible = false;

                }
                else
                {
                    if (int.Parse(strProductTypeId) == 1)
                    {
                        dgv_DSSP.DataSource = objOrderStoreBLL.GetProductBOFromStore(strProductName.Trim(), 0, 0, int.MaxValue, int.Parse(strPageSize.Trim()), (int)FormLogin.objUserBO.StoreId);
                    }
                    else
                    {
                        dgv_DSSP.DataSource = objOrderStoreBLL.GetProductBOFromStore(strProductName.Trim(), int.Parse(strProductTypeId), 0, int.MaxValue, int.Parse(strPageSize.Trim()), (int)FormLogin.objUserBO.StoreId);
                    }
                    bunifuButton1.Visible = true;
                }
            }
            else
            {
                dgv_DSSP.Columns["col_NgayKM"].Visible = false;
                dgv_DSSP.Columns["col_NgayHetHan"].Visible = false;
                if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) == 1)
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeys(strProductName.Trim(), 0, 0, int.Parse(strPageSize.Trim()));
                }
                else if (int.Parse(strCustomerId) == 1)
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeys(strProductName.Trim(), int.Parse(strProductTypeId), 0, int.Parse(strPageSize.Trim()));
                }
                else if (int.Parse(strProductTypeId) == 1)
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeys(strProductName.Trim(), 0, int.Parse(strCustomerId), int.Parse(strPageSize.Trim()));
                }
                else
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeys(strProductName.Trim(), int.Parse(strProductTypeId), int.Parse(strCustomerId), int.Parse(strPageSize.Trim()));
                }
            }
        }
        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_DSSP.CurrentCell.RowIndex;

            //Sửa Sản phẩm
            if (dgv_DSSP["col_Sua", index].Selected)
            {
                if (FormLogin.objUserBO.Permission != 1)
                {
                    MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
                }
                else
                {
                    //Xét trạng thái form
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
                    FormChinhSuaSP frmChinhSuaSP = new FormChinhSuaSP();
                    frmChinhSuaSP.CloseDialogEvent += frmChinhSuaSP_Event;
                    frmChinhSuaSP.ShowDialog();
                }

            }
            //Xóa Sản Phẩm
            if (dgv_DSSP["col_Xoa", index].Selected)
            {
                if (FormLogin.objUserBO.Permission != 1)
                {
                    MessageBox.Show("Bạn không có quyền thực hiện chức năng này.");
                }
                else
                {
                    ProductBO objProductDel = new ProductBO();
                    objProductDel.MaSP = dgv_DSSP["col_MaSP", index].Value.ToString();
                    List<ProductBO> lstProduct = new List<ProductBO>();
                    lstProduct.Add(objProductDel);
                    objProductBLL.DeleteMultiProduct(lstProduct);
                    if (objProductBLL.DeleteMultiProduct(lstProduct))
                    {
                        MessageBox.Show("Xóa Sản Phẩm Thành Công");
                        Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
                        FormMain.lstProduct = objProductBLL.GetListAllProduct();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi trong quá tình Xóa Sản Phẩm");
                    }
                }
            }
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            isEdit = false;


            if (FormLogin.objUserBO.Permission == 1)
            {
                FormChinhSuaSP frmChinhSuaSP = new FormChinhSuaSP();
                frmChinhSuaSP.CloseDialogEvent += frmChinhSuaSP_Event;
                frmChinhSuaSP.ShowDialog();
            }
            else
            {
                int index = dgv_DSSP.CurrentCell.RowIndex;
                objPromotion = objOrderStoreBLL.GetProductPromotionFromStore(dgv_DSSP["col_MaSP", index].Value.ToString().Trim(), (int)FormLogin.objUserBO.StoreId).FirstOrDefault();
                if (objPromotion == null)
                {
                    objPromotion = new ProductPromotionBO();
                    isEdit = false;
                }
                else
                {
                    isEdit = true;
                }

                #region Truyền dữ liệu cho object chung
                objProductBO.MaSP = dgv_DSSP["col_MaSP", index].Value.ToString();
                objProductBO.TenSP = dgv_DSSP["col_TenSP", index].Value.ToString();
                objProductBO.MaLoaiSP = int.Parse(dgv_DSSP["col_MaLoaiSP", index].Value.ToString());
                objProductBO.MaNCC = int.Parse(dgv_DSSP["col_MaNCC", index].Value.ToString());
                objProductBO.SoLuong = int.Parse(dgv_DSSP["col_SoLuong", index].Value.ToString());
                #endregion

                FormThemSPKM frmThemSPKM = new FormThemSPKM();
                frmThemSPKM.CloseDialogEvent += frmThemSPKM_Event;
                frmThemSPKM.ShowDialog();
            }
        }
        void frmThemSPKM_Event()
        {
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
        }
        void frmChinhSuaSP_Event()
        {
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
        }
        private void cbo_PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
        }
    }
}
