using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace DXApplication1
{
    public partial class PhieuSuaChua : DevExpress.XtraEditors.XtraForm
    {
        BUS_PhieuSuaChua bus_psc = new BUS_PhieuSuaChua();
        public PhieuSuaChua()
        {
            InitializeComponent();
        }
        private void Loadfull()
        {
            gridPhieuSuaChua.DataSource = bus_psc.select2(); 
            
            //gridPT_DV.DataSource = bus_psc.select3("PSC4");        
            Bind();
        }
        private void Bind()
        {        
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "KhachHang.TenKH");
            txtHieuXe.DataBindings.Clear();
            txtHieuXe.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "KhachHang.HieuXe");
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "KhachHang.SDT");
            txtBienSo.DataBindings.Clear();
            txtBienSo.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "KhachHang.BienSo");
            txtMaPhieu.DataBindings.Clear();
            txtMaPhieu.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "MaPhieu");
            txtNgayBanGiao.DataBindings.Clear();
            txtNgayBanGiao.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "NgayBanGiao");
            txtNgayLapPhieu.DataBindings.Clear();
            txtNgayLapPhieu.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "NgayLapPhieu");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "NhanVien.TenNV");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "GhiChu");
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", gridPhieuSuaChua.DataSource, "TienSuaChua");            
        }

        private void PhieuSuaChua_Load(object sender, EventArgs e)
        {
            Loadfull();
            gridPT_DV.DataSource = null;
            gridPT_DV.DataSource = bus_psc.select3(txtMaPhieu.Text);     
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridPT_DV.DataSource = null;
            gridPT_DV.DataSource = bus_psc.select3(txtMaPhieu.Text);
        }
    }
}