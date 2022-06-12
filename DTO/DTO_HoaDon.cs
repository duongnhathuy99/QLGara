using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDon
    {
        public string MaHD { get; set; }
        public DTO_NhanVien NhanVien { get; set; }       
        public DateTime NgayThanhToan { get; set; }
        public string HinhThucThanhToan { get; set; }      
        public DTO_PhieuSuaChua PhieuSuaChua { get; set; }
    }
}
