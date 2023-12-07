using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class SampleFunctionApp
    {
        private readonly ILogger _logger;
        private readonly TelemetryClient _telemetryClient;

        public SampleFunctionApp(ILoggerFactory loggerFactory, TelemetryClient telemetryClient)
        {
            _logger = loggerFactory.CreateLogger<SampleFunctionApp>();
            _telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }

        [Function("SampleFunctionApp")]
        public void Run([TimerTrigger("*/30 * * * * *", RunOnStartup = true)] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            using (_telemetryClient.StartOperation<RequestTelemetry>("operation"))
            {
                if (myTimer.ScheduleStatus is not null)
                {
                    _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
                }
            }
        }
    }
}
