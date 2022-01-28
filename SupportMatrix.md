# Application Insights Profiler for ASP.NET Core Supported Matrix

## Quick choose

Which version of the Profiler to use largely rely on which .NET Core runtime is used. Choose the version accordingly:

* .NET 6: [2.3.1-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.1-beta3) or newer.

* .NET Core 3.1: [Latest Stable](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore)

* .NET 5: [Latest Stable](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore) (_Notes: 2.2.0-beta5 or above is recommended._) (Please migrate to .NET 6 ASAP, end of support on May 08, 2022).

## Deprecated

These are last known working versions. It is suggested to migrated to newer versions of .NET runtime.

* .NET Core 2.1: [1.1.7-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/1.1.7-beta2)
  * .NET Core 2.1 is when the profiler initially built and there's a level of unstable there. Upgrade to .NET Core 3.1 is recommended.

* .NET Core 2.2 / 3.0:
  .NET Core 2.2 / 3.0 is out of support. Please upgrade to .NET Core 3.1 when possible. There's no guarantee any profiler keeps working there. If you have to, try the versions list below that supported .NET Core 2.2 / 3.0.

## Details

The profiling technology is based on .NET Core runtime. We do not support applications run on .NET Framework. See the table below for supported runtime.

| Application Insights Profiler                                                                               | Windows (Experimental support)                                        | Linux                                  |
| ----------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------- | -------------------------------------- |
| [2.3.1-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.1-beta3) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5, .NET 6 Beta |
| [2.3.1-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.1-beta2) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5, .NET 6 Beta |
| [2.3.0](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.0)             | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.3.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.0-beta4) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.3.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.0-beta3) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.3.0-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.0-beta2) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.2.0](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0)             | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.2.0-beta7](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta7) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.2.0-beta6](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta6) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| 2.2.0-beta5                                                                                                 | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.2.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta4) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.2.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta3) | .NET Core App 3.1, .NET 5                                             | .NET Core App 3.1, .NET 5              |
| [2.2.0-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta2) | .NET Core App 3.1                                                     | .NET Core App 3.1                      |
| [2.2.0-beta1](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta1) | .NET Core App 3.1                                                     | .NET Core App 3.1                      |
| [2.1.0-beta5](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta5) | .NET Core App 2.2, 3.0, 3.1                                           | .NET Core App 2.2, 3.0, 3.1            |
| [2.1.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta4) | .NET Core App 2.2, 3.0, 3.1                                           | .NET Core App 2.2, 3.0, 3.1            |
| [2.1.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta3) | .NET Core App 2.2, 3.0, 3.1                                           | .NET Core App 2.2, 3.0, 3.1            |
| [2.1.0-beta1](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.1.0-beta1) | .NET Core App 2.2, 3.0, 3.1                                           | .NET Core App 2.2, 3.0, 3.1            |
| [2.0.0-beta5](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta5) | .NET Core App 2.2, 3.0                                                | .NET Core App 2.2, 3.0                 |
| [2.0.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta4) | .NET Core App 2.2, 3.0                                                | .NET Core App 2.2, 3.0                 |
| [2.0.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta3) | .NET Core App 2.2, 3.0                                                | .NET Core App 2.2, 3.0                 |
| [2.0.0-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta2) | .NET Core App 2.2, 3.0                                                | .NET Core App 2.2, 3.0                 |
| [2.0.0-beta1](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.0.0-beta1) | .NET Core App 2.2, 3.0                                                | .NET Core App 2.2, 3.0                 |
| [1.1.7-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/1.1.7-beta2) | .NET Core App 2.2, 3.0                                                | .NET Core App 2.1, 2.2, 3.0            |
| 1.1.7-beta1                                                                                                 | .NET Core App 2.2.                                                    | .NET Core App 2.1, 2.2                 |
| 1.1.6-beta1                                                                                                 | .NET Core App 2.2.                                                    | .NET Core App 2.1, 2.2                 |
| 1.1.5-beta2                                                                                                 | .NET Core App 2.2.                                                    | .NET Core App 2.1, 2.2                 |
| 1.1.4-beta1                                                                                                 | .NET Core App 2.2. Trace tree in the trace explorer looks very noisy. | .NET Core App 2.1, 2.2                 |
| 1.1.3-beta2                                                                                                 | Not supported.                                                        | .NET Core App 2.1, 2.2                 |
| 1.1.3-beta1                                                                                                 | Not supported.                                                        | .NET Core App 2.1, 2.2                 |
| 1.1.2-beta1                                                                                                 | Not supported.                                                        | Deprecated.                            |
| 1.0.0-beta1                                                                                                 | Not supported.                                                        | Deprecated.                            |
