namespace WeddingWebsite.Models.WebsiteConfig;

public interface IBackground
{
    /// <summary>
    /// Affects what text colour to show on top
    /// </summary>
    public bool IsDark { get; }
    
    /// <summary>
    /// Some components take notice of this, most won't. This tells components to do what they can to stick out against
    /// a busy or particularly problematic background.
    /// </summary>
    public bool ExtraContrast { get; }
    
    /// <summary>
    /// If true, the CSS is sufficient. If false, some other code is needed to properly render it, the CSS is only
    /// an approximation.
    /// </summary>
    public bool HasPureCssImplementation { get; }
    
    /// <summary>
    /// Obtain a suitable colour to show on top.
    /// </summary>
    public Colour GetTextColour();
    
    /// <summary>
    /// Check HasPureCssImplementation. If true, applying this CSS is sufficient. If false, this CSS should be ignored,
    /// and the AdvancedBackground component should be used. In this instance, the CSS will be an approximation of the
    /// intended background designed for components that haven't bothered to implement advanced backgrounds, or don't
    /// want to populate the DOM further, or know that they won't receive advanced backgrounds.
    /// </summary>
    /// <returns></returns>
    public string GetBackgroundCss();
}