using Microsoft.AspNetCore.Authorization;
using WeddingWebsite.Config;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Services;

public class ConfigProvider : IConfigProvider
{
    [Authorize]
    public IWebsiteConfig GetConfig()
    {
        return ConfigChoices.ActiveConfig.Theme;
    }

    [Authorize]
    public IWeddingDetails GetDetails()
    {
        return ConfigChoices.ActiveConfig.WeddingDetails;
    }
}