using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
   public class BUS_KhachHang
    {
        DAL_KhachHang dal_kh = new DAL_KhachHang();
        public List<DTO_KhachHang> select()
        {
            return dal_kh.select();
        }

        public bool ThemKH(DTO_KhachHang kh)
        {
            return dal_kh.ThemKH(kh);
        }
        public bool SuaKH(DTO_KhachHang kh)
        {
            return dal_kh.SuaKH(kh);
        }
        public bool XoaKH(string MaKH)
        {
            return dal_kh.XoaKH(MaKH);
        }
    }
}
