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
    public partial class Nhapphutung : DevExpress.XtraEditors.XtraForm
    {
        DTO_NhapPhuTung npt = new DTO_NhapPhuTung();
        DTO_NhanVien nv = new DTO_NhanVien();
        BUS_CTNhapPT bus_ct_npt = new BUS_CTNhapPT();
        BUS_NhapPhuTung bus_npt = new BUS_NhapPhuTung();
        BUS_PhuTung bus_pt = new BUS_PhuTung();
        BUS_NhaCungCap bus_ncc = new BUS_NhaCungCap();
        private bool IsThem = false;
        List<DTO_PhuTung> listPT = new List<DTO_PhuTung>();       
        public Nhapphutung(DTO_NhanVien Nv)
        {
            InitializeComponent();
            nv = Nv;
            txtTenNV.Text =nv.TenNV;
        }

        private void Nhapphutung_Load(object sender, EventArgs e)
        {
            npt.TienNhap = 0;
            txtMaNhap.Text= "NPT" + (bus_npt.taoIDNPT() + 1).ToString();
            foreach (var item in bus_ncc.select())
                 cbNhaCungCap.Properties.Items.Add(item.TenNCC);

            Loadfull();
        }
        private void EnabledTextBox(bool flag)
        {
            txtTenPT.Enabled = flag;
            txtThuongHieu.Enabled = flag;
            txtGiaBan.Enabled = flag;
            txtGiaNhap.Enabled = flag;
            txtXuatXu.Enabled = flag;
            txtSoLuongNhap.Enabled = !flag;
        }
        private void XoaTextBox()
        {
            txtMaPT.Text = "PT" + (bus_pt.taoIDPT() + 1).ToString();
            txtTenPT.Text = "";
            txtXuatXu.Text = "";
            txtThuongHieu.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
        }
        private void Loadfull()
        {           
            dtNgayNhap.DateTime = DateTime.Now;
            gridKho.DataSource = bus_pt.select();
            EnabledTextBox(false);
            btnThem.Enabled = true;
            btnChon.Enabled = btnBoChon.Enabled = btnNhapPT.Enabled = true;
            IsThem =  false;
            btnCapNhat.Enabled = false;
            btnThem.Text = "Thêm";
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                EnabledTextBox(true);
                XoaTextBox();
                IsThem = true;
                btnChon.Enabled = false;
                btnBoChon.Enabled = false;
                btnNhapPT.Enabled = false;
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnThem.Text = "Thêm";
                btnChon.Enabled = true;
                btnBoChon.Enabled = true;
                btnNhapPT.Enabled = true;
                btnCapNhat.Enabled = false;
                Bind();
                EnabledTextBox(false);
                IsThem = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsThem)
            {
                DTO_PhuTung pt = new DTO_PhuTung();
                pt.MaPT = txtMaPT.Text;
                pt.TenPT = txtTenPT.Text;
                pt.XuatXu = txtXuatXu.Text;
                pt.ThuongHieu = txtThuongHieu.Text;
                pt.GiaBan = int.Parse(txtGiaBan.Text);
                pt.GiaNhap = int.Parse(txtGiaNhap.Text);
                pt.SoLuong = 0;
                if (txtTenPT.Text == "" || txtThuongHieu.Text == "" || txtXuatXu.Text == "" || txtGiaNhap.Text == "")
                {
                    MessageBox.Show("Nhập đầy đủ thông tin");

                }
                else if( pt.GiaNhap > pt.GiaBan)
                    MessageBox.Show("Giá bán phải lớn hơn giá nhập");
                else               
                    if (bus_pt.ThemPT(pt))
                    {
                        Loadfull();
                    }
                    else
                        MessageBox.Show("Lỗi cập nhật");          
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {

            DTO_PhuTung pt = new DTO_PhuTung();
            pt.MaPT = txtMaPT.Text;
            pt.TenPT = txtTenPT.Text;
            pt.XuatXu = txtXuatXu.Text;
            pt.ThuongHieu = txtThuongHieu.Text;
            pt.GiaBan = int.Parse(txtGiaBan.Text);
            pt.GiaNhap = int.Parse(txtGiaNhap.Text);            
            pt.SoLuongNhap = int.Parse(txtSoLuongNhap.Text);
            pt.ThanhTien = int.Parse(txtGiaNhap.Text) * int.Parse(txtSoLuongNhap.Text);
            bool b = false;
            foreach (var item in listPT) 
                if(item.MaPT == pt.MaPT)
                    b = true;
            if (!b)
            {
                listPT.Add(pt);
                npt.TienNhap += pt.ThanhTien;
                txtTienNhap.Text = npt.TienNhap.ToString();
            }
            gridNhapPT.DataSource = null;
            gridNhapPT.DataSource = listPT;

           
        }       

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            txtTenNV.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaPT").ToString();
            for (int i = 0; i < listPT.Count; i++)
                if (listPT[i].MaPT == gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaPT").ToString())
                    listPT.RemoveAt(i);
            gridNhapPT.DataSource = null;
            gridNhapPT.DataSource = listPT;
        }

        private void btnNhapPT_Click(object sender, EventArgs e)
        {
            if (listPT != null && cbNhaCungCap.Text!="")
            {
                DTO_NhapPhuTung npt = new DTO_NhapPhuTung();              
                DTO_NhaCungCap ncc = new DTO_NhaCungCap();
                npt.MaNhap = txtMaNhap.Text;
                npt.NgayNhap = DateTime.Parse(dtNgayNhap.Text);
                ncc.MaNCC = bus_ncc.getMaNCC(cbNhaCungCap.Text);
                npt.NhaCungCap = ncc;
                npt.NhanVien = nv;
                npt.TienNhap = int.Parse(txtTienNhap.Text);
                List<DTO_CTNhap_PhuTung> ctn = new List<DTO_CTNhap_PhuTung>();
                foreach (var item in listPT)
                {
                    DTO_CTNhap_PhuTung ct = new DTO_CTNhap_PhuTung();
                    ct.MaPT = item.MaPT;
                    ct.SoLuongNhap = item.SoLuongNhap;
                    ct.MaNhap = txtMaNhap.Text;                 
                    ctn.Add(ct);
                }
                if ( bus_npt.ThemNPT(npt) && bus_ct_npt.ThemCT_NPT(ctn))
                {
                    MessageBox.Show("Nhập kho thành công");
                    this.Close();
                }
            }
            else
                MessageBox.Show("Thiếu thông tin cần nhập");
        }
    }
}