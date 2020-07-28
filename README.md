# Application Insights Profiler for ASP.NET Core

## Announcement

* Profiler 2.1.0-beta4 is published. Please find the NuGet package here: [2.1.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore).

## Previous announcements

* Profiler 2.1.0-beta2 is **NOT** recommended. There is a bug that impacts the ASP.NET Core application starting up. See bug #85 for details. Please wait for 2.1.0-beta3.

* Profiler 2.1.0-beta1 is [available now](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta1). Read [What's new](./docs/WhatIsNew2_0.md) and [Migrate to Application Insights Profiler 2.0](./docs/MigrateTo2_0.md). Follow the example of [quick start](./examples/QuickStart3_0/Readme.md) if you are building a new app service.

  * [Break change] Application Insights Profiler 2.1.0-* depends on [Application Insights SDK for ASP.NET Core 2.12.0](https://www.nuget.org/packages/Microsoft.ApplicationInsights.AspNetCore/2.12.0) and above. It will be referenced implicitly.

  * [New Feature] Hosting startup for ASP.NET Core 3.x application is supported for 2.1.0-beta1 and above. Refer to [readme](examples/HostingStartupCLR3/Readme.md) for how to use it.

  * Recent bug fixes:
    * Reduce uploader size by having targeted binaries. [#70](../../issues/70)
    * Application Insights connection string is supported. Check out the usage in [Configurations](./Configurations.md#Application-Insights-Connection-String).

## Description

This is the project home page for `Microsoft Application Insights Profiler for ASP.NET Core`. The NuGet package can be found [here](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/).

![Profiler Traces](./media/profiler-traces.png)

## Get Started

Refer to [Quick Start](./examples/QuickStart3_0/Readme.md) for more specific steps for ASP.NET Core 3.0 projects._

* Create an application

```shell
dotnet new webapi
```

* Add NuGet packages

```shell
dotnet add package Microsoft.ApplicationInsights.AspNetCore
dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 2.1.0-*
```

* Enable Application Insights Profiler

Open [Startup.cs](./examples/QuickStart3_0/Startup.cs)

```csharp
using System.Diagnostics;
...
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    ...
    // Adding the following lines to enable application insights and profiler.
    services.AddApplicationInsightsTelemetry();
    services.AddServiceProfiler();
}
```

* Add a bottleneck

To make it real, make use the following code to add some delay in the [WeatherForecastController.cs](examples/QuickStart3_0/Controllers/WeatherForecastController.cs) to simulate the bottleneck:

```csharp
using System.Threading;
...
private void SimulateDelay()
{
    // Delay for 200ms to 5s to simulate a bottleneck.
    Thread.Sleep((new Random()).Next(200, 5000));
}
```

And call it from the controller methods:

```csharp
[HttpGet]
public IEnumerable<WeatherForecast> Get()
{
    SimulateDelay();
    var rng = new Random();
    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    ...
}
```

* Setup the instrumentation key for debugging

In [appsettings.Development.json](examples/QuickStart3_0/appsettings.Development.json), add the following configuration:

```jsonc
{
    ...
    "ApplicationInsights": {
        "InstrumentationKey": "replace-with-your-instrumentation-key"
    }
    ...
}
```

* Run the WebAPI, generate traffic for profiling

To run your application locally:

```shell
dotnet run
```

At the beginning of the application, **OneTimeSchedulingPolicy** will immediately kick in, profiling for 2 minutes. Hit the endpoint in a browser during the profiling session in your browser:

```url
https://localhost:5001/weatherforecast
```

* Analyze the trace form Azure Portal

Get a coffee and wait for a couple of minutes - the backend needs some time, usually a 2 minutes, to ingest the data.

Then, open the application insights resource in Azure Portal, go to the **performance** blade, and use the button of `Configure Profiler`. There, you are going to see all profiling sessions:

![Profiler Trace Sessions](./media/OneTimeProfilerTrace.png)

_Tip: Click on the trace to open the trace analyzer._

## Next

* [Configurations for the Profiler](./Configurations.md) - describes how to customize various settings of the profiler.
* [Dockerize an application with Profiler](./examples/QuickStart3_0/Readme2.md)
* [Profiler Sessions](./ProfilerSessions.md) - describes when the profiler starts, stops and what is traced.
* [Trace Analysis](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-profiler-overview?toc=/azure/azure-monitor/toc.json#view-profiler-data) - introduce the trace analysis.
* [Diagnosing a WebAPI experiencing intermittent high CPU using the Application Insights Profiler](https://github.com/Azure/azure-diagnostics-tools/blob/master/Profiler/TriggerProfiler.md).
* [The call tree filter](https://github.com/Azure/azure-diagnostics-tools/blob/master/Profiler/CallTreeFilter.md).

## Supported Versions

The profiling technology is based on .NET Core runtime. We do not support applications run on .NET Framework. See the table below for supported runtime.

| Application Insights Profiler                                                                               | Windows                                                                                        | Linux                                     |
|-------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------|-------------------------------------------|
| [2.1.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta4) | Experimental support for .NET Core App 2.2, 3.0, 3.1                                           | Supported for .NET Core App 2.2, 3.0, 3.1 |
| [2.1.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta3) | Experimental support for .NET Core App 2.2, 3.0, 3.1                                           | Supported for .NET Core App 2.2, 3.0, 3.1 |
| [2.1.0-beta1](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta1) | Experimental support for .NET Core App 2.2, 3.0, 3.1                                           | Supported for .NET Core App 2.2, 3.0, 3.1 |
| [2.0.0-beta5](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta5) | Experimental support for .NET Core App 2.2, 3.0                                                | Supported for .NET Core App 2.2, 3.0      |
| [2.0.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta4) | Experimental support for .NET Core App 2.2, 3.0                                                | Supported for .NET Core App 2.2, 3.0      |
| [2.0.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta3) | Experimental support for .NET Core App 2.2, 3.0                                                | Supported for .NET Core App 2.2, 3.0      |
| [2.0.0-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta2) | Experimental support for .NET Core App 2.2, 3.0                                                | Supported for .NET Core App 2.2, 3.0      |
| [2.0.0-beta1](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta1) | Experimental support for .NET Core App 2.2, 3.0                                                | Supported for .NET Core App 2.2, 3.0      |
| [1.1.7-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/1.1.7-beta2) | Experimental support for .NET Core App 2.2, 3.0                                                | Supported for .NET Core App 2.1, 2.2, 3.0 |
| 1.1.7-beta1                                                                                                 | Experimental support for .NET Core App 2.2.                                                    | Supported for .NET Core App 2.1, 2.2      |
| 1.1.6-beta1                                                                                                 | Experimental support for .NET Core App 2.2.                                                    | Supported for .NET Core App 2.1, 2.2      |
| 1.1.5-beta2                                                                                                 | Experimental support for .NET Core App 2.2.                                                    | Supported for .NET Core App 2.1, 2.2      |
| 1.1.4-beta1                                                                                                 | Experimental support for .NET Core App 2.2. Trace tree in the trace explorer looks very noisy. | Supported for .NET Core App 2.1, 2.2      |
| 1.1.3-beta2                                                                                                 | Not supported.                                                                                 | Supported for .NET Core App 2.1, 2.2      |
| 1.1.3-beta1                                                                                                 | Not supported.                                                                                 | Supported for .NET Core App 2.1, 2.2      |
| 1.1.2-beta1                                                                                                 | Not supported.                                                                                 | Deprecated.                               |
| 1.0.0-beta1                                                                                                 | Not supported.                                                                                 | Deprecated.                               |

## Examples

* [Enable Service Profiler for containerized ASP.NET Core application (.NET Core 3.x)](./examples/QuickStart3_0/Readme.md).

* [Enable Service Profiler for containerized ASP.NET Core application (.NET Core 2.x)](./examples/EnableServiceProfilerCLR2_1/README.md).

* [Enable Service Profiler for ASP.NET Core application in Visual Studio](./examples/EnableServiceProfilerInVSCLR2_1).

## References

* [Profile ASP.NET Core Azure Linux web apps with Application Insights Profiler](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-profiler-aspnetcore-linux)

## CAUTION

This is a documentation/sample repository. The [LICENSE](LICENSE) covers the content in this repository but does **NOT** cover the use of the product of Microsoft.ApplicationInsights.Profiler.AspNetCore. Please reference [EULA-prerelease.md](EULA-prerelease.md) for any prerelase product and [EULA-GA.md](EULA-GA.md) for any non-prerelease product.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
