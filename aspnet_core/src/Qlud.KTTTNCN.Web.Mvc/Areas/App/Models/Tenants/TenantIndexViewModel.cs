using System.Collections.Generic;
using Qlud.KTTTNCN.Editions.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}