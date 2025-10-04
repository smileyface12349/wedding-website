using WeddingWebsite.Core;

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
    
    public string IsActiveString()
    {
        var now = DateTime.UtcNow;
        if (Start.HasValue && now < Start.Value)
        {
            return $"not yet open (opening in approx. {(Start.Value - now).FormatShortDuration()})";
        }
        if (End.HasValue && now > End.Value)
        {
            return $"closed (since approx. {(now - End.Value).FormatShortDuration()} ago)";
        }
        if (Start.HasValue && End.HasValue)
        {
            return $"open for approx. {(End.Value - now).FormatShortDuration()}";
        }
        return "open";
    }
}