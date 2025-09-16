using WeddingWebsite.Client.Models.Theme;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Global theme colours. These are sometimes useful, but are generally overridden by the colours for a particular section.
/// </summary>
/// <see cref="SectionTheme"/>
public record WeddingColours(
    Colour Primary,
    Colour PrimaryBackground,
    Colour Secondary,
    Colour Surface
) {
    public WeddingColours(Colour primary, Colour primaryBackground, Colour secondary) 
        : this (primary,  primaryBackground, secondary, Colour.White) { }

    /// <summary>
    /// This is the main theme colour of the wedding, the first point of call when any colour is needed.
    /// You might find this in the odd component even if you've overridden it in the section theme.
    /// </summary>
    public Colour Primary { get; } = Primary;

    /// <summary>
    /// A lighter version of the primary colour, designed to be used when a colourful background is needed.
    /// </summary>
    public Colour PrimaryBackground { get; } = PrimaryBackground;
    
    /// <summary>
    /// Used occasionally for accents and high-emphasis backgrounds.
    /// </summary>
    public Colour Secondary { get; } = Secondary;
    
    /// <summary>
    /// Default background colour
    /// </summary>
    public Colour Surface { get; } = Surface;
}