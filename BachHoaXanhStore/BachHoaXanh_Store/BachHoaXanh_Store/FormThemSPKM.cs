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
    public partial class FormThemSPKM : Form
    {
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        ProductBO objProduct = FormDanhSachSP.objProductBO;
        ProductPromotionBO objPromotion = FormDanhSachSP.objPromotion;
        public delegate void CloseDialog();
        public event CloseDialog CloseDialogEvent;
        public FormThemSPKM()
        {
            InitializeComponent();
            
            if (FormDanhSachSP.isEdit == false)
            {
                txt_SLThem.Text = "0";
            }
            else
            {
                txt_SLThem.Text = objPromotion.SoLuong.ToString();
                dtp_NgayApDung.Value = (DateTime)objPromotion.NgayKM;
                dtp_NgayKetThuc.Value = (DateTime)objPromotion.NgayHetHan;
                txt_GiaKM.Text = objPromotion.GiaKM.ToString();
            }
            txt_ProductFullName.Text = string.Format(objProduct.MaSP + " - " + objProduct.TenSP);
            toolTip1.SetToolTip(txt_ProductFullName, txt_ProductFullName.Text);
            txtGiaBan.Text = objProduct.GiaBan.ToString();
            txt_SLTon.Text = objProduct.SoLuong.ToString();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormDanhSachSP.objProductBO = new ProductBO();
            FormDanhSachSP.objPromotion = new ProductPromotionBO();
            CloseDialogEvent();
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {
            int intStockUpdate = 0;
            bool isSuccess = true;
            TimeSpan interval = dtp_NgayApDung.Value.Subtract(DateTime.Now);
            if (!int.TryParse(txt_SLThem.Text.Trim(), out intStockUpdate))
            {
                MessageBox.Show("Số lượng Khuyến Mãi cho sản phẩm [ " + txt_ProductFullName.Text + " ] phải là số nguyên dương lớn hơn 0" + Environment.NewLine + "Và nhỏ hơn hoặc bằng số lượng tồn của của Kho Siêu Thị. Xin vui lòng kiểm tra lại!");
                isSuccess = false;
            }
            if (intStockUpdate <= 0 && FormDanhSachSP.isEdit == false)
            {
                MessageBox.Show("Số lượng Khuyến Mãi cho sản phẩm [ " + txt_ProductFullName.Text + " ] phải là số nguyên dương lớn hơn 0" + Environment.NewLine + "Và nhỏ hơn hoặc bằng số lượng tồn của của Kho Siêu Thị. Xin vui lòng kiểm tra lại!");
                isSuccess = false;
            }
            if (objProduct.SoLuong < intStockUpdate)
            {
                MessageBox.Show("Số lượng Khuyến Mãi cho sản phẩm [ " + txt_ProductFullName.Text + " ] phải nhỏ hơn hoặc bằng số lượng tồn của của Kho Siêu Thị" + Environment.NewLine + "Xin vui lòng kiểm tra lại!");
                isSuccess = false;
            }
            if (FormDanhSachSP.isEdit == false && interval.Days < 0)
            {
                MessageBox.Show("Ngày bắt đầu khuyến mãi không được nhỏ hơn ngày hiện tại. Xin vui lòng kiểm tra lại!");
                isSuccess = false;
            }
            if (dtp_NgayApDung.Value > dtp_NgayKetThuc.Value)
            {
                MessageBox.Show("Ngày bắt đầu khuyến mãi không được nhỏ hơn ngày kết thúc. Xin vui lòng kiểm tra lại!");
                isSuccess = false;
            }
            if (int.Parse(txt_GiaKM.Text.Trim()) > int.Parse(txtGiaBan.Text.Trim()))
            {
                MessageBox.Show("Gía bán khuyến mãi của sản phẩm không được lớn hơn giá bán của sản phẩm. Xin vui lòng kiểm tra lại!");
                isSuccess = false;
            }
            if (isSuccess == true)
            {
                if (FormDanhSachSP.isEdit == true && intStockUpdate == 0)
                {
                    if (!objOrderStoreBLL.DeleteProductPromoTion(objPromotion, (int)FormLogin.objUserBO.StoreId))
                    {
                        MessageBox.Show("Lỗi trong quá trình thao tác. Xin vui lòng kiểm tra lại dữ liệu!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm cho Kho Khuyến Mãi thành công!");
                        FormDanhSachSP.objProductBO = new ProductBO();
                        FormDanhSachSP.objPromotion = new ProductPromotionBO();
                        CloseDialogEvent();
                        this.Close();
                    }
                }
                else
                {
                    objPromotion.MaSP = objProduct.MaSP;
                    objPromotion.NgayKM = dtp_NgayApDung.Value;
                    objPromotion.NgayHetHan = dtp_NgayKetThuc.Value;
                    objPromotion.SoLuong = intStockUpdate;
                    objPromotion.GiaKM = int.Parse(txt_GiaKM.Text.Trim());
                    if (!objOrderStoreBLL.InsertOrUpdateProductPromotion(objPromotion, (int)FormLogin.objUserBO.StoreId, FormDanhSachSP.isEdit))
                    {
                        MessageBox.Show("Lỗi trong quá trình thao tác. Xin vui lòng kiểm tra lại dữ liệu!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm cho Kho Khuyến Mãi thành công!");
                        FormDanhSachSP.objProductBO = new ProductBO();
                        FormDanhSachSP.objPromotion = new ProductPromotionBO();
                        CloseDialogEvent();
                        this.Close();
                    }
                }
            }
        }

        private void txt_GiaKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_SLThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
