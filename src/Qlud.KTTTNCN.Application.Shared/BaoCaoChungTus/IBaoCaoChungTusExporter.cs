using Abp.Application.Services;
using Qlud.KTTTNCN.BaoCaoChungTus.Dtos;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    public interface IBaoCaoChungTusExporter: IApplicationService
    {
        Task<FileDto> ExportToWord(long chungtuId);
        Task<FileDto> ExportToPDF(long chungTuId);
        Task<FileDto> ExportToXML(long chungTuId);
    }
}
