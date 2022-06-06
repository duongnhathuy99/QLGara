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
    public class DAL_NhanVien
    {
        public List<DTO_NhanVien> select()
        {
            string s = "select nv.taiKhoan, nv.tenNV, nv.sdt, nv.diaChi, nv.email, nv.matKhau, cv.TenCV";
            s += " from NhanVien nv,ChucVu cv";
            s += " where nv.maCV = cv.maCV";
            //  string s = "select * from NhanVien";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_NhanVien> list = new List<DTO_NhanVien>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DTO_NhanVien Nv = new DTO_NhanVien();
                    Nv.TaiKhoan = row["taiKhoan"].ToString();
                    Nv.TenNV = row["tenNV"].ToString();
                    Nv.SDT = row["sdt"].ToString();
                    Nv.DiaChi = row["diaChi"].ToString();
                    Nv.MatKhau = row["matKhau"].ToString();
                    Nv.TenCV = row["TenCV"].ToString();
                    Nv.Email = row["email"].ToString();
                    list.Add(Nv);
                }
            }
            return list;
        }
        public DTO_NhanVien checkTaiKhoan(DTO_NhanVien nv)
        {
            string s = "select * from NhanVien";
            DataTable dt = Connect.ExcecuteQuery(s);           
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["taiKhoan"].ToString() == nv.TaiKhoan && row["matKhau"].ToString() == nv.MatKhau) {                      
                        nv.TaiKhoan = row["taiKhoan"].ToString();
                        nv.TenNV = row["tenNV"].ToString();
                        nv.SDT = row["sdt"].ToString();
                        nv.DiaChi = row["diaChi"].ToString();
                        nv.MatKhau = row["matKhau"].ToString();
                        nv.MaCV = row["maCV"].ToString();
                        nv.Email = row["email"].ToString();
                        return nv;
                    }
                }
            }
            return nv;
        }
        /*public int slNV()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int NV;
            DataRow row = dt.Rows[0];
            NV = (int)row["soLuongNV"];
            return NV;
        }*/
        public bool ThemNV(DTO_NhanVien Nv)
        {
            string s = "INSERT INTO NhanVien VALUES('" + Nv.TaiKhoan + "','" + Nv.MatKhau + "',N'" + Nv.TenNV + "','" + Nv.SDT + "',N'" + Nv.DiaChi + "','" + Nv.Email + "','" + Nv.MaCV + " ');";
           // s += "UPDATE SoLuongID SET soLuongNV = soLuongNV + 1";
            return Connect.ExcuteNonQuery(s);

        }
        public bool SuaNV(DTO_NhanVien Nv)
        {
            string s = "UPDATE NhanVien";
            s += " SET matKhau='" + Nv.MatKhau + "',tenNV=N'" + Nv.TenNV + "',sdt='" + Nv.SDT + "',diaChi=N'" + Nv.DiaChi + "',email='" + Nv.Email + "',maCV='" + Nv.MaCV + "'";
            s += " WHERE taiKhoan = '" + Nv.TaiKhoan + "'";
            return Connect.ExcuteNonQuery(s);
        }
        public bool XoaNV(string TaiKhoan)
        {
            string s = "delete NhanVien where TaiKhoan ='" + TaiKhoan + "'";
            return Connect.ExcuteNonQuery(s);
        }
    }
}
