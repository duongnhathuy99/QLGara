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
    public partial class NhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        BUS_NhaCungCap bus_ncc = new BUS_NhaCungCap();
        private bool IsThem = false;
        private bool IsSua = false;
        public NhaCungCap()
        {
            InitializeComponent();
        }
        private void EnabledTextBox(bool flag)
        {
            //txtMaKH.Enabled = flag;
            txtTenNCC.Enabled = flag;
            txtSdt.Enabled = flag;
            txtDiaChi.Enabled = flag;
            
        }
        private void XoaTextBox()
        {
            txtMaNCC.Text = "NCC" + (bus_ncc.taoIDNCC() + 1).ToString();
            txtTenNCC.Text = "";
            txtSdt.Text = "";
            txtDiaChi.Text = "";         
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
            gridNhaCungCap.DataSource = bus_ncc.select();
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
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", gridNhaCungCap.DataSource, "MaNCC");
            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", gridNhaCungCap.DataSource, "TenNCC");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", gridNhaCungCap.DataSource, "DiaChi");         
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", gridNhaCungCap.DataSource, "SDT");
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                if (gridViewNCC.RowCount > 0
              && txtMaNCC.Text != ""
              && IsThem == false
              && IsSua == false)
                {
                    if (bus_ncc.XoaNCC(txtMaNCC.Text))
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsThem)
            {
                DTO_NhaCungCap ncc = new DTO_NhaCungCap();
                ncc.MaNCC = txtMaNCC.Text;
                ncc.TenNCC = txtTenNCC.Text;
                ncc.DiaChi = txtDiaChi.Text;
                ncc.SDT = txtSdt.Text;               
                if (txtMaNCC.Text != "" && txtTenNCC.Text != ""  && txtSdt.Text != "")
                {
                    if (bus_ncc.ThemNCC(ncc))
                    {
                        Loadfull();
                    }
                    else
                        MessageBox.Show("Lỗi thêm");
                }
                else
                    MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else if (IsSua)
            {
                DTO_NhaCungCap ncc = new DTO_NhaCungCap();
                ncc.MaNCC = txtMaNCC.Text;
                ncc.TenNCC = txtTenNCC.Text;
                ncc.DiaChi = txtDiaChi.Text;
                ncc.SDT = txtSdt.Text;
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtSdt.Text != "")
                {
                    if (bus_ncc.SuaNCC(ncc))
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

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            Loadfull();
        }
    }
}