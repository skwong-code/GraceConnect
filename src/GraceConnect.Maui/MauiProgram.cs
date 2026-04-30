using GraceConnect.Shared;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;

namespace GraceConnect.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
#pragma warning disable CA1416
        var builder = MauiApp.CreateBuilder();
#pragma warning restore CA1416

        // Load Supabase config from appsettings.json (key is now hidden)
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        builder.Services.AddSupabase(config);

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

#pragma warning restore CA1416
        return app;
    }
}