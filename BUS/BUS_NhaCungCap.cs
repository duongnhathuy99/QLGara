using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dal_ncc = new DAL_NhaCungCap();
        public List<DTO_NhaCungCap> select()
        {
            return dal_ncc.select();
        }
        public int taoIDNCC()
        {
            return dal_ncc.slNCC();
        }
        public bool ThemNCC(DTO_NhaCungCap ncc)
        {
            return dal_ncc.ThemNCC(ncc);
        }
        public bool SuaNCC(DTO_NhaCungCap ncc)
        {
            return dal_ncc.SuaNCC(ncc);
        }
        public bool XoaNCC(string MaNCC)
        {
            return dal_ncc.XoaNCC(MaNCC);
        }
    }
}
