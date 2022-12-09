using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Organizations.Dto
{
    public class FindOrganizationUnitRolesInput : PagedAndFilteredInputDto
    {
        public long OrganizationUnitId { get; set; }
    }
}