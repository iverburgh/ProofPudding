using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging.ApplicationInsights;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging.AddApplicationInsights(
    configureTelemetryConfiguration: (config) =>
        config.ConnectionString = builder.Configuration.GetConnectionString("ApplicationInsights"),
    configureApplicationInsightsLoggerOptions: (options) => { }
);

builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("your-category", LogLevel.Trace);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
