using MudBlazor.Utilities;

namespace WeddingWebsite.Models.WebsiteConfig;

public record WeddingColours(WeddingColour Primary, WeddingColour PrimaryLight, WeddingColour SurfaceVariant)
{
    /// <summary>
    /// This is the main theme colour of the wedding, the first point of call when any colour is needed.
    /// This should be dark enough to stand out against a white background.
    /// </summary>
    public WeddingColour Primary { get; } = Primary;

    /// <summary>
    /// A lighter version of the primary colour. This should look good against dark backgrounds.
    /// </summary>
    public WeddingColour PrimaryLight { get; } = PrimaryLight;

    /// <summary>
    /// The default background is white. This colour is used for some colourful backgrounds.
    /// </summary>
    public WeddingColour SurfaceVariant { get; } = SurfaceVariant;
}