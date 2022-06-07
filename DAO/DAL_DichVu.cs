using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
   public class DAL_DichVu
    {
        public List<DTO_DichVu> select()
        {
            string s = "select * from DichVu";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_DichVu> list = new List<DTO_DichVu>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DTO_DichVu dv = new DTO_DichVu();
                    dv.MaDV = row["maDV"].ToString();
                    dv.TenDV = row["tenDV"].ToString();
                    dv.ThuongHieu = row["thuongHieu"].ToString();
                    dv.TienDV = int.Parse(row["tienDV"].ToString());
                    dv.MoTa = row["moTa"].ToString();                   
                    list.Add(dv);
                }
            }
            return list;
        }

        public int slDV()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int KH;
            DataRow row = dt.Rows[0];
            KH = (int)row["soLuongDV"];
            return KH;
        }
        public bool ThemDV(DTO_DichVu dv)
        {
            string s = "INSERT INTO DichVu VALUES('" + dv.MaDV + "',N'" + dv.TenDV + "','" + dv.ThuongHieu + "','" + dv.TienDV + "','" + dv.MoTa + " ');";
            s += "UPDATE SoLuongID SET soLuongDV = soLuongDV + 1";
            return Connect.ExcuteNonQuery(s);

        }
        public bool SuaDV(DTO_DichVu dv)
        {
            string s = "UPDATE DichVu";
            s += " SET tenDV=N'" + dv.TenDV + "',thuongHieu='" + dv.ThuongHieu + "',tienDV='" + dv.TienDV + "',moTa='" + dv.MoTa + "'";
            s += "WHERE maDV = '" + dv.MaDV + "'";
            return Connect.ExcuteNonQuery(s);
        }
        public bool XoaDV(string MaDV)
        {
            string s = "delete DichVu where maDV ='" + MaDV + "'";
            return Connect.ExcuteNonQuery(s);
        }
    }
}
