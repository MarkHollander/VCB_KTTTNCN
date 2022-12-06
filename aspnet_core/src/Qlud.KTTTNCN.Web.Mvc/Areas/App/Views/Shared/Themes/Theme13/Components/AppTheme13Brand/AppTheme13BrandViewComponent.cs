using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Areas.App.Models.Layout;
using Qlud.KTTTNCN.Web.Session;
using Qlud.KTTTNCN.Web.Views;

namespace Qlud.KTTTNCN.Web.Areas.App.Views.Shared.Themes.Theme13.Components.AppTheme13Brand
{
    public class AppTheme13BrandViewComponent : KTTTNCNViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme13BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
