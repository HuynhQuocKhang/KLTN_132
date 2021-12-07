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
        public static FormDangNhap frmDangNhap = null;
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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new FormMain();
            Application.Run(frmMain);
        }


    }
}
