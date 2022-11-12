using ServiceProfilerInWorkerNet6;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.AddSimpleConsole(c =>
        {
            c.SingleLine = true;
        });
    })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.AddServiceProfiler();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
