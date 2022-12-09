using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.ChungTuKTTs
{
    public interface IChungTuKTTsAppService : IApplicationService
    {
        Task<PagedResultDto<GetChungTuKTTForViewDto>> GetAll(GetAllChungTuKTTsInput input);

        Task<GetChungTuKTTForViewDto> GetChungTuKTTForView(long id);

        Task<GetChungTuKTTForEditOutput> GetChungTuKTTForEdit(EntityDto<long> input);

        Task CreateOrEdit(CreateOrEditChungTuKTTDto input);

        Task Delete(EntityDto<long> input);

        Task<FileDto> GetChungTuKTTsToExcel(GetAllChungTuKTTsForExcelInput input);

    }
}