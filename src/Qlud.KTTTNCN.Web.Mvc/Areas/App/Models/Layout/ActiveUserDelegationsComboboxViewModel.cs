using System.Collections.Generic;
using Qlud.KTTTNCN.Authorization.Delegation;
using Qlud.KTTTNCN.Authorization.Users.Delegation.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }

        public List<UserDelegationDto> UserDelegations { get; set; }

        public string CssClass { get; set; }
    }
}
