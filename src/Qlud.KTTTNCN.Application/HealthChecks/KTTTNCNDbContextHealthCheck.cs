using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Qlud.KTTTNCN.EntityFrameworkCore;

namespace Qlud.KTTTNCN.HealthChecks
{
    public class KTTTNCNDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public KTTTNCNDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("KTTTNCNDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("KTTTNCNDbContext could not connect to database"));
        }
    }
}
