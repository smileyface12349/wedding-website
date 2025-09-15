using WeddingWebsite.Models.WebsiteConfig;

namespace WeddingWebsite.Models.Theme;

public sealed record SectionTheme(
    Colour Background,
    Colour Primary,
    BoxStyle BoxStyle
);