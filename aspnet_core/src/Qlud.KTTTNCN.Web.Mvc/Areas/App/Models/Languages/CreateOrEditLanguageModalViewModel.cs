using Abp.AutoMapper;
using Qlud.KTTTNCN.Localization.Dto;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.Languages
{
    [AutoMapFrom(typeof(GetLanguageForEditOutput))]
    public class CreateOrEditLanguageModalViewModel : GetLanguageForEditOutput
    {
        public bool IsEditMode => Language.Id.HasValue;
    }
}