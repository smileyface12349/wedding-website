namespace WeddingWebsite.Models.WebsiteConfig;

public class ActiveFeature : IOptionalFeature
{
    public bool IsActive() => true;
}