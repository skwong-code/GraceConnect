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

        var supabaseUrl = config["Supabase:Url"]
            ?? throw new InvalidOperationException("Supabase:Url missing in appsettings.json");
        var supabaseAnonKey = config["Supabase:AnonKey"]
            ?? throw new InvalidOperationException("Supabase:AnonKey missing in appsettings.json");

        var supabaseService = new SupabaseService(supabaseUrl, supabaseAnonKey);

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton(supabaseService);
        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        // Non-blocking initialization
        Task.Run(async () => await supabaseService.InitializeAsync());

        return app;
    }
}