namespace WeddingWebsite.Models.WebsiteConfig;

public class InactiveFeature : IOptionalFeature
{
    public bool IsActive() => false;
    public string IsActiveString() => "not open";
}