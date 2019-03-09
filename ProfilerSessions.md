# Profiler Sessions

## Session life cycles

Running Profiler comes with overheads. It is **not** wise to keep profiler always running. Application Insights Profiler splits the profiling into sessions.

By default, a typical profiling session lasts for `2 minutes`. During these 2 minutes, stacks are sampled and the data are all serialized into the memory called a `Circular Buffer`. At the end of the 2 minutes, the buffer will be dump into a trace file (*.netperf).

After finish one session, the Profiler will idle for `58 minutes`, waiting for the next session to start.

At the same time, if there are `interesting activities` in the trace file, it will be uploaded to Azure back-end, getting ready for analysis.

All these happens on a separate threads and shall not blocking any of the code running in ASP.NET Core.

## Interesting Activities

For websites, like ASP.NET Core MVC applications, ASP.NET Core WebAPI and so on, only requests will be treated as `interesting activities`. Traces will be uploaded for analysis only when there are requests to the service during a profiling session.

Requests could be issued to the service manually in a browser or use curl like it below:

```shell
curl https://localhost:5001/api/values
```

There are also automation options like [Azure Monitor availability tests](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-monitor-web-app-availability) and so on.

If you are running the service locally with debug logs, you will see logs like it below when a request is captured by the profiler:

```shell
dbug: ServiceProfiler.EventPipe.Client.EventListeners.TraceSessionListener[0]
      Sample is added. {"ActivityIdPath":"/#4550/1/1/1/","StartTimeUtc":"2018-12-14T21:25:31.1368237+00:00","StopTimeUtc":"2018-12-14T21:25:32.2831271+00:00","RequestId":"|3d89f447-4cc29728c6a81ec4.","RoleInstance":"Computer","OperationName":"GET Values/Get","OperationId":"3d89f447-4cc29728c6a81ec4"}
```

## Customize Profiling Sessions

The default settings might satisfy most profiling cases, there are cases you want to control the life cycles of the sessions. There are ways to [configure all these session life cycle parameters](./Configurations.md).

## Next step

* [View profiler data in Azure Portal](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-profiler-overview?toc=/azure/azure-monitor/toc.json#view-profiler-data).
