using Abp.Application.Services.Dto;

namespace Qlud.KTTTNCN.Notifications.Dto
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}