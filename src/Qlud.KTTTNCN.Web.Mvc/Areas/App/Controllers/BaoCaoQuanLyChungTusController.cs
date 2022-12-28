using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.BaoCaoChungTus;
using Qlud.KTTTNCN.BaoCaoChungTus.Dtos;
using Qlud.KTTTNCN.ChungTuKTTs;
using Qlud.KTTTNCN.Web.Areas.App.Models.BaoCaoQuanLyChungTu;
using Qlud.KTTTNCN.Web.Controllers;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_BaoCaoQuanLyChungTus)]
    public class BaoCaoQuanLyChungTusController : KTTTNCNControllerBase
    {
        private readonly IBaoCaoChungTusAppService _baocaoChungTusAppService;

        public BaoCaoQuanLyChungTusController(IBaoCaoChungTusAppService baocaoChungTusAppService)
        {
            _baocaoChungTusAppService = baocaoChungTusAppService;

        }
        public IActionResult Index()
        {
            
            GetChungTuInput nFilter = new GetChungTuInput();
            PagedResultDto<BaoCaoQuanLyChungTuDto> nPageDto = new PagedResultDto<BaoCaoQuanLyChungTuDto>()
            { 

            };

            BaoCaoQuanLyChungTuViewModel vModel = new BaoCaoQuanLyChungTuViewModel()
            {
                listChungTu = nPageDto,
                filter = nFilter
            };
            return View();
        }
    }
}
