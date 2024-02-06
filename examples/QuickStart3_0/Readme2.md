# This example is deprecated. Please refere to the new [.NET 6 example](../EnableServiceProfilerForContainerAppNet6/Readme.md#dockerize-the-application-above).

# Quick Start to build an ASP.NET Core 3.0 WebAPI with Profiler (Part II)

In [the last post](./Readme.md), we walked through how to build an application with Application Insights Profiler on locally. In this post, we are going to containerize the app and get it run inside a container.

## Prerequisites

1. Finish [part I](./Readme.md) to have a working application with Profiler on.
1. [Docker Desktop on Windows](https://docs.docker.com/docker-for-windows/install/).

## Get started

### Create a Dockerfile for the application

Since we already have a working project, just follow the [dockerfile example](https://docs.docker.com/engine/examples/dotnetcore/) from the docker documentation with the following tweaks:

1. For ASP.NET Core 3.0, update the base images.

    Find the base images for ASP.NET Core [on the dockerhub](https://hub.docker.com/_/microsoft-dotnet-core).

    Specifically, we need [an SDK image](https://hub.docker.com/_/microsoft-dotnet-core-sdk/) and [a ASP.NET Core runtime image](https://hub.docker.com/_/microsoft-dotnet-core-aspnet/) and update the image names in the dockerfile.

    At the moment, actually the changes required are change the tags to `3.0` from `2.2` for both `build-env` and for the runtime image.

1. Set the environment variable to provide instrumentation for release build of the application:

    ```dockerfile
    ENV APPLICATIONINSIGHTS_CONNECTION_STRING="YOUR_APPLICATION_INSIGHTS_CONNECTION_STRING"
    ```

1. Update the entry point toward the end of the file to pick up the proper assembly.

A full example could be found [here](./dockerfile).

### Build and start the container

Here's some shorthands for building and running the container:

```shell
docker build -t quickstart30:0.0.1 .
docker run -p 8080:80 --name aiprofiler-quickstart quickstart30:0.0.1
```

Let's generate traffic for the following endpoint this time:

```shell
http://localhost:8080/weatherforecast
```

And as we did before, we will wait for 2 minutes to let the data ingest after the profiling session.

You will be able to get the same result as it is running locally.

### Delete the container after the testing

```shell
docker container rm aiprofiler-quickstart -f
```
