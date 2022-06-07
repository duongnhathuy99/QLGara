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
    public partial class ChonDV_PT : DevExpress.XtraEditors.XtraForm
    {
        public delegate void GetListChon(List<DTO_PT_DV> list);
        public GetListChon MyListChon;
        BUS_DichVu bus_dv = new BUS_DichVu();
        BUS_PhuTung bus_pt = new BUS_PhuTung();
        List<DTO_PT_DV> listChon = new List<DTO_PT_DV>();
        List<DTO_PT_DV> kho = new List<DTO_PT_DV>();
        public ChonDV_PT()
        {
            InitializeComponent();
            foreach (var item in bus_pt.select())
            {
                DTO_PT_DV PtDv = new DTO_PT_DV();
                PtDv.MaPT_DV = item.MaPT;
                PtDv.TenPT_DV = item.TenPT;
                PtDv.ThuongHieu = item.ThuongHieu;
                PtDv.XuatXu = item.XuatXu;
                PtDv.TienPT_DV = item.GiaBan;
                PtDv.SoLuong = item.SoLuong;
                kho.Add(PtDv);
            }
            foreach (var item in bus_dv.select())
            {
                DTO_PT_DV PtDv = new DTO_PT_DV();
                PtDv.MaPT_DV = item.MaDV;
                PtDv.TenPT_DV = item.TenDV;
                PtDv.ThuongHieu = item.ThuongHieu;
                PtDv.MoTa = item.MoTa;
                PtDv.TienPT_DV = item.TienDV;
                PtDv.XuatXu = "Việt Nam";
                PtDv.SoLuong = 1 ;
                kho.Add(PtDv);
            }
        }
        private void Loadfull()
        {
                             
            gridKho.DataSource = null;
            gridKho.DataSource = kho;
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", gridKho.DataSource, "TenPT_DV");
        }

        private void ChonDV_PT_Load(object sender, EventArgs e)
        {
            Loadfull();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtSoLuong.Text) <= int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SoLuong").ToString())
                || gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPT_DV").ToString().StartsWith("DV"))
            {
                DTO_PT_DV PtDv = new DTO_PT_DV();
                PtDv.MaPT_DV = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaPT_DV").ToString();
                PtDv.TenPT_DV = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TenPT_DV").ToString();
                PtDv.XuatXu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "XuatXu").ToString();
                PtDv.ThuongHieu = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ThuongHieu").ToString();
                PtDv.TienPT_DV = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TienPT_DV").ToString());               
                if (PtDv.MaPT_DV.StartsWith("DV"))
                    PtDv.SoLuong = 1;
                else
                {
                    PtDv.SoLuong = int.Parse(txtSoLuong.Text);
                    for (int i = 0; i < kho.Count(); i++)
                        if (kho[i].MaPT_DV == PtDv.MaPT_DV)                          
                            kho[i].SoLuong -= PtDv.SoLuong;                                                 
                }
                PtDv.ThanhTien = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TienPT_DV").ToString()) * PtDv.SoLuong;
                bool b = false;
                foreach (var item in listChon)
                    if (item.MaPT_DV == PtDv.MaPT_DV)
                        b = true;
                if (!b)
                {
                    listChon.Add(PtDv);
                }
                gridChon.DataSource = null;
                gridChon.DataSource = listChon;
                Loadfull();
            }
            else
                MessageBox.Show("Số lượng phụ tùng chọn phải bé hơn hoặc bằng số lượng tồn");
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            if (listChon != null)
            {
                for (int i = 0; i < listChon.Count; i++)
                    if (listChon[i].MaPT_DV == gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "MaPT_DV").ToString())
                    {                     
                        for (int j = 0; j < kho.Count(); j++)
                            if (kho[j].MaPT_DV == listChon[i].MaPT_DV) 
                                kho[j].SoLuong += listChon[i].SoLuong;
                        listChon.RemoveAt(i);
                    }
                gridChon.DataSource = null;
                gridChon.DataSource = listChon;
                Loadfull();
            }
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            MyListChon(listChon);
            this.Close();
        }
    }
}