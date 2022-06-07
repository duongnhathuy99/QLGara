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
    public partial class Phieusuachua : DevExpress.XtraEditors.XtraForm
    {
        List<DTO_PT_DV> listChon = new List<DTO_PT_DV>();
        BUS_PhieuSuaChua bus_psc = new BUS_PhieuSuaChua();
        public Phieusuachua()
        {
            InitializeComponent();


        }
        public void GetListChon(List<DTO_PT_DV> list)
        {
            listChon = list;
            Loadfull();
        }
        public DTO_KhachHang laykh(DTO_KhachHang kh)
        {
            txtTenKH.Text = kh.TenKH;
            txtMaKH.Text = kh.MaKH;
            txtBienSo.Text = kh.BienSo;
            txtDiaChi.Text = kh.DiaChi;
            txtHieuXe.Text = kh.HieuXe;
            txtSdt.Text = kh.SDT;
            return kh;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ChonDV_PT form = new ChonDV_PT();
            form.MyListChon = new ChonDV_PT.GetListChon(GetListChon);
            form.ShowDialog();
        }
        private void Loadfull()
        {

            gridChon.DataSource = null;
            gridChon.DataSource = listChon;
            int tienDV = 0; 
            int tienPT = 0;
            if (listChon != null)
                foreach (var item in listChon)
                {
                    if (item.MaPT_DV.StartsWith("DV"))
                        tienDV += item.ThanhTien;
                    else
                        tienPT += item.ThanhTien;

                }           
            txtTienDV.Text = tienDV.ToString();
            txtTienPT.Text = tienPT.ToString();
            txtTongTien.Text = (tienDV + tienPT).ToString();
        }

        private void Phieusuachua_Load(object sender, EventArgs e)
        {
            dateLapPhieu.DateTime = DateTime.Now;
            txtMaPhieu.Text= "PSC" + (bus_psc.taoIDPSC() + 1).ToString();
            Loadfull();
        }

        private void dateBanGiao_EditValueChanged(object sender, EventArgs e)
        {
            if (dateBanGiao.DateTime < dateLapPhieu.DateTime)
            {
                dateBanGiao.DateTime = dateLapPhieu.DateTime.AddDays(1);
                MessageBox.Show("Ngày bàn giao phải lớn hơn ngày lập phiếu");
            }
        }
        private void XoaTextBox()
        {
            txtMaKH.Text = "";
            txtDiaChi.Text = "";
            txtHieuXe.Text = "";
            txtBienSo.Text = "";
            txtMaPhieu.Text = "";
            txtTienPT.Text = "";
            txtTienDV.Text = "";
            txtTongTien.Text = "";
            txtTenKH.Text = "";
            txtGhiChu.Text = "";
            txtSdt.Text = "";
        }
        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtTongTien.Text) >0 && txtTenKH.Text!="" && dateBanGiao.DateTime > dateLapPhieu.DateTime)
            {
                DTO_PhieuSuaChua psc = new DTO_PhieuSuaChua();
                psc.MaKH = txtMaKH.Text;
                psc.MaPhieu = txtMaPhieu.Text;
                psc.NgayBanGiao = DateTime.Parse(dateBanGiao.Text);
                psc.NgayLapPhieu = DateTime.Parse(dateLapPhieu.Text);
                psc.TaiKhoan = "admin";
                psc.TienSuaChua = int.Parse(txtTongTien.Text);
                psc.TrangThaiThanhToan = "Chưa thanh Toán";
                psc.GhiChu = txtGhiChu.Text;
                for (int i = 0; i < listChon.Count; i++)
                {
                    listChon[i].MaPhieu = psc.MaPhieu;
                }
                if (bus_psc.ThemPSC(psc) && bus_psc.ThemCT_PSC(listChon))
                {               
                        listChon = null;
                        MessageBox.Show("Lập phiếu thành công");
                        XoaTextBox();
                        Loadfull();                   
                }  
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
        }
    }
}