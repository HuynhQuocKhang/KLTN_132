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
    public partial class FormBanHang : Form
    {
        StoreBLL objStoreBll = new StoreBLL();
        ProductBLL objProductBLL = new ProductBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        InvoiceBLL objInvoiceBLL = new InvoiceBLL();
        public static List<ProductBO> lstProduct = new List<ProductBO>();
        public static List<ProductBO> lstProductPromotion = new List<ProductBO>();
        public static List<InvoiceDetailBO> lsInvoiceDetail = new List<InvoiceDetailBO>();
        bool isApplyPromo = false;
        public FormBanHang()
        {
            InitializeComponent();
            lbl_MaSieuThi.Text = FormLogin.objUserBO.StoreId.ToString() + " - " + objStoreBll.getStoreNameByUser(FormLogin.objUserBO.StoreId);
            lbl_MaNhanVien.Text = FormLogin.objUserBO.UserFullName;
            txt_SoLuong.Text = "1";
            lbl_TongTien.Text = "0";
            lbl_SoLuong.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            label1.Text = DateTime.Now.ToString("T");
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_MaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (txt_MaSP.Text.Length > 0)
            {

            }
        }

        private void txt_MaSP_TextChange(object sender, EventArgs e)
        {
            if (txt_MaSP.Text.Length >= 13)
            {
                if (isApplyPromo == false)
                {
                    List<ProductOrderCustomerBO> lstResult = new List<ProductOrderCustomerBO>();
                    lstResult = objOrderStoreBLL.GetProductFromStore(txt_MaSP.Text.Trim(), 0, 0, int.MaxValue, 10, (int)FormLogin.objUserBO.StoreId);
                    if (lstResult.Count == 1)
                    {
                        if (txt_SoLuong.Text == null || txt_SoLuong.Text == string.Empty || txt_SoLuong.Text == "0")
                        {
                            txt_SoLuong.Text = "1";
                        }
                        ProductOrderCustomerBO objResult = lstResult.FirstOrDefault();
                        if (objResult.SoLuong == 0)
                        {
                            MessageBox.Show("Sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện tại đã hết trên hệ thống. Xin vui lòng chọn sản phẩm khác để thanh toán!");
                        }
                        if (objResult.SoLuong > 0)
                        {
                            var objProduct = objProductBLL.GetProductByKeys(txt_MaSP.Text.Trim(), 0, 0, 5);
                            if (dgv_DSSP.Rows.Count == 0)
                            {
                                if (int.Parse(txt_SoLuong.Text.Trim()) > objResult.SoLuong)
                                {
                                    MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                                else
                                {
                                    lbl_TongTien.Text = (int.Parse(txt_SoLuong.Text) * objProduct.FirstOrDefault().GiaBan).ToString();
                                    lbl_SoLuong.Text = txt_SoLuong.Text;
                                    dgv_DSSP.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text, objProduct.FirstOrDefault().GiaBan.ToString(), (int.Parse(txt_SoLuong.Text) * objProduct.FirstOrDefault().GiaBan).ToString());
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                            }
                            else
                            {
                                int intIndex = -1;
                                bool isExists = false;
                                for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                                {
                                    if (txt_MaSP.Text.Trim() == dgv_DSSP["col_MaSP", i].Value.ToString())
                                    {
                                        isExists = true;
                                        intIndex = i;
                                        break;
                                    }
                                }
                                if (isExists)
                                {
                                    int intSoluong = int.Parse(dgv_DSSP["col_SoLuong", intIndex].Value.ToString().Trim()) + int.Parse(txt_SoLuong.Text.Trim());
                                    int intTotalPrice = intSoluong * int.Parse(dgv_DSSP["col_GiaBan", intIndex].Value.ToString().Trim());
                                    if (intSoluong > objResult.SoLuong)
                                    {
                                        MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                        txt_MaSP.Clear();
                                        txt_SoLuong.Clear();
                                    }
                                    else
                                    {
                                        dgv_DSSP["col_SoLuong", intIndex].Value = intSoluong;
                                        dgv_DSSP["col_ThanhTien", intIndex].Value = intTotalPrice;
                                        txt_MaSP.Clear();
                                        txt_SoLuong.Clear();
                                    }
                                }
                                if (!isExists)
                                {
                                    dgv_DSSP.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text, objProduct.FirstOrDefault().GiaBan.ToString(), (int.Parse(txt_SoLuong.Text) * objProduct.FirstOrDefault().GiaBan).ToString());
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                                int totalPrice = 0;
                                int totalStock = 0;
                                for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                                {
                                    totalPrice += int.Parse(dgv_DSSP["col_ThanhTien", i].Value.ToString().Trim());
                                    totalStock += int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                                }
                                lbl_TongTien.Text = totalPrice.ToString();
                                lbl_SoLuong.Text = totalStock.ToString();
                            }
                        }
                    }
                }
                if (isApplyPromo == true)
                {
                    List<ProductPromotionBO> lstResult = new List<ProductPromotionBO>();
                    lstResult = objOrderStoreBLL.GetProductPromotionFromStore(txt_MaSP.Text.Trim(), (int)FormLogin.objUserBO.StoreId);
                    if (lstResult.Count == 1)
                    {
                        if (txt_SoLuong.Text == null || txt_SoLuong.Text == string.Empty || txt_SoLuong.Text == "0")
                        {
                            txt_SoLuong.Text = "1";
                        }
                        ProductPromotionBO objResult = lstResult.FirstOrDefault();
                        if (objResult.NgayKM <= DateTime.Now && objResult.NgayHetHan >= DateTime.Now)
                        {
                            if (objResult.SoLuong == 0)
                            {
                                MessageBox.Show("Sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện tại đã hết hàng KM trên hệ thống. Xin vui lòng chọn sản phẩm khác để thay thế!");
                            }
                            if (objResult.SoLuong > 0)
                            {
                                if (dgv_DSKM.Rows.Count == 0)
                                {
                                    if (int.Parse(txt_SoLuong.Text.Trim()) > objResult.SoLuong)
                                    {
                                        MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn KM trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                        txt_MaSP.Clear();
                                        txt_SoLuong.Clear();
                                    }
                                    else
                                    {
                                        lbl_SoLuong.Text = (int.Parse(lbl_SoLuong.Text) + int.Parse(txt_SoLuong.Text)).ToString();
                                        dgv_DSKM.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text);
                                        txt_MaSP.Clear();
                                        txt_SoLuong.Clear();
                                    }
                                }
                                else
                                {
                                    int intIndex = -1;
                                    bool isExists = false;
                                    for (int i = 0; i < dgv_DSKM.Rows.Count; i++)
                                    {
                                        if (txt_MaSP.Text.Trim() == dgv_DSKM["MaSP", i].Value.ToString())
                                        {
                                            isExists = true;
                                            intIndex = i;
                                            break;
                                        }
                                    }
                                    if (isExists)
                                    {
                                        int intSoluong = int.Parse(dgv_DSKM["SoLuong", intIndex].Value.ToString().Trim()) + int.Parse(txt_SoLuong.Text.Trim());
                                        if (intSoluong > objResult.SoLuong)
                                        {
                                            MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                            txt_MaSP.Clear();
                                            txt_SoLuong.Clear();
                                        }
                                        else
                                        {
                                            dgv_DSKM["SoLuong", intIndex].Value = intSoluong;
                                            txt_MaSP.Clear();
                                            txt_SoLuong.Clear();
                                        }
                                    }
                                    if (!isExists)
                                    {
                                        dgv_DSKM.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text);
                                        txt_MaSP.Clear();
                                        txt_SoLuong.Clear();
                                    }
                                    int totalStock = 0;
                                    for (int i = 0; i < dgv_DSKM.Rows.Count; i++)
                                    {
                                        totalStock += int.Parse(dgv_DSKM["SoLuong", i].Value.ToString().Trim());
                                    }
                                    for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                                    {
                                        totalStock += int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                                    }
                                    lbl_SoLuong.Text = totalStock.ToString();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] chỉ áp dụng khuyến mãi trong khoản [ " + objResult.NgayKM + " -> " + objResult.NgayHetHan + " ]. Xin vui lòng kiểm tra lại!");
                        }
                    }
                }
            }
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_TongTien.Text.Trim()) < 100000 && dgv_DSKM.Rows.Count > 0)
            {
                MessageBox.Show("Giá trị của hóa đơn không thỏa để áp dụng Sản phẩm khuyến mãi. Xin vui lòng kiểm tra lại!");
            }
            else if (dgv_DSSP.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm cần thanh toán hiện đang rỗng");
            }
            else
            {
                string strMaHD = FormLogin.objUserBO.StoreId.ToString() + FormLogin.objUserBO.UserId + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + (objInvoiceBLL.CountInvoicebyCreateDate(DateTime.Now) + 1).ToString();
                InvoiceBO objInvoiceBO = new InvoiceBO();
                objInvoiceBO.MaHD = strMaHD;
                objInvoiceBO.MaST = (int)FormLogin.objUserBO.StoreId;
                objInvoiceBO.MaNV = (int)FormLogin.objUserBO.UserId;
                objInvoiceBO.NgayTao = DateTime.Now;
                objInvoiceBO.TongSP = int.Parse(lbl_SoLuong.Text.Trim());
                objInvoiceBO.ThanhTien = int.Parse(lbl_TongTien.Text);
                if (objInvoiceBLL.InsertInvoice(objInvoiceBO))
                {
                    if (dgv_DSKM.Rows.Count > 0)
                    {
                        for (int i = 0; i < dgv_DSKM.Rows.Count; i++)
                        {
                            ProductBO objProduct = new ProductBO();
                            objProduct.MaSP = dgv_DSKM["MaSP", i].Value.ToString();
                            objProduct.SoLuong = int.Parse(dgv_DSKM["SoLuong", i].Value.ToString().Trim());
                            lstProductPromotion.Add(objProduct);

                            InvoiceDetailBO objInvoiceDetail = new InvoiceDetailBO();
                            objInvoiceDetail.MaHD = strMaHD;
                            objInvoiceDetail.MaSP = dgv_DSKM["MaSP", i].Value.ToString();
                            objInvoiceDetail.SoLuong = int.Parse(dgv_DSKM["SoLuong", i].Value.ToString().Trim());
                            objInvoiceDetail.ThanhTien = 0;
                            lsInvoiceDetail.Add(objInvoiceDetail);
                        }

                        for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                        {

                            ProductBO objProduct = new ProductBO();
                            objProduct.MaSP = dgv_DSSP["col_MaSP", i].Value.ToString();
                            objProduct.SoLuong = int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                            lstProduct.Add(objProduct);

                            InvoiceDetailBO objInvoiceDetail = new InvoiceDetailBO();
                            objInvoiceDetail.MaHD = strMaHD;
                            objInvoiceDetail.MaSP = dgv_DSSP["col_MaSP", i].Value.ToString();
                            objInvoiceDetail.SoLuong = int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                            objInvoiceDetail.ThanhTien = int.Parse(dgv_DSSP["col_ThanhTien", i].Value.ToString().Trim());
                            lsInvoiceDetail.Add(objInvoiceDetail);
                        }

                        if (objInvoiceBLL.InsertInvoiceDetail(lsInvoiceDetail) && objOrderStoreBLL.UpdateMultiProductFromStore(lstProduct, (int)FormLogin.objUserBO.StoreId) && objOrderStoreBLL.UpdateListProductPromotion(lstProductPromotion, (int)FormLogin.objUserBO.StoreId))
                        {
                            MessageBox.Show("Tạo hóa đơn thành công");
                            lstProduct = new List<ProductBO>();
                            lsInvoiceDetail = new List<InvoiceDetailBO>();
                            lstProductPromotion = new List<ProductBO>();
                            setColor(Color.FromArgb(76, 154, 42));
                            isApplyPromo = false;
                            Tag = "1";
                            txt_SoLuong.Text = "1";
                            lbl_TongTien.Text = "0";
                            lbl_SoLuong.Text = "0";
                            dgv_DSSP.Rows.Clear();
                            dgv_DSKM.Rows.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong quá trình thao tác. Xin vui lòng kiểm tra lại!");
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                        {

                            ProductBO objProduct = new ProductBO();
                            objProduct.MaSP = dgv_DSSP["col_MaSP", i].Value.ToString();
                            objProduct.SoLuong = int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                            lstProduct.Add(objProduct);

                            InvoiceDetailBO objInvoiceDetail = new InvoiceDetailBO();
                            objInvoiceDetail.MaHD = strMaHD;
                            objInvoiceDetail.MaSP = dgv_DSSP["col_MaSP", i].Value.ToString();
                            objInvoiceDetail.SoLuong = int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                            objInvoiceDetail.ThanhTien = int.Parse(dgv_DSSP["col_ThanhTien", i].Value.ToString().Trim());
                            lsInvoiceDetail.Add(objInvoiceDetail);
                        }

                        if (objInvoiceBLL.InsertInvoiceDetail(lsInvoiceDetail) && objOrderStoreBLL.UpdateMultiProductFromStore(lstProduct, (int)FormLogin.objUserBO.StoreId))
                        {
                            MessageBox.Show("Tạo hóa đơn thành công");
                            lstProduct = new List<ProductBO>();
                            lsInvoiceDetail = new List<InvoiceDetailBO>();
                            lstProductPromotion = new List<ProductBO>();
                            setColor(Color.FromArgb(76, 154, 42));
                            isApplyPromo = false;
                            Tag = "1";
                            txt_SoLuong.Text = "1";
                            lbl_TongTien.Text = "0";
                            lbl_SoLuong.Text = "0";
                            dgv_DSSP.Rows.Clear();
                            dgv_DSKM.Rows.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong quá trình thao tác. Xin vui lòng kiểm tra lại!");
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Khởi tạo hóa đơn thất bại. Xin vui lòng kiểm tra lại dữ liệu trước khi thanh toán!");
                }
            }
            
        }

        private void btn_ApDungKM_Click(object sender, EventArgs e)
        {
            if (Tag == "1")
            {
                if (int.Parse(lbl_TongTien.Text.Trim()) < 100000)
                {
                    MessageBox.Show("Gía trị của hóa đơn phải từ 100.000 trở lên mới được áp dụng khuyến mãi. Xin vui lòng kiểm tra lại!");
                }
                else
                {
                    setColor(Color.Red);
                    isApplyPromo = true;
                    Tag = "0";
                }
            }
            else
            {
                setColor(Color.FromArgb(76, 154, 42));
                isApplyPromo = false;
                Tag = "1";
            }
        }
        public void setColor(Color rgb)
        {
            btn_ApDungKM.IdleFillColor = rgb;
            btn_ApDungKM.IdleBorderColor = rgb;
            btn_ApDungKM.onHoverState.FillColor = rgb;
            btn_ApDungKM.onHoverState.BorderColor = rgb;
            btn_ApDungKM.OnPressedState.BorderColor = rgb;
            btn_ApDungKM.OnPressedState.FillColor = rgb;
            btn_ApDungKM.OnIdleState.BorderColor = rgb;
            btn_ApDungKM.OnIdleState.FillColor = rgb;
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            Program.frmTimKiem = new FormTimKiem();
            Program.frmTimKiem.ShowDialog();
        }

        private void btn_Ketca_Click(object sender, EventArgs e)
        {
            Program.frmKetCa = new FormKetCa();
            Program.frmKetCa.ShowDialog();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (isApplyPromo == false)
            {
                List<ProductOrderCustomerBO> lstResult = new List<ProductOrderCustomerBO>();
                lstResult = objOrderStoreBLL.GetProductFromStore(txt_MaSP.Text.Trim(), 0, 0, int.MaxValue, 10, (int)FormLogin.objUserBO.StoreId);
                if (lstResult.Count == 1)
                {
                    if (txt_SoLuong.Text == null || txt_SoLuong.Text == string.Empty || txt_SoLuong.Text == "0")
                    {
                        txt_SoLuong.Text = "1";
                    }
                    ProductOrderCustomerBO objResult = lstResult.FirstOrDefault();
                    if (objResult.SoLuong == 0)
                    {
                        MessageBox.Show("Sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện tại đã hết trên hệ thống. Xin vui lòng chọn sản phẩm khác để thanh toán!");
                    }
                    if (objResult.SoLuong > 0)
                    {
                        var objProduct = objProductBLL.GetProductByKeys(txt_MaSP.Text.Trim(), 0, 0, 5);
                        if (dgv_DSSP.Rows.Count == 0)
                        {
                            if (int.Parse(txt_SoLuong.Text.Trim()) > objResult.SoLuong)
                            {
                                MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                txt_MaSP.Clear();
                                txt_SoLuong.Clear();
                            }
                            else
                            {
                                lbl_TongTien.Text = (int.Parse(txt_SoLuong.Text) * objProduct.FirstOrDefault().GiaBan).ToString();
                                lbl_SoLuong.Text = txt_SoLuong.Text;
                                dgv_DSSP.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text, objProduct.FirstOrDefault().GiaBan.ToString(), (int.Parse(txt_SoLuong.Text) * objProduct.FirstOrDefault().GiaBan).ToString());
                                txt_MaSP.Clear();
                                txt_SoLuong.Clear();
                            }
                        }
                        else
                        {
                            int intIndex = -1;
                            bool isExists = false;
                            for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                            {
                                if (txt_MaSP.Text.Trim() == dgv_DSSP["col_MaSP", i].Value.ToString())
                                {
                                    isExists = true;
                                    intIndex = i;
                                    break;
                                }
                            }
                            if (isExists)
                            {
                                int intSoluong = int.Parse(dgv_DSSP["col_SoLuong", intIndex].Value.ToString().Trim()) + int.Parse(txt_SoLuong.Text.Trim());
                                int intTotalPrice = intSoluong * int.Parse(dgv_DSSP["col_GiaBan", intIndex].Value.ToString().Trim());
                                if (intSoluong > objResult.SoLuong)
                                {
                                    MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                                else
                                {
                                    dgv_DSSP["col_SoLuong", intIndex].Value = intSoluong;
                                    dgv_DSSP["col_ThanhTien", intIndex].Value = intTotalPrice;
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                            }
                            if (!isExists)
                            {
                                dgv_DSSP.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text, objProduct.FirstOrDefault().GiaBan.ToString(), (int.Parse(txt_SoLuong.Text) * objProduct.FirstOrDefault().GiaBan).ToString());
                                txt_MaSP.Clear();
                                txt_SoLuong.Clear();
                            }
                            int totalPrice = 0;
                            int totalStock = 0;
                            for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                            {
                                totalPrice += int.Parse(dgv_DSSP["col_ThanhTien", i].Value.ToString().Trim());
                                totalStock += int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                            }
                            lbl_TongTien.Text = totalPrice.ToString();
                            lbl_SoLuong.Text = totalStock.ToString();
                        }
                    }
                }
            }
            if (isApplyPromo == true)
            {
                List<ProductPromotionBO> lstResult = new List<ProductPromotionBO>();
                lstResult = objOrderStoreBLL.GetProductPromotionFromStore(txt_MaSP.Text.Trim(), (int)FormLogin.objUserBO.StoreId);
                if (lstResult.Count == 1)
                {
                    if (txt_SoLuong.Text == null || txt_SoLuong.Text == string.Empty || txt_SoLuong.Text == "0")
                    {
                        txt_SoLuong.Text = "1";
                    }
                    ProductPromotionBO objResult = lstResult.FirstOrDefault();
                    if (objResult.NgayKM <= DateTime.Now && objResult.NgayHetHan >= DateTime.Now)
                    {
                        if (objResult.SoLuong == 0)
                        {
                            MessageBox.Show("Sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện tại đã hết hàng KM trên hệ thống. Xin vui lòng chọn sản phẩm khác để thay thế!");
                        }
                        if (objResult.SoLuong > 0)
                        {
                            if (dgv_DSKM.Rows.Count == 0)
                            {
                                if (int.Parse(txt_SoLuong.Text.Trim()) > objResult.SoLuong)
                                {
                                    MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn KM trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                                else
                                {
                                    lbl_SoLuong.Text = (int.Parse(lbl_SoLuong.Text) + int.Parse(txt_SoLuong.Text)).ToString();
                                    dgv_DSKM.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text);
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                            }
                            else
                            {
                                int intIndex = -1;
                                bool isExists = false;
                                for (int i = 0; i < dgv_DSKM.Rows.Count; i++)
                                {
                                    if (txt_MaSP.Text.Trim() == dgv_DSKM["MaSP", i].Value.ToString())
                                    {
                                        isExists = true;
                                        intIndex = i;
                                        break;
                                    }
                                }
                                if (isExists)
                                {
                                    int intSoluong = int.Parse(dgv_DSKM["SoLuong", intIndex].Value.ToString().Trim()) + int.Parse(txt_SoLuong.Text.Trim());
                                    if (intSoluong > objResult.SoLuong)
                                    {
                                        MessageBox.Show("Số lượng sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] hiện đang vượt quá số lượng tồn trên hệ thống [ " + objResult.SoLuong + " ]. Xin vui lòng kiểm tra lại!");
                                        txt_MaSP.Clear();
                                        txt_SoLuong.Clear();
                                    }
                                    else
                                    {
                                        dgv_DSSP["SoLuong", intIndex].Value = intSoluong;
                                        txt_MaSP.Clear();
                                        txt_SoLuong.Clear();
                                    }
                                }
                                if (!isExists)
                                {
                                    dgv_DSKM.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text);
                                    txt_MaSP.Clear();
                                    txt_SoLuong.Clear();
                                }
                                int totalStock = 0;
                                for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
                                {
                                    totalStock += int.Parse(dgv_DSSP["col_SoLuong", i].Value.ToString().Trim());
                                }
                                lbl_SoLuong.Text = (int.Parse(lbl_SoLuong.Text) + totalStock).ToString();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm [ " + objResult.MaSP.Trim() + " - " + objResult.TenSP.Trim() + " ] chỉ áp dụng khuyến mãi trong khoản [ " + objResult.NgayKM + " -> " + objResult.NgayHetHan + " ]. Xin vui lòng kiểm tra lại!");
                    }
                }
            }
        }

        private void btn_XoaDonHang_Click(object sender, EventArgs e)
        {
            lstProduct = new List<ProductBO>();
            lsInvoiceDetail = new List<InvoiceDetailBO>();
            lstProductPromotion = new List<ProductBO>();
            setColor(Color.FromArgb(76, 154, 42));
            isApplyPromo = false;
            Tag = "1";
            txt_SoLuong.Text = "1";
            lbl_TongTien.Text = "0";
            lbl_SoLuong.Text = "0";
            dgv_DSSP.Rows.Clear();
            dgv_DSKM.Rows.Clear();
        }
    }
}
