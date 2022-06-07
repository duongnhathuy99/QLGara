using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_PhuTung
    {
        public List<DTO_PhuTung> select()
        {
            string s = "select * from PhuTung";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_PhuTung> list = new List<DTO_PhuTung>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DTO_PhuTung Pt = new DTO_PhuTung();
                    Pt.MaPT = row["maPT"].ToString();
                    Pt.TenPT = row["tenPT"].ToString();
                    Pt.XuatXu = row["xuatXu"].ToString();
                    Pt.ThuongHieu = row["thuongHieu"].ToString();
                    Pt.GiaBan = int.Parse(row["giaBan"].ToString());
                    Pt.GiaNhap = int.Parse(row["giaNhap"].ToString());
                    Pt.SoLuong = (int)row["soLuong"];
                    list.Add(Pt);
                }
            }
            return list;
        }

        public int slPT()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int PT;
            DataRow row = dt.Rows[0];
            PT = (int)row["soLuongPT"];
            return PT;
        }
        public bool ThemPT(DTO_PhuTung Pt)
        {
            string s = "INSERT INTO PhuTung VALUES('" + Pt.MaPT + "',N'" + Pt.TenPT + "',N'" + Pt.XuatXu + "','" + Pt.ThuongHieu + "','" + Pt.GiaNhap + "','" + Pt.GiaBan + "','" + Pt.SoLuong + " ');";
            s += " UPDATE SoLuongID SET soLuongPT = soLuongPT + 1";
            return Connect.ExcuteNonQuery(s);

        }
        public bool SuaPT(DTO_PhuTung Pt)
        {
            string s = "UPDATE PhuTung";
            s += " SET tenPT=N'" + Pt.TenPT + "',xuatXu=N'" + Pt.XuatXu + "',thuongHieu='" + Pt.ThuongHieu + "',giaBan='" + Pt.GiaBan + "'";
            s += " WHERE maPT = '" + Pt.MaPT + "'";
            return Connect.ExcuteNonQuery(s);
        }
        /*public bool XoaKH(string MaKH)
        {
            string s = "delete PhuTung where maKH ='" + MaKH + "'";
            return Connect.ExcuteNonQuery(s);
        }*/
    }
}
