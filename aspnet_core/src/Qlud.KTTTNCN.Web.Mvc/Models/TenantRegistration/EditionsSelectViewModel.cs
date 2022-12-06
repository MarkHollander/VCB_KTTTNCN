using Abp.AutoMapper;
using Qlud.KTTTNCN.MultiTenancy.Dto;

namespace Qlud.KTTTNCN.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
