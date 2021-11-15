using Bunifu.UI.WinForms.BunifuTextbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
namespace BachHoaXanh_Store
{
    class XuLiGiaoDien
    {
        public void thongTinDatHang(RadTextBox pTongTien, RadTextBox pSoLuong, RadTextBox pNgayDat, RadTextBox pTinhTrang)
        {
            pTongTien.ShowEmbeddedLabel = true;
            pTongTien.EmbeddedLabelText = "Tổng tiền (VNĐ)";
            pSoLuong.ShowEmbeddedLabel = true;
            pSoLuong.EmbeddedLabelText = "Số lượng";
            pTongTien.Text = "0";
            pNgayDat.ShowEmbeddedLabel = true;
            pNgayDat.EmbeddedLabelText = "Ngày đặt";
            DateTime today = DateTime.Today;
            pNgayDat.Text = today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString();
            pTinhTrang.ShowEmbeddedLabel = true;
            pTinhTrang.EmbeddedLabelText = "Tình trạng";
            pTinhTrang.Text = "Đã đặt";
           
        }

        public void thongTinSanPhamPPH(RadTextBox pMaSP, RadTextBox pTenSP, RadTextBox pSoLuong)
        {
            pMaSP.ShowEmbeddedLabel = true;
            pMaSP.EmbeddedLabelText = "Mã sản phẩm";
            pTenSP.ShowEmbeddedLabel = true;
            pTenSP.EmbeddedLabelText = "Tên sản phẩm";
            pSoLuong.ShowEmbeddedLabel = true;
            pSoLuong.EmbeddedLabelText = "Số lượng";
        }

        public void thongTinPhieuXuatKho(RadTextBox pMaST, RadTextBox pMaDH,RadTextBox pTongTien, RadTextBox pNgayXuat)
        {
            pMaST.ShowEmbeddedLabel = true;
            pMaST.EmbeddedLabelText = "Mã siêu thị";
            pMaDH.ShowEmbeddedLabel = true;
            pMaDH.EmbeddedLabelText = "Mã đơn hàng";
            pTongTien.ShowEmbeddedLabel = true;
            pTongTien.EmbeddedLabelText = "Tổng tiền";
            pNgayXuat.ShowEmbeddedLabel = true;
            DateTime today = DateTime.Today;
            pNgayXuat.Text = today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString();
            pNgayXuat.EmbeddedLabelText = "Ngày xuất";

        }


        public void chiTietPhieuTraHang(RadTextBox pSoLuong,RadTextBox pNgayHetHan)
        {
            pSoLuong.ShowEmbeddedLabel = true;
            pSoLuong.EmbeddedLabelText = "Số lượng";
            pNgayHetHan.ShowEmbeddedLabel = true;
            pNgayHetHan.EmbeddedLabelText = "Ngày hết hạn";
        }

        public void thongtinPhieuTraHang(BunifuTextBox pNhaCungCap, BunifuTextBox pNgayTra, BunifuTextBox pTongTien, BunifuTextBox pTinhTrang)
        {
            pNhaCungCap.TextPlaceholder = "Nhà cung cấp";
            pTongTien.TextPlaceholder = "Tổng tiền";
            DateTime today = DateTime.Today;
            pNgayTra.Text = today.Day.ToString() + "/" + today.Month.ToString() + "/" + today.Year.ToString();
            pNgayTra.TextPlaceholder = "Ngày trả";
            pTinhTrang.TextPlaceholder = "Tình trạng";
            pTinhTrang.Text = "Đang xử lí";
        }

    }
}
