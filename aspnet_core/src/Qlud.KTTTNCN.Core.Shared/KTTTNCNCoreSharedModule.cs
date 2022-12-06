using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Qlud.KTTTNCN
{
    public class KTTTNCNCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KTTTNCNCoreSharedModule).GetAssembly());
        }
    }
}