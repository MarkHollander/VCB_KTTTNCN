using Abp.AspNetCore.Mvc.Views;

namespace Qlud.KTTTNCN.Web.Views
{
    public abstract class KTTTNCNRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected KTTTNCNRazorPage()
        {
            LocalizationSourceName = KTTTNCNConsts.LocalizationSourceName;
        }
    }
}
