using WeddingWebsite.Models.WebsiteConfig;

namespace WeddingWebsite.Models.Theme;

public sealed record BoxStyle(
    BoxType Type,
    SectionTheme InnerTheme
);