using Abp;

namespace Qlud.KTTTNCN
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="KTTTNCNDomainServiceBase"/>.
    /// For application services inherit KTTTNCNAppServiceBase.
    /// </summary>
    public abstract class KTTTNCNServiceBase : AbpServiceBase
    {
        protected KTTTNCNServiceBase()
        {
            LocalizationSourceName = KTTTNCNConsts.LocalizationSourceName;
        }
    }
}