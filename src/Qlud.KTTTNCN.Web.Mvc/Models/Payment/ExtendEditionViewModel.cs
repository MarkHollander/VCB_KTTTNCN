using System.Collections.Generic;
using Qlud.KTTTNCN.Editions.Dto;
using Qlud.KTTTNCN.MultiTenancy.Payments;

namespace Qlud.KTTTNCN.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}