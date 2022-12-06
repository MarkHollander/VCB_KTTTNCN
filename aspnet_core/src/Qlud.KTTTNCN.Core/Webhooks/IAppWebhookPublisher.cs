using System.Threading.Tasks;
using Qlud.KTTTNCN.Authorization.Users;

namespace Qlud.KTTTNCN.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
