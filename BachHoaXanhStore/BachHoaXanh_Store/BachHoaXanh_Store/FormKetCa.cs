using BLL_DAO;
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
    public partial class FormKetCa : DevExpress.XtraEditors.XtraForm
    {
        StoreBLL objStoreBLL = new StoreBLL();
        public delegate void CloseDialog();
        public event CloseDialog CloseDialogEvent;
        public static int pTotalReality;
        public static int pTotal;
        public static int p500;
        public static int p200;
        public static int p100;
        public static int p50;
        public static int p20;
        public static int p10;
        public static int p5;
        public static int p2;
        public static int p1;
        public static int p12;
        public FormKetCa()
        {
            InitializeComponent();
            lbl_ThoiGianKetCa.Text = DateTime.Now.ToString();
            lbl_DoanhThuThucTe.Text = objStoreBLL.GetSaleOfStore(DateTime.Now, (int)FormLogin.objUserBO.StoreId, (int)FormLogin.objUserBO.UserId).ToString();
            lbl_NhanVienKetCa.Text = FormLogin.objUserBO.UserId.ToString() + " - " + FormLogin.objUserBO.UserFullName;
            lbl_DoanhThuNgay.Text = "0";
            lbl_ChenhLech.Text = "0";
            pTotalReality = int.Parse(lbl_DoanhThuThucTe.Text);
            lbl_DoanhThuNgay.Text = "0";
            lbl_ChenhLech.Text = (Math.Abs(int.Parse(lbl_DoanhThuThucTe.Text) - int.Parse(lbl_DoanhThuNgay.Text))).ToString();
        }

        private void txt_200k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_100k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_50k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_20k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_10k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_5k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_2k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_1k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_500_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_500k_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_500k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_200k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_100k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_50k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_20k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_10k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_5k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_2k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_1k_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void txt_500_TextChange(object sender, EventArgs e)
        {
            SaleLabelChange();
        }

        private void SaleLabelChange()
        {
            pTotal = 0;
            int total = 0;
            int int500k = 0;
            int int200k = 0;
            int int100k = 0;
            int int50k = 0;
            int int20k = 0;
            int int10k = 0;
            int int5k = 0;
            int int2k = 0;
            int int1k = 0;
            int int500 = 0;

            if (txt_500.Text == null || txt_500.Text.Trim() == "")
            {
                int500 = 0;
            }
            else
            {
                p12 = int500 = int.Parse(txt_500.Text);
            }

            if (txt_1k.Text == null || txt_1k.Text.Trim() == "")
            {
                int1k = 0;
            }
            else
            {
                p1=int1k = int.Parse(txt_1k.Text);
            }

            if (txt_2k.Text == null || txt_2k.Text.Trim() == "")
            {
                int2k = 0;
            }
            else
            {
               p2=int2k = int.Parse(txt_2k.Text);
            }

            if (txt_5k.Text == null || txt_5k.Text.Trim() == "")
            {
                int5k = 0;
            }
            else
            {
                p5=int5k = int.Parse(txt_5k.Text);
            }

            if (txt_10k.Text == null || txt_10k.Text.Trim() == "")
            {
                int10k = 0;
            }
            else
            {
                p10=int10k = int.Parse(txt_10k.Text);
            }


            if (txt_20k.Text == null || txt_20k.Text.Trim() == "")
            {
                int20k = 0;
            }
            else
            {
                p20=int20k = int.Parse(txt_20k.Text);
            }

            if (txt_50k.Text == null || txt_50k.Text.Trim() == "")
            {
                int50k = 0;
            }
            else
            {
                p50=int50k = int.Parse(txt_50k.Text);
            }

            if (txt_100k.Text == null || txt_100k.Text.Trim() == "")
            {
                int100k = 0;
            }
            else
            {
               p100= int100k = int.Parse(txt_100k.Text);
            }

            if (txt_200k.Text == null || txt_200k.Text.Trim() == "")
            {
                int200k = 0;
            }
            else
            {
                p200=int200k = int.Parse(txt_200k.Text);
            }

            if (txt_500k.Text == null || txt_500k.Text.Trim() == "")
            {
                int500k = 0;
            }
            else
            {
                p500=int500k = int.Parse(txt_500k.Text);
            }

            total += int500k * 500000 + int200k * 200000 + int100k * 100000 + int50k * 50000 +
                                    int20k * 20000 + int10k * 10000 + int5k * 5000 + int2k * 2000 +
                                    int1k * 1000 + int500 * 500;
            pTotal = total;
            lbl_DoanhThuNgay.Text = total.ToString();
            lbl_ChenhLech.Text = (Math.Abs(int.Parse(lbl_DoanhThuThucTe.Text) - int.Parse(lbl_DoanhThuNgay.Text))).ToString();

        }

        private void btn_KetCa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kết ca thành công!");
            FormReport frmReport = new FormReport("KetCa");
            frmReport.ShowDialog();
            CloseDialogEvent();
            pTotalReality = 0;
            pTotal = 0;
            p500 = 0;
            p200 = 0;
            p100 = 0;
            p50 = 0;
            p20 = 0;
            p10 = 0;
            p5 = 0;
            p2 = 0;
            p1 = 0;
            p12= 0;
            this.Close();
        }
    }
}