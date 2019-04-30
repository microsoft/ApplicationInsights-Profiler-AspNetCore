FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copy everything and build
COPY . ./

# Adding a reference to hosting startup package
RUN dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 1.1.6-*

# Restore & publish the app
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime

# Create an argument to allow docker builder to passing in application insights key.
# For example: docker build . --build-arg APPINSIGHTS_KEY=YOUR_APPLICATIONINSIGHTS_INSTRUMENTATION_KEY
ARG APPINSIGHTS_KEY
# Making sure the argument is set. Fail the build of the container otherwise.
RUN test -n "$APPINSIGHTS_KEY"

# Light up Application Insights and Service Profiler
ENV APPINSIGHTS_INSTRUMENTATIONKEY $APPINSIGHTS_KEY
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES Microsoft.ApplicationInsights.Profiler.AspNetCore

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AppInsightsProfilerExample.dll"]
