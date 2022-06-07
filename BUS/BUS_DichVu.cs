using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_DichVu
    {
        DAL_DichVu dal_dv = new DAL_DichVu();
        public List<DTO_DichVu> select()
        {
            return dal_dv.select();
        }
        public int taoIDDV()
        {
            return dal_dv.slDV();
        }
        public bool ThemDV(DTO_DichVu dv)
        {
            return dal_dv.ThemDV(dv);
        }
        public bool SuaDV(DTO_DichVu dv)
        {
            return dal_dv.SuaDV(dv);
        }
        public bool XoaDV(string MaDV)
        {
            return dal_dv.XoaDV(MaDV);
        }
    }
}
