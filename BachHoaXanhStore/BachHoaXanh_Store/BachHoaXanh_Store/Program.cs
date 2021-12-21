using BachHoaXanh_Store.ReportForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachHoaXanh_Store
{
    static class Program
    {  
        public static FormDatHang frmDatHang = null;
        public static FormPhanPhoiHang frmPhanPhoiHang = null;
        public static FormTraHangNCC frmTraHangNCC = null;
        public static FormPhieuTraHang frmPhieuTraHang = null;
        public static FormPhieuXuatKho frmPhieuXuatKho = null;
        public static FormDonDatHang frmDonDatHang = null;
        public static FormDanhSachSP frmDanhSachSP = null;
        public static FormChinhSuaSP frmChinhSuaSP = null;
        public static FormXemDonDatHang frmXemDonDatHang = null;
        public static FormMain frmMain = null;
        public static FormReport frmReport = null;
        public static FormBanHang frmBanHang = null;
        public static FormLogin frmLogin = null;
        public static FormDuyetPhieuTraHang frmDuyetPhieuTraHang = null;
        public static FormThemSPKM frmThemSPKM = null;
        public static FormTimKiem frmTimKiem = null;
        public static FormKetCa frmKetCa = null;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmKetCa = new  FormKetCa();
            Application.Run(frmKetCa);
        }


    }
}
