# Release Note
## v1.0.0-beta1
Profiling the application and the services and monitoring the performance by using Application Insights Profiler. Beta1 is now available for testing on ASP.NET Core 2.0 Web Apps hosted in the Linux on Microsoft Azure App Services. Follow the `Get Started Guide [Coming soon]`, [Get the packages now](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Profiler.AspNetCore/1.0.0-beta1) and start your performance improvement adventures!

### Features
* Profiling the performance of the ASP.NET Core 2.0 Web Application on Linux.
* Trace/calling tree analysis.

### Known issues
* Enable button in Profiler Configuration pane does not work
**If you host your app using App Services Linux, you do not need to enable Profiler again in the Performance pane in App Insights portal. Including NuGet package in project and setting App Insights iKey in App Settings are sufficient to enable Profiler**
If you follow the [App Insights Profiler for Windows](./app-insights-profiler.md) enablement workflow to click **Enable** in the Configure Profiler pane, you will receive an error as the button will try to install the Windows version of profiler agent on Linux environment.
We are working on resolving this issue in the enablement experience.

![You don't need to enable the Profiler again in performance pane to make profiler work on Linux App Services](./media/issue-enable-profiler.png)


**[Feedbacks are welcome!](https://github.com/Microsoft/ApplicationInsights-Profiler-AspNetCore/issues)**
