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

        public List<DTO_HoaDon> select()
        {
            string s = "select h.MaHD,h.ngayThanhToan,k.tenKH,k.hieuXe,k.bienSo,h.hinhThucThanhToan,p.tienSuaChua,n.tenNV ";
            s += " from HoaDon h,PhieuSuaChua p ,KhachHang k, NhanVien n";
            s += " where h.maPSC=p.MaPSC and p.MaKH=k.maKH and h.taiKhoan=n.taiKhoan";
            DataTable dt = Connect.ExcecuteQuery(s);
            List<DTO_HoaDon> list = new List<DTO_HoaDon>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DTO_HoaDon hd = new DTO_HoaDon();
                    DTO_PhieuSuaChua psc = new DTO_PhieuSuaChua();
                    DTO_KhachHang kh = new DTO_KhachHang();
                    DTO_NhanVien nv = new DTO_NhanVien();
                    hd.MaHD = row["maHD"].ToString();
                    hd.NgayThanhToan = DateTime.Parse(row["ngayThanhToan"].ToString());
                    hd.HinhThucThanhToan = row["hinhThucThanhToan"].ToString();
                    kh.TenKH = row["tenKH"].ToString();
                    kh.HieuXe = row["hieuXe"].ToString();
                    kh.BienSo = row["bienSo"].ToString();
                    psc.KhachHang = kh;
                    psc.TienSuaChua = int.Parse(row["tienSuaChua"].ToString());
                    hd.PhieuSuaChua = psc;
                    nv.TenNV= row["tenNV"].ToString();
                    hd.NhanVien = nv;
                    list.Add(hd);
                }
            }
            return list;
        }
        public bool ThemHD(DTO_HoaDon hd)
        {
            string s = "INSERT INTO HoaDon VALUES('" + hd.MaHD + "','" + hd.NgayThanhToan + "',N'" + hd.HinhThucThanhToan + "','" + hd.NhanVien.TaiKhoan + "','" + hd.PhieuSuaChua.MaPhieu + "');";
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
