﻿using Qlud.KTTTNCN.MultiTenancy.Payments;

namespace Qlud.KTTTNCN.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}