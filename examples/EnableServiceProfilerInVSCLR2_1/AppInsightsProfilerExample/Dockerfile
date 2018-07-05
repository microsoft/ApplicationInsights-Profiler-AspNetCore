FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY AppInsightsProfilerExample/AppInsightsProfilerExample.csproj AppInsightsProfilerExample/
RUN dotnet restore AppInsightsProfilerExample/AppInsightsProfilerExample.csproj
COPY . .
WORKDIR /src/AppInsightsProfilerExample
RUN dotnet build AppInsightsProfilerExample.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AppInsightsProfilerExample.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AppInsightsProfilerExample.dll"]
