using Qlud.KTTTNCN.Sessions.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Layout
{
    public class SubscriptionBarViewModel
    {
        public int SubscriptionExpireNotifyDayCount { get; set; }

        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public string CssClass { get; set; }
    }
}
