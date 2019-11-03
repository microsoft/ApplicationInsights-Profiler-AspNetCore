# Application Insights Profiler for Asp.Net core on Linux App Services

## Announcement

* Profiler 2.0.0-beta2 is [available now](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta2). Read [What's new](./docs/WhatIsNew2_0.md) and [Migrate to Application Insights Profiler 2.0](./docs/MigrateTo2_0.md). Follow the example of [quick start](./examples/QuickStart3_0/Readme.md) if you are building a new app service.

* Fixed the issue in 2.0.0-beta1 that blob can't be found by the trace analyzer when the app is hosted in app service on Windows platform.

## Description

This is the project home page for `Microsoft Application Insights Profiler for ASP.NET Core`. The NuGet package can be found [here](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/).

![Profiler Traces](./media/profiler-traces.png)

## Get Started

_The following steps based are based on ASP.NET Core 2.2 project. Refer to [Quick Start](./examples/QuickStart3_0/Readme.md) for more specific steps for ASP.NET Core 3.0 projects._

* Create a WebApi project

    ```shell
    dotnet new webapi -n ProfilerEnabledWebAPI
    ```

To make it real, make use the following code to add some delay in the controllers to simulate the bottleneck:

```CSharp
using System.Threading;
...
private void SimulateDelay()
{
    // Delay for 500ms to 2s to simulate a bottleneck.
    Thread.Sleep((new Random()).Next(500, 2000));
}
```

And call it from the controller methods:

```CSharp
// GET api/values
[HttpGet]
public ActionResult<IEnumerable<string>> Get()
{
    SimulateDelay();  // Bottleneck
    return new string[] { "value1", "value2" };
}

// GET api/values/5
[HttpGet("{id}")]
public ActionResult<string> Get(int id)
{
    SimulateDelay();  // Bottleneck
    return "value";
}
```

Reference [ValuesController.cs](./examples/EnableServiceProfilerInVSCLR2_2_Win/EnableSPInVSWin/Controllers/ValuesController.cs) for full code.

* Add the NuGet packages

    ```shell
    dotnet add package Microsoft.ApplicationInsights.AspNetCore
    dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 2.0.0-*
    ```

    _Note: Find the latest package from the [NuGet.org here](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/)._

* [Create an Application Insights in Azure Portal](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-dotnetcore-quick-start?toc=/azure/azure-monitor/toc.json#log-in-to-the-azure-portal), set Application Insights instrumentation key in `appsettings.Development.json`:

    ```json
    {
        "ApplicationInsights": {
            "InstrumentationKey": "replace-with-your-instrumentation-key"
        }
    }
    ```

* Enable Profiler in `Startup.cs`:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetry(); // Enable Application Insights telemetry
        services.AddServiceProfiler(); // Add this line of code to Enable Profiler
        ...
    }
    ```

* Run the code:

    ```shell
    dotnet run
    ```

    And you will see the following logs, indicating Profiler is up and running:

    ```shell
    dbug: ServiceProfiler.EventPipe.AspNetCore.ServiceProfilerStartupFilter[0]
        Constructing ServiceProfilerStartupFilter
    dbug: ServiceProfiler.EventPipe.AspNetCore.ServiceProfilerStartupFilter[0]
        User Settings:
        {
            "BufferSizeInMB": 250,
        }
    dbug: ServiceProfiler.EventPipe.Client.Utilities.RuntimeCompatibilityUtility[0]
        Checking compatibility for Linux platform.
    dbug: ServiceProfiler.EventPipe.AspNetCore.ServiceProfilerStartupFilter[0]
        Pass Runtime Compatibility test.
    dbug: ServiceProfiler.EventPipe.Client.Schedules.TraceSchedule[0]
        Entering TriggerStart - initial: True.
    dbug: ServiceProfiler.EventPipe.Client.Schedules.TraceSchedule[0]
        Entering StartAsync, idle for the interval of 3000 ms.
    Hosting environment: Development
    Content root path: /mnt/d/ApplicationInsightsProfiler
    Now listening on: https://localhost:5001
    Now listening on: http://localhost:5000
    Application started. Press Ctrl+C to shut down.
    ...
    ```

You have been start to run the the WebApi with Profiler on.

* Generate some traffic for traces by visiting during the 2 minutes profiling session:

    ```url
    https://localhost:5001/api/values
    ```

## Learn More

* [Profiler Sessions](./ProfilerSessions.md) - describes when the profiler starts, stops and what is traced.
* [Configurations for the Profiler](./Configurations.md) - describes how to customize various settings of the profiler.
* [Trace Analysis](./https://docs.microsoft.com/en-us/azure/application-insights/app-insights-profiler-overview?toc=/azure/azure-monitor/toc.json#view-profiler-data) - introduce the trace analysis.
* [Diagnosing a WebAPI experiencing intermittent high CPU using the Application Insights Profiler](https://github.com/Azure/azure-diagnostics-tools/blob/master/Profiler/TriggerProfiler.md).
* [The call tree filter](https://github.com/Azure/azure-diagnostics-tools/blob/master/Profiler/CallTreeFilter.md).

## Supported Versions

| Application Insights Profiler                                                                               | Windows                                                                                        | Linux                                     |
|-------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------|-------------------------------------------|
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

* [Enable Service Profiler for containerized ASP.NET Core application](./examples/EnableServiceProfilerCLR2_1/README.md).

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
