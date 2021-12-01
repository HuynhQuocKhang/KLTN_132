
namespace BachHoaXanh_Store
{
    partial class FormDanhSachSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDanhSachSP));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtKeyWord = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.cbo_NhaCungCap = new Bunifu.UI.WinForms.BunifuDropdown();
            this.btn_TimKiem = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dgv_DSSP = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.col_MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_MaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GiaVon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgv_DSSP, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.bunifuButton1, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.17304F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.82696F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 418);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.bunifuLabel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtKeyWord, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbo_NhaCungCap, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_TimKiem, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(936, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.AutoSize = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(19)))), ((int)(((byte)(10)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(115, 3);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(94, 34);
            this.bunifuLabel1.TabIndex = 3;
            this.bunifuLabel1.Text = "Tìm kiếm";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.AcceptsReturn = false;
            this.txtKeyWord.AcceptsTab = false;
            this.txtKeyWord.AnimationSpeed = 200;
            this.txtKeyWord.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtKeyWord.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtKeyWord.BackColor = System.Drawing.Color.Transparent;
            this.txtKeyWord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtKeyWord.BackgroundImage")));
            this.txtKeyWord.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(92)))), ((int)(((byte)(83)))));
            this.txtKeyWord.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtKeyWord.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(186)))), ((int)(((byte)(27)))));
            this.txtKeyWord.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(92)))), ((int)(((byte)(83)))));
            this.txtKeyWord.BorderRadius = 35;
            this.txtKeyWord.BorderThickness = 1;
            this.txtKeyWord.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtKeyWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyWord.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.txtKeyWord.DefaultText = "";
            this.txtKeyWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyWord.FillColor = System.Drawing.Color.White;
            this.txtKeyWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(19)))), ((int)(((byte)(10)))));
            this.txtKeyWord.HideSelection = true;
            this.txtKeyWord.IconLeft = null;
            this.txtKeyWord.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyWord.IconPadding = 10;
            this.txtKeyWord.IconRight = null;
            this.txtKeyWord.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyWord.Lines = new string[0];
            this.txtKeyWord.Location = new System.Drawing.Point(215, 3);
            this.txtKeyWord.MaxLength = 32767;
            this.txtKeyWord.MinimumSize = new System.Drawing.Size(100, 20);
            this.txtKeyWord.Modified = false;
            this.txtKeyWord.Multiline = false;
            this.txtKeyWord.Name = "txtKeyWord";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(92)))), ((int)(((byte)(83)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtKeyWord.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.Empty;
            stateProperties2.FillColor = System.Drawing.Color.White;
            stateProperties2.ForeColor = System.Drawing.Color.Empty;
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtKeyWord.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(186)))), ((int)(((byte)(27)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtKeyWord.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(92)))), ((int)(((byte)(83)))));
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(19)))), ((int)(((byte)(10)))));
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtKeyWord.OnIdleState = stateProperties4;
            this.txtKeyWord.PasswordChar = '\0';
            this.txtKeyWord.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtKeyWord.PlaceholderText = "Enter text";
            this.txtKeyWord.ReadOnly = false;
            this.txtKeyWord.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKeyWord.SelectedText = "";
            this.txtKeyWord.SelectionLength = 0;
            this.txtKeyWord.SelectionStart = 0;
            this.txtKeyWord.ShortcutsEnabled = true;
            this.txtKeyWord.Size = new System.Drawing.Size(250, 34);
            this.txtKeyWord.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtKeyWord.TabIndex = 2;
            this.txtKeyWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKeyWord.TextMarginBottom = 0;
            this.txtKeyWord.TextMarginLeft = 5;
            this.txtKeyWord.TextMarginTop = 0;
            this.txtKeyWord.TextPlaceholder = "Enter text";
            this.txtKeyWord.UseSystemPasswordChar = false;
            this.txtKeyWord.WordWrap = true;
            // 
            // cbo_NhaCungCap
            // 
            this.cbo_NhaCungCap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(216)))), ((int)(((byte)(211)))));
            this.cbo_NhaCungCap.BorderRadius = 13;
            this.cbo_NhaCungCap.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(92)))), ((int)(((byte)(83)))));
            this.cbo_NhaCungCap.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cbo_NhaCungCap.DisabledColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbo_NhaCungCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_NhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_NhaCungCap.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.cbo_NhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_NhaCungCap.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cbo_NhaCungCap.FillDropDown = false;
            this.cbo_NhaCungCap.FillIndicator = false;
            this.cbo_NhaCungCap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_NhaCungCap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_NhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(19)))), ((int)(((byte)(10)))));
            this.cbo_NhaCungCap.FormattingEnabled = true;
            this.cbo_NhaCungCap.Icon = null;
            this.cbo_NhaCungCap.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(92)))), ((int)(((byte)(83)))));
            this.cbo_NhaCungCap.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cbo_NhaCungCap.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(247)))), ((int)(((byte)(228)))));
            this.cbo_NhaCungCap.ItemBorderColor = System.Drawing.Color.Transparent;
            this.cbo_NhaCungCap.ItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(19)))), ((int)(((byte)(10)))));
            this.cbo_NhaCungCap.ItemHeight = 26;
            this.cbo_NhaCungCap.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(209)))), ((int)(((byte)(175)))));
            this.cbo_NhaCungCap.Items.AddRange(new object[] {
            "ALL"});
            this.cbo_NhaCungCap.Location = new System.Drawing.Point(471, 3);
            this.cbo_NhaCungCap.MaximumSize = new System.Drawing.Size(5000, 0);
            this.cbo_NhaCungCap.Name = "cbo_NhaCungCap";
            this.cbo_NhaCungCap.Size = new System.Drawing.Size(250, 32);
            this.cbo_NhaCungCap.TabIndex = 4;
            this.cbo_NhaCungCap.Text = null;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.AllowToggling = false;
            this.btn_TimKiem.AnimationSpeed = 200;
            this.btn_TimKiem.AutoGenerateColors = false;
            this.btn_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btn_TimKiem.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(207)))), ((int)(((byte)(138)))));
            this.btn_TimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TimKiem.BackgroundImage")));
            this.btn_TimKiem.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_TimKiem.ButtonText = "Tìm kiếm";
            this.btn_TimKiem.ButtonTextMarginLeft = 0;
            this.btn_TimKiem.ColorContrastOnClick = 45;
            this.btn_TimKiem.ColorContrastOnHover = 45;
            this.btn_TimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btn_TimKiem.CustomizableEdges = borderEdges1;
            this.btn_TimKiem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_TimKiem.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btn_TimKiem.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_TimKiem.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_TimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TimKiem.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_TimKiem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(46)))), ((int)(((byte)(41)))));
            this.btn_TimKiem.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TimKiem.IconMarginLeft = 11;
            this.btn_TimKiem.IconPadding = 10;
            this.btn_TimKiem.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TimKiem.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(207)))), ((int)(((byte)(138)))));
            this.btn_TimKiem.IdleBorderRadius = 35;
            this.btn_TimKiem.IdleBorderThickness = 1;
            this.btn_TimKiem.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(207)))), ((int)(((byte)(138)))));
            this.btn_TimKiem.IdleIconLeftImage = null;
            this.btn_TimKiem.IdleIconRightImage = null;
            this.btn_TimKiem.IndicateFocus = false;
            this.btn_TimKiem.Location = new System.Drawing.Point(727, 3);
            this.btn_TimKiem.Name = "btn_TimKiem";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(221)))), ((int)(((byte)(158)))));
            stateProperties5.BorderRadius = 35;
            stateProperties5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties5.BorderThickness = 1;
            stateProperties5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(221)))), ((int)(((byte)(158)))));
            stateProperties5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(46)))), ((int)(((byte)(41)))));
            stateProperties5.IconLeftImage = null;
            stateProperties5.IconRightImage = null;
            this.btn_TimKiem.onHoverState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(154)))), ((int)(((byte)(42)))));
            stateProperties6.BorderRadius = 35;
            stateProperties6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties6.BorderThickness = 1;
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(148)))), ((int)(((byte)(1)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(244)))), ((int)(((byte)(215)))));
            stateProperties6.IconLeftImage = null;
            stateProperties6.IconRightImage = null;
            this.btn_TimKiem.OnPressedState = stateProperties6;
            this.btn_TimKiem.Size = new System.Drawing.Size(122, 34);
            this.btn_TimKiem.TabIndex = 8;
            this.btn_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_TimKiem.TextMarginLeft = 0;
            this.btn_TimKiem.UseDefaultRadiusAndThickness = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // dgv_DSSP
            // 
            this.dgv_DSSP.AccessibleName = "";
            this.dgv_DSSP.AllowUserToAddRows = false;
            this.dgv_DSSP.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_DSSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_DSSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DSSP.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_DSSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DSSP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(139)))), ((int)(((byte)(125)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(223)))), ((int)(((byte)(135)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DSSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_DSSP.ColumnHeadersHeight = 35;
            this.dgv_DSSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaSP,
            this.col_TenSP,
            this.col_MaLoaiSP,
            this.Column1,
            this.col_MaNCC,
            this.col_TenNCC,
            this.col_DonViTinh,
            this.col_SoLuong,
            this.col_GiaBan,
            this.col_GiaVon,
            this.col_Sua,
            this.col_Xoa});
            this.tableLayoutPanel1.SetColumnSpan(this.dgv_DSSP, 2);
            this.dgv_DSSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DSSP.DoubleBuffered = true;
            this.dgv_DSSP.EnableHeadersVisualStyles = false;
            this.dgv_DSSP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(186)))), ((int)(((byte)(27)))));
            this.dgv_DSSP.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(139)))), ((int)(((byte)(125)))));
            this.dgv_DSSP.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(223)))), ((int)(((byte)(135)))));
            this.dgv_DSSP.Location = new System.Drawing.Point(23, 68);
            this.dgv_DSSP.Name = "dgv_DSSP";
            this.dgv_DSSP.ReadOnly = true;
            this.dgv_DSSP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DSSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DSSP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel1.SetRowSpan(this.dgv_DSSP, 2);
            this.dgv_DSSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_DSSP.Size = new System.Drawing.Size(936, 281);
            this.dgv_DSSP.TabIndex = 2;
            this.dgv_DSSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DSSP_CellClick);
            this.dgv_DSSP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DSSP_CellContentClick);
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
            // col_MaLoaiSP
            // 
            this.col_MaLoaiSP.DataPropertyName = "MaLoaiSP";
            this.col_MaLoaiSP.HeaderText = "Mã loại sản phẩm";
            this.col_MaLoaiSP.Name = "col_MaLoaiSP";
            this.col_MaLoaiSP.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TenLoaiSP";
            this.Column1.HeaderText = "Tên Loại Sản Phẩm";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // col_MaNCC
            // 
            this.col_MaNCC.DataPropertyName = "MaNCC";
            this.col_MaNCC.HeaderText = "Mã nhà cung cấp";
            this.col_MaNCC.Name = "col_MaNCC";
            this.col_MaNCC.ReadOnly = true;
            // 
            // col_TenNCC
            // 
            this.col_TenNCC.DataPropertyName = "TenNCC";
            this.col_TenNCC.HeaderText = "Tên Nhà Cung Cấp";
            this.col_TenNCC.Name = "col_TenNCC";
            this.col_TenNCC.ReadOnly = true;
            // 
            // col_DonViTinh
            // 
            this.col_DonViTinh.DataPropertyName = "DVT";
            this.col_DonViTinh.HeaderText = "ĐVT";
            this.col_DonViTinh.Name = "col_DonViTinh";
            this.col_DonViTinh.ReadOnly = true;
            // 
            // col_SoLuong
            // 
            this.col_SoLuong.DataPropertyName = "SoLuong";
            this.col_SoLuong.HeaderText = "Số Lượng";
            this.col_SoLuong.Name = "col_SoLuong";
            this.col_SoLuong.ReadOnly = true;
            // 
            // col_GiaBan
            // 
            this.col_GiaBan.DataPropertyName = "GiaBan";
            this.col_GiaBan.HeaderText = "Giá Bán";
            this.col_GiaBan.Name = "col_GiaBan";
            this.col_GiaBan.ReadOnly = true;
            // 
            // col_GiaVon
            // 
            this.col_GiaVon.DataPropertyName = "GiaVon";
            this.col_GiaVon.HeaderText = "Giá Vốn";
            this.col_GiaVon.Name = "col_GiaVon";
            this.col_GiaVon.ReadOnly = true;
            // 
            // col_Sua
            // 
            this.col_Sua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Sua.HeaderText = "Sửa";
            this.col_Sua.Name = "col_Sua";
            this.col_Sua.ReadOnly = true;
            this.col_Sua.Text = "Sửa";
            this.col_Sua.ToolTipText = "Sửa";
            this.col_Sua.UseColumnTextForButtonValue = true;
            // 
            // col_Xoa
            // 
            this.col_Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Xoa.HeaderText = "Xoá";
            this.col_Xoa.Name = "col_Xoa";
            this.col_Xoa.ReadOnly = true;
            this.col_Xoa.Text = "Xoá";
            this.col_Xoa.ToolTipText = "Xoá";
            this.col_Xoa.UseColumnTextForButtonValue = true;
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(207)))), ((int)(((byte)(138)))));
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.ButtonText = "Thêm sản phẩm";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges2;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(46)))), ((int)(((byte)(41)))));
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(207)))), ((int)(((byte)(138)))));
            this.bunifuButton1.IdleBorderRadius = 35;
            this.bunifuButton1.IdleBorderThickness = 1;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(207)))), ((int)(((byte)(138)))));
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(790, 355);
            this.bunifuButton1.Name = "bunifuButton1";
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(221)))), ((int)(((byte)(158)))));
            stateProperties7.BorderRadius = 35;
            stateProperties7.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties7.BorderThickness = 1;
            stateProperties7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(221)))), ((int)(((byte)(158)))));
            stateProperties7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(46)))), ((int)(((byte)(41)))));
            stateProperties7.IconLeftImage = null;
            stateProperties7.IconRightImage = null;
            this.bunifuButton1.onHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(148)))), ((int)(((byte)(1)))));
            stateProperties8.BorderRadius = 35;
            stateProperties8.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties8.BorderThickness = 1;
            stateProperties8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(148)))), ((int)(((byte)(1)))));
            stateProperties8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(244)))), ((int)(((byte)(215)))));
            stateProperties8.IconLeftImage = null;
            stateProperties8.IconRightImage = null;
            this.bunifuButton1.OnPressedState = stateProperties8;
            this.bunifuButton1.Size = new System.Drawing.Size(169, 39);
            this.bunifuButton1.TabIndex = 16;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // FormDanhSachSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(216)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(1014, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDanhSachSP";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "FormDanhSachSP";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Bunifu.UI.WinForms.BunifuDropdown cbo_NhaCungCap;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtKeyWord;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgv_DSSP;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_TimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GiaVon;
        private System.Windows.Forms.DataGridViewButtonColumn col_Sua;
        private System.Windows.Forms.DataGridViewButtonColumn col_Xoa;
    }
}