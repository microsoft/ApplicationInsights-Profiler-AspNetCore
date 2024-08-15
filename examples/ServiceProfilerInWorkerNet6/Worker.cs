using HeavyArrayForecast;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace ServiceProfilerInWorkerNet6;

public class Worker : BackgroundService
{
    private readonly TelemetryClient _telemetryClient;
    private readonly ILogger _logger;

    public Worker(
        TelemetryClient telemetryClient,
        ILogger<Worker> logger)
    {
        _telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            // These request operations will be captured by the profiler
            using (_telemetryClient.StartOperation<RequestTelemetry>("operation"))
            {
                _ = WeatherForecastHelper.GetForecasts();
                _logger.LogInformation("Wether reported.");
            }

            // Wait for 10 seconds, do not repeat too frequently.
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}
