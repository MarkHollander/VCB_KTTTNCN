using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Authorization.Permissions.Dto;
using Qlud.KTTTNCN.Web.Areas.App.Models.Common;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}