using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.ChungTuKTTs
{
    public interface IChungTuKTTsAppService : IApplicationService
    {
        Task<PagedResultDto<GetChungTuKTTForViewDto>> GetAll(GetAllChungTuKTTsInput input);

        Task<PagedResultDto<GetChungTuKTTForViewDto>> GetByIdList(GetAllChungTuKTTsInput input);

        Task<GetChungTuKTTForViewDto> GetChungTuKTTForView(long id);

        Task<GetChungTuKTTForEditOutput> GetChungTuKTTForEdit(EntityDto<long> input);

        Task CreateOrEdit(CreateOrEditChungTuKTTDto input);

        Task Delete(EntityDto<long> input);

        Task<FileDto> GetChungTuKTTsToExcel(GetAllChungTuKTTsForExcelInput input);

        Task<List<long>> ImportChungTuKTTsFromExcel(IFormFile ChungTuBatch);

        Task<PagedResultDto<BaoCaoQuanLyChungTuDto>> GetChungTu(GetChungTuInput input);
    }
}