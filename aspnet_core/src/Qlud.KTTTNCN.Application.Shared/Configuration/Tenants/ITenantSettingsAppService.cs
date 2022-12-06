using System.Threading.Tasks;
using Abp.Application.Services;
using Qlud.KTTTNCN.Configuration.Tenants.Dto;

namespace Qlud.KTTTNCN.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
