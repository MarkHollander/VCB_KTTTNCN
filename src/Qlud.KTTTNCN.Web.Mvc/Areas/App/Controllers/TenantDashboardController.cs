using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.DashboardCustomization;
using System.Threading.Tasks;
using Qlud.KTTTNCN.Web.Areas.App.Startup;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class TenantDashboardController : CustomizableDashboardControllerBase
    {
        public TenantDashboardController(DashboardViewConfiguration dashboardViewConfiguration, 
            IDashboardCustomizationAppService dashboardCustomizationAppService) 
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(KTTTNCNDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard);
        }
    }
}