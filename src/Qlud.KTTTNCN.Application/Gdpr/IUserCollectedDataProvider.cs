using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
