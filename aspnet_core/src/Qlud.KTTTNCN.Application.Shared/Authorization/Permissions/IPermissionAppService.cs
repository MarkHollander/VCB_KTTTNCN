using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Authorization.Permissions.Dto;

namespace Qlud.KTTTNCN.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
