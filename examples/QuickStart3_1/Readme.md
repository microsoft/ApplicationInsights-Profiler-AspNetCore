# Quick Start (.NET Core 3.1 WebAPI)

> ⚠️ .NET Core 3.x has reached its end of support. For information on upgrading, please visit <https://dot.net>.

## Build the solution

Refer to the same steps to build a [WebAPI for .NET 3.0](../QuickStart3_0/Readme.md).

## To run this example locally

* Create an Application Insights resource in Azure, refer to [Create workspace-based resource](https://docs.microsoft.com/en-us/azure/azure-monitor/app/create-workspace-resource) for instructions.
  * Note down the connection string.

* Update the connection string in [appsettings.Development.json](appsettings.Development.json).

  ```jsonc
  {
    ...
    "ApplicationInsights": {
        "ConnectionString": "__ReplaceWithYourConnectionString__"
    }
  }
  ```

* Run the code

  ```shell
  dotnet run
  ```

Example of a successful log locally:

```shell
> PS D:\Repos\profiler\examples\QuickStart3_1> dotnet run
info: Microsoft.ApplicationInsights.Profiler.Core.IServiceProfilerContext[0]
      Profiler Endpoint: https://profiler.monitor.azure.com/
info: Microsoft.ApplicationInsights.Profiler.AspNetCore.ServiceProfilerStartupFilter[0]
      Starting application insights profiler with instrumentation key: your-ikey-will-show-up-here
info: Microsoft.ApplicationInsights.Profiler.Core.ServiceProfilerProvider[0]
      Service Profiler session started.
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: D:\Repos\fork-ai-profiler\examples\QuickStart3_1
info: Microsoft.ApplicationInsights.Profiler.Core.UploaderProxy.TraceUploaderProxy[0]
      Finished calling trace uploader. Exit code: 0
info: Microsoft.ApplicationInsights.Profiler.Core.ServiceProfilerProvider[0]
      Service Profiler session finished.
```
