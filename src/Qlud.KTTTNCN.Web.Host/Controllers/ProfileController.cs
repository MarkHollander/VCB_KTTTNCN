using Abp.AspNetCore.Mvc.Authorization;
using Qlud.KTTTNCN.Authorization.Users.Profile;
using Qlud.KTTTNCN.Graphics;
using Qlud.KTTTNCN.Storage;

namespace Qlud.KTTTNCN.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService,
            IImageFormatValidator imageFormatValidator) :
            base(tempFileCacheManager, profileAppService, imageFormatValidator)
        {
        }
    }
}