using System.Collections.Generic;
using Qlud.KTTTNCN.Caching.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}