using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class DAL_HoaDon
    {
        public bool ThemHD(DTO_HoaDon hd)
        {
            string s = "INSERT INTO HoaDon VALUES('" + hd.MaHD + "','" + hd.NgayThanhToan + "',N'" + hd.HinhThucThanhToan + "','" + hd.TaiKhoan + "','" + hd.PhieuSuaChua.MaPhieu + "');";
            s += " UPDATE SoLuongID SET soLuongHD = soLuongHD + 1";
            s += " UPDATE PhieuSuaChua SET TrangThaiThanhToan = 'Đã thanh toán' WHERE MaPSC='" + hd.PhieuSuaChua.MaPhieu + "'";
            return Connect.ExcuteNonQuery(s);

        }
        public int slHD()
        {
            string s = "select * from SoLuongID";
            DataTable dt = Connect.ExcecuteQuery(s);
            int HD;
            DataRow row = dt.Rows[0];
            HD = (int)row["soLuongHD"];
            return HD;
        }
    }
}
