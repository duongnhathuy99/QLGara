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
    public partial class ThanhToan : DevExpress.XtraEditors.XtraForm
    {
        BUS_PhieuSuaChua bus_psc = new BUS_PhieuSuaChua();
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        List<DTO_PhieuSuaChua> psc = new List<DTO_PhieuSuaChua>();
        DTO_NhanVien nv = new DTO_NhanVien();
        public ThanhToan(DTO_NhanVien Nv)
        {
            InitializeComponent();
            nv = Nv;
            txtTenNV.Text = nv.TenNV;
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            Loadfull();
        }
        private void Loadfull()
        {
            gridHoaDon.DataSource = bus_psc.select1();
            Bind();
        }
        private void Bind()
        {
            txtMaPhieu.DataBindings.Clear();
            txtMaPhieu.DataBindings.Add("Text", gridHoaDon.DataSource, "MaPhieu");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", gridHoaDon.DataSource, "KhachHang.TenKH");         
            txtHieuXe.DataBindings.Clear();
            txtHieuXe.DataBindings.Add("Text", gridHoaDon.DataSource, "KhachHang.HieuXe");
            txtTienSuaChua.DataBindings.Clear();
            txtTienSuaChua.DataBindings.Add("Text", gridHoaDon.DataSource, "TienSuaChua");
            txtBienSo.DataBindings.Clear();
            txtBienSo.DataBindings.Add("Text", gridHoaDon.DataSource, "KhachHang.BienSo");
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            if (btnTaoHD.Text == "Tạo Hóa Đơn")
            {
                txtMaHD.Text= "HD" + (bus_hd.taoIDHD() + 1).ToString();
                dtThanhToan.DateTime = DateTime.Now;
                btnTaoHD.Text = "Hủy";
                txtTienNhap.Enabled = true;              
                btnThanhToanTienMat.Enabled = true;
                btnThanhToanThe.Enabled = true;               
            }
            else
            {
                dtThanhToan.Text = "";
                txtMaHD.Text = "";
                btnTaoHD.Text = "Tạo Hóa Đơn";
                txtTienNhap.Enabled = false;
                btnThanhToanTienMat.Enabled = false;
                btnThanhToanThe.Enabled = false;
                Bind();                          
            }
        }

        private void btnThanhToanTienMat_Click(object sender, EventArgs e)
        {
            DTO_HoaDon hd = new DTO_HoaDon();
            DTO_NhanVien nv = new DTO_NhanVien();
            hd.MaHD = txtMaHD.Text;
            hd.NgayThanhToan = DateTime.Parse(dtThanhToan.Text);
            nv.TaiKhoan = "admin";
            hd.NhanVien = nv;
            hd.HinhThucThanhToan = "Tiền mặt";
            DTO_PhieuSuaChua psc = new DTO_PhieuSuaChua();
            psc.MaPhieu = txtMaPhieu.Text;
            hd.PhieuSuaChua = psc;          
            if (bus_hd.ThemHD(hd))
            {
                Loadfull();
                MessageBox.Show("Thanh toán thành công");
                dtThanhToan.Text = "";
                txtMaHD.Text = "";
                btnTaoHD.Text = "Tạo Hóa Đơn";
                txtTienNhap.Enabled = false;
                btnThanhToanTienMat.Enabled = false;
                btnThanhToanThe.Enabled = false;
            }
        }

        private void btnThanhToanThe_Click(object sender, EventArgs e)
        {
            DTO_HoaDon hd = new DTO_HoaDon();          
            hd.MaHD = txtMaHD.Text;
            hd.NgayThanhToan = DateTime.Parse(dtThanhToan.Text);
            hd.NhanVien = nv;
            hd.HinhThucThanhToan = "Thẻ ATM";
            DTO_PhieuSuaChua psc = new DTO_PhieuSuaChua();
            psc.MaPhieu = txtMaPhieu.Text;
            hd.PhieuSuaChua = psc;
            if (bus_hd.ThemHD(hd))
            {
                Loadfull();
                MessageBox.Show("Thanh toán thành công");
                dtThanhToan.Text = "";
                txtMaHD.Text = "";
                btnTaoHD.Text = "Tạo Hóa Đơn";
                txtTienNhap.Enabled = false;
                btnThanhToanTienMat.Enabled = false;
                btnThanhToanThe.Enabled = false;
            }
        }
    }
}