using Abp.Application.Services.Dto;

namespace Qlud.KTTTNCN.ChungTuKTTs.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}