using Qlud.KTTTNCN.Editions.Dto;

namespace Qlud.KTTTNCN.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < KTTTNCNConsts.MinimumUpgradePaymentAmount;
        }
    }
}
