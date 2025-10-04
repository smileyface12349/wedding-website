namespace WeddingWebsite.Models.WebsiteConfig;

public interface IOptionalFeature
{
    bool IsActive();
    
    /// <summary>
    /// A string that can fit into the following sentences, describing whether it is active or not:
    ///  - RSVPs are {0}.
    ///  - The registry is {0}.
    ///  - The lift-sharing feature is {0}.
    /// </summary>
    string IsActiveString();
}