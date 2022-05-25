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
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {      
        public DangNhap()
        {
            InitializeComponent();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.TaiKhoan = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            BUS_NhanVien bus_nv = new BUS_NhanVien();
            bus_nv.CheckTaiKhoan(nv);
            if (nv.TenNV == null)
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông báo");
                
            }
            else {
                Home home = new Home(nv);               
                home.Show();
                this.Hide();
                home.FormClosed += new FormClosedEventHandler(home_FormClosed);
            }

        }
        void home_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtMatKhau.Text = "";
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }
    }
}