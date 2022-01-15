using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAO;
using BO;

namespace BachHoaXanh_Store
{
    public partial class FormTraHangNCC : Form
    {
        UserBO objUser = FormLogin.objUserBO;
        CustomerBLL objCustomerBLL = new CustomerBLL();
        ProductBLL objProductBLL = new ProductBLL();
        ProductTypeBLL objProductTyepBLL = new ProductTypeBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        ReturnProductBLL objReturnProductBLL = new ReturnProductBLL();
        public static List<OrderDetailBO> lstOrderDetailBO = new List<OrderDetailBO>();
        public static int intTotalPrice = 0;
        public static string strCustomerName = string.Empty;
        public static int intCustomerId = 0;
        public FormTraHangNCC()
        {
            InitializeComponent();
            toolTip1.SetToolTip(cbo_LoaiSP, "Chọn tìm kiếm theo loại sản phẩm");
            toolTip1.SetToolTip(cbo_NhaCungCap, "Chọn tìm kiếm theo nhà cung cấp");
            toolTip1.SetToolTip(txtKeyWord, "Tìm kiếm dữ liệu sản phẩm");

            cbo_NhaCungCap.DataSource = objCustomerBLL.GetListALlCustomer();
            cbo_NhaCungCap.DisplayMember = "FullName";
            cbo_NhaCungCap.ValueMember = "MaNCC";

            cbo_LoaiSP.DataSource = objProductTyepBLL.GetALLProductType();
            cbo_LoaiSP.DisplayMember = "FullName";
            cbo_LoaiSP.ValueMember = "MaLoaiSP";
            if (objUser.Permission == 2)
            {
                cbo_NhaCungCap.SelectedIndex = 0;
                cbo_NhaCungCap.Enabled = false;
                cbo_PageSize.SelectedIndex = 0;
            }
            if (objUser.Permission == 1)
            {
                cbo_NhaCungCap.SelectedIndex = 1;
                cbo_PageSize.SelectedIndex = 0;
            }
        }

