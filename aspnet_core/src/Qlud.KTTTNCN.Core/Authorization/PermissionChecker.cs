using Abp.Authorization;
using Qlud.KTTTNCN.Authorization.Roles;
using Qlud.KTTTNCN.Authorization.Users;

namespace Qlud.KTTTNCN.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
