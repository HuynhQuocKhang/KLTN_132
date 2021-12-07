﻿using BLL_DAO;
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
    public partial class FormPhieuTraHang : Form
    {
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        ReturnProductBLL objReturnProductBLL = new ReturnProductBLL();
        public FormPhieuTraHang()
        {
            InitializeComponent();

            txt_NguoiDat.Text = FormTraHangNCC.objUser.UserFullName;
            txt_NgayTra.Text = DateTime.Now.ToString();
            txt_NhaCungCap.Text = FormTraHangNCC.strCustomerName;
            txt_TinhTrang.Text = "Trả Hàng";
            dgv_Order.DataSource = FormTraHangNCC.lstOrderDetailBO;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormDatHang.lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {
            ReturnProductBO objReturnProductBO = new ReturnProductBO();
            if (FormTraHangNCC.objUser.Permission == 1)
            {
                objReturnProductBO.MaNCC = FormTraHangNCC.intCustomerId;
                objReturnProductBO.MaST = 0;
            }
            else
            {
                objReturnProductBO.MaNCC = 0;
                objReturnProductBO.MaST = FormTraHangNCC.objUser.StoreId;
            }
            objReturnProductBO.NguoiLapPhieu = txt_NguoiDat.Text;

            objReturnProductBO.NgayTra = DateTime.Now;
            objReturnProductBO.Isdeleted = false;
            objReturnProductBO.TinhTrang = 0;
            if (!objReturnProductBLL.InsertReturnOrder(objReturnProductBO))
            {
                MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
            }
            else
            {
                int id = objReturnProductBLL.GetIdNew();
                bool isDone = true;
                foreach (OrderDetailBO item in FormTraHangNCC.lstOrderDetailBO)
                {
                    item.MaHD = id;
                    if (!objReturnProductBLL.InsertReturnOrderDetail(item))
                    {
                        MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
                        isDone = false;
                        return;
                    }
                }
                if (isDone == true)
                {
                    MessageBox.Show("Tạo Phiếu Trả Hàng Thành CÔng");
                    this.Close();
                }
            }
        }
    }
}
