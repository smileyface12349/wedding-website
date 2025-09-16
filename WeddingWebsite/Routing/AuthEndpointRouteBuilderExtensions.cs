using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using WeddingWebsite.Data;

namespace WeddingWebsite.Routing;

public static class AuthEndpointRouteBuilderExtensions
{
    public static IEndpointConventionBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpoints) {
        var group = endpoints.MapGroup("/Account");
        
        group.MapGet("/Logout", async (
            ClaimsPrincipal user,
            SignInManager<Account> signInManager) =>
        {
            await signInManager.SignOutAsync();
            return TypedResults.LocalRedirect("/");
        });
        
        return group;
    }
}