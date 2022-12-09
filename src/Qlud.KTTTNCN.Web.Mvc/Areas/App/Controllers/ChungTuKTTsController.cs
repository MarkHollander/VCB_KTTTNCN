using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Areas.App.Models.ChungTuKTTs;
using Qlud.KTTTNCN.Web.Controllers;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.ChungTuKTTs;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_ChungTuKTTs)]
    public class ChungTuKTTsController : KTTTNCNControllerBase
    {
        private readonly IChungTuKTTsAppService _chungTuKTTsAppService;

        public ChungTuKTTsController(IChungTuKTTsAppService chungTuKTTsAppService)
        {
            _chungTuKTTsAppService = chungTuKTTsAppService;

        }

        public ActionResult Index()
        {
            var model = new ChungTuKTTsViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_ChungTuKTTs_Create, AppPermissions.Pages_ChungTuKTTs_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(long? id)
        {
            GetChungTuKTTForEditOutput getChungTuKTTForEditOutput;

            if (id.HasValue)
            {
                getChungTuKTTForEditOutput = await _chungTuKTTsAppService.GetChungTuKTTForEdit(new EntityDto<long> { Id = (long)id });
            }
            else
            {
                getChungTuKTTForEditOutput = new GetChungTuKTTForEditOutput
                {
                    ChungTuKTT = new CreateOrEditChungTuKTTDto()
                };
                getChungTuKTTForEditOutput.ChungTuKTT.NgayCap = DateTime.Now;
                getChungTuKTTForEditOutput.ChungTuKTT.ThoiGianNhap = DateTime.Now;
                getChungTuKTTForEditOutput.ChungTuKTT.ThoiGianDuyet = DateTime.Now;
            }

            var viewModel = new CreateOrEditChungTuKTTModalViewModel()
            {
                ChungTuKTT = getChungTuKTTForEditOutput.ChungTuKTT,

            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewChungTuKTTModal(long id)
        {
            var getChungTuKTTForViewDto = await _chungTuKTTsAppService.GetChungTuKTTForView(id);

            var model = new ChungTuKTTViewModel()
            {
                ChungTuKTT = getChungTuKTTForViewDto.ChungTuKTT
            };

            return PartialView("_ViewChungTuKTTModal", model);
        }

    }
}