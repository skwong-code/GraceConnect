using Supabase;
using Supabase.Gotrue;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Supabase.Gotrue.Constants;

using SupabaseClient = Supabase.Client;

namespace GraceConnect.Shared;

public class SupabaseService
{
    public SupabaseClient Client { get; private set; }

    public SupabaseService(string url, string anonKey)
    {
        var options = new SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        Client = new SupabaseClient(url, anonKey, options);
    }

    public async Task InitializeAsync()
    {
        await Client.InitializeAsync();
    }

    // Email + Password Login
    public async Task<Session?> LoginAsync(string email, string password)
    {
        return await Client.Auth.SignIn(email, password);
    }

    // Email + Password Register
    public async Task<Session?> RegisterAsync(string email, string password, string fullName = "New Member")
    {
        var signUpOptions = new SignUpOptions
        {
            Data = new Dictionary<string, object> { { "full_name", fullName } }
        };
        return await Client.Auth.SignUp(email, password, signUpOptions);
    }

    // Social Login (Google / Apple) - returns the OAuth URL as string
    public async Task<string?> GetOAuthSignInUrlAsync(Provider provider, string? redirectTo = null)
    {
        var authState = await Client.Auth.SignIn(provider, new SignInOptions
        {
            RedirectTo = redirectTo
        });
        return authState?.Uri?.AbsoluteUri;
    }

    // Logout
    public async Task LogoutAsync()
    {
        await Client.Auth.SignOut();
    }

    // Current user + role
    public User? CurrentUser => Client.Auth.CurrentUser;

    public string GetUserRole()
    {
        return CurrentUser?.UserMetadata?["role"]?.ToString() ?? "Member";
    }
}