using Abp.AutoMapper;
using Qlud.KTTTNCN.Sessions.Dto;

namespace Qlud.KTTTNCN.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}