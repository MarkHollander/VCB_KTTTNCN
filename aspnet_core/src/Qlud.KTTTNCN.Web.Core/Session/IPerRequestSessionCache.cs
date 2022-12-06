using System.Threading.Tasks;
using Qlud.KTTTNCN.Sessions.Dto;

namespace Qlud.KTTTNCN.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
