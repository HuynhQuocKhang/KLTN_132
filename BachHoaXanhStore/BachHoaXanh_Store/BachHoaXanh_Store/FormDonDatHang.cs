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
using System.Net;
using System.Net.Mail;
using System.IO;

namespace BachHoaXanh_Store
{
    
    public partial class FormDonDatHang : Form
    {
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        CustomerBLL objCustomerBLL = new CustomerBLL();
        public delegate void CloseDialog();
        public event CloseDialog CloseDialogEvent;
        string[] str2 = new string[500];
        public FormDonDatHang()
        {
            InitializeComponent();
            List<OrderCustomerDetailBO> lstOrderTmp = FormDatHang.lstOrderCustomerDetailBO;
            txt_NguoiDat.Text = FormLogin.objUserBO.UserFullName;
            txt_NhaCungCap.Text = FormDatHang.strCustomerName;
            string strDate = DateTime.Now.ToString("d");
            txt_NgayDat.Text = strDate;
            txt_TongTien.Text = FormDatHang.intTotalPrice.ToString();
            dgv_Order.DataSource = lstOrderTmp;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormDatHang.lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
            FormDatHang.intTotalPrice = 0;
            CloseDialogEvent();
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {
            if (FormLogin.objUserBO.Permission == 1)
            {
                OrderCustomerBO objOrderCustomerBO = new OrderCustomerBO();
                objOrderCustomerBO.NguoiLapPhieu = txt_NguoiDat.Text;
                objOrderCustomerBO.MaNCC = FormDatHang.intCustomerId;
                objOrderCustomerBO.TongTien = int.Parse(txt_TongTien.Text);
                objOrderCustomerBO.NgayDat = DateTime.Now;
                objOrderCustomerBO.TinhTrang = 0;
                if (!objOrderCustomerBLL.InsertOrderCustomer(objOrderCustomerBO))
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
                }
                else
                {
                    int OrderId = objOrderCustomerBLL.GetOrderCustomerIdNew();
                    bool isDone = true;
                    foreach (OrderCustomerDetailBO item in FormDatHang.lstOrderCustomerDetailBO)
                    {
                        if (!objOrderCustomerBLL.InsertOrderCustomerDetail(OrderId, item.MaSP, item.SoLuong, item.ThanhTien))
                        {
                            MessageBox.Show("Lỗi trong quá trình thực hiện. Xin vui lòng thử lại sau");
                            isDone = false;
                            return;
                        }
                    }
                    if (isDone == true)
                    {
                        Program.frmReport = new FormReport("DatHang");
                        Program.frmReport.ShowDialog();

                        //Gửi Email đến NCC
                        DialogResult result;
                        result = MessageBox.Show("Bạn có muốn gửi email đến cho Nhà Cung Cấp?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CustomerBO objCustomerBO = objCustomerBLL.GetListALlCustomer().Where(x => x.MaNCC == FormDatHang.intCustomerId).FirstOrDefault();
                            string fileName = "";
                            using (OpenFileDialog myDialog = new OpenFileDialog())
                            {
                                myDialog.Multiselect = true;
                                myDialog.InitialDirectory = "";
                                myDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                                myDialog.FilterIndex = 2;
                                myDialog.RestoreDirectory = true;

                                if (myDialog.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (string file in myDialog.FileNames)
                                    {
                                        fileName = Path.GetFileName(file);
                                    }

                                }
                                str2 = myDialog.FileNames;
                            }

                            MailMessage mail = new MailMessage("doanbachhoaxanh@gmail.com", objCustomerBO.Email, "Đơn Đặt Hàng", "");
                            mail.IsBodyHtml = true;
                            SmtpClient client = new SmtpClient("doanbachhoaxanh@gmail.com");
                            client.Host = "smtp.gmail.com";
                            client.UseDefaultCredentials = false;
                            client.Port = 587;
                            client.Credentials = new System.Net.NetworkCredential("doanbachhoaxanh@gmail.com", "Bhx@2021");
                            client.EnableSsl = true;
                            foreach (string names in str2)
                            {
                                if (names != null)
                                {
                                    mail.Attachments.Add(new Attachment(names));
                                }
                            }
                            client.Send(mail);
                            MessageBox.Show("Đã gửi tin nhắn thành công!", "Thành Công", MessageBoxButtons.OK);
                        }
                        FormDatHang.lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
                        FormDatHang.intTotalPrice = 0;
                        CloseDialogEvent();
                        this.Close();
                    }
                }
                
            }
            else
            {
                OrderStoreBO objOrderStoreBO = new OrderStoreBO();
                objOrderStoreBO.NguoiLapPhieu = txt_NguoiDat.Text;
                objOrderStoreBO.MaST = FormLogin.objUserBO.StoreId;
                objOrderStoreBO.TongTien = int.Parse(txt_TongTien.Text);
                objOrderStoreBO.NgayDat = DateTime.Now;
                objOrderStoreBO.TinhTrang = 0;
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
                        Program.frmReport = new FormReport("STDatHang");
                        Program.frmReport.ShowDialog();
                        MessageBox.Show("Đặt hàng thành công");
                        FormDatHang.lstOrderCustomerDetailBO = new List<OrderCustomerDetailBO>();
                        FormDatHang.intTotalPrice = 0;
                        CloseDialogEvent();
                        this.Close();
                    }
                }
            }
        }
    }
}
