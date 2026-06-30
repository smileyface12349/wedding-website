using WeddingWebsite.Models.LiftSharing;

namespace WeddingWebsite.Models.WebsiteConfig;

public sealed record LiftSharingOptions(IEnumerable<Journey> Presets, bool AllowCustomJourneys);