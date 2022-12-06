using Abp.Events.Bus;

namespace Qlud.KTTTNCN.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}