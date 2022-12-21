using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.BaoCaoChungTus.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    public interface IBaoCaoChungTusAppService: IApplicationService
    {
        Task<PagedResultDto<BaoCaoQuanLyChungTuDto>> GetChungTu(GetChungTuInput input);
    }
}
