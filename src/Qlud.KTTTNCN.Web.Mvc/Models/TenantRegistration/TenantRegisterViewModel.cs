using Qlud.KTTTNCN.Editions;
using Qlud.KTTTNCN.Editions.Dto;
using Qlud.KTTTNCN.MultiTenancy.Payments;
using Qlud.KTTTNCN.Security;
using Qlud.KTTTNCN.MultiTenancy.Payments.Dto;

namespace Qlud.KTTTNCN.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
