using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;

namespace DXApplication1
{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
         DTO_NhanVien nv = new DTO_NhanVien();
        public Home(DTO_NhanVien Nv)
        {
            InitializeComponent();
            lbTen.Text += Nv.TenNV;
            nv = Nv;
        }
        public void OpenChildForm(Form f)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.Name == f.Name)
                {      
                    frm.Activate();
                    return;
                }
            }                 
            f.MdiParent = this;
            f.Show();         
        }
        public void OpenPhieuSuaChua(DTO_KhachHang kh)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.Name == "Phieusuachua")
                {
                    frm.Dispose();                 
                }
            }
            Phieusuachua f = new Phieusuachua();
            f.laykh(kh);
            OpenChildForm(f);            
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHang f = new KhachHang();
            OpenChildForm(f);
            f.truyenKH = new KhachHang.TruyenKH(OpenPhieuSuaChua);         
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Phieusuachua f = new Phieusuachua();       
            OpenChildForm(f);           
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kho f = new Kho();

            OpenChildForm(f);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DichVu f = new DichVu();

            OpenChildForm(f);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Nhanvien f = new Nhanvien();

            OpenChildForm(f);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThanhToan f = new ThanhToan();

            OpenChildForm(f);
        }    

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {                   
            this.Close();           
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhaCungCap f = new NhaCungCap();

            OpenChildForm(f);          
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HoaDon f = new HoaDon();

            OpenChildForm(f);          
        }
    }
}
