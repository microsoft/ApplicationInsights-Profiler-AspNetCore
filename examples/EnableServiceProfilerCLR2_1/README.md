# Enable Service Profiler for containerized ASP.NET Core application

Enable Service Profiler for ASP.NET Core application running in Linux Container is very easy and almost code free.

This example assumes you already have an ASP.NET Core Application. If you are new to ASP.NET, follow the Get Started for [.NET Core 2.1 SDK](https://dot.net) or just clone and use this project.

This example is a bare bone project created by calling the following cli command:

```shell
dotnet new mvc -n AppInsightsProfilerExample
```

To make it real, make use the following code to add some delay in the controllers to simulate the bottleneck:

```CSharp
private void SimulateDelay()
{
    // Delay for 500ms to 2s to simulate a bottleneck.
    Thread.Sleep((new Random()).Next(500, 2000));
}
```

Reference [HomeController.cs](./Controllers/HomeController.cs) for full code.

## Reference Application Insights SDK

_Note:_ You can skip this step if you are using 1.1.3-beta1 or above.

Due to a recent CLR image change, adding a reference to Application Insights SDK manually became required. We are looking into removing this step later (fixed in 1.1.3-beta2).

For now, adding the package by:

```shell
dotnet add package Microsoft.ApplicationInsights.AspNetCore
```

Once executed, you will see the following package being added to [AppInsightsProfilerExample.csproj](AppInsightsProfilerExample.csproj):

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.ApplicationInsights.AspNetCore" Version="2.3.0" />
  </ItemGroup>
```

## Create a Dockerfile for the application

To enable Service Profiler, NuGet package needs to be installed and proper environment variables need to be set. One way to reach the goal is adding the following lines to your [Dockerfile](./Dockerfile):

```docker
...
# Adding a reference to hosting startup package
RUN dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 2.2.0-*
...
# Light up Application Insights for Kubernetes
ENV APPINSIGHTS_INSTRUMENTATIONKEY YOUR_APPLICATION_INSIGHTS_KEY
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES Microsoft.ApplicationInsights.Profiler.AspNetCore
...
```

* The first line adds the reference to the NuGet package of Service Profiler before the build of the project happens.
* The second line sets the instrumentation key to Application Insights so that the application knows where to send the trace to.
* The third line sets the boot strapper for Service Profiler.

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

```shell
docker build -t appinsights-profiler-example --build-arg APPINSIGHTS_KEY=YOUR_APPLICATION_INSIGHTS_KEY .
docker run -p 8080:80 --name appinsights-profiler-example appinsights-profiler-example
```

Note, replace **YOUR_APPLICATION_INSIGHTS_KEY** with the real instrumentation key from the previous step.

Once the container starts to run, the Service Profiler will kick in for 2 minutes.

## View the web page running from a container

Go to [localhost:8080](http://localhost:8080) to access your app in a web browser. Use this chance to generate some web traffic for the Service Profiler to catch the traces.

## Inspect the logs

If you have set up the Log Level to Information for Service Profiler and you run the container attached, you will see the info logs like it below:

```shell
info: ServiceProfiler.EventPipe.Client.Schedules.TraceSchedule[0]
      Service Profiler session started.
info: ServiceProfiler.EventPipe.Client.Schedules.TraceSchedule[0]
      Service Profiler session finished. Samples: 8
info: ServiceProfiler.EventPipe.Client.TraceUploader.TraceUploaderProxy[0]
      Finished calling trace uploader. Exit code: 0
```

When you see Samples number larger than 0, it means trace has been gathered.

You can also check the logs for the container:

```shell
docker container logs myapp
```

## View the Service Profiler traces

* Wait for 2-5 minutes so the events can be aggregated to Application Insights.
* Open the **Performance** blade in the application insights resource created. Once the process of the trace is done, you will see the Profiler Traces button like it below:

![Profiler Traces](../../media/performance-blade.png)

## Summary

To recap a bit, there are 2 major steps to enable Service Profiler:

* Add the reference to the NuGet package.
* Set the environment variables to enable it.

There are various ways to reach the same goal. The NuGet package could be installed in the project. The environment variable could be set by the orchestrator (like Kubernetes) as well.

And when it comes to production deployment, there are also other aspects to be considered, like the security. For example, how to protect Application Insights Instrumentation key from being leaked and so on.

All in all, we hope the Service Profiler will help improve the application performance! If you have any issues or suggestions, please report to [issues](https://github.com/Microsoft/ApplicationInsights-Profiler-AspNetCore/issues).
