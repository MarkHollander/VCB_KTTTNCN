using System.Threading.Tasks;
using Abp.Webhooks;

namespace Qlud.KTTTNCN.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
