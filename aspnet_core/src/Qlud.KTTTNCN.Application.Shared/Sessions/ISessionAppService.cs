using System.Threading.Tasks;
using Abp.Application.Services;
using Qlud.KTTTNCN.Sessions.Dto;

namespace Qlud.KTTTNCN.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
