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
    public class DAL_KhachHang
    {
        public List<DTO_KhachHang> select()
        {
            string s = "select * from KhachHang";           
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_KhachHang> list = new List<DTO_KhachHang>();           
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DTO_KhachHang Kh = new DTO_KhachHang();
                    Kh.MaKH = row["maKH"].ToString();
                    Kh.TenKH = row["tenKH"].ToString();
                    Kh.SDT = row["sdt"].ToString();
                    Kh.DiaChi = row["diaChi"].ToString();
                    Kh.HieuXe = row["hieuXe"].ToString();
                    Kh.BienSo = row["bienSo"].ToString();
                    list.Add(Kh);
                }
            }
            return list;
        }

        public int slKH()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int KH;
            DataRow row = dt.Rows[0];
            KH = (int)row["soLuongKH"];
            return KH;
        }
        public bool ThemKH(DTO_KhachHang Kh)
        {
            string s = "INSERT INTO KhachHang VALUES('" + Kh.MaKH + "',N'" + Kh.TenKH + "','" + Kh.SDT + "',N'" + Kh.DiaChi + "','" + Kh.HieuXe + "','" + Kh.BienSo + " ');";
            s += "UPDATE SoLuongID SET soLuongKH = soLuongKH + 1";
            return Connect.ExcuteNonQuery(s);

        }
        public bool SuaKH(DTO_KhachHang kh)
        {
            string s = "UPDATE KhachHang";
            s += " SET tenKH=N'" + kh.TenKH + "',diaChi=N'" + kh.DiaChi + "',sdt='" + kh.SDT + "',hieuXe='" + kh.HieuXe + "',bienSo='" + kh.BienSo + "'";
            s += "WHERE maKH = '" + kh.MaKH + "'";
            return Connect.ExcuteNonQuery(s);
        }
        public bool XoaKH(string MaKH)
        {
            string s = "delete KhachHang where maKH ='" + MaKH + "'";
            return Connect.ExcuteNonQuery(s);
        }
    }
}
