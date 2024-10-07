using Microsoft.Extensions.Logging.ApplicationInsights;
using MudBlazor.Services;
using MudBlazorWebApp_TakeTwo.Client.Pages;
using MudBlazorWebApp_TakeTwo.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddApplicationInsights(
    configureTelemetryConfiguration: (config) =>
        config.ConnectionString = builder.Configuration.GetConnectionString("ApplicationInsights"),
    configureApplicationInsightsLoggerOptions: (options) => { }
);

builder.Logging.AddFilter<ApplicationInsightsLoggerProvider>("your-category", LogLevel.Trace);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MakeCompleteReservation).Assembly);

app.Run();
