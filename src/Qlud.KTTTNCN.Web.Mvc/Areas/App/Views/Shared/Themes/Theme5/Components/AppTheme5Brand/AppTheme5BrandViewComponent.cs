using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Areas.App.Models.Layout;
using Qlud.KTTTNCN.Web.Session;
using Qlud.KTTTNCN.Web.Views;

namespace Qlud.KTTTNCN.Web.Areas.App.Views.Shared.Themes.Theme5.Components.AppTheme5Brand
{
    public class AppTheme5BrandViewComponent : KTTTNCNViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme5BrandViewComponent(IPerRequestSessionCache sessionCache)
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
