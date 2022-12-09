using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.WebHooks.Dto
{
    public class GetAllSendAttemptsInput : PagedInputDto
    {
        public string SubscriptionId { get; set; }
    }
}
