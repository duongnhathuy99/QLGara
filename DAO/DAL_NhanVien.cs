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
            string s = "select * from NhanVien";
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
                    Nv.MaCV = row["maCV"].ToString();
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
    }
}
