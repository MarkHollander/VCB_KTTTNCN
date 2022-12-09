using System.Threading.Tasks;
using Abp.Application.Services;
using Qlud.KTTTNCN.Editions.Dto;
using Qlud.KTTTNCN.MultiTenancy.Dto;

namespace Qlud.KTTTNCN.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}