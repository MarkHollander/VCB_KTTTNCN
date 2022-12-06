using System;
using System.Threading.Tasks;
using Flurl.Http.Content;
using Qlud.KTTTNCN.Authorization.Users.Profile.Dto;

namespace Qlud.KTTTNCN.Authorization.Users.Profile
{
    public class ProxyProfileControllerService : ProxyControllerBase
    {
        public async Task<UploadProfilePictureOutput> UploadProfilePicture(Action<CapturedMultipartContent> buildContent)
        {
            return await ApiClient
                .PostMultipartAsync<UploadProfilePictureOutput>(GetEndpoint(nameof(UploadProfilePicture)), buildContent);
        }
    }
}