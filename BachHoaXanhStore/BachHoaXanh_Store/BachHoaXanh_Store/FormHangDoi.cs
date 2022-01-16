using DevExpress.XtraEditors;
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
    public partial class FormHangDoi : DevExpress.XtraEditors.XtraForm
    {
        public delegate void RemoveInvoiceBO(int intMaHD);
        public event RemoveInvoiceBO RemoveInvoiceBOEvent;
        public FormHangDoi()
        {
            InitializeComponent();
            for (int i = 0; i < FormBanHang.lstWating.Count; i++)
            {
                dgv_HangDoi.Rows.Add(FormBanHang.lstWating[i].MaHD, FormBanHang.lstWating[i].TongSP, FormBanHang.lstWating[i].ThanhTien);
            }
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            if (dgv_HangDoi.Rows.Count > 0)
            {
                int index = dgv_HangDoi.CurrentCell.RowIndex;
                RemoveInvoiceBOEvent(int.Parse(dgv_HangDoi["MaHD", index].Value.ToString()));
                this.Close();
            }
            else
            {
                MessageBox.Show("Danh sách hàng đợi đang rỗng.Xin vui lòng kiểm tra lại!");
            }
        }

        private void btn_HuyHangDoi_Click(object sender, EventArgs e)
        {
            if (dgv_HangDoi.Rows.Count > 0)
            {
                FormBanHang.lstWating = new List<BO.InvoiceWatingBO>();
                dgv_HangDoi.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Danh sách hàng đợi đang rỗng.Xin vui lòng kiểm tra lại!");
            }
        }

        private void btn_XoaHoaDon_Click(object sender, EventArgs e)
        {
            if (dgv_HangDoi.Rows.Count > 0)
            {
                int index = dgv_HangDoi.CurrentCell.RowIndex;
                foreach (var item in FormBanHang.lstWating)
                {
                    if (item.MaHD == int.Parse(dgv_HangDoi["MaHD", index].Value.ToString()))
                    {
                        FormBanHang.lstWating.Remove(item);
                        break;
                    }
                }
                dgv_HangDoi.Rows.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Danh sách hàng đợi đang rỗng.Xin vui lòng kiểm tra lại!");
            }
        }
    }
}