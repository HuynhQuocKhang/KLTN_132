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
        public FormBanHang()
        {
            InitializeComponent();
            lbl_MaSieuThi.Text = FormLogin.objUserBO.StoreId.ToString() + " - " + objStoreBll.getStoreNameByUser(FormLogin.objUserBO.StoreId);
            lbl_MaNhanVien.Text = FormLogin.objUserBO.UserFullName;
            txt_SoLuong.Text = "1";
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
                        dgv_DSSP.Rows.Add(objResult.MaSP.ToString(), objResult.TenSP.ToString(), txt_SoLuong.Text, objProduct.FirstOrDefault().GiaBan.ToString(), (int.Parse(txt_SoLuong.Text) * objProduct.FirstOrDefault().GiaBan).ToString());
                    }
                    txt_MaSP.Clear();
                    txt_SoLuong.Clear();
                }
            }
        }

        private void btn_ApDungKM_Click(object sender, EventArgs e)
        {
            if (Tag == "1")
            {
                setColor(Color.Red);
                Tag = "0";
            }
            else
            {
                setColor(Color.FromArgb(76, 154, 42));
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
    }
}
