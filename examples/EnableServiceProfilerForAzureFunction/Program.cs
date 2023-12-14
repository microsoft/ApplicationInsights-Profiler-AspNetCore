// -----------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;

var host = new HostBuilder()
    .ConfigureLogging((ctx, logging) =>
    {
        logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
        logging.AddSimpleConsole(logging =>
        {
            logging.SingleLine = true;
            logging.UseUtcTimestamp = true;
            logging.TimestampFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
        });
    })
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.AddServiceProfiler(p =>
        {
            p.Duration = TimeSpan.FromSeconds(30);
        });
        services.ConfigureFunctionsApplicationInsights();
    })
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
