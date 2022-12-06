using Abp.AutoMapper;
using Qlud.KTTTNCN.Authorization.Users;
using Qlud.KTTTNCN.Authorization.Users.Dto;
using Qlud.KTTTNCN.Web.Areas.App.Models.Common;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}