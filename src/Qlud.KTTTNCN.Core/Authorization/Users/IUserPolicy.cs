using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Qlud.KTTTNCN.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
