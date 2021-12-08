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
    public partial class FormPhanPhoiHang : Form
    {
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        StoreBLL objStoreBLL = new StoreBLL();
        public static ExportProductBO objExportProductBO = new ExportProductBO();
        ProductBLL objProductBLL = new ProductBLL();
        public static List<ExportProductDetailBO> lstExportProductDetailBO = new List<ExportProductDetailBO>();
        public FormPhanPhoiHang()
        {
            InitializeComponent();
            cbo_SieuThi.DataSource = objStoreBLL.GetAllStore();
            cbo_SieuThi.DisplayMember = "FullName";
            cbo_SieuThi.ValueMember = "MaST";
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (dgv_DHDT.Rows.Count > 0)
            {
                bool isOpen = true;
                int totalPrice = 0;
                for (int i = 0; i < dgv_DHDT.Rows.Count; i++)
                {
                    int intStock;
                    if (!int.TryParse(dgv_DHDT["col_SoLuongXuat", i].Value.ToString().Trim(), out intStock))
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_DHDT["col_MaSP", i].Value.ToString() + " - " + dgv_DHDT["col_TenSP", i].Value.ToString() + " ] có số lượng xuất phải là số nguyên dương và lớn hơn 0");
                        isOpen = false;
                        lstExportProductDetailBO = new List<ExportProductDetailBO>();
                        return;
                    }
                    if (intStock > int.Parse(dgv_DHDT["col_SoLuong", i].Value.ToString().Trim()))
                    {
                        MessageBox.Show("Sản phẩm [ " + dgv_DHDT["col_MaSP", i].Value.ToString() + " - " + dgv_DHDT["col_TenSP", i].Value.ToString() + " ] có số lượng xuất phải nhỏ hơn hoặc bằng số lượng của siêu thị");
                        isOpen = false;
                        lstExportProductDetailBO = new List<ExportProductDetailBO>();
                        return;
                    }
                    else
                    {
                        ExportProductDetailBO objExportProductDetailBO = new ExportProductDetailBO();
                        objExportProductDetailBO.MaSP = dgv_DHDT["col_MaSP", i].Value.ToString().Trim();
                        objExportProductDetailBO.TenSP = dgv_DHDT["col_TenSP", i].Value.ToString().Trim();
                        objExportProductDetailBO.SoLuong = int.Parse(dgv_DHDT["col_SoLuong", i].Value.ToString().Trim());
                        objExportProductDetailBO.ThanhTien = intStock * (int)objProductBLL.GetProductByKeys(dgv_DHDT["col_MaSP", i].Value.ToString()).FirstOrDefault().GiaVon;
                        totalPrice += (int)objExportProductDetailBO.ThanhTien;
                        lstExportProductDetailBO.Add(objExportProductDetailBO);
                    }
                }
                if (isOpen == true)
                {
                    objExportProductBO.MaDH = int.Parse(dgv_DSDH["col_MaDH", dgv_DSDH.CurrentCell.RowIndex].Value.ToString().Trim());
                    objExportProductBO.MaST = int.Parse(dgv_DSDH["col_MaST", dgv_DSDH.CurrentCell.RowIndex].Value.ToString().Trim());
                    objExportProductBO.NguoiLapPhieu = FormLogin.objUserBO.UserFullName;
                    objExportProductBO.TongTien = totalPrice;
                }
            }
            else
            {
                MessageBox.Show("Danh sách hàng hóa cần xuất không được rỗng");
            }

            Program.frmPhieuXuatKho = new FormPhieuXuatKho();
            Program.frmPhieuXuatKho.ShowDialog();
        }

        private void chk_AllStore_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chk_AllStore.Checked == true)
                cbo_SieuThi.Enabled = false;
            else
                cbo_SieuThi.Enabled = true;
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            
            if (chk_AllStore.Checked == true)
            {
                dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(0, (DateTime)dtp_NgayBatDau.Value, (DateTime)dtp_NgayKetThuc.Value);
            }
            else
            {
                dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(int.Parse(cbo_SieuThi.SelectedValue.ToString()), (DateTime)dtp_NgayBatDau.Value, (DateTime)dtp_NgayKetThuc.Value);

            }
        }

        private void chk_AllStore_CheckedChanged_1(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chk_AllStore.Checked == true)
            {
                cbo_SieuThi.Enabled = false;
            }
            else
            {
                cbo_SieuThi.Enabled = true;

            }
        }

        private void dgv_DSDH_SelectionChanged(object sender, EventArgs e)
        {
            int index = dgv_DSDH.CurrentCell.RowIndex;
            if (dgv_DSDH.DataSource != null && index != -1)
            {
                
                dgv_DHDT.DataSource = objOrderStoreDetailBLL.GetListOrderStoreByOrderId(int.Parse(dgv_DSDH["col_MaDH", index].Value.ToString().Trim()));
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            if (chk_AllStore.Checked == true)
            {
                dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(0, (DateTime)dtp_NgayBatDau.Value, (DateTime)dtp_NgayKetThuc.Value);
            }
            else
            {
                dgv_DSDH.DataSource = objOrderStoreBLL.GetOrderFromStoreBO(int.Parse(cbo_SieuThi.SelectedValue.ToString()), (DateTime)dtp_NgayBatDau.Value, (DateTime)dtp_NgayKetThuc.Value);

            }
        }
    }
}
