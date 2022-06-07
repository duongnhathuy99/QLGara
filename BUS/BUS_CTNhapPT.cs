using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_CTNhapPT
    {
        DAL_CTNhap_PhuTung dal_ct_npt = new DAL_CTNhap_PhuTung();
        public bool ThemCT_NPT(List<DTO_CTNhap_PhuTung> ct_npt)
        {
            return dal_ct_npt.ThemCT_NPT(ct_npt);
        }
    }
}
