using Microsoft.Extensions.DependencyInjection;
using Qlud.KTTTNCN.HealthChecks;

namespace Qlud.KTTTNCN.Web.HealthCheck
{
    public static class AbpZeroHealthCheck
    {
        public static IHealthChecksBuilder AddAbpZeroHealthCheck(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<KTTTNCNDbContextHealthCheck>("Database Connection");
            builder.AddCheck<KTTTNCNDbContextUsersHealthCheck>("Database Connection with user check");
            builder.AddCheck<CacheHealthCheck>("Cache");

            // add your custom health checks here
            // builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
