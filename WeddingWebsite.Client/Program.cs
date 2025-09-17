using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WeddingWebsite.Client;

public class Program
{
    public static async Task Main(string[] args) {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<HeadOutlet>("head::after");
        
        builder.Services.AddAuthorizationCore();

        await builder.Build().RunAsync();
    }
}