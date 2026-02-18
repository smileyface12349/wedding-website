using WeddingWebsite.Models.WebsiteConfig;

namespace WeddingWebsite.Models.ConfigInterfaces;

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
    /// The options to display in the navbar at the top of every page. These are all aligned to the left - the ones
    /// aligned to the right relate to account management and are not configurable.
    /// </summary>
    public NavbarConfig Navbar { get; }
    
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
    
    public PageConfig.Rsvp RsvpConfig { get; }
    
    /// <summary>
    /// Config for the login page, including some of the text.
    /// </summary>
    public PageConfig.Login LoginConfig { get; }
    
    /// <summary>
    /// Enable/disable optional features (e.g. RSVP, registry). You may configure a time to auto-activate.
    /// </summary>
    public OptionalFeatures OptionalFeatures { get; }
    
    /// <summary>
    /// Demo mode makes everything read-only. This is designed to showcase the functionality, without letting users
    /// tamper with data. This means that changing passwords and RSVPing is disabled.
    /// </summary>
    public DemoMode DemoMode { get; }
    
    /// <summary>
    /// Manually ignore specific validation warnings that you are aware of and don't care about.
    /// </summary>
    public IEnumerable<String> IgnoredValidationIssues { get; }
    
}