using Abp.Application.Services.Dto;
using System;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos
{
    public class GetAllToChucTraThuNhapsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string TenToChucFilter { get; set; }

        public string MaSoThueFilter { get; set; }

        public string DiaChiFilter { get; set; }

        public string SoDienThoaiFilter { get; set; }

        public string UserNhapFilter { get; set; }

        public DateTime? MaxThoiGianNhapFilter { get; set; }
        public DateTime? MinThoiGianNhapFilter { get; set; }

        public string TrangThaiFilter { get; set; }

    }
}