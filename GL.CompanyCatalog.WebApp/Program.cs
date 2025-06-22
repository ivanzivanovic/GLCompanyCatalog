using Blazored.LocalStorage;
using GL.CompanyCatalog.WebApp;
using GL.CompanyCatalog.WebApp.Auth;
using GL.CompanyCatalog.WebApp.Contracts;
using GL.CompanyCatalog.WebApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add root components for the Blazor app
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register AutoMapper and Blazored.LocalStorage
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

// Register custom cookie handler for authenticated requests
builder.Services.AddScoped<CookieHandler>();

// Add built-in Blazor authorization support
builder.Services.AddAuthorizationCore();

// Register custom authentication state provider
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddTransient<CookieAuthenticationStateProvider>();

// ✅ Get ApiUrl from environment variables or fallback to localhost for local debugging
var apiUrl = builder.Configuration["ApiUrl"] ?? "http://localhost:7081/";


Console.WriteLine($"ApiUrl from configuration: {apiUrl}");

// ✅ Register main HttpClient for API calls with cookie support
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(apiUrl);
})
.AddHttpMessageHandler<CookieHandler>();

// ✅ Register a separate HttpClient for authentication endpoints, also using the cookie handler
builder.Services.AddHttpClient(
    "Authentication",
    client => client.BaseAddress = new Uri(apiUrl))
    .AddHttpMessageHandler<CookieHandler>();

// ✅ Register NSwag-generated client with the same base URL and HttpClient
builder.Services.AddScoped<IClient>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = factory.CreateClient("API");
    return new Client(apiUrl, httpClient);
});

// ✅ Register other application services
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
builder.Services.AddScoped<ICompanyDataService, CompanyDataService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();
