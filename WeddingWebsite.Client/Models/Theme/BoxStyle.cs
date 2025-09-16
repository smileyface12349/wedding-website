namespace WeddingWebsite.Client.Models.Theme;

public sealed record BoxStyle(
    BoxType Type,
    SectionTheme InnerTheme
);