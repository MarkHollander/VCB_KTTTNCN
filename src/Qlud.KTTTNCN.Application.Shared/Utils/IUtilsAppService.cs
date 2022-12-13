using Abp.Application.Services;
using Qlud.KTTTNCN.Authorization.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Qlud.KTTTNCN.Utils
{
    public interface IUtilsAppService : IApplicationService
    {
        Task<UserListDto> GetUserListDto(long userId);

        Task<Dictionary<string, string>> GetStatusDict();
    }
}
