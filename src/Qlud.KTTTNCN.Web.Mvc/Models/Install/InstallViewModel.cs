using System.Collections.Generic;
using Abp.Localization;
using Qlud.KTTTNCN.Install.Dto;

namespace Qlud.KTTTNCN.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
