using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_NhapPhuTung
    {
        public List<DTO_NhapPhuTung> select()
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
        }

        public int slNPT()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int NPT;
            DataRow row = dt.Rows[0];
            NPT = (int)row["soLuongNPT"];
            return NPT;
        }
        public bool ThemNPT(DTO_NhapPhuTung Npt)
        {
            string s = "INSERT INTO NhapPhuTung VALUES('" + Npt.MaNhap + "',N'" + Npt.NgayNhap + "',N'" + Npt.TienNhap + "','" + Npt.TaiKhoan + "','" + Npt.MaNCC + " ');";
            s += " UPDATE SoLuongID SET soLuongNPT = soLuongNPT + 1";
            return Connect.ExcuteNonQuery(s);

        }
    }
}
