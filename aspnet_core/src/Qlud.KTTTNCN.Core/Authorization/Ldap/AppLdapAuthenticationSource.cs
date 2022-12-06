using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Qlud.KTTTNCN.Authorization.Users;
using Qlud.KTTTNCN.MultiTenancy;

namespace Qlud.KTTTNCN.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}