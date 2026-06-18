using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using WeddingWebsite.Config;
using WeddingWebsite.Data;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Services;

public class ConfigProvider(AuthenticationStateProvider authenticationStateProvider, UserManager<Account> userManager, IAccountService accountService)
    : IConfigProvider
{
    [Authorize]
    public async Task<IWebsiteConfig> GetConfigAsync()
    {
        var userType = await GetUserTypeAsync();
        var activeConfig = ConfigChoices.ActiveConfig;
        if (userType == null)
        {
            return activeConfig.Theme;
        }
        activeConfig.AlternativeThemes.TryGetValue(userType, out var config);
        config ??= activeConfig.Theme;
        return config;
    }
    
    [Authorize]
    public async Task<IWeddingDetails> GetDetailsAsync()
    {
        var userType = await GetUserTypeAsync();
        var activeConfig = ConfigChoices.ActiveConfig;
        if (userType == null)
        {
            return activeConfig.WeddingDetails;
        }
        activeConfig.AlternativeWeddingDetails.TryGetValue(userType, out var details);
        details ??= activeConfig.WeddingDetails;
        return details;
    }
    
    private async Task<string?> GetUserTypeAsync()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        var userId = userManager.GetUserId(user);
        var userType = userId != null ? accountService.GetUserType(userId) : null;
        return userType;
    }
}