# Application Insights Profiler for Azure Function Example

This folder contains an example of Application Insights Profiler running in an Azure Function of [isolated worker model](https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide).


## Create an Azure Function
Follow [this tutorial](https://learn.microsoft.com/en-us/azure/azure-functions/functions-get-started?pivots=programming-language-csharp#create-your-first-function) to create an Azure Function.

Optionally, you can add a [DockerFile](./Dockerfile) to run your Azure Function in a container.
See this [tutorial](../EnableServiceProfilerForContainerAppNet6/Readme.md#dockerize-the-application-above) for more details on how to dockerize your Azure Function.

## Create an Application Insights resource

Follow the [Create an Application Insights resource](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-create-new-resource). Note down the [instrumentation key](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-create-new-resource#copy-the-instrumentation-key).

## Add Application Insights Profiler to your Azure Function
If you are building an Azure Function in **Isolated Worker Mode**, please refer to [this readme](../ServiceProfilerInWorkerNet6/) for further guidance on code instrumentation.

Otherwise, you can refer to [this readme](../../README.md#get-started) for guidance on setting up Profiler in ASP.NET Core applications.



