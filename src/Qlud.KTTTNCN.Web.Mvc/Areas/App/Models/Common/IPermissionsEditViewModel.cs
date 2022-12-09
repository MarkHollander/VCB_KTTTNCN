using System.Collections.Generic;
using Qlud.KTTTNCN.Authorization.Permissions.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}