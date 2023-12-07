// -----------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------------

using Microsoft.ApplicationInsights.Profiler.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureLogging(logging =>
    {
        logging.AddConsole();
    })
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.AddServiceProfiler(p =>
        {
            p.Duration = TimeSpan.FromSeconds(10);
            p.UploadMode = UploadMode.Always;
        });
    })
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddUserSecrets<Program>(true);
    })
    .Build();

host.Run();
