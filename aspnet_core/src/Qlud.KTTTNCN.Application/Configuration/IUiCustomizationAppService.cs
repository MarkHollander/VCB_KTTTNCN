using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Qlud.KTTTNCN.Configuration.Dto;

namespace Qlud.KTTTNCN.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<List<ThemeSettingsDto>> GetUiManagementSettings();

        Task UpdateUiManagementSettings(ThemeSettingsDto settings);

        Task UpdateDefaultUiManagementSettings(ThemeSettingsDto settings);

        Task UseSystemDefaultSettings();
    }
}
