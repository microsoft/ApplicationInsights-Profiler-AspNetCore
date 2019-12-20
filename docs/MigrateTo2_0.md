# Migrating from Application Insights Profiler 1.x to 2.0

There are break changes between 1.x and 2.0 for Application Insights Profiler but the migration should be very easy.

## Update the NuGet packages

* To use .NET Core CLI:

```shell
dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore --version 2.0.0-*
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

## Stop using hosting startup

Hosting startup is not supported for .NET Core 3.0 in 2.0.0-beta.

1. **Stop** setting environment variable: **ASPNETCORE_HOSTINGSTARTUPASSEMBLIES**=Microsoft.ApplicationInsights.Profiler.AspNetCore
1. Enable Profile through the code in `Startup.cs` like this:

  ```csharp
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddControllers();
        // Adding the following lines to enable application insights and profiler.
        services.AddApplicationInsightsTelemetry();
        services.AddServiceProfiler();
    }
  ```
