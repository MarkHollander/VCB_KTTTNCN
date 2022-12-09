using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Qlud.KTTTNCN.Authorization;

namespace Qlud.KTTTNCN
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(KTTTNCNApplicationSharedModule),
        typeof(KTTTNCNCoreModule)
        )]
    public class KTTTNCNApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KTTTNCNApplicationModule).GetAssembly());
        }
    }
}