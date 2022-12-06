using System.Collections.Generic;

namespace Qlud.KTTTNCN.MultiTenancy.Payments
{
    public interface IPaymentGatewayStore
    {
        List<PaymentGatewayModel> GetActiveGateways();
    }
}
