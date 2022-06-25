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
    public partial class Nhanvien : DevExpress.XtraEditors.XtraForm
    {
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        private bool IsThem = false;
        private bool IsSua = false;
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void EnabledTextBox(bool flag)
        {
            txtTaiKhoan.Enabled = flag;
            txtMatKhau.Enabled = flag;
            txtTen.Enabled = flag;
            txtSdt.Enabled = flag;
            txtDiaChi.Enabled = flag;
            txtEmail.Enabled = flag;
            txtChucVu.Enabled = flag;
        }
        private void XoaTextBox()
        {
            txtMatKhau.Text = "";
            txtTaiKhoan.Text = "";
            txtTen.Text = "";
            txtSdt.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtChucVu.Text = "";
        }

        private void Loadfull()
        {
            gridNhanVien.DataSource = bus_nv.select();
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
            txtTaiKhoan.DataBindings.Clear();
            txtTaiKhoan.DataBindings.Add("Text", gridNhanVien.DataSource, "TaiKhoan");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", gridNhanVien.DataSource, "TenNV");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", gridNhanVien.DataSource, "DiaChi");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", gridNhanVien.DataSource, "Email");
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", gridNhanVien.DataSource, "SDT");
            txtChucVu.DataBindings.Clear();
            txtChucVu.DataBindings.Add("Text", gridNhanVien.DataSource, "TenCV");
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", gridNhanVien.DataSource, "MatKhau");
        }
        private string CheckmaCV(string tenCV)
        {
            string maCV="";
            if (tenCV == "Nhân viên kho")
                maCV = "CV3";
            if (tenCV == "Nhân viên thu ngân")
                maCV = "CV4";
            if (tenCV == "Nhân viên lễ tân")
                maCV = "CV2";
            return maCV;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Hủy";
                EnabledTextBox(true);
                txtTaiKhoan.Enabled = false;
                txtChucVu.Enabled = false;
                IsSua = true;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                if (gridViewNV.RowCount > 0
              && txtTaiKhoan.Text != ""
              && IsThem == false
              && IsSua == false)
                {
                    if (bus_nv.XoaNV(txtTaiKhoan.Text))
                        Loadfull();
                    else
                        MessageBox.Show("loi");
                }
                else
                    MessageBox.Show("khong co de xoa");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsThem)
            {
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.TaiKhoan = txtTaiKhoan.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.TenNV = txtTen.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.SDT = txtSdt.Text;
                nv.Email = txtEmail.Text;                
                nv.MaCV=CheckmaCV(txtChucVu.Text);
                if (txtTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtTen.Text != "" && txtSdt.Text != "")
                {
                    if (bus_nv.ThemNV(nv))
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
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.TaiKhoan = txtTaiKhoan.Text;
                nv.MatKhau = txtMatKhau.Text;
                nv.TenNV = txtTen.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.SDT = txtSdt.Text;
                nv.Email = txtEmail.Text;
                nv.MaCV = CheckmaCV(txtChucVu.Text);
                if (txtTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtTen.Text != "" && txtSdt.Text != "")
                {
                    if (bus_nv.SuaNV(nv))
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

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            Loadfull();
        }

        
    }
}