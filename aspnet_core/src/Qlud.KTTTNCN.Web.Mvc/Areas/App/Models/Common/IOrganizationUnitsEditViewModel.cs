using System.Collections.Generic;
using Qlud.KTTTNCN.Organizations.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Common
{
    public interface IOrganizationUnitsEditViewModel
    {
        List<OrganizationUnitDto> AllOrganizationUnits { get; set; }

        List<string> MemberedOrganizationUnits { get; set; }
    }
}