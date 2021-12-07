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
    public partial class FormDatHang : Form
    {
        UserBO objUser = FormLogin.objUserBO;
        CustomerBLL objCustomerBLL = new CustomerBLL();
        ProductBLL objProductBll = new ProductBLL();
        ProductTypeBLL objProductTyepBLL = new ProductTypeBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        public static List<OrderCustomerDetailBO> lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
        public static int intTotalPrice = 0;
        public static string strCustomerName = string.Empty;
        public static int intCustomerId = 0;
        public FormDatHang()
        {
            InitializeComponent();
            cbo_NhaCungCap.DataSource = objCustomerBLL.GetListALlCustomer();
            cbo_NhaCungCap.DisplayMember = "FullName";
            cbo_NhaCungCap.ValueMember = "MaNCC";
            toolTip1.SetToolTip(cbo_LoaiSP, "Chọn tìm kiếm theo loại sản phẩm");
            toolTip1.SetToolTip(cbo_NhaCungCap, "Chọn tìm kiếm theo nhà cung cấp");
            toolTip1.SetToolTip(txtSoLuong, "Tìm kiếm những sản phẩm có số lượng nhỏ hơn hoặc bằng số lượng nhập vào");
            toolTip1.SetToolTip(txtKeyWord, "Tìm kiếm dữ liệu sản phẩm");

            cbo_LoaiSP.DataSource = objProductTyepBLL.GetALLProductType();
            cbo_LoaiSP.DisplayMember = "FullName";
            cbo_LoaiSP.ValueMember = "MaLoaiSP";
            if (objUser.Permission == 2)
            {
                cbo_NhaCungCap.SelectedIndex = 0;
                cbo_NhaCungCap.Enabled = false;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (dgv_Order.Rows.Count > 0)
            {
                bool isOpen = true;
                int Id = objOrderCustomerBLL.GetOrderCustomerIdNew() + 1;
                for (int i = 0; i < dgv_Order.Rows.Count; i++)
                {
                    int intStock;
                    if (!int.TryParse(dgv_Order["SoLuong", i].Value.ToString(), out intStock))
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + dgv_DSSP["col_TenSP", i].Value.ToString() + " ] có số lượng đặt phải là số nguyên dương và lớn hơn 0");
                        isOpen = false;
                        lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
                        return;
                    }
                    else if (intStock == 0)
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + dgv_DSSP["col_TenSP", i].Value.ToString() + " ] có số lượng đặt phải là số nguyên dương và lớn hơn 0");
                        isOpen = false;
                        lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
                        return;
                    }
                    else
                    {
                        OrderCustomerDetailBO objOrderCustomerDetailBO = new OrderCustomerDetailBO();
                        objOrderCustomerDetailBO.MaHDDat = Id;
                        objOrderCustomerDetailBO.MaSP = dgv_Order["MaSP", i].Value.ToString();
                        objOrderCustomerDetailBO.TenSP = dgv_Order["TenSP", i].Value.ToString();
                        objOrderCustomerDetailBO.SoLuong = int.Parse(dgv_Order["SoLuong", i].Value.ToString());
                        objOrderCustomerDetailBO.GiaVon = int.Parse(dgv_Order["GiaVon", i].Value.ToString());
                        objOrderCustomerDetailBO.ThanhTien = int.Parse(dgv_Order["col_ThanhTien", i].Value.ToString());
                        lstOrderCustomerDetailBO.Add(objOrderCustomerDetailBO);
                        intTotalPrice += int.Parse(dgv_Order["col_ThanhTien", i].Value.ToString());
                        strCustomerName = cbo_NhaCungCap.Text;
                        intCustomerId = int.Parse(cbo_NhaCungCap.SelectedValue.ToString());
                    }
                }

                if (isOpen == true)
                {
                    Program.frmDonDatHang = new FormDonDatHang();
                    Program.frmDonDatHang.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Danh sách hàng hóa cần đặt không được rỗng");
            }

        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (objUser.Permission == 1)
            {
                if (cbo_NhaCungCap.SelectedValue.ToString() != "1")
                {
                    Search(txtKeyWord.Text.Trim(), cbo_LoaiSP.SelectedValue.ToString(), cbo_NhaCungCap.SelectedValue.ToString(), txtSoLuong.Text);
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp BHX chỉ áp dụng cho siêu thị");
                }
            }
            else
            {
                Search(txtKeyWord.Text.Trim(), cbo_LoaiSP.SelectedValue.ToString(), cbo_NhaCungCap.SelectedValue.ToString(), txtSoLuong.Text);
            }

        }
        private void Search(string strProductName, string strProductTypeId, string strCustomerId, string strStock)
        {
            if (strStock == null || strStock.Trim() == String.Empty)
            {
                MessageBox.Show("Só lượng phải lớn hoặc hoặc bằng 0 và là số nguyên dương");
            }
            else
            {
                if (objUser.Permission == 1)
                {
                    if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) == 1)
                    {
                        dgv_DSSP.DataSource = objProductBll.GetProductByKeysForOrderCustomer(strProductName.Trim(), 0, 0, int.Parse(strStock));
                    }
                    else if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) != 1)
                    {
                        dgv_DSSP.DataSource = objProductBll.GetProductByKeysForOrderCustomer(strProductName.Trim(), int.Parse(strProductTypeId), 0, int.Parse(strStock));
                    }
                    else if (int.Parse(strCustomerId) != 1 && int.Parse(strProductTypeId) == 1)
                    {
                        dgv_DSSP.DataSource = objProductBll.GetProductByKeysForOrderCustomer(strProductName.Trim(), 0, int.Parse(strCustomerId), int.Parse(strStock));
                    }
                    else
                    {
                        dgv_DSSP.DataSource = objProductBll.GetProductByKeysForOrderCustomer(strProductName.Trim(), int.Parse(strProductTypeId), int.Parse(strCustomerId), int.Parse(strStock));
                    }
                }
                else
                {
                    if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) == 1)
                    {
                        dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), 0, 0, int.Parse(strStock), (int) objUser.StoreId);
                    }
                    else if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) != 1)
                    {
                        dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), int.Parse(strProductTypeId), 0, int.Parse(strStock), (int)objUser.StoreId);
                    }
                    else if (int.Parse(strCustomerId) != 1 && int.Parse(strProductTypeId) == 1)
                    {
                        dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), 0, int.Parse(strCustomerId), int.Parse(strStock), (int)objUser.StoreId);
                    }
                    else
                    {
                        dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), int.Parse(strProductTypeId), int.Parse(strCustomerId), int.Parse(strStock), (int) objUser.StoreId);
                    }
                }
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (dgv_DSSP.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu của danh sách đang rông. Xin vui lòng thử lại");
            }
            else
            {
                int index = dgv_DSSP.CurrentCell.RowIndex;
                cbo_NhaCungCap.Enabled = false;
                if (dgv_Order.Rows.Count == 0)
                {
                    this.dgv_Order.Rows.Add(dgv_DSSP["col_MaSP", index].Value.ToString(), dgv_DSSP["col_TenSP", index].Value.ToString(), "1", dgv_DSSP["col_GiaVon", index].Value.ToString(), dgv_DSSP["col_GiaVon", index].Value.ToString());
                }
                else
                {
                    int indexOrder = -1;
                    for (int i = 0; i < dgv_Order.Rows.Count; i++)
                    {
                        if (dgv_DSSP["col_MaSP", index].Value.ToString() == dgv_Order["MaSP", i].Value.ToString() && dgv_Order["MaSP", i].Value != null)
                        {
                            dgv_Order["SoLuong", i].Value = (int.Parse(dgv_Order["SoLuong", i].Value.ToString()) + 1).ToString();
                            dgv_Order["col_ThanhTien", i].Value = (int.Parse(dgv_Order["SoLuong", i].Value.ToString()) * int.Parse(dgv_Order["GiaVon", i].Value.ToString())).ToString();
                            indexOrder = i;
                            return;
                        }
                    }
                    if (indexOrder == -1)
                    {
                        this.dgv_Order.Rows.Add(dgv_DSSP["col_MaSP", index].Value.ToString(), dgv_DSSP["col_TenSP", index].Value.ToString(), "1", dgv_DSSP["col_GiaVon", index].Value.ToString(), dgv_DSSP["col_GiaVon", index].Value.ToString());
                    }
                }
            }    

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

            if (dgv_Order.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm cần đặt hiện đang trống");
            }
            else
            {
                int index = dgv_Order.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    dgv_Order.Rows.RemoveAt(index);
                    if (dgv_Order.Rows.Count == 0 && objUser.Permission == 1)
                    {
                        cbo_NhaCungCap.Enabled = true;
                    }
                }
                if (index < 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa");
                }
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            dgv_DSSP.DataSource = objProductBll.GetProductByKeysForOrderCustomer("", 0, 0, 1000);
        }
    }
}
