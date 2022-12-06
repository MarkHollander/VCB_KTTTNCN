using System.Collections.Generic;
using Qlud.KTTTNCN.Authorization.Permissions.Dto;

namespace Qlud.KTTTNCN.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}