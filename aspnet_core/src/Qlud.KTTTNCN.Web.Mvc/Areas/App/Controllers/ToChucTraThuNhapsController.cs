using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Web.Areas.App.Models.ToChucTraThuNhaps;
using Qlud.KTTTNCN.Web.Controllers;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.ToChucTraThuNhaps;
using Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_ToChucTraThuNhaps)]
    public class ToChucTraThuNhapsController : KTTTNCNControllerBase
    {
        private readonly IToChucTraThuNhapsAppService _toChucTraThuNhapsAppService;

        public ToChucTraThuNhapsController(IToChucTraThuNhapsAppService toChucTraThuNhapsAppService)
        {
            _toChucTraThuNhapsAppService = toChucTraThuNhapsAppService;

        }

        public ActionResult Index()
        {
            var model = new ToChucTraThuNhapsViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_ToChucTraThuNhaps_Create, AppPermissions.Pages_ToChucTraThuNhaps_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetToChucTraThuNhapForEditOutput getToChucTraThuNhapForEditOutput;

            if (id.HasValue)
            {
                getToChucTraThuNhapForEditOutput = await _toChucTraThuNhapsAppService.GetToChucTraThuNhapForEdit(new EntityDto { Id = (int)id });
            }
            else
            {
                getToChucTraThuNhapForEditOutput = new GetToChucTraThuNhapForEditOutput
                {
                    ToChucTraThuNhap = new CreateOrEditToChucTraThuNhapDto()
                };
                getToChucTraThuNhapForEditOutput.ToChucTraThuNhap.ThoiGianNhap = DateTime.Now;
            }

            var viewModel = new CreateOrEditToChucTraThuNhapModalViewModel()
            {
                ToChucTraThuNhap = getToChucTraThuNhapForEditOutput.ToChucTraThuNhap,

            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewToChucTraThuNhapModal(int id)
        {
            var getToChucTraThuNhapForViewDto = await _toChucTraThuNhapsAppService.GetToChucTraThuNhapForView(id);

            var model = new ToChucTraThuNhapViewModel()
            {
                ToChucTraThuNhap = getToChucTraThuNhapForViewDto.ToChucTraThuNhap
            };

            return PartialView("_ViewToChucTraThuNhapModal", model);
        }

    }
}