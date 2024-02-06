FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app

# Copy everything and build
COPY . ./

# Adding a reference to hosting startup package
RUN dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 2.*

# Restore & publish the app
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1

# Create an argument to allow docker builder to passing in application insights conneection string.
# For example: docker build . --build-arg APPINSIGHTS_CONN=YOUR_APPLICATIONINSIGHTS_CONNECTION_STRING
ARG APPINSIGHTS_CONN
# Making sure the argument is set. Fail the build of the container otherwise.
RUN test -n "$APPINSIGHTS_CONN"

# Light up Application Insights and Service Profiler
ENV APPLICATIONINSIGHTS_CONNECTION_STRING=$APPINSIGHTS_CONN
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=Microsoft.ApplicationInsights.Profiler.AspNetCore

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "EnableServiceProfilerForContainerApp.dll"]
