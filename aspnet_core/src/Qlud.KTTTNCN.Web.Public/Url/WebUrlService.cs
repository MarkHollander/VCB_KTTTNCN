using Abp.Dependency;
using Qlud.KTTTNCN.Configuration;
using Qlud.KTTTNCN.Url;
using Qlud.KTTTNCN.Web.Url;

namespace Qlud.KTTTNCN.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}