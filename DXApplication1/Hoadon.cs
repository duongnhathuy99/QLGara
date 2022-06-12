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
    public partial class HoaDon : DevExpress.XtraEditors.XtraForm
    {
        BUS_HoaDon bus_hd = new BUS_HoaDon();
        BUS_NhapPhuTung bus_npt = new BUS_NhapPhuTung();
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            loadfull();
        }
        public void loadfull()
        {
            gridHoaDon.DataSource = bus_hd.select();
            gridNhapPhuTung.DataSource = bus_npt.select();
        }
    }
}