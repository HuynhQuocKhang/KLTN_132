using BLL_DAO;
using BO;
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
    public partial class FormTimKiem : DevExpress.XtraEditors.XtraForm
    {
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        public delegate void InsertProduct(string strProductName, string strProductId, int intStock, int intPrice, int totalPrice);
        public event InsertProduct InsertProductEvent;
        public FormTimKiem()
        {
            InitializeComponent();
        }

        private void txt_MaSP_TextChanged(object sender, EventArgs e)
        {  
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (FormBanHang.isApplyPromo == false)
            {
                dgv_DSSP.DataSource = objOrderStoreBLL.GetProductFromStoreFromSearchUsing(txt_Keyword.Text.Trim(), 0, 0, int.MaxValue, 50, (int)FormLogin.objUserBO.StoreId);
            }
            else
            {
                List<ProductFromStoreFromSearch> lstProductView = new List<ProductFromStoreFromSearch>();
                List<ProductPromotionBO> lstPromo = objOrderStoreBLL.GetProductPromotionFromStoreByKey(txt_Keyword.Text.Trim(), (int)FormLogin.objUserBO.StoreId, 50);
                foreach (ProductPromotionBO item in lstPromo)
                {
                    ProductFromStoreFromSearch objProductFromStoreFromSearch = new ProductFromStoreFromSearch();
                    objProductFromStoreFromSearch.MaSP = item.MaSP;
                    objProductFromStoreFromSearch.TenSP = item.TenSP;
                    objProductFromStoreFromSearch.GiaBan = 0;
                    objProductFromStoreFromSearch.SoLuong = item.SoLuong;
                    lstProductView.Add(objProductFromStoreFromSearch);
                }
                dgv_DSSP.DataSource = lstProductView;
            }
        }

        private void dgv_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_DSSP.CurrentCell.RowIndex;
            if (dgv_DSSP["col_Add", index].Selected)
            {
                InsertProductEvent(dgv_DSSP["col_MaSP", index].Value.ToString(), dgv_DSSP["col_TenSP", index].Value.ToString(), 1, int.Parse(dgv_DSSP["col_GiaBan", index].Value.ToString()), int.Parse(dgv_DSSP["col_GiaBan", index].Value.ToString()));
                this.Close();
            }
        }
    }
}