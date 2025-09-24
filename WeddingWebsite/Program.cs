using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using WeddingWebsite.Components;
using WeddingWebsite.Core;
using WeddingWebsite.Data;
using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.Credentials;
using WeddingWebsite.Models.Validation;
using WeddingWebsite.Models.WebsiteConfig;
using WeddingWebsite.Models.WeddingDetails;
using WeddingWebsite.Routing;
using WeddingWebsite.Services;
using RsvpController = WeddingWebsite.Controllers.RsvpController;

var builder = WebApplication.CreateBuilder(args);

// Swap out SampleWeddingDetails for your own implementation.
builder.Services.AddScoped<IWeddingDetails, SampleWeddingDetails>();

// If you want to, swap out DefaultConfig for your own implementation (you can inherit from DefaultConfig).
builder.Services.AddScoped<IWebsiteConfig, DefaultConfig>();

// Credentials.cs is automatically gitignored. If you don't have any credentials, you can swap this to NoCredentials,
// which will automatically throw a NotImplementedException when attempting to use credentials.
builder.Services.AddScoped<IGoogleMapsApiKey, Credentials>();


builder.Services.AddScoped<IDetailsAndConfigValidator, DetailsAndConfigValidator>();
builder.Services.AddScoped<RsvpController>();
builder.Services.AddScoped<IRsvpService, RsvpService>();
builder.Services.AddScoped<IStore, Store>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddControllers();

builder.Services.AddMudServices();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
// builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<Account>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapAuthEndpoints();

app.MapDefaultControllerRoute();
app.MapControllers();

app.Run();