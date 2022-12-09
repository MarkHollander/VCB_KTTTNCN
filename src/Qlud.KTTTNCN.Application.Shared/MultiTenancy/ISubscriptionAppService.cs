using System.Threading.Tasks;
using Abp.Application.Services;

namespace Qlud.KTTTNCN.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
