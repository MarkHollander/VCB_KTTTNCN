using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Qlud.KTTTNCN
{
    [DependsOn(typeof(KTTTNCNXamarinSharedModule))]
    public class KTTTNCNXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KTTTNCNXamarinIosModule).GetAssembly());
        }
    }
}