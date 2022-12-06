using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Qlud.KTTTNCN.WebHooks.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
