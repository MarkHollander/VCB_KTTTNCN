using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Qlud.KTTTNCN.Web.Public.Views
{
    public abstract class KTTTNCNRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected KTTTNCNRazorPage()
        {
            LocalizationSourceName = KTTTNCNConsts.LocalizationSourceName;
        }
    }
}
