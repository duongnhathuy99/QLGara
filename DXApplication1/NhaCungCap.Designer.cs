
namespace DXApplication1
{
    partial class NhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhaCungCap));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridNhaCungCap = new DevExpress.XtraGrid.GridControl();
            this.gridViewNCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColumnMaNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnTenNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtSdt = new DevExpress.XtraEditors.TextEdit();
            this.txtTenNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNCC = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhaCungCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSdt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridNhaCungCap;
            this.gridView2.Name = "gridView2";
            // 
            // gridNhaCungCap
            // 
            this.gridNhaCungCap.Location = new System.Drawing.Point(12, 12);
            this.gridNhaCungCap.MainView = this.gridViewNCC;
            this.gridNhaCungCap.Name = "gridNhaCungCap";
            this.gridNhaCungCap.Size = new System.Drawing.Size(479, 447);
            this.gridNhaCungCap.TabIndex = 4;
            this.gridNhaCungCap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNCC,
            this.cardView1,
            this.gridView2});
            // 
            // gridViewNCC
            // 
            this.gridViewNCC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColumnMaNCC,
            this.ColumnTenNCC,
            this.ColumnSDT,
            this.ColumnDiaChi});
            this.gridViewNCC.GridControl = this.gridNhaCungCap;
            this.gridViewNCC.Name = "gridViewNCC";
            // 
            // ColumnMaNCC
            // 
            this.ColumnMaNCC.Caption = "Mã nhà cung cấp";
            this.ColumnMaNCC.FieldName = "MaNCC";
            this.ColumnMaNCC.Name = "ColumnMaNCC";
            this.ColumnMaNCC.OptionsColumn.AllowEdit = false;
            this.ColumnMaNCC.Visible = true;
            this.ColumnMaNCC.VisibleIndex = 0;
            this.ColumnMaNCC.Width = 78;
            // 
            // ColumnTenNCC
            // 
            this.ColumnTenNCC.Caption = "Tên nhà cung cấp";
            this.ColumnTenNCC.FieldName = "TenNCC";
            this.ColumnTenNCC.Name = "ColumnTenNCC";
            this.ColumnTenNCC.OptionsColumn.AllowEdit = false;
            this.ColumnTenNCC.Visible = true;
            this.ColumnTenNCC.VisibleIndex = 1;
            this.ColumnTenNCC.Width = 165;
            // 
            // ColumnSDT
            // 
            this.ColumnSDT.Caption = "Số điện thoại";
            this.ColumnSDT.FieldName = "SDT";
            this.ColumnSDT.Name = "ColumnSDT";
            this.ColumnSDT.OptionsColumn.AllowEdit = false;
            this.ColumnSDT.Visible = true;
            this.ColumnSDT.VisibleIndex = 2;
            this.ColumnSDT.Width = 72;
            // 
            // ColumnDiaChi
            // 
            this.ColumnDiaChi.Caption = "Địa chỉ";
            this.ColumnDiaChi.FieldName = "DiaChi";
            this.ColumnDiaChi.Name = "ColumnDiaChi";
            this.ColumnDiaChi.OptionsColumn.AllowEdit = false;
            this.ColumnDiaChi.Visible = true;
            this.ColumnDiaChi.VisibleIndex = 3;
            this.ColumnDiaChi.Width = 139;
            // 
            // cardView1
            // 
            this.cardView1.GridControl = this.gridNhaCungCap;
            this.cardView1.Name = "cardView1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCapNhat);
            this.layoutControl1.Controls.Add(this.btnSua);
            this.layoutControl1.Controls.Add(this.btnXoa);
            this.layoutControl1.Controls.Add(this.btnThem);
            this.layoutControl1.Controls.Add(this.txtDiaChi);
            this.layoutControl1.Controls.Add(this.txtSdt);
            this.layoutControl1.Controls.Add(this.txtTenNCC);
            this.layoutControl1.Controls.Add(this.txtMaNCC);
            this.layoutControl1.Controls.Add(this.gridNhaCungCap);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(876, 471);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.ImageOptions.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(684, 193);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(180, 36);
            this.btnCapNhat.StyleController = this.layoutControl1;
            this.btnCapNhat.TabIndex = 17;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnSua
            // 
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.Location = new System.Drawing.Point(495, 193);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(185, 36);
            this.btnSua.StyleController = this.layoutControl1;
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(684, 153);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(180, 36);
            this.btnXoa.StyleController = this.layoutControl1;
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(495, 153);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(185, 36);
            this.btnThem.StyleController = this.layoutControl1;
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(599, 117);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(253, 20);
            this.txtDiaChi.StyleController = this.layoutControl1;
            this.txtDiaChi.TabIndex = 9;
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(599, 93);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Properties.MaxLength = 11;
            this.txtSdt.Size = new System.Drawing.Size(253, 20);
            this.txtSdt.StyleController = this.layoutControl1;
            this.txtSdt.TabIndex = 8;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(599, 69);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(253, 20);
            this.txtTenNCC.StyleController = this.layoutControl1;
            this.txtTenNCC.TabIndex = 7;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Enabled = false;
            this.txtMaNCC.Location = new System.Drawing.Point(599, 45);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(253, 20);
            this.txtMaNCC.StyleController = this.layoutControl1;
            this.txtMaNCC.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(876, 471);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridNhaCungCap;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(483, 451);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnThem;
            this.layoutControlItem2.Location = new System.Drawing.Point(483, 141);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(189, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnXoa;
            this.layoutControlItem7.Location = new System.Drawing.Point(672, 141);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(184, 40);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSua;
            this.layoutControlItem8.Location = new System.Drawing.Point(483, 181);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(189, 270);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnCapNhat;
            this.layoutControlItem9.Location = new System.Drawing.Point(672, 181);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(184, 270);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(483, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(373, 141);
            this.layoutControlGroup1.Text = "Thông tin nhà cung cấp";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMaNCC;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItem3.Text = "Mã nhà cung cấp:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(89, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtTenNCC;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItem4.Text = "Tên nhà cung cấp:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(89, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtSdt;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItem5.Text = "Số điện thoại:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(89, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtDiaChi;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItem6.Text = "Địa chỉ:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(89, 13);
            // 
            // NhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 471);
            this.Controls.Add(this.layoutControl1);
            this.Name = "NhaCungCap";
            this.Text = "Nhà Cung Cấp";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridNhaCungCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSdt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.TextEdit txtSdt;
        private DevExpress.XtraEditors.TextEdit txtTenNCC;
        private DevExpress.XtraEditors.TextEdit txtMaNCC;
        private DevExpress.XtraGrid.GridControl gridNhaCungCap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNCC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnMaNCC;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnTenNCC;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnSDT;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnDiaChi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
    }
}