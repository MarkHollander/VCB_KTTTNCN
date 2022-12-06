using System.ComponentModel.DataAnnotations;

namespace Qlud.KTTTNCN.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
