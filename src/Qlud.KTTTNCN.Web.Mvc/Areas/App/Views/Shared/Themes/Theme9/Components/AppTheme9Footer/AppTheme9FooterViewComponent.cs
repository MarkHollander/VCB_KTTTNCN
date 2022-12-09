using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Areas.App.Models.Layout;
using Qlud.KTTTNCN.Web.Session;
using Qlud.KTTTNCN.Web.Views;

namespace Qlud.KTTTNCN.Web.Areas.App.Views.Shared.Themes.Theme9.Components.AppTheme9Footer
{
    public class AppTheme9FooterViewComponent : KTTTNCNViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme9FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
