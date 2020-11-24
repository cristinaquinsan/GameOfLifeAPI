using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeAPI
{
    public class HealthChecks : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var healthCheckStatus = File.OpenRead("C:\\Users\\cquintana\\source\\repos\\GameOfLifeAPI\\healthlogs.txt");
                healthCheckStatus.Flush();
                healthCheckStatus.Close();
                return Task.FromResult(HealthCheckResult.Healthy("A healthy result!"));
            }
            catch
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("An unhealthy result!"));
            }
        }
    }
}
