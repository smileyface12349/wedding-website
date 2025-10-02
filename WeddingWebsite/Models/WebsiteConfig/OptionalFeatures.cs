namespace WeddingWebsite.Models.WebsiteConfig;

public record OptionalFeatures
{
    bool LiftSharing { get; init; } = false;
    bool Rsvp { get; init; } = false;
}