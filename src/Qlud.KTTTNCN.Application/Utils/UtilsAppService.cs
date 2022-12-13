using Abp.Application.Services;
using Abp.Domain.Repositories;
using Qlud.KTTTNCN.Authorization.Users.Dto;
using Qlud.KTTTNCN.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qlud.KTTTNCN.Utils
{
    public class UtilsAppService : KTTTNCNAppServiceBase, IUtilsAppService
    {
        private readonly IRepository<User, long> _userRepository;

        public UtilsAppService(IRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserListDto> GetUserListDto(long userId)
        {
            var user = _userRepository.FirstOrDefault(userId);
            UserListDto userListDto = new UserListDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                BranchCode = user.BranchCode,
                DeptCode = user.DeptCode
            };
            return Task.Run(() => userListDto);
        }

        public Task<Dictionary<string, string>> GetStatusDict()
        {
            return Task.Run(() => QludConsts.TrangThai.MappingList);
        }
    }
}
