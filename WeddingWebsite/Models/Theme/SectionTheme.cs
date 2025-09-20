using WeddingWebsite.Models.WebsiteConfig;

namespace WeddingWebsite.Models.Theme;

/// <summary>
/// The theming of a particular section. This can be the same across all sections, or it may vary depending on the section.
///
/// You have the freedom to control what boxes look like, which have their own inner themes. You are strongly advised
/// to provide at least one inner theme, although within this theme you can stop the recursion and set the box style to
/// null. If you don't set it to null you'll be going on forever!
/// </summary>
public sealed record SectionTheme(
    IBackground Background,
    Colour Primary,
    BoxStyle? BoxStyle
);