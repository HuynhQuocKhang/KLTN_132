
namespace BachHoaXanh_Store
{
    partial class FormTimKiem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTimKiem));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_DSSP = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.txt_Keyword = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.btn_TimKiem = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.col_Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_DSSP);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(726, 267);
            this.panel3.TabIndex = 1;
            // 
            // dgv_DSSP
            // 
            this.dgv_DSSP.AccessibleName = "";
            this.dgv_DSSP.AllowUserToAddRows = false;
            this.dgv_DSSP.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_DSSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DSSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DSSP.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_DSSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DSSP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DSSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_DSSP.ColumnHeadersHeight = 35;
            this.dgv_DSSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Add,
            this.col_MaSP,
            this.col_TenSP,
            this.col_Soluong,
            this.col_GiaBan});
            this.dgv_DSSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DSSP.DoubleBuffered = true;
            this.dgv_DSSP.EnableHeadersVisualStyles = false;
            this.dgv_DSSP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(186)))), ((int)(((byte)(27)))));
            this.dgv_DSSP.HeaderBgColor = System.Drawing.Color.Silver;
            this.dgv_DSSP.HeaderForeColor = System.Drawing.Color.Black;
            this.dgv_DSSP.Location = new System.Drawing.Point(0, 0);
            this.dgv_DSSP.Name = "dgv_DSSP";
            this.dgv_DSSP.ReadOnly = true;
            this.dgv_DSSP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_DSSP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_DSSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DSSP.Size = new System.Drawing.Size(726, 267);
            this.dgv_DSSP.TabIndex = 3;
            this.dgv_DSSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DSSP_CellClick);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 386);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 267);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.bunifuLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_Keyword, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_TimKiem, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(726, 67);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.AutoSize = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(3, 3);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(250, 20);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "Mã sản phẩm";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txt_Keyword
            // 
            this.txt_Keyword.AcceptsReturn = false;
            this.txt_Keyword.AcceptsTab = false;
            this.txt_Keyword.AnimationSpeed = 200;
            this.txt_Keyword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_Keyword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_Keyword.AutoSize = true;
            this.txt_Keyword.BackColor = System.Drawing.Color.Transparent;
            this.txt_Keyword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_Keyword.BackgroundImage")));
            this.txt_Keyword.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txt_Keyword.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txt_Keyword.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txt_Keyword.BorderColorIdle = System.Drawing.Color.Silver;
            this.txt_Keyword.BorderRadius = 1;
            this.txt_Keyword.BorderThickness = 1;
            this.txt_Keyword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_Keyword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Keyword.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.txt_Keyword.DefaultText = "";
            this.txt_Keyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Keyword.FillColor = System.Drawing.Color.White;
            this.txt_Keyword.HideSelection = true;
            this.txt_Keyword.IconLeft = null;
            this.txt_Keyword.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Keyword.IconPadding = 10;
            this.txt_Keyword.IconRight = null;
            this.txt_Keyword.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Keyword.Lines = new string[0];
            this.txt_Keyword.Location = new System.Drawing.Point(3, 29);
            this.txt_Keyword.MaxLength = 32767;
            this.txt_Keyword.MinimumSize = new System.Drawing.Size(100, 35);
            this.txt_Keyword.Modified = false;
            this.txt_Keyword.Multiline = false;
            this.txt_Keyword.Name = "txt_Keyword";
            stateProperties7.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Keyword.OnActiveState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Empty;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_Keyword.OnDisabledState = stateProperties8;
            stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties9.FillColor = System.Drawing.Color.Empty;
            stateProperties9.ForeColor = System.Drawing.Color.Empty;
            stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Keyword.OnHoverState = stateProperties9;
            stateProperties10.BorderColor = System.Drawing.Color.Silver;
            stateProperties10.FillColor = System.Drawing.Color.White;
            stateProperties10.ForeColor = System.Drawing.Color.Empty;
            stateProperties10.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Keyword.OnIdleState = stateProperties10;
            this.txt_Keyword.PasswordChar = '\0';
            this.txt_Keyword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_Keyword.PlaceholderText = "";
            this.txt_Keyword.ReadOnly = false;
            this.txt_Keyword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Keyword.SelectedText = "";
            this.txt_Keyword.SelectionLength = 0;
            this.txt_Keyword.SelectionStart = 0;
            this.txt_Keyword.ShortcutsEnabled = true;
            this.txt_Keyword.Size = new System.Drawing.Size(250, 35);
            this.txt_Keyword.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txt_Keyword.TabIndex = 2;
            this.txt_Keyword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Keyword.TextMarginBottom = 0;
            this.txt_Keyword.TextMarginLeft = 5;
            this.txt_Keyword.TextMarginTop = 0;
            this.txt_Keyword.TextPlaceholder = "";
            this.txt_Keyword.UseSystemPasswordChar = false;
            this.txt_Keyword.WordWrap = true;
            this.txt_Keyword.TextChanged += new System.EventHandler(this.txt_MaSP_TextChanged);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.AllowToggling = false;
            this.btn_TimKiem.AnimationSpeed = 200;
            this.btn_TimKiem.AutoGenerateColors = false;
            this.btn_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btn_TimKiem.BackColor1 = System.Drawing.SystemColors.ControlLight;
            this.btn_TimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TimKiem.BackgroundImage")));
            this.btn_TimKiem.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_TimKiem.ButtonText = "Tìm kiếm";
            this.btn_TimKiem.ButtonTextMarginLeft = 0;
            this.btn_TimKiem.ColorContrastOnClick = 45;
            this.btn_TimKiem.ColorContrastOnHover = 45;
            this.btn_TimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btn_TimKiem.CustomizableEdges = borderEdges2;
            this.btn_TimKiem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_TimKiem.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btn_TimKiem.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_TimKiem.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_TimKiem.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_TimKiem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimKiem.ForeColor = System.Drawing.Color.Black;
            this.btn_TimKiem.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TimKiem.IconMarginLeft = 11;
            this.btn_TimKiem.IconPadding = 10;
            this.btn_TimKiem.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TimKiem.IdleBorderColor = System.Drawing.SystemColors.ControlLight;
            this.btn_TimKiem.IdleBorderRadius = 3;
            this.btn_TimKiem.IdleBorderThickness = 1;
            this.btn_TimKiem.IdleFillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_TimKiem.IdleIconLeftImage = null;
            this.btn_TimKiem.IdleIconRightImage = null;
            this.btn_TimKiem.IndicateFocus = false;
            this.btn_TimKiem.Location = new System.Drawing.Point(259, 29);
            this.btn_TimKiem.Name = "btn_TimKiem";
            stateProperties11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(154)))), ((int)(((byte)(42)))));
            stateProperties11.BorderRadius = 3;
            stateProperties11.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties11.BorderThickness = 1;
            stateProperties11.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(154)))), ((int)(((byte)(42)))));
            stateProperties11.ForeColor = System.Drawing.Color.White;
            stateProperties11.IconLeftImage = null;
            stateProperties11.IconRightImage = null;
            this.btn_TimKiem.onHoverState = stateProperties11;
            stateProperties12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(154)))), ((int)(((byte)(42)))));
            stateProperties12.BorderRadius = 3;
            stateProperties12.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties12.BorderThickness = 1;
            stateProperties12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(154)))), ((int)(((byte)(42)))));
            stateProperties12.ForeColor = System.Drawing.Color.White;
            stateProperties12.IconLeftImage = null;
            stateProperties12.IconRightImage = null;
            this.btn_TimKiem.OnPressedState = stateProperties12;
            this.btn_TimKiem.Size = new System.Drawing.Size(141, 35);
            this.btn_TimKiem.TabIndex = 0;
            this.btn_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_TimKiem.TextMarginLeft = 0;
            this.btn_TimKiem.UseDefaultRadiusAndThickness = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // col_Add
            // 
            this.col_Add.HeaderText = "Thao Tác";
            this.col_Add.Name = "col_Add";
            this.col_Add.ReadOnly = true;
            this.col_Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Add.Text = "Thêm";
            this.col_Add.ToolTipText = "Thêm Sản Phẩm";
            this.col_Add.UseColumnTextForButtonValue = true;
            // 
            // col_MaSP
            // 
            this.col_MaSP.DataPropertyName = "MaSP";
            this.col_MaSP.HeaderText = "Mã sản phẩm";
            this.col_MaSP.Name = "col_MaSP";
            this.col_MaSP.ReadOnly = true;
            // 
            // col_TenSP
            // 
            this.col_TenSP.DataPropertyName = "TenSP";
            this.col_TenSP.HeaderText = "Tên sản phẩm";
            this.col_TenSP.Name = "col_TenSP";
            this.col_TenSP.ReadOnly = true;
            // 
            // col_Soluong
            // 
            this.col_Soluong.DataPropertyName = "SoLuong";
            this.col_Soluong.HeaderText = "Số Lượng";
            this.col_Soluong.Name = "col_Soluong";
            this.col_Soluong.ReadOnly = true;
            // 
            // col_GiaBan
            // 
            this.col_GiaBan.DataPropertyName = "GiaBan";
            this.col_GiaBan.HeaderText = "Giá Bán";
            this.col_GiaBan.Name = "col_GiaBan";
            this.col_GiaBan.ReadOnly = true;
            // 
            // FormTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 386);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm Sản Phẩm";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_DSSP;
        private System.Windows.Forms.Timer timer2;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txt_Keyword;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_TimKiem;
        private System.Windows.Forms.DataGridViewButtonColumn col_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GiaBan;
    }
}