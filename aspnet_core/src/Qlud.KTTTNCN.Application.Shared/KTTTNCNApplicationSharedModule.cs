using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Qlud.KTTTNCN
{
    [DependsOn(typeof(KTTTNCNCoreSharedModule))]
    public class KTTTNCNApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KTTTNCNApplicationSharedModule).GetAssembly());
        }
    }
}