using System.Threading.Tasks;
using Abp.Application.Services;
using Qlud.KTTTNCN.MultiTenancy.Payments.PayPal.Dto;

namespace Qlud.KTTTNCN.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
