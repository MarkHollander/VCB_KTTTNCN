using System.Collections.Generic;
using Qlud.KTTTNCN.DynamicEntityProperties.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
