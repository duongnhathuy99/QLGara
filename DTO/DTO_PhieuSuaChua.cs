﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DTO_PhieuSuaChua
    {
        public string MaPhieu { get; set; }
        public string TaiKhoan { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayLapPhieu { get; set; }
        public int TienSuaChua { get; set; }    
        public string TrangThaiThanhToan { get; set; }
        public DateTime NgayBanGiao { get; set; }
        public string GhiChu { get; set; }

    }
}
