using Abp.AutoMapper;
using Qlud.KTTTNCN.Organizations.Dto;

namespace Qlud.KTTTNCN.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}