using WeddingWebsite.Config;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Services;

public interface IConfigProvider
{
    /// <summary>
    /// Get the website configuration for the current user asynchronously.
    /// </summary>
    Task<IWebsiteConfig> GetConfigAsync();
    
    /// <summary>
    /// Get the wedding details for the current user asynchronously.
    /// </summary>
    Task<IWeddingDetails> GetDetailsAsync();
    
    /// <summary>
    /// Quick access for the default website configuration. This may be used while the specific config is still loading.
    /// No equivalent property is provided for wedding details - this would potentially leak sensitive information.
    /// </summary>
    static IWebsiteConfig DefaultConfig => ConfigChoices.ActiveConfig.Theme;
    
    /// <summary>
    /// User types are cached to prevent unnecessary database queries. If a user's type is changed, the cache must be
    /// revoked.
    /// </summary>
    void RevokeUserTypeCache(string userId);
}