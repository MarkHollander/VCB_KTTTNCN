using System.Collections.Generic;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.ChungTuKTTs.Exporting
{
    public interface IChungTuKTTsExcelExporter
    {
        FileDto ExportToFile(List<GetChungTuKTTForViewDto> chungTuKTTs);
    }
}