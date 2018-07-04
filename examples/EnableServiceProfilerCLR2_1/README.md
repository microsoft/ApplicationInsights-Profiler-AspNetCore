# Enable Service Profiler for containerized ASP.NET Core application
Enable Service Profiler for ASP.NET Core application running in Linux Container is very easy and almost code free.

This example assumes you already have an ASP.NET Core Application. If you are new to ASP.NET, follow the Get Started for [.NET Core 2.1 SDK](https://dot.net) or just clone and use this project.

This example is a barebone project created by calling the following cli command:
```
dotnet new mvc -n AppInsightsProfilerExample
```

## Create a Dockerfile for the application
To enable Service Profiler, NuGet package needs to be installed and proper environment variables need to be set. One way to reach the goal is adding the following lines to your [Dockerfile](./Dockerfile):
```docker
...
# Adding a reference to hosting startup package
RUN dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 1.1.2-beta1
...
# Light up Application Insights for Kubernetes
ENV APPINSIGHTS_INSTRUMENTATIONKEY YOUR_APPLICATION_INSIGHTS_KEY
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES Microsoft.ApplicationInsights.Profiler.AspNetCore
...
```
* The first line adds the reference to the NuGet package of Service Profiler before the build of the project happens.
* The second line sets the instrumentation key to Application Insights so that the application knows where to send the trace to.
* The third line sets the bootstrapper for Service Profiler.

*To make your build context as small as possible add a [.dockerignore](.dockerignore) file to your project folder.*

Reference the full [Dockerfile](./Dockerfile), you will notice it is a bit different. The major change is that **YOUR_APPLICATION_INSIGHTS_KEY** has been pulled out to become an argument - the main consideration is for the code security.

## Create an Application Insights resource
Follow the [Create an Application Insights resource](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-create-new-resource). Note down the [instrumentation key](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-create-new-resource#copy-the-instrumentation-key).

## Optionally set the log level to Information for Service Profiler
To see a simple log, you can add the following settings to appsettings.json to reveal some Service Profiler logs:
```json
    "LogLevel": {
      "Default": "Warning",
      "ServiceProfiler":"Information"
    }
```
Just like in [appsettings.json](./appsettings.json).

## Build and run the Docker image
```bash
$ docker build -t appinsights-profiler-example --build-arg APPINSIGHTS_KEY=YOUR_APPLICATION_INSIGHTS_KEY .
$ docker run -p 8080:80 --name appinsights-profiler-example appinsights-profiler-example
```
Note, replace **YOUR_APPLICATION_INSIGHTS_KEY** with the real instrumentation key from the previous step.

Once the container starts to run, the Service Profiler will kick in for 2 minutes.