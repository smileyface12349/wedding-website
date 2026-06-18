using WeddingWebsite.Config;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Services;

public interface IConfigProvider
{
    /// <summary>
    /// Get the website configuration for the current user.
    /// </summary>
    IWebsiteConfig GetConfig();
    
    /// <summary>
    /// Get the wedding details for the current user.
    /// </summary>
    IWeddingDetails GetDetails();
    
    /// <summary>
    /// Quick access for the default website configuration. This may be used while the specific config is still loading.
    /// No equivalent property is provided for wedding details - this would potentially leak sensitive information.
    /// </summary>
    static IWebsiteConfig DefaultConfig => ConfigChoices.ActiveConfig.Theme;
}