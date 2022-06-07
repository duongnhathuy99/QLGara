using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhapPhuTung
    {
        DAL_NhapPhuTung dal_npt = new DAL_NhapPhuTung();
        public List<DTO_NhapPhuTung> select()
        {
            return dal_npt.select(); 
        }
        public int taoIDNPT()
        {
            return dal_npt.slNPT();
        }
        public bool ThemNPT(DTO_NhapPhuTung npt)
        {
            return dal_npt.ThemNPT(npt);
        }
       /* public bool SuaPT(DTO_NhapPhuTung npt)
        {
            return dal_npt.SuaPT(npt);
        }*/
    }
}
