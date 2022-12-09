using Abp.AspNetCore.Mvc.ViewComponents;

namespace Qlud.KTTTNCN.Web.Views
{
    public abstract class KTTTNCNViewComponent : AbpViewComponent
    {
        protected KTTTNCNViewComponent()
        {
            LocalizationSourceName = KTTTNCNConsts.LocalizationSourceName;
        }
    }
}