using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_hd = new DAL_HoaDon();
        /*public List<DTO_PhieuSuaChua> select1()
        {
            return dal_psc.select1();
        }*/
        public int taoIDHD()
        {
            return dal_hd.slHD();
        }
        public bool ThemHD(DTO_HoaDon hd)
        {
            return dal_hd.ThemHD(hd);
        }
    }
}
