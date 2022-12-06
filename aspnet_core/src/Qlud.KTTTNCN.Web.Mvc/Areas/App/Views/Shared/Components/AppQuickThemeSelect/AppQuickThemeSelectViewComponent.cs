using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Areas.App.Models.Layout;
using Qlud.KTTTNCN.Web.Views;

namespace Qlud.KTTTNCN.Web.Areas.App.Views.Shared.Components.
    AppQuickThemeSelect
{
    public class AppQuickThemeSelectViewComponent : KTTTNCNViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass, string iconClass = "flaticon-interface-7 fs-2")
        {
            return Task.FromResult<IViewComponentResult>(View(new QuickThemeSelectionViewModel
            {
                CssClass = cssClass,
                IconClass = iconClass
            }));
        }
    }
}
