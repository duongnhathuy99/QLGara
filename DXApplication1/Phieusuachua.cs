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

namespace DXApplication1
{
    public partial class Phieusuachua : DevExpress.XtraEditors.XtraForm
    {      

        public Phieusuachua()
        {
            InitializeComponent();
            
            
        }
        public DTO_KhachHang laykh(DTO_KhachHang kh)
        {
            textEdit12.Text = kh.TenKH;
            textEdit1.Text = kh.MaKH;
            return kh;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ChonDV_PT form = new ChonDV_PT();          
            form.ShowDialog();
        }
    }
}