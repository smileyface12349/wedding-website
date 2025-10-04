namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// A feature that's active between specified dates. Null means no boundary.
/// </summary>
public record TimeBasedFeature(DateTime? Start, DateTime? End) : IOptionalFeature
{
    public bool IsActive()
    {
        var now = DateTime.UtcNow;
        if (Start.HasValue && now < Start.Value)
        {
            return false;
        }
        if (End.HasValue && now > End.Value)
        {
            return false;
        }
        return true;
    }
}