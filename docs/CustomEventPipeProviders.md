# Use Custom EventPipe Providers (preview)

There are more than just built-in providers that the Profiler supported. With this capability, you will be able to turn on additional providers.

## Steps

1. Add the providers you want.
   1. For example, [Well-known event providers in .NET](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/well-known-event-providers)

> ⚠️ Although it is possible to overwrite the built-in providers, it is not recommended.

## Limitations

> ⚠️ You will still need to have traffic to your service for the trace to show up in Azure Portal. There needs to be at least one valid request for the trace to be correctly uploaded.

> ⚠️ You will need to use `2.5.0-beta1` or above for this feature.

> 🚩 Turn on `Debug` logs for `Microsoft.ApplicationInsights.Profiler` for troubleshooting.

## Use custom EventPipe providers

To append a provider, `Microsoft-Extensions-DependencyInjection` provider for example:

```json
{
  ...
  "ServiceProfiler": {
    "CustomEventPipeProviders": [
      { "name": "Microsoft-Extensions-DependencyInjection", "eventLevel": "Verbose", "keywords": "0xffffffff" }
    ]
  }
  ...
}
```

## The default providers

You **don't** need to configure these providers. This is just FYI:

| Provider Name                           | EventLevel | Keywords    |
| --------------------------------------- | ---------- | ----------- |
| Microsoft-Windows-DotNETRuntime         | Verbose    | 0x4c14fccbd |
| Microsoft-Windows-DotNETRuntimePrivate  | Verbose    | 0x4002000b  |
| Microsoft-DotNETCore-SampleProfiler     | Verbose    | 0x0         |
| System.Threading.Tasks.TplEventSource   | Verbose    | 0xc7        |
| Microsoft-ApplicationInsights-DataRelay | Verbose    | 0xffffffff  |
