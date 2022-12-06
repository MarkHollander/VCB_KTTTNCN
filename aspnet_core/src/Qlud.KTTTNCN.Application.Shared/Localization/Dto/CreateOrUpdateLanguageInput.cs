using System.ComponentModel.DataAnnotations;

namespace Qlud.KTTTNCN.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}