using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
   public class BUS_NhanVien
    {

        DAL_NhanVien dal_nv = new DAL_NhanVien();
        public List<DTO_NhanVien> select()
        {
            return dal_nv.select();
        }
        public DTO_NhanVien CheckTaiKhoan(DTO_NhanVien nv)
        {
            return dal_nv.checkTaiKhoan(nv);
        }
       /* public int taoIDNV()
        {
            return dal_nv.slNV();
        }*/
        public bool ThemNV(DTO_NhanVien nv)
        {
            return dal_nv.ThemNV(nv);
        }
        public bool SuaNV(DTO_NhanVien nv)
        {
            return dal_nv.SuaNV(nv);
        }
        public bool XoaNV(string TaiKhoan)
        {
            return dal_nv.XoaNV(TaiKhoan);
        }

    }
}
