using Abp.Auditing;
using Qlud.KTTTNCN.Configuration.Dto;

namespace Qlud.KTTTNCN.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}