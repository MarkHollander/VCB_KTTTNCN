using System.Collections.Generic;
using Qlud.KTTTNCN.DashboardCustomization.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.CustomizableDashboard
{
    public class AddWidgetViewModel
    {
        public List<WidgetOutput> Widgets { get; set; }

        public string DashboardName { get; set; }

        public string PageId { get; set; }
    }
}
