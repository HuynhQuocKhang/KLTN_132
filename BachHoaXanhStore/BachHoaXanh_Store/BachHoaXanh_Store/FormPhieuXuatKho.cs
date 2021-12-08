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
    public partial class FormPhieuXuatKho : Form
    {
        ExportProductBLL objExportProductBLL = new ExportProductBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        public FormPhieuXuatKho()
        {
            InitializeComponent();
            txt_NguoiLap.Text = FormPhanPhoiHang.objExportProductBO.NguoiLapPhieu;
            txt_MaST.Text = FormPhanPhoiHang.objExportProductBO.MaST.ToString();
            txt_DonDatHang.Text = FormPhanPhoiHang.objExportProductBO.MaDH.ToString();
            txt_TongTien.Text = FormPhanPhoiHang.objExportProductBO.TongTien.ToString();
            txt_NgayXuat.Text = DateTime.Now.ToString();
            dgv_CTPX.DataSource = FormPhanPhoiHang.lstExportProductDetailBO;
        }

        private void txt_NgayTra_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormPhanPhoiHang.objExportProductBO = new BO.ExportProductBO();
            FormPhanPhoiHang.lstExportProductDetailBO = new List<ExportProductDetailBO>();
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {
            if (!objExportProductBLL.InsertExportProduct(FormPhanPhoiHang.objExportProductBO))
            {
                MessageBox.Show("Khởi tạo phiếu xuất thất bại, xin vui lòng kiểm tra lại thông tin");
            }
            else
            {
                int intMaPXK = objExportProductBLL.GetExportProductIdNew();
                objOrderStoreBLL.UpdateOrderStoreStatus((int)FormPhanPhoiHang.objExportProductBO.MaDH);
                if (objExportProductBLL.InsertExportProductDetail(FormPhanPhoiHang.lstExportProductDetailBO, intMaPXK))
                {
                    MessageBox.Show("Khởi tạo phiếu xuất kho thành công");
                    FormPhanPhoiHang.lstExportProductDetailBO = new List<ExportProductDetailBO>();
                    FormPhanPhoiHang.objExportProductBO = new BO.ExportProductBO();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Khởi tạo phiếu xuất thất bại, xin vui lòng kiểm tra lại thông tin");
                }
            }
        }
    }
}
