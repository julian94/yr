using Example.Service.Reporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ReportWorker>();

IHost host = builder.Build();
host.Run();
