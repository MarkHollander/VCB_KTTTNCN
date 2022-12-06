using System.Collections.Generic;

namespace Qlud.KTTTNCN.Configuration.Dto
{
    public class ExternalLoginSettingsDto
    {
        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();
    }
}