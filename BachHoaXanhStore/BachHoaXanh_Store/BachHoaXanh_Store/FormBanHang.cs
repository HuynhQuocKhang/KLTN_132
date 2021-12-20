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
                    else
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
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (dgv_DSSP.Rows.Count == 0)
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
                    }
                }
                else
                {
                    MessageBox.Show("Khởi tạo hóa đơn thất bại. Xin vui lòng kiểm tra lại dữ liệu trước khi thanh toán!");
                }
            }
            
        }
    }
}
