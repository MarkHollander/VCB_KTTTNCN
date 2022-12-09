using Abp.Application.Services;
using Qlud.KTTTNCN.Dto;
using Qlud.KTTTNCN.Logging.Dto;

namespace Qlud.KTTTNCN.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
