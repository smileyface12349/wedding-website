using MudBlazor.Utilities;

namespace WeddingWebsite.Models.WebsiteConfig;

public record WeddingColours(
    Colour Primary,
    Colour PrimaryLight,
    Colour SurfaceVariant,
    Colour Tertiary,
    Colour TextOnTertiary
) {
    /// <summary>
    /// This is the main theme colour of the wedding, the first point of call when any colour is needed.
    /// This should be dark enough to stand out against a white background.
    /// </summary>
    public Colour Primary { get; } = Primary;

    /// <summary>
    /// A lighter version of the primary colour. This should look good against dark backgrounds.
    /// </summary>
    public Colour PrimaryLight { get; } = PrimaryLight;

    /// <summary>
    /// The default background is white. This colour is used for some colourful backgrounds.
    /// </summary>
    public Colour SurfaceVariant { get; } = SurfaceVariant;
    
    /// <summary>
    /// Used occasionally for accents and high-emphasis backgrounds.
    /// </summary>
    public Colour Tertiary { get; } = Tertiary;
    
    public Colour TextOnTertiary { get; } = TextOnTertiary;
}