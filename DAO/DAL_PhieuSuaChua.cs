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
        /*public List<DTO_NhapPhuTung> select()
        {
            string s = "select * from NhapPhuTung";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_NhapPhuTung> list = new List<DTO_NhapPhuTung>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DTO_NhapPhuTung Npt = new DTO_NhapPhuTung();
                    Npt.MaNhap = row["maNhap"].ToString();
                    Npt.TaiKhoan = row["taiKhoan"].ToString();
                    Npt.NgayNhap = DateTime.Parse(row["ngayNhap"].ToString());
                    Npt.MaNCC = row["maNCC"].ToString();
                    Npt.TienNhap = int.Parse(row["tienNhap"].ToString());
                    list.Add(Npt);
                }
            }
            return list;
        }*/

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
            string s = "INSERT INTO PhieuSuaChua VALUES('" + psc.MaPhieu + "','" + psc.NgayLapPhieu + "','" + psc.NgayBanGiao + "',N'" + psc.GhiChu + "','" + psc.TienSuaChua + "',N'" + psc.TrangThaiThanhToan + "','" + psc.TaiKhoan + "','" + psc.MaKH + " ');";
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
