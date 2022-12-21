using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.BaoCaoChungTus.Dtos;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.BaoCaoQuanLyChungTu
{
    public class BaoCaoQuanLyChungTuViewModel
    {
        public PagedResultDto<BaoCaoQuanLyChungTuDto> listChungTu { get; set; }
        public GetChungTuInput filter { get; set; }
    }
}
