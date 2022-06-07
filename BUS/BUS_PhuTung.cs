using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_PhuTung
    {
        DAL_PhuTung dal_pt = new DAL_PhuTung();
        public List<DTO_PhuTung> select()
        {
            return dal_pt.select();
        }
        public int taoIDPT()
        {
            return dal_pt.slPT();
        }
        public bool ThemPT(DTO_PhuTung pt)
        {
            return dal_pt.ThemPT(pt);
        }
        public bool SuaPT(DTO_PhuTung pt)
        {
            return dal_pt.SuaPT(pt);
        }
    }
}
