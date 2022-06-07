using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhapPhuTung
    {       
        public string MaNhap { get; set; }
        public string TaiKhoan { get; set; }
        public string MaNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public int TienNhap { get; set; }
    }
}
