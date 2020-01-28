# Migrating from Application Insights Profiler 1.x to 2.0

There are break changes between 1.x and 2.0 for Application Insights Profiler but the migration should be very easy.

## Update the NuGet packages

* To use .NET Core CLI:

```shell
dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore --version 2.1.0-*
```

* To use package manager:

```shell
Install-Package Microsoft.ApplicationInsights.Profiler.AspNetCore -Version 1.1.7-*
```

## Update the configurations

There are changes in the configurations. Refer to [What's new](./WhatIsNew2_0#New_customization_options) for details. The minimum step is to remove the obsoleted parameter named 'Interval' form the following location:

1. appsettings.[Environment].json
1. appsettings.json
1. Update the method of `AddServiceProfiler` to remove the option of **Interval** if it is used.

And that's it.

## Update to use the new hosting startup

Hosting startup is supported for .NET Core 3.0 in 2.1.0-beta1 or above.

1. **Stop** setting environment variable specific to .NET Core 2.x: **ASPNETCORE_HOSTINGSTARTUPASSEMBLIES**=Microsoft.ApplicationInsights.Profiler.AspNetCore
2. **Use** the environment variable: **ASPNETCORE_HOSTINGSTARTUPASSEMBLIES**=Microsoft.ApplicationInsights.Profiler.HostingStartup30

Read [this post](../examples/HostingStartupCLR3/Readme.md) for more details.
