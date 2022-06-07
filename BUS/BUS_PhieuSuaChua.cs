using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_PhieuSuaChua
    {
        DAL_PhieuSuaChua dal_psc = new DAL_PhieuSuaChua();
        /*public List<DTO_NhapPhuTung> select()
        {
            return dal_psc.select();
        }*/
        public int taoIDPSC()
        {
            return dal_psc.slPSC();
        }
        public bool ThemPSC(DTO_PhieuSuaChua psc)
        {
            return dal_psc.ThemPSC(psc);
        }
        public bool ThemCT_PSC(List<DTO_PT_DV> list)
        {
            return dal_psc.ThemCT_PSC(list);
        }
    }
}
