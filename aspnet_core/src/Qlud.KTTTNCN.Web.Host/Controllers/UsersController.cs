using Abp.AspNetCore.Mvc.Authorization;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.Storage;
using Abp.BackgroundJobs;

namespace Qlud.KTTTNCN.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}