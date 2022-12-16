using System;
using System.Collections.Generic;
using System.Text;

namespace Qlud.KTTTNCN.ChungTuKTTs.Dtos
{
    public class GetChungTuInput
    {
        public string SoChungTu { get; set; }
        public string MaSoThue { get; set; }
        public string HoVaTen { get; set; }
        public string Status { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayDuyet { get; set; }
    }
}
