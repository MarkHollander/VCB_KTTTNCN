using Abp.Application.Services;
using Qlud.KTTTNCN.BaoCaoChungTus.Dtos;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    public interface IBaoCaoChungTusExporter: IApplicationService
    {
        FileDto ExportToPDF(long chungTuId);
        FileDto ExportToXML(long chungTuId);
    }
}
