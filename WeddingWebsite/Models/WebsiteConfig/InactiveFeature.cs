namespace WeddingWebsite.Models.WebsiteConfig;

public class InactiveFeature : IOptionalFeature
{
    public bool IsActive() => false;
}