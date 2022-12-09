using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Qlud.KTTTNCN
{
    [DependsOn(typeof(KTTTNCNXamarinSharedModule))]
    public class KTTTNCNXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KTTTNCNXamarinAndroidModule).GetAssembly());
        }
    }
}