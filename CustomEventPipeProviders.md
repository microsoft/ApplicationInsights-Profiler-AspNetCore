# Support Custom EventPipe Providers (preview)

// TODO: Description

## Steps

1. Apply default providers;
1. Add the providers you want.
   1. For example: [Well-known event providers in .NET](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/well-known-event-providers)

> ⚠️ Once the custom providers is provided, all the default providers will be turned off.

> ⚠️ At this moment, profiler won't upload/show up in Azure Portal if the default providers are off. Please only **append** your providers below.

## The default providers

```json
{
  "ApplicationInsights": {
    // Application insights settings. for example, the connection string...
  },
  "ServiceProfiler": {
    "CustomEventPipeProviders": [
      { "name": "Microsoft-Windows-DotNETRuntime", "eventLevel": "Verbose", "keywords": "0x4c14fccbd" },
      { "name": "Microsoft-Windows-DotNETRuntimePrivate", "eventLevel": "Verbose", "keywords": "0x4002000b" },
      { "name": "Microsoft-DotNETCore-SampleProfiler", "eventLevel": "Verbose", "keywords": "0x0" },
      { "name": "System.Threading.Tasks.TplEventSource", "eventLevel": "Verbose", "keywords": "0xc7" },
      { "name": "Microsoft-ApplicationInsights-DataRelay", "eventLevel": "Verbose", "keywords": "0xffffffff" }
    ]
  }
}
```

To append a provider, `Microsoft-Extensions-DependencyInjection` provider for example:

```json
{
  ...
  "ServiceProfiler": {
    "CustomEventPipeProviders": [
      { "name": "Microsoft-Windows-DotNETRuntime", "eventLevel": "Verbose", "keywords": "0x4c14fccbd" },
      { "name": "Microsoft-Windows-DotNETRuntimePrivate", "eventLevel": "Verbose", "keywords": "0x4002000b" },
      { "name": "Microsoft-DotNETCore-SampleProfiler", "eventLevel": "Verbose", "keywords": "0x0" },
      { "name": "System.Threading.Tasks.TplEventSource", "eventLevel": "Verbose", "keywords": "0xc7" },
      { "name": "Microsoft-ApplicationInsights-DataRelay", "eventLevel": "Verbose", "keywords": "0xffffffff" },
      { "name": "Microsoft-Extensions-DependencyInjection", "eventLevel": "Verbose", "keywords": "0xffffffff" }
    ]
  }
  ...
}
```