using System.Threading.Tasks;
using Qlud.KTTTNCN.ApiClient.Models;

namespace Qlud.KTTTNCN.Services.Account
{
    public interface IAccountService
    {
        AbpAuthenticateModel AbpAuthenticateModel { get; set; }
        
        AbpAuthenticateResultModel AuthenticateResultModel { get; set; }
        
        Task LoginUserAsync();

        Task LogoutAsync();
    }
}
