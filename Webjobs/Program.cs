using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Webjobs;

namespace WebJobs
{
    internal class Program
    {
        private static async void Main()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new HostBuilder()
                .UseEnvironment(environment)
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices()
                        // This is for QueueTrigger support
                        .AddAzureStorage(options =>
                        {
                            options.BatchSize = 1;
                            options.MaxPollingInterval = TimeSpan.FromSeconds(10);
                            options.VisibilityTimeout = TimeSpan.FromSeconds(30);
                        });
                })
                .ConfigureAppConfiguration(b =>
                {
                    b.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Debug);

                    // If this key exists in any config, use it to enable App Insights
                    string appInsightsKey = context.Configuration.GetSection("ApplicationInsights")["WebJobsInstrumentationKey"];
                    if (!string.IsNullOrEmpty(appInsightsKey))
                    {
                        b.AddApplicationInsights(o => o.InstrumentationKey = appInsightsKey);
                    }
                })
                .UseConsoleLifetime()          
                .ConfigureServices((context, services) =>
                 {
                     // Configure all DI classes here
                     services.AddTransient<ActionProcessor, ActionProcessor>();
                 });

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}