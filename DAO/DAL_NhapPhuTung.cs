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
            string s = "select npt.*, ncc.tenNCC,nv.tenNV";
            s += " from NhapPhuTung npt, NhaCungCap ncc,NhanVien nv";
            s += " where npt.maNCC=ncc.maNCC and npt.taiKhoan=nv.taiKhoan";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_NhapPhuTung> list = new List<DTO_NhapPhuTung>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {                 
                    DTO_NhapPhuTung Npt = new DTO_NhapPhuTung();
                    DTO_NhanVien nv = new DTO_NhanVien();
                    DTO_NhaCungCap ncc = new DTO_NhaCungCap();
                    Npt.MaNhap = row["maNhap"].ToString();
                    nv.TenNV = row["tenNV"].ToString();
                    Npt.NhanVien = nv;
                    Npt.NgayNhap = DateTime.Parse(row["ngayNhap"].ToString());
                    ncc.TenNCC = row["tenNCC"].ToString();
                    Npt.NhaCungCap = ncc;
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
            string s = "INSERT INTO NhapPhuTung VALUES('" + Npt.MaNhap + "',N'" + Npt.NgayNhap + "',N'" + Npt.TienNhap + "','" + Npt.NhanVien.TaiKhoan + "','" + Npt.NhaCungCap.MaNCC + " ');";
            s += " UPDATE SoLuongID SET soLuongNPT = soLuongNPT + 1";
            return Connect.ExcuteNonQuery(s);

        }
    }
}
