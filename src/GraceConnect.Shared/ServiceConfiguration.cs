using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraceConnect.Shared;

public static class ServiceConfiguration
{
    public static IServiceCollection AddSupabase(this IServiceCollection services, IConfiguration config)
    {
        var supabaseUrl = config["Supabase:Url"]
            ?? throw new InvalidOperationException("Supabase:Url missing in appsettings.json");
        var supabaseAnonKey = config["Supabase:AnonKey"]
            ?? throw new InvalidOperationException("Supabase:AnonKey missing in appsettings.json");

        var supabaseService = new SupabaseService(supabaseUrl, supabaseAnonKey);
        services.AddSingleton(supabaseService);

        // Initialize asynchronously in a background task
        Task.Run(async () => await supabaseService.InitializeAsync());

        return services;
    }
}