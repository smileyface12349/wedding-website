using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeddingWebsite.Client.Config;

namespace WeddingWebsite.Client;

public class Program
{
    public static async Task Main(string[] args) {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<HeadOutlet>("head::after");
        
        builder.Services.AddAuthorizationCore();
        
        builder.Services.AddScoped<IWebsiteConfig, WebsiteConfig>();

        await builder.Build().RunAsync();
    }
}