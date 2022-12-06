using System.ComponentModel.DataAnnotations;

namespace Qlud.KTTTNCN.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}