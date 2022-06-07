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
    public partial class Kho : DevExpress.XtraEditors.XtraForm
    {
        BUS_PhuTung bus_pt = new BUS_PhuTung();
        private bool IsThem = false;
        private bool IsSua = false;
        public Kho()
        {
            InitializeComponent();
        }
        private void EnabledTextBox(bool flag)
        {
            txtTenPT.Enabled = flag;
            txtThuongHieu.Enabled = flag;
            txtGiaBan.Enabled = flag;
            txtXuatXu.Enabled = flag;
        }
        private void Loadfull()
        {
            gridKho.DataSource = bus_pt.select();
            EnabledTextBox(false);
            btnSua.Enabled = true;
            IsThem = IsSua = false;
            btnCapNhat.Enabled = false;
            btnSua.Text = "Sửa";
            Bind();
        }
        private void Bind()
        {
            txtMaPT.DataBindings.Clear();
            txtMaPT.DataBindings.Add("Text", gridKho.DataSource, "MaPT");
            txtTenPT.DataBindings.Clear();
            txtTenPT.DataBindings.Add("Text", gridKho.DataSource, "TenPT");
            txtXuatXu.DataBindings.Clear();
            txtXuatXu.DataBindings.Add("Text", gridKho.DataSource, "XuatXu");
            txtThuongHieu.DataBindings.Clear();
            txtThuongHieu.DataBindings.Add("Text", gridKho.DataSource, "ThuongHieu");
            txtGiaNhap.DataBindings.Clear();
            txtGiaNhap.DataBindings.Add("Text", gridKho.DataSource, "GiaNhap");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", gridKho.DataSource, "GiaBan");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", gridKho.DataSource, "SoLuong");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Hủy";
                EnabledTextBox(true);
                IsSua = true;         
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnSua.Text = "Sửa";               
                btnCapNhat.Enabled = false;
                Bind();
                EnabledTextBox(false);
                IsSua = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsSua)
            {
                DTO_PhuTung pt = new DTO_PhuTung();
                pt.MaPT = txtMaPT.Text;
                pt.TenPT = txtTenPT.Text;
                pt.XuatXu = txtXuatXu.Text;
                pt.ThuongHieu = txtThuongHieu.Text;
                pt.GiaBan = int.Parse(txtGiaBan.Text);                             
                if (bus_pt.SuaPT(pt))
                {
                   Loadfull();
                }                               
                else
                    MessageBox.Show("Lỗi sửa");
            }
        }

        private void Kho_Load(object sender, EventArgs e)
        {
            Loadfull();
        }

        private void btnNhapPT_Click(object sender, EventArgs e)
        {
            Nhapphutung form = new Nhapphutung();
            form.Show();
            form.FormClosed += new FormClosedEventHandler(NhapPT_FormClosed);
        }
        void NhapPT_FormClosed(object sender, FormClosedEventArgs e)
        {
            Loadfull();
        }
    }
}