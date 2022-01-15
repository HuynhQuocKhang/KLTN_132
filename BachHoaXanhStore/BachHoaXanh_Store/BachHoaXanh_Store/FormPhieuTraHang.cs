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
    public partial class FormPhieuTraHang : Form
    {
        OrderCustomerBLL objOrderCustomerBLL = new OrderCustomerBLL();
        OrderStoreBLL objOrderStoreBLL = new OrderStoreBLL();
        OrderStoreDetailBLL objOrderStoreDetailBLL = new OrderStoreDetailBLL();
        ReturnProductBLL objReturnProductBLL = new ReturnProductBLL();
        CustomerBLL objCustomerBLL = new CustomerBLL();
        ProductBLL objProductBLL = new ProductBLL();
        public delegate void CloseDialog();
        public event CloseDialog CloseDialogEvent;
        string[] str2 = new string[500];
        public FormPhieuTraHang()
        {
            InitializeComponent();
            
            txt_NguoiDat.Text = FormLogin.objUserBO.UserFullName;
            txt_NgayTra.Text = DateTime.Now.ToString();
            txt_NhaCungCap.Text = FormTraHangNCC.strCustomerName;
            dgv_Order.DataSource = FormTraHangNCC.lstOrderDetailBO;

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormTraHangNCC.lstOrderDetailBO = new List<OrderDetailBO>();
            CloseDialogEvent();
            this.Close();
        }

        private void btn_TraHang_Click(object sender, EventArgs e)
        {
            ReturnProductBO objReturnProductBO = new ReturnProductBO();
            if (FormLogin.objUserBO.Permission == 1)
            {
                objReturnProductBO.MaNCC = FormTraHangNCC.intCustomerId;
                objReturnProductBO.MaST = -1;
            }
            else
            {
                objReturnProductBO.MaNCC = -1;
                objReturnProductBO.MaST = FormLogin.objUserBO.StoreId;
            }
            objReturnProductBO.NguoiLapPhieu = txt_NguoiDat.Text;
            objReturnProductBO.NgayTra = DateTime.Now;
            objReturnProductBO.Isdeleted = false;
            objReturnProductBO.TinhTrang = 0;
            foreach (var orderDetail in FormTraHangNCC.lstOrderDetailBO)
            {
                var objProduct = objProductBLL.GetProductByid(orderDetail.MaSP);
                objReturnProductBO.TongTien += (int)objProduct.GiaVon;
            }
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
                    Program.frmReport = new FormReport("TraHang");
                    Program.frmReport.ShowDialog();
                    FormTraHangNCC.lstOrderDetailBO = new List<OrderDetailBO>();
                    CloseDialogEvent();
                    if (FormLogin.objUserBO.Permission != 1)
                    {
                        MessageBox.Show("Tạo Phiếu Trả Hàng Thành Công");
                    }
                    //Gửi Mail cho NCC
                    if (FormLogin.objUserBO.Permission == 1)
                    {
                        DialogResult result;
                        result = MessageBox.Show("Bạn có muốn gửi email đến cho Nhà Cung Cấp?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            CustomerBO objCustomerBO = objCustomerBLL.GetListALlCustomer().Where(x => x.MaNCC == FormTraHangNCC.intCustomerId).FirstOrDefault();
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

                            MailMessage mail = new MailMessage("doanbachhoaxanh@gmail.com", objCustomerBO.Email, "Phiếu Trả Hàng", "");
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
                    }
                    this.Close();
                }
            }
        }
    }
}
