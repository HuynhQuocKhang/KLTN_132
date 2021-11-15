
namespace BachHoaXanh_Store
{
    partial class FormDatHangNCC
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Xoa = new FontAwesome.Sharp.IconButton();
            this.btn_Them = new FontAwesome.Sharp.IconButton();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txt_SoLuong = new Telerik.WinControls.UI.RadTextBox();
            this.txt_TinhTrang = new Telerik.WinControls.UI.RadTextBox();
            this.txt_NgayDat = new Telerik.WinControls.UI.RadTextBox();
            this.txt_TongTien = new Telerik.WinControls.UI.RadTextBox();
            this.cbo_NhaCungCap = new System.Windows.Forms.ComboBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.txt_TenNhaCungCap = new Telerik.WinControls.UI.RadTextBox();
            this.txt_MaNCC = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sanPhamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bachHoaXanh_StoreDataSet = new BachHoaXanh_Store.BachHoaXanh_StoreDataSet();
            this.sanPhamTableAdapter = new BachHoaXanh_Store.BachHoaXanh_StoreDataSetTableAdapters.SanPhamTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NgayDat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TongTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenNhaCungCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanh_StoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(159)))), ((int)(((byte)(177)))));
            this.btn_Xoa.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btn_Xoa.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(46)))), ((int)(((byte)(91)))));
            this.btn_Xoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Xoa.IconSize = 35;
            this.btn_Xoa.Location = new System.Drawing.Point(585, 284);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(70, 70);
            this.btn_Xoa.TabIndex = 1;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Xoa.UseVisualStyleBackColor = false;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(188)))));
            this.btn_Them.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btn_Them.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(175)))), ((int)(((byte)(101)))));
            this.btn_Them.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Them.IconSize = 35;
            this.btn_Them.Location = new System.Drawing.Point(585, 214);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(70, 70);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Them.UseVisualStyleBackColor = false;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txt_SoLuong);
            this.radGroupBox1.Controls.Add(this.txt_TinhTrang);
            this.radGroupBox1.Controls.Add(this.txt_NgayDat);
            this.radGroupBox1.Controls.Add(this.txt_TongTien);
            this.radGroupBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderPosition = Telerik.WinControls.UI.HeaderPosition.Left;
            this.radGroupBox1.HeaderText = "Thông tin đơn đặt hàng";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(316, 196);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Thông tin đơn đặt hàng";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Enabled = false;
            this.txt_SoLuong.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoLuong.Location = new System.Drawing.Point(36, 21);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(93, 23);
            this.txt_SoLuong.TabIndex = 2;
            this.txt_SoLuong.ThemeName = "TelerikMetro";
            // 
            // txt_TinhTrang
            // 
            this.txt_TinhTrang.Enabled = false;
            this.txt_TinhTrang.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TinhTrang.Location = new System.Drawing.Point(36, 125);
            this.txt_TinhTrang.Name = "txt_TinhTrang";
            this.txt_TinhTrang.Size = new System.Drawing.Size(275, 23);
            this.txt_TinhTrang.TabIndex = 1;
            this.txt_TinhTrang.ThemeName = "TelerikMetro";
            // 
            // txt_NgayDat
            // 
            this.txt_NgayDat.Enabled = false;
            this.txt_NgayDat.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NgayDat.Location = new System.Drawing.Point(36, 74);
            this.txt_NgayDat.Name = "txt_NgayDat";
            this.txt_NgayDat.Size = new System.Drawing.Size(275, 23);
            this.txt_NgayDat.TabIndex = 1;
            this.txt_NgayDat.ThemeName = "TelerikMetro";
            // 
            // txt_TongTien
            // 
            this.txt_TongTien.Enabled = false;
            this.txt_TongTien.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TongTien.Location = new System.Drawing.Point(135, 21);
            this.txt_TongTien.Name = "txt_TongTien";
            this.txt_TongTien.Size = new System.Drawing.Size(176, 23);
            this.txt_TongTien.TabIndex = 1;
            this.txt_TongTien.ThemeName = "TelerikMetro";
            // 
            // cbo_NhaCungCap
            // 
            this.cbo_NhaCungCap.FormattingEnabled = true;
            this.cbo_NhaCungCap.Location = new System.Drawing.Point(40, 21);
            this.cbo_NhaCungCap.Name = "cbo_NhaCungCap";
            this.cbo_NhaCungCap.Size = new System.Drawing.Size(281, 21);
            this.cbo_NhaCungCap.TabIndex = 2;
            this.cbo_NhaCungCap.SelectedIndexChanged += new System.EventHandler(this.cbo_NhaCungCap_SelectedIndexChanged);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.cbo_NhaCungCap);
            this.radGroupBox2.Controls.Add(this.txt_TenNhaCungCap);
            this.radGroupBox2.Controls.Add(this.txt_MaNCC);
            this.radGroupBox2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox2.HeaderPosition = Telerik.WinControls.UI.HeaderPosition.Left;
            this.radGroupBox2.HeaderText = "Thông tin nhà cung cấp";
            this.radGroupBox2.Location = new System.Drawing.Point(334, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(326, 196);
            this.radGroupBox2.TabIndex = 2;
            this.radGroupBox2.Text = "Thông tin nhà cung cấp";
            this.radGroupBox2.ThemeName = "TelerikMetro";
            // 
            // txt_TenNhaCungCap
            // 
            this.txt_TenNhaCungCap.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenNhaCungCap.Location = new System.Drawing.Point(40, 125);
            this.txt_TenNhaCungCap.Name = "txt_TenNhaCungCap";
            this.txt_TenNhaCungCap.Size = new System.Drawing.Size(281, 23);
            this.txt_TenNhaCungCap.TabIndex = 2;
            this.txt_TenNhaCungCap.ThemeName = "TelerikMetro";
            // 
            // txt_MaNCC
            // 
            this.txt_MaNCC.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaNCC.Location = new System.Drawing.Point(40, 74);
            this.txt_MaNCC.Name = "txt_MaNCC";
            this.txt_MaNCC.Size = new System.Drawing.Size(281, 23);
            this.txt_MaNCC.TabIndex = 1;
            this.txt_MaNCC.ThemeName = "TelerikMetro";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.dataGridView1);
            this.radGroupBox3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox3.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox3.HeaderText = "Danh sách sản phẩm";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 214);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(562, 395);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "Danh sách sản phẩm";
            this.radGroupBox3.ThemeName = "TelerikMetro";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(558, 372);
            this.dataGridView1.TabIndex = 0;
            // 
            // sanPhamBindingSource
            // 
            this.sanPhamBindingSource.DataMember = "SanPham";
            this.sanPhamBindingSource.DataSource = this.bachHoaXanh_StoreDataSet;
            // 
            // bachHoaXanh_StoreDataSet
            // 
            this.bachHoaXanh_StoreDataSet.DataSetName = "BachHoaXanh_StoreDataSet";
            this.bachHoaXanh_StoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sanPhamTableAdapter
            // 
            this.sanPhamTableAdapter.ClearBeforeFill = true;
            // 
            // FormDatHangNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1030, 637);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "FormDatHangNCC";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FormDatHangNCC";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.FormDatHangNCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NgayDat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TongTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TenNhaCungCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sanPhamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bachHoaXanh_StoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox txt_TinhTrang;
        private Telerik.WinControls.UI.RadTextBox txt_NgayDat;
        private Telerik.WinControls.UI.RadTextBox txt_TongTien;
        private System.Windows.Forms.ComboBox cbo_NhaCungCap;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTextBox txt_TenNhaCungCap;
        private Telerik.WinControls.UI.RadTextBox txt_MaNCC;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private BachHoaXanh_StoreDataSet bachHoaXanh_StoreDataSet;
        private System.Windows.Forms.BindingSource sanPhamBindingSource;
        private BachHoaXanh_StoreDataSetTableAdapters.SanPhamTableAdapter sanPhamTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton btn_Xoa;
        private FontAwesome.Sharp.IconButton btn_Them;
        private Telerik.WinControls.UI.RadTextBox txt_SoLuong;
    }
}
