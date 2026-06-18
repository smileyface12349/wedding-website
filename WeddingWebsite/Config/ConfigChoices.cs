using WeddingWebsite.Config.Strings;
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
        // Replace this line with your own implementation of IWebsiteConfig. I would suggest inheriting from
        // DefaultConfig - see DemoConfig for an example. If you rename the file to CustomConfig, it will be ignored
        // from git so that it is kept private.
        new DefaultConfig(),
        
        // Replace this line with your own implementation of IWeddingDetails. See SampleWeddingDetails for an example.
        // If you rename the file to RealWeddingDetails, it will be ignored from git so that it is kept private.
        new SampleWeddingDetails(),
        
        // Here you can specify alternative themes for particular users, e.g. ceremony only guests.
        new Dictionary<string, IWebsiteConfig>()
        {
            // {"ceremony", new DefaultConfig()}
        },
        
        // Here you can specify alternative wedding details for particular users, e.g. evening guests.
        new Dictionary<string, IWeddingDetails>()
        {
            // {"evening", new SampleWeddingDetails()}
        }
    );
    
    // Note that the RSVP form, strings, and credentials, are all injected directly and cannot depend on user types.
    // Please change these in Program.cs.
}