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
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        UserBLL objUserBLL = new UserBLL();
        public static UserBO objUserBO = new UserBO();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            objUserBO = objUserBLL.GetUserByKey(txt_user.Text.Trim(), txt_pass.Text.Trim());
            if (objUserBO == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác." + Environment.NewLine + "Xin vui lòng kiểm tra lại.");
            }
            else
            {
                if (objUserBO.Permission == 3)
                {
                    Program.frmBanHang = new FormBanHang();
                    Program.frmBanHang.Show();
                    this.Hide();
                }
                else
                {
                    FormMain frm = new FormMain();
                    frm.Show();
                    this.Hide();
                }
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát", "Thoát?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát", "Thoát?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}