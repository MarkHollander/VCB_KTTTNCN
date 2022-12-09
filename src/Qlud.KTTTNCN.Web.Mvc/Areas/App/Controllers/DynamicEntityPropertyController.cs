﻿using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.DynamicEntityProperties;
using Qlud.KTTTNCN.Web.Areas.App.Models.DynamicEntityProperty;
using Qlud.KTTTNCN.Web.Controllers;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_DynamicEntityProperties)]
    public class DynamicEntityPropertyController : KTTTNCNControllerBase
    {
        private readonly IDynamicPropertyAppService _dynamicPropertyAppService;
        private readonly IDynamicEntityPropertyAppService _dynamicEntityPropertyAppService;

        public DynamicEntityPropertyController(
            IDynamicPropertyAppService dynamicPropertyAppService,
            IDynamicEntityPropertyAppService dynamicEntityPropertyAppService
        )
        {
            _dynamicPropertyAppService = dynamicPropertyAppService;
            _dynamicEntityPropertyAppService = dynamicEntityPropertyAppService;
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_DynamicEntityProperties_Create)]
        public async Task<IActionResult> CreateModal(string entityFullName)
        {
            var model = new CreateEntityDynamicPropertyViewModel()
            {
                EntityFullName = entityFullName
            };

            var allDynamicProperties = (await _dynamicPropertyAppService.GetAll()).Items.ToList();
            var definedPropertyIds = (await _dynamicEntityPropertyAppService.GetAllPropertiesOfAnEntity(new DynamicEntityPropertyGetAllInput() {EntityFullName = entityFullName}))
                .Items.Select(x => x.DynamicPropertyId).ToList();

            model.DynamicProperties = allDynamicProperties.Where(x => !definedPropertyIds.Contains(x.Id)).ToList();

            return PartialView("_CreateModal", model);
        }
        
        public IActionResult ManageModal()
        {
            return PartialView("_ManageModal");
        }
    }
}