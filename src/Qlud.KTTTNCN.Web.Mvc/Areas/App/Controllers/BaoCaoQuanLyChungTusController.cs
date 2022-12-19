using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Qlud.KTTTNCN.ChungTuKTTs;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Web.Areas.App.Models.BaoCaoQuanLyChungTu;
using Qlud.KTTTNCN.Web.Controllers;

namespace Qlud.KTTTNCN.Web.Areas.App.Controllers
{
    public class BaoCaoQuanLyChungTusController : KTTTNCNControllerBase
    {
        private readonly IChungTuKTTsAppService _chungTuKTTsAppService;

        public BaoCaoQuanLyChungTusController(IChungTuKTTsAppService chungTuKTTsAppService)
        {
            _chungTuKTTsAppService = chungTuKTTsAppService;

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
