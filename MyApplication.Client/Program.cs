using BlazorApplicationInsights;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);



builder.Services.AddBlazorApplicationInsights(x =>
{
    x.ConnectionString = "InstrumentationKey=bfd00310-cf98-4fb9-bc39-4d0d1c6e2320;IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/;LiveEndpoint=https://westeurope.livediagnostics.monitor.azure.com/;ApplicationId=d875b245-1764-4e60-b587-a6038abd3435";
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();



await builder.Build().RunAsync();
