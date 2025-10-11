using WeddingWebsite.Models.WebsiteElement;

namespace WeddingWebsite.Models.WebsiteConfig;

/// <summary>
/// Configuration options. None of this information should be sensitive, and it should be stuff that relates to
/// configuring the website rather than anything related to a particular wedding.
///
/// Configuration options that relate to one section only can be found within that particular section's constructor.
/// </summary>

public interface IWebsiteConfig
{
    /// <summary>
    /// Colour theme. This is sometimes used, but usually overridden by the section themes.
    /// </summary>
    public WeddingColours Colours { get; }
    
    /// <summary>
    /// The sections to show on the website, and per-section config.
    /// </summary>
    public IReadOnlyList<Section> Sections { get; }
    
    /// <summary>
    /// The buttons to display on the top of the homepage e.g. "RSPV".
    /// </summary>
    public TopButtonsConfig TopButtons { get; }
    
    /// <summary>
    /// If false, shows "GROOM and BRIDE". If true, shows "BRIDE and GROOM".
    /// </summary>
    public bool BrideFirst { get; }
    
    /// <summary>
    /// Config for the "My Account" page.
    /// </summary>
    public PageConfig.Account AccountConfig { get; }
    
    /// <summary>
    /// Config for the registry page. Use OptionalFeatures.Registry to enable/disable.
    /// </summary>
    public PageConfig.Registry RegistryConfig { get; }
    
    public PageConfig.RegistryItem RegistryItemConfig { get; }
    
    /// <summary>
    /// Enable/disable optional features (e.g. RSVP, registry). You may configure a time to auto-activate.
    /// </summary>
    public OptionalFeatures OptionalFeatures { get; }
}