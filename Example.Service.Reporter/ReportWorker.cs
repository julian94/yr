using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Service.Reporter;

public class ReportWorker(
    ILogger<ReportWorker> logger,
    IHostApplicationLifetime appLifetime,
    IList<ReportTask> tasks
    ) : IHostedService, IHostedLifecycleService
{
    Task IHostedLifecycleService.StartingAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    Task IHostedService.StartAsync(CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        foreach (var task in tasks)
        {
            if (task.Interval.Next(now) is DateTimeOffset next)
            {
                // better solution is needed, also this has a max of 49ish days.
                var t = Task.Delay(next - now, cancellationToken);

            }
        }

        logger.LogInformation("StartAsync has been called.");

        return Task.CompletedTask;
    }

    Task IHostedLifecycleService.StartedAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    Task IHostedLifecycleService.StoppingAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    Task IHostedService.StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    Task IHostedLifecycleService.StoppedAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
