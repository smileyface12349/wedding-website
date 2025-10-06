namespace WeddingWebsite.Models.WebsiteConfig;

public class ActiveFeature : IOptionalFeature
{
    public bool IsActive() => true;
    
    /// <summary>
    /// Although we are only using this string when inactive, we should still implement the interface properly.
    /// </summary>
    public string IsActiveString() => "open";
}