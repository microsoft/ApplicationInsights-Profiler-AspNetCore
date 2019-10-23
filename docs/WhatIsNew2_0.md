# What is New in Application Insights Profiler 2.0.0

## Profiler Now

The profiler is talking with the service profiler azure backend and will accept `Profile Now` requests from the portal.

You can use the `Profile Now` button in the portal and review the traces from the Azure Portal.

## New scheduling system

**Random scheduling policy** is used to replace the old fixed time scheduling system.

In previous versions (1.x), the scheduling system takes 3 parameters: initial delay, duration and interval. The Profiler will be started with an initial delay, run for duration and then pause for interval.

It is replaced by a random scheduling system/policy. A new parameter of `RandomProfilingOverhead` has been introduced. The random scheduling policy will calculate the profiling count based on the request overhead. For example, to calculate for the next 24 hours:

```shell
dn / 60 = 24 * r
```

In the formula above, `r` is the overhead rate, `d` is the duration, n is the number of profiling. Take duration of **2 minutes**, rate of **5%**, in the next **24 hours** as an example:

```shell
n = 24 * 0.05 * 60 / 2 = 36
```

Profiler will happen 36 times.

Notices, depends on the traffic and sampling and other factors, the real trace you get may be less than 36.

Also, if you watch carefully, you will see other scheduling policies like **OneTimeSchedulingPolicy**, which runs every time after the initial delay per app session. Profile Now is implemented by **OnDemandSchedulingPolicy**.

## CPU / Memory trigger support for Apps running on Windows

When Application Insights Profiler for ASP.NET Core NuGet package is included in an ASP.NET Core Application on **Windows**, **CPU triggers** and **Memory triggers** are supported.

The threshold for the triggers are 80% by default. The trigger policy will look back for 30 second, get the average resource usage and compare it with the threshold. When the value goes beyond the threshold, profiling will be triggered.

Notes: Although sharing the backend, this is different than the traditional Profiling [here](https://docs.microsoft.com/en-us/azure/azure-monitor/app/profiler-overview).

## Better container support for .NET Core 3.0 Application

* Uploaders for .NET Core Runtime 2.0 and .NET Core Runtime 3.0 are sim-shipped in the NuGet package. No more hacks needed to run the same profiler in both .NET Core 2.0 based containers as well as .NET Core 3.0 runtime based containers.

* In the scenario where you want to pull down the uploader in your dockerfile directly, we are now uploading the exact same uploader binaries on GitHub. Check them out in [Releases](https://github.com/microsoft/ApplicationInsights-Profiler-AspNetCore/releases).

## New customization options

* There are changes of options to control the profiling:

| Option                  | v2      | v1       | Remark                                                        |
|-------------------------|---------|----------|---------------------------------------------------------------|
| RandomProfilingOverhead | 0.05    | N/A      | Random profiling overhead percentage in float. The default value of 0.05 means 5%. |
| CPUTriggerThreshold     | 0.80    | N/A      | Windows only. Threshold for CPU profiling trigger.            |
| MemoryTriggerThreshold  | 0.80    | N/A      | Windows only. Threshold for memory profiling trigger.         |
| Interval                | Removed | 00:58:00 | Intervals between profiling. Replaced by random policy.       |
