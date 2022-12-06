using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Qlud.KTTTNCN.Authentication.TwoFactor.Google;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.Authorization.Roles;
using Qlud.KTTTNCN.Authorization.Users;
using Qlud.KTTTNCN.Editions;
using Qlud.KTTTNCN.MultiTenancy;

namespace Qlud.KTTTNCN.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
