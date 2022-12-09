using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps
{
    public interface IToChucTraThuNhapsAppService : IApplicationService
    {
        Task<PagedResultDto<GetToChucTraThuNhapForViewDto>> GetAll(GetAllToChucTraThuNhapsInput input);

        Task<GetToChucTraThuNhapForViewDto> GetToChucTraThuNhapForView(int id);

        Task<GetToChucTraThuNhapForEditOutput> GetToChucTraThuNhapForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditToChucTraThuNhapDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetToChucTraThuNhapsToExcel(GetAllToChucTraThuNhapsForExcelInput input);

    }
}