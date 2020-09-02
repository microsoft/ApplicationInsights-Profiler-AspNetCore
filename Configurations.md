# Customize Application Insights Profiler

## Ways of settings

There are several ways to customize the [profiler session life cycle](./ProfilerSessions.md) and other aspects of the profiler. Here's some common ways.

Generally, all Profiler sessions stays in the section of `ServiceProfiler`. The following settings will all short the session duration to 30 seconds, and it will also set the interval between sessions to 10 minutes.

### Using `appsettings.json`

```jsonc
{
  "ServiceProfiler": {
    "Duration": "00:00:30",
    "Interval": "00:10:00"
    // ...
  }
}
```

### Using environment variables

```bash
export ServiceProfiler__Duration="00:00:30"
export ServiceProfiler__Interval="00:10:00"
```

_Notice that `__` (2 underscores) are used to separate sections._

### Using the code

Overloads are provided to allow customize settings directly in code:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddServiceProfiler(options =>
    {
        options.Duration = TimeSpan.FromSeconds(30);
        options.Duration = TimeSpan.FromMinutes(10);
        // ... more options.
    });
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

All other ways document here: [Configuration in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2) are also supported.

## Configuration References

Here lists all supported configurations.

| Key                               | Value/Types | Default Value | Description                                                                                                                                                                                                                       |   |
|-----------------------------------|-------------|---------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---|
| BufferSizeInMB                    | Integer     | 250           | Circular Buffer size. For 2 minutes session, it usually generates less than 200MB traces. Reduce the size for saving resources, increase the size for longer sessions.                                                            |   |
| Duration                          | TimeSpan    | 00:02:00      | The duration of a session.                                                                                                                                                                                                        |   |
| InitialDelay                      | TimeSpan    | 00:00:00      | Delay before starting the very first session after the application starts up.                                                                                                                                                     |   |
| ConfigurationUpdateFrequency      | TimeSpan    | 00:00:05      | The frequency for configuration updates for triggers or on demand profiling. This configuration decides how frequent the agent pulls configurations from the server. Optional, default value is 5 seconds            |   |
| ProvideAnonymousTelemetry         | Boolean     | true          | Sends anonymous telemetry data to Microsoft to make the product better when sets to true.                                                                                                                                         |   |
| RandomProfilingOverhead           | Float       | 0.05          | The overhead for random profiling. The rate, in form of percentage, is used to calculate the time of profiling in average per hour. Basically, n = (60 * overhead rate) / profiling-duration. Default value is 0.05. |   |
| IsDisabled                        | Boolean     | false         | Kill switch to turn off Profiler.                                                                                                                                                                                                 |   |
| IsSkipCompatibilityTest           | Boolean     | false         | Bypass the check of platform compatibility testing to turn Profiler on by force. This is introduced mainly for internal use for evaluation and might cause unexpected result.                                                     |   |
| SkipUpload                        | Boolean     | false         | Skip uploading the traces to the back-end. Notice: Skipping uploading will always preserve the trace file.                                                                                                                        |   |
| PreserveTraceFile                 | Boolean     | false         | The trace file will be deleted once uploaded by default. Set this to true when you want to keep the local trace files.                                                                                                            |   |
| SkipEndpointCertificateValidation | Boolean     | false         | The value to skip the certificate validation to establish SSL communication with the Endpoint. It is **strongly recommended** to keep this the default value.                                                                  |   |
| LocalCacheFolder                  | String      | User's temp folder. | Path to the folder for temporary working files, traces for example. The default value is the temp folder depends on the OS. `/tmp/` on linux for example, or `%UserProfile%\temp\` on Windows. Set the value to overwrite it if the default folder happens to be read-only. This setting only available for 2.1.0-beta6 or above. |   |

## Sets the logging level for Profiler

Sometimes, the Profiler might not run as expected. Set the log level to `Debug` or `Trace` will reveal a lot of related information. On the other hand, once running normally, set the log level to `Information` or above to reduce noise.

To do that, in `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "ServiceProfiler": "Debug"
    }
  }
}
```

Here's a complete example of `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "ServiceProfiler": "Debug"
    }
  },
  "AllowedHosts": "*",
  "ServiceProfiler": {
    "IsDisabled": false,
    "Duration": "00:00:30",
    "Interval": "00:10:00",
    "InitialDelay": "00:00:03",
    "ProvideAnonymousTelemetry": true,
    "IsSkipCompatibilityTest": false
  },
  "ApplicationInsights": {
    "InstrumentationKey": "application-insights-instrumentation-key"
  }
}
```

## Application Insights Connection String

Application Insights connection string is also supported (For Profiler 2.1.0-beta1 or above) in configuration. For example:

```jsonc
{
...
  "ServiceProfiler": {
...
  },
  "ApplicationInsights": {
    "ConnectionString": "InstrumentationKey=your-instrumentation-key;IngestionEndpoint=https://anotheringestionEndpoint.io/;..."
  },
}
```

A proper connection string could be found in the Application Insights Resource overview page of the Azure Portal, right below the `Instrumentation Key` field.
