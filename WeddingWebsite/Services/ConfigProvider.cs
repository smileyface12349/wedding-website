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
    private IDictionary<string, string?> UserTypeCache { get; } = new Dictionary<string, string?>();
    
    [Authorize]
    public async Task<IWebsiteConfig> GetConfigAsync()
    {
        var userType = await GetUserTypeCachedAsync();
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
        var userType = await GetUserTypeCachedAsync();
        var activeConfig = ConfigChoices.ActiveConfig;
        if (userType == null)
        {
            return activeConfig.WeddingDetails;
        }
        activeConfig.AlternativeWeddingDetails.TryGetValue(userType, out var details);
        details ??= activeConfig.WeddingDetails;
        return details;
    }

    [Authorize(Roles = "Admin")]
    public void RevokeUserTypeCache(string userId)
    {
        UserTypeCache.Remove(userId);
    }

    private async Task<string?> GetUserTypeCachedAsync()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        var userId = userManager.GetUserId(user);
        if (userId == null)
        {
            return null;
        }
        
        if (UserTypeCache.TryGetValue(userId, out var cachedUserType))
        {
            return cachedUserType;
        }

        var userType = accountService.GetUserType(userId);
        UserTypeCache[userId] = userType;
        return userType;
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