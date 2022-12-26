using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qlud.KTTTNCN.BaoCaoChungTus.Dtos
{
    public class GetChungTuInput: PagedAndSortedResultRequestDto
    {
        public string SoChungTu { get; set; }
        public string MaSoThue { get; set; }
        public string HoVaTen { get; set; }
        public string Status { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public string TrangThai { get; set; }
        public string MauSo { get; set; }
        public string KyHieu { get; set; }
    }
}
