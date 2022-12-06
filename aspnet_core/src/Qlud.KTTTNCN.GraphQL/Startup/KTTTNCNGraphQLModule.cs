using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Qlud.KTTTNCN.Startup
{
    [DependsOn(typeof(KTTTNCNCoreModule))]
    public class KTTTNCNGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KTTTNCNGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}