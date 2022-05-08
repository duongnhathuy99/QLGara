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
using BUS;
using DTO;
namespace DXApplication1
{
    public partial class KhachHang : DevExpress.XtraEditors.XtraForm
    {
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        private bool IsThem = false;
        private bool IsSua = false;
        public KhachHang()
        {
            InitializeComponent();
        }
        private void EnabledTextBox(bool flag)
        {
            txtMaKH.Enabled = flag;
            txtTenKH.Enabled = flag;
            txtSdt.Enabled = flag;
            txtDiaChi.Enabled = flag;
            txtHieuXe.Enabled = flag;
            txtBienSo.Enabled = flag;
        }
        private void XoaTextBox()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSdt.Text = "";
            txtDiaChi.Text = "";
            txtHieuXe.Text = "";
            txtBienSo.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                EnabledTextBox(true);
                XoaTextBox();
                IsThem = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnThem.Text = "Thêm";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnCapNhat.Enabled = false;
                Bind();
                EnabledTextBox(false);
                IsThem = false;
            }
        }
        private void Loadfull()
        {
            gridKhachHang.DataSource = bus_kh.select();           
            EnabledTextBox(false);
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            IsThem = IsSua = false;
            btnCapNhat.Enabled = false;
            btnThem.Text = "Thêm";
            btnSua.Text = "Sửa";
            Bind();
        }
        private void Bind()
        {
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", gridKhachHang.DataSource, "MaKH");
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", gridKhachHang.DataSource, "TenKH");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", gridKhachHang.DataSource, "DiaChi");
            txtHieuXe.DataBindings.Clear();
            txtHieuXe.DataBindings.Add("Text", gridKhachHang.DataSource, "HieuXe");
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", gridKhachHang.DataSource, "SDT");
            txtBienSo.DataBindings.Clear();
            txtBienSo.DataBindings.Add("Text", gridKhachHang.DataSource, "BienSo");
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsThem)
            {
                DTO_KhachHang kh = new DTO_KhachHang();
                kh.MaKH = txtMaKH.Text;
                kh.TenKH = txtTenKH.Text;
                kh.DiaChi = txtDiaChi.Text;
                kh.SDT = txtSdt.Text;
                kh.HieuXe = txtHieuXe.Text;
                kh.BienSo = txtBienSo.Text;
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtBienSo.Text != "" && txtSdt.Text != "")
                {
                    if (bus_kh.ThemKH(kh))
                    {
                        Loadfull();
                    }
                    else
                        MessageBox.Show("Lỗi cập nhật");
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else if (IsSua)
            {
                DTO_KhachHang kh = new DTO_KhachHang();
                kh.MaKH = txtMaKH.Text;
                kh.TenKH = txtTenKH.Text;
                kh.DiaChi = txtDiaChi.Text;
                kh.SDT = txtSdt.Text;
                kh.HieuXe = txtHieuXe.Text;
                kh.BienSo = txtBienSo.Text;
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtBienSo.Text != "" && txtSdt.Text != "")
                {
                    if (bus_kh.SuaKH(kh))
                    {
                        Loadfull();
                    }
                    else
                        MessageBox.Show("Lỗi cập nhật");
                }
                else
                    MessageBox.Show("Lỗi sửa");
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            Loadfull();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                if (gridViewKH.RowCount > 0
              && txtMaKH.Text != ""
              && IsThem == false
              && IsSua == false)
                {
                    if (bus_kh.XoaKH(txtMaKH.Text))
                        Loadfull();
                    else
                        MessageBox.Show("loi");
                }
                else
                    MessageBox.Show("khong co de xoa");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Hủy";
                EnabledTextBox(true);             
                IsSua = true;
                txtMaKH.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnCapNhat.Enabled = false;
                Bind();
                EnabledTextBox(false);
                IsSua = false;
            }
        }
    }
}