using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class DAL_CTNhap_PhuTung
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

        
        public bool ThemCT_NPT(List<DTO_CTNhap_PhuTung> ct_npt)
        {
            string s ="";
            foreach (var item in ct_npt)
            {
                s += " INSERT INTO CT_Nhap VALUES('" + item.SoLuongNhap + "','" + item.MaPT + "','" + item.MaNhap + " '); ";
                s += " UPDATE PhuTung SET soLuong+=" + item.SoLuongNhap + " WHERE maPT = '" + item.MaPT + "'";
            }
            return Connect.ExcuteNonQuery(s);

        }
    }
}
