
namespace BachHoaXanh_Store.ReportForm
{
    partial class rptThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.chr_SoLuong = new DevExpress.XtraReports.UI.XRChart();
            this.rptPXK_DataSet1 = new BachHoaXanh_Store.ReportForm.rptPXK_DataSet();
            this.cTPhieuXuatKhoTableAdapter = new BachHoaXanh_Store.ReportForm.rptPXK_DataSetTableAdapters.CTPhieuXuatKhoTableAdapter();
            this.rptPXK_DataSet2 = new BachHoaXanh_Store.ReportForm.rptPXK_DataSet();
            this.rptPXK_DataSet3 = new BachHoaXanh_Store.ReportForm.rptPXK_DataSet();
            this.rptPXK_DataSet4 = new BachHoaXanh_Store.ReportForm.rptPXK_DataSet();
            this.chr_GiaTri = new DevExpress.XtraReports.UI.XRChart();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chr_SoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chr_GiaTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 7.708359F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.chr_GiaTri,
            this.chr_SoLuong});
            this.Detail.HeightF = 728.75F;
            this.Detail.Name = "Detail";
            // 
            // chr_SoLuong
            // 
            this.chr_SoLuong.BorderColor = System.Drawing.Color.Black;
            this.chr_SoLuong.Borders = DevExpress.XtraPrinting.BorderSide.None;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.chr_SoLuong.Diagram = xyDiagram2;
            this.chr_SoLuong.Legend.Name = "Default Legend";
            this.chr_SoLuong.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.chr_SoLuong.Name = "chr_SoLuong";
            series4.Name = "Đơn đặt hàng";
            series5.Name = "Phiếu xuất kho";
            series6.Name = "Phiếu trả hàng";
            this.chr_SoLuong.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4,
        series5,
        series6};
            this.chr_SoLuong.SizeF = new System.Drawing.SizeF(650F, 358.3333F);
            chartTitle2.Text = "Thống kê số lượng";
            this.chr_SoLuong.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // rptPXK_DataSet1
            // 
            this.rptPXK_DataSet1.DataSetName = "rptPXK_DataSet";
            this.rptPXK_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cTPhieuXuatKhoTableAdapter
            // 
            this.cTPhieuXuatKhoTableAdapter.ClearBeforeFill = true;
            // 
            // rptPXK_DataSet2
            // 
            this.rptPXK_DataSet2.DataSetName = "rptPXK_DataSet";
            this.rptPXK_DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptPXK_DataSet3
            // 
            this.rptPXK_DataSet3.DataSetName = "rptPXK_DataSet";
            this.rptPXK_DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptPXK_DataSet4
            // 
            this.rptPXK_DataSet4.DataSetName = "rptPXK_DataSet";
            this.rptPXK_DataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chr_GiaTri
            // 
            this.chr_GiaTri.BorderColor = System.Drawing.Color.Black;
            this.chr_GiaTri.Borders = DevExpress.XtraPrinting.BorderSide.None;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.chr_GiaTri.Diagram = xyDiagram1;
            this.chr_GiaTri.Legend.Name = "Default Legend";
            this.chr_GiaTri.LocationFloat = new DevExpress.Utils.PointFloat(1.999998F, 370.4166F);
            this.chr_GiaTri.Name = "chr_GiaTri";
            series1.Name = "Đơn đặt hàng";
            series2.Name = "Phiếu xuất kho";
            series3.Name = "Phiếu trả hàng";
            this.chr_GiaTri.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.chr_GiaTri.SizeF = new System.Drawing.SizeF(650F, 358.3333F);
            chartTitle1.Text = "Thống kê giá trị";
            this.chr_GiaTri.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(652F, 80.00002F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Báo cáo thống kê";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // rptThongKe
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.rptPXK_DataSet1,
            this.rptPXK_DataSet2,
            this.rptPXK_DataSet3,
            this.rptPXK_DataSet4});
            this.DataAdapter = this.cTPhieuXuatKhoTableAdapter;
            this.DataMember = "CTPhieuXuatKho";
            this.DataSource = this.rptPXK_DataSet1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(100, 75, 100, 8);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chr_SoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptPXK_DataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chr_GiaTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRChart chr_GiaTri;
        private DevExpress.XtraReports.UI.XRChart chr_SoLuong;
        private rptPXK_DataSet rptPXK_DataSet1;
        private rptPXK_DataSetTableAdapters.CTPhieuXuatKhoTableAdapter cTPhieuXuatKhoTableAdapter;
        private rptPXK_DataSet rptPXK_DataSet2;
        private rptPXK_DataSet rptPXK_DataSet3;
        private rptPXK_DataSet rptPXK_DataSet4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
