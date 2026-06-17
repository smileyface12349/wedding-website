using WeddingWebsite.Config.ThemeAndLayout;
using WeddingWebsite.Config.WeddingDetails;
using WeddingWebsite.Models.ConfigInterfaces;

namespace WeddingWebsite.Config;

public record ConfigChoices(
    IWebsiteConfig Theme,
    IWeddingDetails WeddingDetails,
    IDictionary<string, IWebsiteConfig> AlternativeThemes,
    IDictionary<string, IWeddingDetails> AlternativeWeddingDetails
)
{
    public static ConfigChoices ActiveConfig => new ConfigChoices(
        new DefaultConfig(),
        new SampleWeddingDetails(),
        [],
        []
    );
}