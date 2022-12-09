using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Common.Dto;
using Qlud.KTTTNCN.Editions.Dto;

namespace Qlud.KTTTNCN.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}