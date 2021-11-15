using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace BachHoaXanh_Store
{
    public partial class FormDangNhap : Telerik.WinControls.UI.RadForm
    {
        public FormDangNhap()
        {
            InitializeComponent();
            txt_username.ShowEmbeddedLabel = true;
            txt_username.EmbeddedLabelText = "Username";
            txt_Password.ShowEmbeddedLabel = true;
            txt_Password.EmbeddedLabelText = "Password"; 
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            RadMessageBox.SetThemeName(telerikMetroTheme1.ThemeName);
               DialogResult dr = RadMessageBox.Show("Bạn có muốn thoát không?", "Warning", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dr==DialogResult.Yes)
            {
                this.Close();
            } 
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if(txt_username.Text== "admin")
            {
                Program.frmDatHang = new FormDatHang();
                Program.frmDatHang.Show();
                this.Hide();
            }    


        }
    }
}
