using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Services;

public interface IConfigProvider
{
    IWebsiteConfig GetConfig();
    IWeddingDetails GetDetails();
}