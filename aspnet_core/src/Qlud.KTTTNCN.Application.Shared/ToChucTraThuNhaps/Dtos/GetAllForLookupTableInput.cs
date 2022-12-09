using Abp.Application.Services.Dto;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}