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
    public IWebsiteConfig GetConfig()
    {
        var userType = GetUserType();
        ConfigChoices.ActiveConfig.AlternativeThemes.TryGetValue(userType ?? "", out var config);
        config ??= ConfigChoices.ActiveConfig.Theme;
        return config;
    }

    [Authorize]
    public IWeddingDetails GetDetails()
    {
        var userType = GetUserType();
        ConfigChoices.ActiveConfig.AlternativeWeddingDetails.TryGetValue(userType ?? "", out var details);
        details ??= ConfigChoices.ActiveConfig.WeddingDetails;
        return details;
    }

    [Authorize]
    public async Task<IWebsiteConfig> GetConfigAsync()
    {
        var userType = await GetUserTypeAsync();
        ConfigChoices.ActiveConfig.AlternativeThemes.TryGetValue(userType ?? "", out var config);
        config ??= ConfigChoices.ActiveConfig.Theme;
        return config;
    }
    
    [Authorize]
    public async Task<IWeddingDetails> GetDetailsAsync()
    {
        var userType = await GetUserTypeAsync();
        ConfigChoices.ActiveConfig.AlternativeWeddingDetails.TryGetValue(userType ?? "", out var details);
        details ??= ConfigChoices.ActiveConfig.WeddingDetails;
        return details;
    }

    private string? GetUserType()
    {
        var authState = authenticationStateProvider.GetAuthenticationStateAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        var user = authState.User;
        var userId = userManager.GetUserId(user);
        var userType = userId != null ? accountService.GetUserType(userId) : null;
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