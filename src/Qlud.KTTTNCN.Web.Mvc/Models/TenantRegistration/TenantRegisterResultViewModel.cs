using Abp.AutoMapper;
using Qlud.KTTTNCN.MultiTenancy.Dto;

namespace Qlud.KTTTNCN.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}