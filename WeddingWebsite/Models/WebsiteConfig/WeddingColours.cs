namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Global theme colours. These are sometimes useful, but are generally overridden by the colours for a particular section.
/// </summary>
/// <seealso cref="WeddingWebsite.Models.Theme.SectionTheme"/>
public record WeddingColours(
    Colour Primary,
    Colour PrimaryBackground,
    Colour Secondary,
    IBackground Surface,
    IBackground SurfaceVariant
) {
    public WeddingColours(Colour primary, Colour primaryBackground, Colour secondary) 
        : this (primary, primaryBackground, secondary, new Colour("#F8F8EF"), Colour.White) { }
    
    public WeddingColours(Colour primary, Colour primaryBackground, Colour secondary, Colour background)
        : this (primary, primaryBackground, secondary, background, Colour.White) { }

    /// <summary>
    /// This is the main theme colour of the wedding, the first point of call when any colour is needed - generally
    /// used in things like buttons.
    /// </summary>
    public Colour Primary { get; } = Primary;

    /// <summary>
    /// A lighter version of the primary colour, designed to be used when a colourful background is needed.
    /// This can also be a completely different hue to the primary colour, which will look fine.
    /// </summary>
    public Colour PrimaryBackground { get; } = PrimaryBackground;
    
    /// <summary>
    /// Used occasionally for accents and buttons that are placed on top of the primary colour.
    /// </summary>
    public Colour Secondary { get; } = Secondary;
    
    /// <summary>
    /// Default background colour.
    /// </summary>
    public IBackground Surface { get; } = Surface;
    
    /// <summary>
    /// Alternative background colour to go on top of the default background colour.
    /// </summary>
    public IBackground SurfaceVariant { get; } = SurfaceVariant;
}