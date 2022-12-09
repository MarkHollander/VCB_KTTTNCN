using Abp.Domain.Services;

namespace Qlud.KTTTNCN
{
    public abstract class KTTTNCNDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected KTTTNCNDomainServiceBase()
        {
            LocalizationSourceName = KTTTNCNConsts.LocalizationSourceName;
        }
    }
}
