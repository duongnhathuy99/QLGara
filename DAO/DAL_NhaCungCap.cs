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
    public class DAL_NhaCungCap
    {
        public List<DTO_NhaCungCap> select()
        {
            string s = "select * from NhaCungCap";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_NhaCungCap> list = new List<DTO_NhaCungCap>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DTO_NhaCungCap Ncc = new DTO_NhaCungCap();
                    Ncc.MaNCC = row["maNCC"].ToString();
                    Ncc.TenNCC = row["tenNCC"].ToString();
                    Ncc.SDT = row["sdt"].ToString();
                    Ncc.DiaChi = row["diaChi"].ToString();                 
                    list.Add(Ncc);
                }
            }
            return list;
        }

        public int slNCC()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int NCC;
            DataRow row = dt.Rows[0];
            NCC = (int)row["soLuongNCC"];
            return NCC;
        }
        public bool ThemNCC(DTO_NhaCungCap Ncc)
        {
            string s = "INSERT INTO NhaCungCap VALUES('" + Ncc.MaNCC + "',N'" + Ncc.TenNCC + "','" + Ncc.SDT + "',N'" + Ncc.DiaChi +  " ');";
            s += "UPDATE SoLuongID SET soLuongNCC = soLuongNCC + 1";
            return Connect.ExcuteNonQuery(s);

        }
        public bool SuaNCC(DTO_NhaCungCap Ncc)
        {
            string s = "UPDATE NhaCungCap";
            s += " SET tenNCC=N'" + Ncc.TenNCC + "',diaChi=N'" + Ncc.DiaChi + "',sdt='" + Ncc.SDT +  "'";
            s += "WHERE maNCC = '" + Ncc.MaNCC + "'";
            return Connect.ExcuteNonQuery(s);
        }
        public bool XoaNCC(string MaNCC)
        {
            string s = "delete NhaCungCap where maNCC ='" + MaNCC + "'";
            return Connect.ExcuteNonQuery(s);
        }
    }
}
