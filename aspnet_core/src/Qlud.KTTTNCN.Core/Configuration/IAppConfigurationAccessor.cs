using Microsoft.Extensions.Configuration;

namespace Qlud.KTTTNCN.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
