# Release Note [Deprecated]

**We are deprecating this page.** All the information here is either covered by the [milestones](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/milestones?state=closed) or implied by the semantic versions.

If you are deciding which version to use for your application, check out the [Support Matrix](./SupportMatrix.md) page.

## Stable

### 2.2.0

* Find the NuGet package: [2.2.0](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0).
  * We are officially out of beta.

## Previews

### 2.3.0-beta3

* Find the NuGet package: [2.3.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.3.0-beta3).
  * Find out update details in the [milestone](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/milestone/13).

### 2.2.0-beta7

* Find the NuGet package here: [2.2.0-beta7](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta7).
  * Find out update details in the [milestone](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/milestone/12?closed=1).

### 2.2.0-beta6

* Find the NuGet package here: [2.2.0-beta6](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta6).
  * Fix the issue of Uploader not exit in the 2.2.0-beta5. Details: [#124](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/issues/124).

### 2.2.0-beta5

* Find the NuGet package here: 2.0.0-beta5
  * Release the Uploader for .NET 5.0 applications. Recommend upgrade for .NET 5 applications.
  * Find out update details in the [milestone](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/milestone/11?closed=1).

### 2.2.0-beta4

* NuGet package: [2.2.0-beta4](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta4).
  * Fixed a memory leak and some reliability issues.
  * Checkout [the milestone](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/milestone/9?closed=1) for details.

### 2.2.0-beta3

* NuGet package: [2.2.0-beta3](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta3).
  * Supports .NET 5.
  * Some other small bug fixes. Checkout [the milestone](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/milestone/8?closed=1) for details.

### 2.2.0-beta2

* NuGet package: [2.2.0-beta2](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta2).
  * Fix the bug that blocks the Profiler to work with Microsoft.ApplicationInsights.AspNetCore 2.15.
  * Some other small bug fixes.

### 2.2.0-beta1

* NuGet package: [2.2.0-beta1](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/2.2.0-beta1).
  * Fixed profiler failing for deploy to Azure WebSite on Windows due to permissions to fetch performance counters (#93).
  * Switch to new API to control profiling start/stop.

### v1.0.0-beta1

Profiling the application and the services and monitoring the performance by using Application Insights Profiler. Beta1 is now available for testing on ASP.NET Core 2.0 Web Apps hosted in the Linux on Microsoft Azure App Services. Follow the `Get Started Guide [Coming soon]`, [Get the packages now](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/1.0.0-beta1) and start your performance improvement adventures!

#### Features

* Profiling the performance of the ASP.NET Core 2.0 Web Application on Linux.
* Trace/calling tree analysis.

#### Known issues

* Enable button in Profiler Configuration pane does not work

**If you host your app using App Services Linux, you do not need to enable Profiler again in the Performance pane in App Insights portal. Including NuGet package in project and setting App Insights Connection String in App Settings are sufficient to enable Profiler**
If you follow the [App Insights Profiler for Windows](https://docs.microsoft.com/azure/application-insights/app-insights-profiler) enablement workflow to click **Enable** in the Configure Profiler pane, you will receive an error as the button will try to install the Windows version of profiler agent on Linux environment.
We are working on resolving this issue in the enablement experience.

![You don't need to enable the Profiler again in performance pane to make profiler work on Linux App Services](https://raw.githubusercontent.com/Microsoft/ApplicationInsights-Profiler-AspNetCore/master/media/issue-enable-profiler.PNG)

**[Feedbacks are welcome!](https://github.com/Microsoft/ApplicationInsights-Profiler-AspNetCore/issues)**
