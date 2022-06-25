using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using DTO;
using System.Collections.Generic;
namespace DXApplication1
{
    public partial class rptPhieuSuaChua : DevExpress.XtraReports.UI.XtraReport
    {
        List<DTO_PhieuSuaChua> list = new List<DTO_PhieuSuaChua>();
        public rptPhieuSuaChua(DTO_PhieuSuaChua psc, List<DTO_PT_DV> list)
        {
            InitializeComponent();
            //xrTableCell7.Text = psc.NgayBanGiao.ToString();
            // xrTableCell6.Text = psc.NgayLapPhieu.ToString();
            //xrTableCell4 = psc.KhachHang.TenKH;
            // xrTableCell2.Text = psc.KhachHang.HieuXe;
            xrTableCell13.Text = psc.MaPhieu;
            xrTableCell14.Text = psc.NhanVien.TenNV;
            xrTableCell17.Text = psc.NgayLapPhieu.ToString();
            xrTableCell15.Text = psc.TienSuaChua.ToString();
            xrTableCell16.Text = psc.NgayBanGiao.ToString();
            xrTableCell21.Text = psc.GhiChu;
            xrTableCell18.Text = psc.KhachHang.MaKH;
            xrTableCell19.Text = psc.KhachHang.TenKH;
            xrTableCell23.Text = psc.KhachHang.SDT;
            xrTableCell20.Text = psc.KhachHang.HieuXe;
            xrTableCell26.Text = psc.KhachHang.BienSo;
            objectDataSource4.DataSource = list;
        }
    }
}
