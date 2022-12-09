using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}
