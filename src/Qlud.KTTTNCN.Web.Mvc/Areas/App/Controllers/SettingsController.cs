﻿using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Runtime.Session;
using Abp.Timing;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.Authorization.Users;
using Qlud.KTTTNCN.Configuration;
using Qlud.KTTTNCN.Configuration.Tenants;
using Qlud.KTTTNCN.MultiTenancy;
using Qlud.KTTTNCN.Security;
using Qlud.KTTTNCN.Timing;
using Qlud.KTTTNCN.Timing.Dto;
using Qlud.KTTTNCN.Web.Areas.App.Models.Settings;
using Qlud.KTTTNCN.Web.Controllers;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Tenant_Settings)]
    public class SettingsController : KTTTNCNControllerBase
    {
        private readonly UserManager _userManager;
        private readonly TenantManager _tenantManager;
        private readonly IAppConfigurationAccessor _configurationAccessor;
        private readonly ITenantSettingsAppService _tenantSettingsAppService;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly ITimingAppService _timingAppService;

        public SettingsController(
            ITenantSettingsAppService tenantSettingsAppService,
            IMultiTenancyConfig multiTenancyConfig,
            ITimingAppService timingAppService, 
            UserManager userManager, 
            TenantManager tenantManager,
            IAppConfigurationAccessor configurationAccessor)
        {
            _tenantSettingsAppService = tenantSettingsAppService;
            _multiTenancyConfig = multiTenancyConfig;
            _timingAppService = timingAppService;
            _userManager = userManager;
            _tenantManager = tenantManager;
            _configurationAccessor = configurationAccessor;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _tenantSettingsAppService.GetAllSettings();
            ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;

            var timezoneItems = await _timingAppService.GetTimezoneComboboxItems(new GetTimezoneComboboxItemsInput
            {
                DefaultTimezoneScope = SettingScopes.Tenant,
                SelectedTimezoneId = await SettingManager.GetSettingValueForTenantAsync(TimingSettingNames.TimeZone, AbpSession.GetTenantId())
            });

            var user = await _userManager.GetUserAsync(AbpSession.ToUserIdentifier());

            ViewBag.CurrentUserEmail = user.EmailAddress;

            var tenant = await _tenantManager.FindByIdAsync(AbpSession.GetTenantId());
            ViewBag.TenantId = tenant.Id;
            ViewBag.TenantLogoId = tenant.LogoId;
            ViewBag.TenantCustomCssId = tenant.CustomCssId;

            var model = new SettingsViewModel
            {
                Settings = output,
                TimezoneItems = timezoneItems
                
            };

            AddEnabledSocialLogins(model);
            
            return View(model);
        }
        
        private void AddEnabledSocialLogins(SettingsViewModel model)
        {
            if (!bool.Parse(_configurationAccessor.Configuration["Authentication:AllowSocialLoginSettingsPerTenant"]))
            {
                return;
            }

            if (bool.Parse(_configurationAccessor.Configuration["Authentication:Facebook:IsEnabled"]))
            {
                model.EnabledSocialLoginSettings.Add("Facebook");
            }

            if (bool.Parse(_configurationAccessor.Configuration["Authentication:Google:IsEnabled"]))
            {
                model.EnabledSocialLoginSettings.Add("Google");
            }

            if (bool.Parse(_configurationAccessor.Configuration["Authentication:Twitter:IsEnabled"]))
            {
                model.EnabledSocialLoginSettings.Add("Twitter");
            }

            if (bool.Parse(_configurationAccessor.Configuration["Authentication:Microsoft:IsEnabled"]))
            {
                model.EnabledSocialLoginSettings.Add("Microsoft");
            }
            
            if (bool.Parse(_configurationAccessor.Configuration["Authentication:OpenId:IsEnabled"]))
            {
                model.EnabledSocialLoginSettings.Add("OpenId");
            }
            
            if (bool.Parse(_configurationAccessor.Configuration["Authentication:WsFederation:IsEnabled"]))
            {
                model.EnabledSocialLoginSettings.Add("WsFederation");
            }
        }
    }
}