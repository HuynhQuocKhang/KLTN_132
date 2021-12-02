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
        public static UserBO objUser = new UserBO();
        CustomerBLL objCustomerBLL = new CustomerBLL();
        ProductBLL objProductBll = new ProductBLL();
        public static List<OrderCustomerDetailBO> lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
        public static int intTotalPrice = 0;
        public FormDatHang()
        {
            InitializeComponent();
            objUser.UserFullName = "Võ Hoàng Bảo Sơn";
            objUser.Permission = "Kho";
            cbo_NhaCungCap.DataSource = objCustomerBLL.GetListALlCustomer();
            cbo_NhaCungCap.DisplayMember = "FullName";
            cbo_NhaCungCap.ValueMember = "MaNCC";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (dgv_Order.Rows.Count > 0)
            {
                bool isOpen = true;
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
                    //else if (intStock > objProductBll.GetProductByKeys(dgv_Order["MaSP", i].Value.ToString(), 0, int.Parse(cbo_NhaCungCap.SelectedValue.ToString())).FirstOrDefault().SoLuong)
                    //{
                    //    MessageBox.Show("Sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + dgv_DSSP["col_TenSP", i].Value.ToString() + " ] có số lượng đặt phải bé hơn số lượng tồn của kho");
                    //    isOpen = false;
                    //    lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
                    //    return;
                    //}
                    else
                    {
                        OrderCustomerDetailBO objOrderCustomerDetailBO = new OrderCustomerDetailBO();
                        objOrderCustomerDetailBO.MaSP = dgv_Order["MaSP", i].Value.ToString();
                        objOrderCustomerDetailBO.SoLuong = int.Parse(dgv_Order["SoLuong", i].Value.ToString());
                        objOrderCustomerDetailBO.GiaVon = int.Parse(dgv_Order["GiaVon", i].Value.ToString());
                        objOrderCustomerDetailBO.ThanhTien = int.Parse(dgv_Order["col_ThanhTien", i].Value.ToString());
                        lstOrderCustomerDetailBO.Add(objOrderCustomerDetailBO);
                        intTotalPrice += int.Parse(dgv_Order["col_ThanhTien", i].Value.ToString());
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
            if (objUser.Permission == "Kho")
            {
                if (cbo_NhaCungCap.SelectedValue.ToString() != "1")
                {
                    Search(txtKeyWord.Text.Trim(), cbo_NhaCungCap.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp BHX chỉ áp dụng cho siêu thị");
                }
            }

        }
        private void Search(string strProductName, string strCustomerId)
        {
            if (int.Parse(strCustomerId) == 1)
            {
                dgv_DSSP.DataSource = objProductBll.GetProductByKeys(strProductName.Trim(), 0, 0);
            }
            else
            {
                dgv_DSSP.DataSource = objProductBll.GetProductByKeysForOrderCustomer(strProductName.Trim(), 0, int.Parse(strCustomerId));
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            int index = dgv_DSSP.CurrentCell.RowIndex;
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
                        dgv_Order["SoLuong", i].Value = (int.Parse(dgv_Order["SoLuong", index].Value.ToString()) + 1).ToString();
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
                }
                if (index < 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa");
                }
            }
        }
    }
}
