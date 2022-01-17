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
    public partial class FormChinhSuaSP : Form
    {
        ProductBO objProductTmp = FormDanhSachSP.objProductBO;
        CustomerBLL customerBLL = new CustomerBLL();
        ProductTypeBLL objProductTypeBLL = new ProductTypeBLL();
        ProductBLL objProductBLL = new ProductBLL();
        public delegate void CloseDialog();
        public event CloseDialog CloseDialogEvent;
        public FormChinhSuaSP()
        {
            InitializeComponent();
            cbo_NhaCungCap.DataSource = customerBLL.GetListALlCustomer();
            cbo_NhaCungCap.DisplayMember = "FullName";
            cbo_NhaCungCap.ValueMember = "MaNCC";

            cbo_MaLoaiSP.DataSource = objProductTypeBLL.GetALLProductType();
            cbo_MaLoaiSP.DisplayMember = "FullName";
            cbo_MaLoaiSP.ValueMember = "MaLoaiSP";
            if (FormDanhSachSP.isEdit == true)
            {
                txt_MaSP.ReadOnly = true;
                txt_MaSP.Text = objProductTmp.MaSP.ToString();
                bunifuLabel1.Text = "THÔNG TIN SẢN PHẢM";
                txt_TenSP.Text = objProductTmp.TenSP;
                cbo_MaLoaiSP.Text = objProductTmp.MaLoaiSP.ToString();
                cbo_DVT.Text = objProductTmp.DVT;
                txt_GiaBan.Text = objProductTmp.GiaBan.ToString();
                txt_GiaVon.Text = objProductTmp.GiaVon.ToString();
                cbo_NhaCungCap.SelectedIndex = FormDanhSachSP.indexCustomerId;
                cbo_MaLoaiSP.SelectedIndex = FormDanhSachSP.indexProductTypeId;
            }
            else
            {
                cbo_DVT.SelectedIndex = 1;
                bunifuLabel1.Text = "THÊM SẢN PHẢM";
                btn_TraHang.Text = "Thêm Mới";
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            CloseDialogEvent();
            FormDanhSachSP.objProductBO = new ProductBO();
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {
            string strNote = string.Empty;
            if (cbo_MaLoaiSP.SelectedValue.ToString() == "1")
            {
                strNote = "Mã loại sản phẩm này không được áp dụng cho Kho. Xin vui lòng chọn mã loại sản phẩm khác!";
            }
            if ((strNote.Trim() == null || strNote == string.Empty) && cbo_NhaCungCap.SelectedValue.ToString() == "1")
            {
                strNote = "Mã nhà cung cấp này không được áp dụng. Xin vui lòng chọn mã loại sản phẩm khác!";
            }
            if ((strNote.Trim() == null || strNote == string.Empty) && (txt_TenSP.Text.Trim() == null || txt_TenSP.Text.Trim() == string.Empty))
            {
                strNote = "Xin vui lòng điền vào tên của sản phẩm";
            }
            if (strNote.Trim() == null || strNote == string.Empty)
            {
                strNote = CheckValuePrice(txt_GiaBan.Text.Trim(), txt_GiaVon.Text.Trim());
            }
            if (strNote.Trim() == null || strNote == string.Empty)
            {
                if (FormDanhSachSP.isEdit != true)
                {
                    objProductTmp = new ProductBO();
                    objProductTmp.MaSP = txt_MaSP.Text.Trim();
                }
                objProductTmp.TenSP = txt_TenSP.Text;
                objProductTmp.MaLoaiSP = int.Parse(cbo_MaLoaiSP.SelectedValue.ToString());
                objProductTmp.MaNCC = int.Parse(cbo_NhaCungCap.SelectedValue.ToString());
                objProductTmp.DVT = cbo_DVT.Text;
                objProductTmp.GiaBan = int.Parse(txt_GiaBan.Text.Trim());
                objProductTmp.GiaVon = int.Parse(txt_GiaVon.Text.Trim());
                objProductTmp.SoLuong = 0;
                //Kiểm tra tòn tại của sản phẩm
                if (!FormDanhSachSP.isEdit)
                {
                    var objProductexists = objProductBLL.GetProductByid(objProductTmp.MaSP);
                    if (objProductexists != null)
                    {
                        DialogResult result;
                        result = MessageBox.Show("Sản phẩm [ " + objProductexists.MaSP + " - " + objProductexists.TenSP + " ] đã tồn tại. Bạn có muốn cập nhật lại thông tin của sản phẩm này?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (objProductBLL.InsertOrUpdate(objProductTmp))
                            {
                                MessageBox.Show("Cập Nhật Thông Tin Thành Công");
                                CloseDialogEvent();
                                FormMain.lstProduct = objProductBLL.GetListAllProduct();
                                FormDanhSachSP.objProductBO = new ProductBO();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi trong quá trình thao tác. Xin vui lòng thử lại sau");
                            }
                        }
                    }
                    else
                    {
                        if (objProductBLL.InsertOrUpdate(objProductTmp))
                        {
                            MessageBox.Show("Cập Nhật Thông Tin Thành Công");
                            CloseDialogEvent();
                            FormMain.lstProduct = objProductBLL.GetListAllProduct();
                            FormDanhSachSP.objProductBO = new ProductBO();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong quá trình thao tác. Xin vui lòng thử lại sau");
                        }
                    }
                }
                else
                {
                    if (objProductBLL.InsertOrUpdate(objProductTmp))
                    {
                        MessageBox.Show("Cập Nhật Thông Tin Thành Công");
                        CloseDialogEvent();
                        FormMain.lstProduct = objProductBLL.GetListAllProduct();
                        FormDanhSachSP.objProductBO = new ProductBO();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình thao tác. Xin vui lòng thử lại sau");
                    }
                }
            }
            else
            {
                MessageBox.Show(strNote);
            }
            
        }

        private string CheckValuePrice(string strGiaBan, string strGiaVon)
        {
            int intGiaBan;
            int intGiaVon;
            string Note = string.Empty;
            if (!int.TryParse(strGiaBan, out intGiaBan) || !int.TryParse(strGiaVon, out intGiaVon))
            {
                return Note = "Giá bán và Giá vốn không đúng định dạng";
            }
            else if (intGiaBan < 0 || intGiaVon < 0)
            {
                return Note = "Giá bán và Giá vốn phải lớn hơn 0";
            }
            else if (intGiaBan < intGiaVon)
            {
                return Note = "Giá bán phải lớn hơn Giá vốn";
            }
            else
            {
                return Note;
            }
        }
    }
}
