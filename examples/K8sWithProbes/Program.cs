var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddApplicationInsightsKubernetesEnricher();

builder.Services.AddServiceProfiler();

var app = builder.Build();

app.MapGet("/health/live", () => "Live!");
app.MapGet("/health/ready", () => "Ready!");


app.Run();