        private void btn_LapPhieu_Click(object sender, EventArgs e)
        {
            if (dgv_Order.Rows.Count > 0)
            {
                bool isOpen = true;
                int Id = objReturnProductBLL.GetIdNew() + 1;
                for (int i = 0; i < dgv_Order.Rows.Count; i++)
                {
                    int intStock;
                    string strProductName = string.Empty;
                    int? intStockProduct = 0;
                    ProductBO objProductTmp = new ProductBO();
                    ProductOrderCustomerBO objProductOrderCustomerBOTmp = new ProductOrderCustomerBO();
                    DateTime dDate = DateTime.Now.Date;
                    if (objUser.Permission == 1)
                    {
                        objProductTmp = objProductBLL.GetProductByKeys(dgv_Order["MaSP", i].Value.ToString().Trim()).FirstOrDefault();
                        strProductName = objProductTmp.TenSP;
                        intStockProduct = objProductTmp.SoLuong;
                    }
                    if (objUser.Permission == 2)
                    {
                        objProductOrderCustomerBOTmp = objOrderStoreBLL.GetProductFromStore(dgv_Order["MaSP", i].Value.ToString().Trim(), 0, 0, int.MaxValue, 10, (int)objUser.StoreId).FirstOrDefault();
                        strProductName = objProductOrderCustomerBOTmp.TenSP;
                        intStockProduct = objProductOrderCustomerBOTmp.SoLuong;
                    }

                    if (!int.TryParse(dgv_Order["SoLuong", i].Value.ToString(), out intStock))
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + strProductName + " ] có số lượng trả phải là số nguyên dương và lớn hơn 0" + Environment.NewLine + "và nhỏ hơn hoặc bằng số lượng tồn của kho");
                        isOpen = false;
                        lstOrderDetailBO = new List<OrderDetailBO>();
                        return;
                    }
                    else if (intStock == 0)
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + strProductName + " ] có số lượng trả phải là số nguyên dương lớn hơn 0" + Environment.NewLine + "và nhỏ hơn hoặc bằng số lượng tồn của kho");
                        isOpen = false;
                        lstOrderDetailBO = new List<OrderDetailBO>();
                        return;
                    }
                    else if (intStock > intStockProduct)
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + strProductName + " ] có số lượng trả phải là số nguyên dương lớn hơn 0" + Environment.NewLine + "và nhỏ hơn hoặc bằng số lượng tồn của kho");
                        isOpen = false;
                        lstOrderDetailBO = new List<OrderDetailBO>();
                        return;
                    }
                    else if (!DateTime.TryParse(dgv_Order["col_NgayHetHan", i].Value.ToString(), out dDate))
                    {
                        MessageBox.Show("Ngày hết hạn của sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + strProductName + " ] không đúng định dạng (dd/MM/yyyy). Xin vui lòng thử lại");
                        return;
                    }
                    else
                    {
                        TimeSpan interval = dDate.Subtract(DateTime.Now);
                        if (interval.Days < 29)
                        {
                            MessageBox.Show("Ngày hết hạn của sản phẩm [ " + dgv_Order["MaSP", i].Value.ToString() + " - " + strProductName + " ] phải từ 30 ngày trở lên." + Environment.NewLine + "Xin vui lòng kiểm tra lại");
                            isOpen = false;
                            lstOrderDetailBO = new List<OrderDetailBO>();
                            return;
                        }
                        else
                        {
                            OrderDetailBO objOrderCustomerDetailBO = new OrderDetailBO();
                            objOrderCustomerDetailBO.MaHD = Id;
                            objOrderCustomerDetailBO.MaSP = dgv_Order["MaSP", i].Value.ToString();
                            objOrderCustomerDetailBO.TenSP = dgv_Order["TenSP", i].Value.ToString();
                            objOrderCustomerDetailBO.SoLuong = int.Parse(dgv_Order["SoLuong", i].Value.ToString());
                            objOrderCustomerDetailBO.Ngay = dgv_Order["col_NgayHetHan", i].Value.ToString();
                            lstOrderDetailBO.Add(objOrderCustomerDetailBO);
                            if (objUser.Permission != 1)
                            {
                                strCustomerName = cbo_NhaCungCap.Text;
                                intCustomerId = int.Parse(cbo_NhaCungCap.SelectedValue.ToString());
                            }
                        }
                    }
                }
                if (objUser.Permission == 1)
                {
                    var objProduct = objProductBLL.GetProductByid(dgv_Order["MaSP", 0].Value.ToString().Trim());
                    var objCustomeer = objCustomerBLL.GetListALlCustomer().Where(x => x.MaNCC == objProduct.MaNCC).FirstOrDefault();
                    strCustomerName = objCustomeer.FullName;
                    intCustomerId = objCustomeer.MaNCC;
                }
                    
                if (isOpen == true)
                {
                    FormPhieuTraHang frmPhieuTraHang = new FormPhieuTraHang();
                    frmPhieuTraHang.CloseDialogEvent += frmPhieuTraHang_Event;
                    frmPhieuTraHang.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Danh sách hàng hóa cần đặt không được rỗng");
            }
        }

        private void frmPhieuTraHang_Event()
        {
            dgv_Order.Rows.Clear();
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
        }

        private void Search(string strProductName, string strCustomerId, string strProductTypeId, string strPageSize)
        {
            if (objUser.Permission == 1)
            {
                if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) == 1)
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeysForOrderCustomer(strProductName.Trim(), 0, 0, int.MaxValue, int.Parse(strPageSize));
                }
                else if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) != 1)
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeysForOrderCustomer(strProductName.Trim(), int.Parse(strProductTypeId), 0, int.MaxValue, int.Parse(strPageSize));
                }
                else if (int.Parse(strCustomerId) != 1 && int.Parse(strProductTypeId) == 1)
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeysForOrderCustomer(strProductName.Trim(), 0, int.Parse(strCustomerId), int.MaxValue, int.Parse(strPageSize));
                }
                else
                {
                    dgv_DSSP.DataSource = objProductBLL.GetProductByKeysForOrderCustomer(strProductName.Trim(), int.Parse(strProductTypeId), int.Parse(strCustomerId), int.MaxValue, int.Parse(strPageSize));
                }
            }
            else
            {
                if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) == 1)
                {
                    dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), 0, 0, int.MaxValue, int.Parse(strPageSize), (int)objUser.StoreId);
                }
                else if (int.Parse(strCustomerId) == 1 && int.Parse(strProductTypeId) != 1)
                {
                    dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), int.Parse(strProductTypeId), 0, int.MaxValue, int.Parse(strPageSize), (int)objUser.StoreId);
                }
                else if (int.Parse(strCustomerId) != 1 && int.Parse(strProductTypeId) == 1)
                {
                    dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), 0, int.Parse(strCustomerId), int.MaxValue, int.Parse(strPageSize), (int)objUser.StoreId);
                }
                else
                {
                    dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStore(strProductName.Trim(), int.Parse(strProductTypeId), int.Parse(strCustomerId), int.MaxValue, int.Parse(strPageSize), (int)objUser.StoreId);
                }
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            
            if (objUser.Permission == 1)
            {
                if (cbo_NhaCungCap.SelectedValue.ToString() != "1")
                {
                    Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp BHX chỉ áp dụng cho siêu thị");
                }
            }
            else
            {
                Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
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
                string date = DateTime.Now.Date.AddDays(30).ToString("d");
                cbo_NhaCungCap.Enabled = false;
                if (dgv_Order.Rows.Count == 0)
                {
                    this.dgv_Order.Rows.Add(dgv_DSSP["col_MaSP", index].Value.ToString(), dgv_DSSP["col_TenSP", index].Value.ToString(), "1", dgv_DSSP["col_GiaVon", index].Value.ToString(), date);
                }
                else
                {
                    int indexOrder = -1;
                    for (int i = 0; i < dgv_Order.Rows.Count; i++)
                    {
                        if (dgv_DSSP["col_MaSP", index].Value.ToString() == dgv_Order["MaSP", i].Value.ToString() && dgv_Order["MaSP", i].Value != null)
                        {
                            int intSoluong = (int.Parse(dgv_Order["SoLuong", i].Value.ToString()) + 1);
                            if (intSoluong > int.Parse(dgv_DSSP["col_SoLuong", index].Value.ToString()))
                            {
                                MessageBox.Show("Số lượng cần trả phải nhỏ hơn hoặc bằng số lượng tôn của kho");
                                return;
                            }
                            else
                            {
                                dgv_Order["SoLuong", i].Value = (int.Parse(dgv_Order["SoLuong", i].Value.ToString()) + 1).ToString();
                                indexOrder = i;
                                return;
                            }
                        }
                    }
                    if (indexOrder == -1)
                    {
                        this.dgv_Order.Rows.Add(dgv_DSSP["col_MaSP", index].Value.ToString(), dgv_DSSP["col_TenSP", index].Value.ToString(), "1", dgv_DSSP["col_GiaVon", index].Value.ToString(), date);
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

        private void cbo_PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(txtKeyWord.Text, cbo_NhaCungCap.SelectedValue.ToString(), cbo_LoaiSP.SelectedValue.ToString(), cbo_PageSize.Text);
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            dgv_Order.Rows.Clear();
        }
    }
}
