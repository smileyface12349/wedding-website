using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using WeddingWebsite.Components;
using WeddingWebsite.Config.Credentials;
using WeddingWebsite.Config.Rsvp;
using WeddingWebsite.Config.Strings;
using WeddingWebsite.Config.ThemeAndLayout;
using WeddingWebsite.Config.WeddingDetails;
using WeddingWebsite.Core;
using WeddingWebsite.Data;
using WeddingWebsite.Data.Stores;
using WeddingWebsite.Models.ConfigInterfaces;
using WeddingWebsite.Models.Validation;
using WeddingWebsite.Services;

var builder = WebApplication.CreateBuilder(args);

// Required - All the information about your wedding. Please create your own implementation of IWeddingDetails.
// See WeddingDetailsTemplate for a starting point. If you rename the file to RealWeddingDetails, it will be
// ignored from git so that it is kept private.
builder.Services.AddScoped<IWeddingDetails, SampleWeddingDetails>();

// Recommended - Customise the theme and layout. Please create your own implementation of IWebsiteConfig. It is
// recommended to have this also inherit from DefaultConfig. See DemoConfig for an example. If you rename the file
// to CustomConfig, it will be ignored from git so that it is kept private.
builder.Services.AddScoped<IWebsiteConfig, DefaultConfig>();

// Recommended - Customise your RSVP form to gather the information that you need! You can safely ignore this until you
// plan to open RSVPs. You should implement IRsvpForm - see DemoRsvpForm for an example. If you rename the file to
// CustomRsvpForm, it will be ignored from git so that it is kept private.
builder.Services.AddScoped<IRsvpForm, DemoRsvpForm>();

// Optional - If you would like to use any functionality that requires credentials (e.g. google maps), please create a
// file called Credentials.cs that implements ICredentials. This will be ignored from git so that it is kept private.
builder.Services.AddScoped<ICredentials, NoCredentials>();

// Optional - If you'd like to customise the wording or translate into a different language, you can swap out for a
// different implementation of IStringProvider. If you're only changing a few strings, you can inherit from
// StandardBritishEnglish as is done in FriendlyBritishEnglish.
builder.Services.AddScoped<IStringProvider, StandardBritishEnglish>();


builder.Services.AddScoped<IDetailsAndConfigValidator, DetailsAndConfigValidator>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IRegistryService, RegistryService>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IStore, Store>();
builder.Services.AddScoped<IRegistryStore, RegistryStore>();
builder.Services.AddScoped<ITodoStore, TodoStore>();

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
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
})
    .AddRoles<IdentityRole>()
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