using System.Collections.Generic;
using Qlud.KTTTNCN.Editions.Dto;
using Qlud.KTTTNCN.MultiTenancy.Payments;

namespace Qlud.KTTTNCN.Web.Models.Payment
{
    public class UpgradeEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public PaymentPeriodType PaymentPeriodType { get; set; }

        public SubscriptionPaymentType SubscriptionPaymentType { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}