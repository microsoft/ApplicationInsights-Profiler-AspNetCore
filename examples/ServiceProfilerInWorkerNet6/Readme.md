# Application Insights Profiler for Worker Service Example

Follow this example to use `Microsoft.ApplicationInsights.Profiler.ASPNETCore` in `Worker Services` where there is no ASP.NET.

## Add NuGet Packages

These NuGet packages are needed:

```xml
<PackageReference Include="Microsoft.ApplicationInsights.WorkerService" Version="2.21.0" />
<PackageReference Include="Microsoft.ApplicationInsights.Profiler.AspNetCore" Version="2.5.0-alpha3">
```

See [ServiceProfilerInWorkerNet6.csproj](./ServiceProfilerInWorkerNet6.csproj) for details.

> ⚠️ The profiler package to support worker service `Microsoft.ApplicationInsights.Profiler.AspNetCore` is in alpha. Download **both** packages here: <https://github.com/xiaomi7732/ApplicationInsights-Profiler-AspNetCore/releases/tag/v2.5.0-alpha3>.

## Add application insights connection string in secrets

In this example, `UserSecrets` is used to protect the connection string. Choose your own way to set it up.

* Create an application insight resource if you haven't already. Note down the connection string.
* Create a file named `secrets.json` in current folder.
* Add content like this:

```jsonc
{
    "ApplicationInsights":
    {
        "ConnectionString": "InstrumentationKey=iKey;IngestionEndpoint=someurl/;LiveEndpoint=..."
    }
}
```
* Apply the user secrets:

```shell
type secrets.json | dotnet user-secrets set
```

You should see prompt like this:

```shell
Successfully saved 1 secrets to the secret store.
```

## Enable Application Insights and Profiler by code

Enable application insights and profiler by registering the services in the dependency injection container.

```csharp
services.AddApplicationInsightsTelemetryWorkerService();    // Enable Application Insights for Worker
services.AddServiceProfiler();                              // Enable Application Insights Profiler
```

See [Program.cs](./Program.cs) for more details.

## Manually instrument the code as request operations

As of today, Profiling is request based. You will need to instrument your code for Profiler to capture it. For example

```csharp
// These request operations will be captured by the profiler
using (_telemetryClient.StartOperation<RequestTelemetry>("operation"))
{
    // Simulate some operation that takes 200 ms to finish
    await Task.Delay(TimeSpan.FromMilliseconds(200), stoppingToken);
}
```

See [Worker.cs](./Worker.cs) for more details.

## Optionally configure the behavior of the profiler

For debugging, in [appsettings.Development.json](./appsettings.Development.json):

```jsonc
{
  ...
  "ServiceProfiler":{
    "Duration": "00:00:15",
    "PreserveTraceFile": true
  }
  ...
}
```
See [Customize Application Insights Profiler](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/blob/main/Configurations.md) for all available options.

## Run Profiler locally

Run the project locally, you will see logs like this:

```shell
info: ServiceProfilerInWorkerNet6.Worker[0]
      Worker running at: 11/01/2022 17:33:47 -07:00
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.ApplicationInsights.Profiler.Core.ServiceProfilerProvider[0]
      Service Profiler session started.                                         # Profiler started.
...
info: Microsoft.ApplicationInsights.Profiler.Core.ServiceProfilerProvider[0]
      Service Profiler session finished.                                        # Profiler finished.
...
```