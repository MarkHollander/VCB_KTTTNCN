using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Configuration.Host.Dto;
using Qlud.KTTTNCN.Editions.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public List<string> EnabledSocialLoginSettings { get; set; } = new List<string>();
    }
}