FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy everything for build
COPY . ./

# Add additional nuget packages
RUN dotnet add package Microsoft.ApplicationInsights.AspNetCore --no-restore
RUN dotnet add package Microsoft.ApplicationInsights.Profiler.AspNetCore -v 2.2.0-* --no-restore

# Restore
RUN dotnet restore

# Publish
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

# Setup environment variable for application insights instrumentation key
ENV APPINSIGHTS_INSTRUMENTATIONKEY=#YOUR-APPINSIGHTS_INSTRUMENTATIONKEY#

# Setup environment variable for hosting startup assembly
ENV ASPNETCORE_HOSTINGSTARTUPASSEMBLIES=Microsoft.ApplicationInsights.Profiler.HostingStartup30

WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "ServiceProfiler.EventPipe.DockerApp30HS.dll"]