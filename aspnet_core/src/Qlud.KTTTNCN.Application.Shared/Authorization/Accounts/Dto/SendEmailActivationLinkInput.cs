using System.ComponentModel.DataAnnotations;

namespace Qlud.KTTTNCN.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}