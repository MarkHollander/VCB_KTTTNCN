using System.Threading.Tasks;

namespace Qlud.KTTTNCN.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}