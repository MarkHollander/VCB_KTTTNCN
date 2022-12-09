using System.Collections.Generic;
using Qlud.KTTTNCN.Authorization.Permissions.Dto;

namespace Qlud.KTTTNCN.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}