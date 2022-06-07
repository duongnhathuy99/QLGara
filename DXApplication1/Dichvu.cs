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
    public partial class DichVu : DevExpress.XtraEditors.XtraForm
    {
        BUS_DichVu bus_dv = new BUS_DichVu();
        private bool IsThem = false;
        private bool IsSua = false;
        public DichVu()
        {
            InitializeComponent();
        }
        private void EnabledTextBox(bool flag)
        {
            txtTenDV.Enabled = flag;
            txtThuongHieu.Enabled = flag;
            txtTienDV.Enabled = flag;
            txtMoTa.Enabled = flag;          
        }
        private void XoaTextBox()
        {
            txtMaDV.Text = "DV" + (bus_dv.taoIDDV() + 1).ToString();
            txtTenDV.Text = "";
            txtThuongHieu.Text = "";
            txtMoTa.Text = "";
            txtTienDV.Text = "";
        }
        private void Loadfull()
        {
            gridDichVu.DataSource = bus_dv.select();
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
            txtMaDV.DataBindings.Clear();
            txtMaDV.DataBindings.Add("Text", gridDichVu.DataSource, "MaDV");
            txtTenDV.DataBindings.Clear();
            txtTenDV.DataBindings.Add("Text", gridDichVu.DataSource, "TenDV");
            txtThuongHieu.DataBindings.Clear();
            txtThuongHieu.DataBindings.Add("Text", gridDichVu.DataSource, "ThuongHieu");
            txtTienDV.DataBindings.Clear();
            txtTienDV.DataBindings.Add("Text", gridDichVu.DataSource, "TienDV");
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", gridDichVu.DataSource, "MoTa");          
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                if (gridView1.RowCount > 0
              && txtMaDV.Text != ""
              && IsThem == false
              && IsSua == false)
                {
                    if (bus_dv.XoaDV(txtMaDV.Text))
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
                DTO_DichVu dv = new DTO_DichVu();
                dv.MaDV = txtMaDV.Text;
                dv.TenDV = txtTenDV.Text;
                dv.ThuongHieu = txtThuongHieu.Text;
                dv.TienDV = int.Parse(txtTienDV.Text);
                dv.MoTa = txtMoTa.Text;             
                if (txtMaDV.Text != "" && txtTenDV.Text != "" )
                {
                    if (bus_dv.ThemDV(dv))
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
                DTO_DichVu dv = new DTO_DichVu();
                dv.MaDV = txtMaDV.Text;
                dv.TenDV = txtTenDV.Text;
                dv.ThuongHieu = txtThuongHieu.Text;
                dv.TienDV = int.Parse(txtTienDV.Text);
                dv.MoTa = txtMoTa.Text;
                if (txtMaDV.Text != "" && txtTenDV.Text != "")
                {
                    if (bus_dv.SuaDV(dv))
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

        private void DichVu_Load(object sender, EventArgs e)
        {
            Loadfull();
        }
    }
}