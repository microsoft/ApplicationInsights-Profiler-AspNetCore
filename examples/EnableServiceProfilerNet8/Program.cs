var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsTelemetry(); // Register Application Insights
builder.Services.AddServiceProfiler(opt =>{
    // Customize by code, for example:
    opt.Duration = TimeSpan.FromSeconds(30);    // Profile for 30 seconds than the default of 2 minutes.
});  // Register Profiler

var app = builder.Build();

app.MapGet("/", async () => {
    await Task.Delay(500);
    return "Hello Profiler";
});

app.Run();
