FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copy everything and build
COPY . ./

# Adding a reference to hosting startup package
RUN dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 1.1.7-beta2

# Restore & publish the app
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime

# Create an argument to allow docker builder to passing in application insights connection string.
# For example: docker build . --build-arg APPINSIGHTS_CONN=<YOUR_APPLICATIONINSIGHTS_CONNECTION_STRING>
ARG APPINSIGHTS_CONN
# Making sure the argument is set. Fail the build of the container otherwise.
RUN test -n "$APPINSIGHTS_CONN"

# Light up Application Insights and Service Profiler
ENV APPLICATIONINSIGHTS_CONNECTION_STRING=$APPINSIGHTS_CONN
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=Microsoft.ApplicationInsights.Profiler.AspNetCore

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AppInsightsProfilerExample.dll"]
