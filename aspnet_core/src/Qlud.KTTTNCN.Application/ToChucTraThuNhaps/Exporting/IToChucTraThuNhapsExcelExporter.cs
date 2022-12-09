using System.Collections.Generic;
using Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps.Exporting
{
    public interface IToChucTraThuNhapsExcelExporter
    {
        FileDto ExportToFile(List<GetToChucTraThuNhapForViewDto> toChucTraThuNhaps);
    }
}