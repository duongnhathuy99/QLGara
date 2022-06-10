using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
   public class DAL_PhieuSuaChua
    {
        public List<DTO_PhieuSuaChua> select1()
        {
            string s = "select p.MaPSC,k.tenKH,k.sdt,k.bienSo,k.hieuXe,p.tienSuaChua,p.TrangThaiThanhToan";
            s += " from PhieuSuaChua p, KhachHang k";
            s += " where p.MaKH=k.maKH and p.TrangThaiThanhToan=N'Chưa Thanh Toán'";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_PhieuSuaChua> list = new List<DTO_PhieuSuaChua>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {                   
                    DTO_PhieuSuaChua psc = new DTO_PhieuSuaChua();
                    DTO_KhachHang kh = new DTO_KhachHang();
                    psc.MaPhieu = row["MaPSC"].ToString();
                    psc.TienSuaChua = int.Parse(row["tienSuaChua"].ToString());                    
                    kh.TenKH = row["tenKH"].ToString();
                    kh.SDT = row["sdt"].ToString();
                    kh.HieuXe = row["hieuXe"].ToString();
                    kh.BienSo = row["bienSo"].ToString();
                    psc.KhachHang = kh;
                    list.Add(psc);
                }
            }
            return list;
        }

        public int slPSC()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int PSC;
            DataRow row = dt.Rows[0];
            PSC = (int)row["soLuongPSC"];
            return PSC;
        }
        public bool ThemPSC(DTO_PhieuSuaChua psc)
        {
            string s = "INSERT INTO PhieuSuaChua VALUES('" + psc.MaPhieu + "','" + psc.NgayLapPhieu + "','" + psc.NgayBanGiao + "',N'" + psc.GhiChu + "','" + psc.TienSuaChua + "',N'" + psc.TrangThaiThanhToan + "','" + psc.TaiKhoan + "','" + psc.KhachHang.MaKH + "');";
            s += " UPDATE SoLuongID SET soLuongPSC = soLuongPSC + 1";
            return Connect.ExcuteNonQuery(s);

        }
        public bool ThemCT_PSC(List<DTO_PT_DV> list)
        {
            string s = "";
            foreach (var item in list)
            {
                if (item.MaPT_DV.StartsWith("DV"))
                    s += " INSERT INTO CTDV_PhieuSuaChua VALUES('" + item.MaPT_DV + "','" + item.MaPhieu + " '); ";

                else
                {
                    s += " INSERT INTO CTPT_PhieuSuaChua VALUES('" + item.SoLuong + "','" + item.MaPT_DV + "','" + item.MaPhieu + " '); ";
                    s += " UPDATE PhuTung SET soLuong-=" + item.SoLuong + " WHERE maPT = '" + item.MaPT_DV + "' ";
                }
            }
            return Connect.ExcuteNonQuery(s);
        }
    }
}
