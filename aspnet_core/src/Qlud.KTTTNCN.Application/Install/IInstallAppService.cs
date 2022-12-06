using System.Threading.Tasks;
using Abp.Application.Services;
using Qlud.KTTTNCN.Install.Dto;

namespace Qlud.KTTTNCN.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}