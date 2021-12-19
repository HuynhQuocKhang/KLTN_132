﻿using BLL_DAO;
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

        public FormBanHang()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            label1.Text = DateTime.Now.ToString("T");
            lbl_MaSieuThi.Text = FormLogin.objUserBO.StoreId.ToString() + " - " + objStoreBll.getStoreNameByUser(FormLogin.objUserBO.StoreId);
            lbl_MaNhanVien.Text = FormLogin.objUserBO.UserFullName;
        }

        private void dgv_DSSP_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv_DSSP_SelectionChanged_1(object sender, EventArgs e)
        {

        }
    }
}
