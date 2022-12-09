using Qlud.KTTTNCN.ChungTuKTTs.Dtos;

using Abp.Extensions;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.ChungTuKTTs
{
    public class CreateOrEditChungTuKTTModalViewModel
    {
        public CreateOrEditChungTuKTTDto ChungTuKTT { get; set; }

        public bool IsEditMode => ChungTuKTT.Id.HasValue;
    }
}