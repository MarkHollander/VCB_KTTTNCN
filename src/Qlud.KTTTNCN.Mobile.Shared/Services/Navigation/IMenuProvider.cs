using System.Collections.Generic;
using MvvmHelpers;
using Qlud.KTTTNCN.Models.NavigationMenu;

namespace Qlud.KTTTNCN.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}