using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Qlud.KTTTNCN
{
    public class KTTTNCNClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(KTTTNCNClientModule).GetAssembly());
        }
    }
}
