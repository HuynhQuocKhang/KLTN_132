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
    
    public partial class FormDonDatHang : Form
    {
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        public FormDonDatHang()
        {
            InitializeComponent();
            List<OrderCustomerDetailBO> lstOrderTmp = FormDatHang.lstOrderCustomerDetailBO;
            txt_NguoiDat.Text = FormDatHang.objUser.UserFullName;
            txt_NhaCungCap.Text = FormDatHang.strCustomerName;
            txt_NgayDat.Text = DateTime.Now.ToString();
            txt_TongTien.Text = FormDatHang.intTotalPrice.ToString();
            txt_TinhTrang.Text = "Đặt hàng";
            dgv_Order.DataSource = lstOrderTmp;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormDatHang.lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
            FormDatHang.intTotalPrice = 0;
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {
            if (FormDatHang.objUser.Permission == 1)
            {
                OrderCustomerBO objOrderCustomerBO = new OrderCustomerBO();
                objOrderCustomerBO.NguoiLapPhieu = txt_NguoiDat.Text;
                objOrderCustomerBO.MaNCC = FormDatHang.intCustomerId;
                objOrderCustomerBO.TongTien = int.Parse(txt_TongTien.Text);
                objOrderCustomerBO.NgayDat = DateTime.Now;
                objOrderCustomerBO.TinhTrang = 0;
                objOrderCustomerBO.Isdeleted = false;
                if (!objOrderCustomerBLL.InsertOrderCustomer(objOrderCustomerBO))
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
                }
                else
                {
                    int OrderId = objOrderCustomerBLL.GetOrderCustomerIdNew();
                    foreach (OrderCustomerDetailBO item in FormDatHang.lstOrderCustomerDetailBO)
                    {
                        if (!objOrderCustomerBLL.InsertOrderCustomerDetail(OrderId, item.MaSP, item.SoLuong, item.ThanhTien))
                        {
                            MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
                        }
                    }
                }
                MessageBox.Show("Đặt hàng thành công");
                this.Close();
            }
            else
            {
                //Hiện tại đang gán cứng mã siêu thị = 1 để test chức năng phân phối hàng hóa
                //Cải thiện sau khi hoàn thành xong form đăng nhập
                OrderStoreBO objOrderStoreBO = new OrderStoreBO();
                objOrderStoreBO.NguoiLapPhieu = txt_NguoiDat.Text;
                objOrderStoreBO.MaST = FormDatHang.objUser.StoreId;
                objOrderStoreBO.TongTien = int.Parse(txt_TongTien.Text);
                objOrderStoreBO.NgayDat = DateTime.Now;
                objOrderStoreBO.TinhTrang = 0;
                objOrderStoreBO.Isdeleted = false;
                if (!objOrderStoreBLL.InsertOrderStore(objOrderStoreBO))
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
                }
                else
                {
                    int OrderId = objOrderStoreBLL.GetOrderStoreIdNew();
                    if (!objOrderStoreDetailBLL.InserOrderStoreDetail(FormDatHang.lstOrderCustomerDetailBO, OrderId))
                    {
                        MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
                    }
                    else
                    {
                        MessageBox.Show("Đặt hàng thành công");
                        this.Close();
                    }
                }
            }
        }
    }
}
