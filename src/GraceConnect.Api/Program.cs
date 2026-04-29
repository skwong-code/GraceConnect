using GraceConnect.Shared;

var builder = WebApplication.CreateBuilder(args);

// Supabase (for API later)
var supabaseUrl = builder.Configuration["Supabase:Url"] ?? throw new InvalidOperationException("Supabase URL missing");
var supabaseAnonKey = builder.Configuration["Supabase:AnonKey"] ?? throw new InvalidOperationException("Supabase AnonKey missing");

var supabaseService = new SupabaseService(supabaseUrl, supabaseAnonKey);
await supabaseService.InitializeAsync();

builder.Services.AddSingleton(supabaseService);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();